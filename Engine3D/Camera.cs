using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Engine3D
{
    public class Camera
    {        
        private Model _model;

        private ViewPointMatrix vpMatrix;
        private CameraParameters _parameters;
        
        private Transform _transform;
        private Graphics _graphics;

        private double _minSide;        
       
        public Camera(CameraParameters parameters)
        {
            _transform = new Transform();
            vpMatrix = new ViewPointMatrix(_transform);
            _parameters = parameters;

            _minSide = (parameters.Canvas.Height < parameters.Canvas.Width ? parameters.Canvas.Height : parameters.Canvas.Width) /2;
            
            _graphics = _parameters.Canvas.CreateGraphics();

            _parameters.NormalizableMatrix.Settings = _parameters.SvvSettings;
            _parameters.NormalizableMatrix.SetMatrix();
        }
        
        public Model Model { get => _model; set => _model = value; }                

        public void Render()
        {
            _graphics.Clear(Color.White);
            foreach (var vertex in _model.Vertices)
            {                
                var camPoint = vpMatrix.TransformToViewPoint(vertex);
                var normPoint = _parameters.NormalizableMatrix.Normalize(camPoint);
                var pointOnScreen = _parameters.ProjectionMatrix.Project(normPoint);

                ////scaling point
                //pointOnScreen.X *= _parameters.Scale;
                //pointOnScreen.Y *= _parameters.Scale;

                //align point with cetner
                pointOnScreen.X = _parameters.Canvas.Width / 2 + (pointOnScreen.X * (float)_minSide);
                pointOnScreen.Y = _parameters.Canvas.Height / 2 + (pointOnScreen.Y * (float)_minSide);

                if(normPoint.Z>-1 && normPoint.Z <1)
                    _graphics.FillEllipse(new SolidBrush(Color.Black), pointOnScreen.X, pointOnScreen.Y, 2, 2);
            }
        }
        
    }
}
