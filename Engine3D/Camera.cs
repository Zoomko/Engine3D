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
        private INormalizableMatrix _normalizableMatrix;
        private Transform _transform;
        private Graphics _graphics;
        private PictureBox _canvas;

        private double _nearPlane = 1;
        private double _farPlane = 100;
        public Camera(IProjectableMatrix projectionMatrix, INormalizableMatrix normalMatrix, PictureBox pictureBox)
        {
            _transform = new Transform();
            vpMatrix = new ViewPointMatrix(_transform);
            _projectionMatrix = projectionMatrix;
            _normalizableMatrix = normalMatrix;
            _canvas = pictureBox;
            
            _graphics = pictureBox.CreateGraphics();
            SetCCV();
        }
        private void SetCCV()
        {
            _normalizableMatrix.MinX = -30;
            _normalizableMatrix.MaxX = 30;
            _normalizableMatrix.MinY = -30;
            _normalizableMatrix.MaxY = 30;
            _normalizableMatrix.MinZ = _nearPlane;
            _normalizableMatrix.MaxZ = _farPlane;
            _normalizableMatrix.SetMatrix();
        }
        public Model Model { get => _model; set => _model = value; }                

        public void Render()
        {
            _graphics.Clear(Color.White);
            foreach (var vertex in _model.Vertices)
            {                
                var camPoint = vpMatrix.TransformToViewPoint(vertex);
                var normPoint = _normalizableMatrix.Normalize(camPoint);
                var pointOnScreen = _projectionMatrix.Project(normPoint);
                _graphics.FillEllipse(new SolidBrush(Color.Black), pointOnScreen.X * _canvas.Height / 2, pointOnScreen.Y * _canvas.Height / 2, 2, 2);
            }
        }
    }
}
