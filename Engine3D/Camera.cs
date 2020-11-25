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
            _transform = new Transform(new Vector(0,-10,-10));
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
            Pen pen = new Pen(Color.Black);
            _graphics.Clear(Color.White);
            foreach (var polygon in _model.Polygons)
            {
                PointF[] points = new PointF[polygon.Vertices.Count];
                for (int i = 0; i < polygon.Vertices.Count; i++)
                {                    
                     points[i] = GetPointOnScreen(polygon.Vertices[i]);      
                    
                }
                _graphics.DrawPolygon(pen, points);
            }
        }
        private PointF GetPointOnScreen(Vector vector)
        {
            var camPoint = vpMatrix.TransformToViewPoint(vector);
            var normPoint = _parameters.NormalizableMatrix.Normalize(camPoint);
            var pointOnScreen = _parameters.ProjectionMatrix.Project(normPoint);

            pointOnScreen.X = _parameters.Canvas.Width / 2 + (pointOnScreen.X * (float)_minSide);
            pointOnScreen.Y = _parameters.Canvas.Height / 2 + (pointOnScreen.Y * (float)_minSide);
            return pointOnScreen;
        }
        
    }
}
