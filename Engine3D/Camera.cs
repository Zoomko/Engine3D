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
        private IProjectableMatrix _projectionMatrix;
        private Transform _transform;
        private Graphics _graphics;
        private PictureBox _canvas;        
        public Camera(IProjectableMatrix matrix, PictureBox pictureBox)
        {
            _transform = new Transform();
            vpMatrix = new ViewPointMatrix(_transform);
            _projectionMatrix = matrix;
            _canvas = pictureBox;
            
            _graphics = pictureBox.CreateGraphics();
        }

        public Model Model { get => _model; set => _model = value; }                

        public void Render()
        {
            _graphics.Clear(Color.White);
            foreach (var vertex in _model.Vertices)
            {                
                var camPoint = vpMatrix.TransformToViewPoint(vertex);
                var pointOnScreen = _projectionMatrix.Project(camPoint);
                _graphics.FillEllipse(new SolidBrush(Color.Black), pointOnScreen.X, pointOnScreen.Y, 2, 2);
            }
        }
    }
}
