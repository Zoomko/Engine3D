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

        private double _currentDegreeX = 0;
        private double _currentDegreeY = 0;

        private double _minSide;      
        
        private double _horizontalRadius;
        private readonly double _verticalRadius;
       
        public Camera(CameraParameters parameters)
        {
            _parameters = parameters;

            _horizontalRadius = parameters.Radius;
            _verticalRadius = parameters.Radius;

            _transform = new Transform(new Vector(0, -parameters.Radius, 0)); ;
            vpMatrix = new ViewPointMatrix(_transform);            

            _minSide = (parameters.Canvas.Height < parameters.Canvas.Width ? parameters.Canvas.Height : parameters.Canvas.Width) /2;
            
            _graphics = _parameters.Canvas.CreateGraphics();

            _parameters.NormalizableMatrix.Settings = _parameters.SvvSettings;
            _parameters.NormalizableMatrix.SetMatrix();
        }
        public double CurrentDegreeX { get => _currentDegreeX; }
        public Model Model { get => _model; set => _model = value; }
        public Transform Transform { get => _transform; }
        public double CurrentDegreeY { get => _currentDegreeY;}

        public void TranslateByDegree(double deltaX, double deltaY)
        {
            _currentDegreeX += deltaX;
            if (((_currentDegreeY + deltaY) < Math.PI / 2) && ((_currentDegreeY + deltaY) > -(Math.PI / 2)))
            {
                _currentDegreeY += deltaY;
                _transform.Position.Y = _verticalRadius * Math.Sin(_currentDegreeY);
                _horizontalRadius = _verticalRadius * Math.Cos(_currentDegreeY);

                //_transform.Left = Operataion.RotateX(_transform.Left, CurrentDegreeY);
                //_transform.Backward = Operataion.RotateX(_transform.Backward, CurrentDegreeY);
                //_transform.Down = Operataion.RotateX(_transform.Down, CurrentDegreeY);
            }

            _transform.Position.X = _horizontalRadius * Math.Cos(_currentDegreeX);
            _transform.Position.Z = _horizontalRadius * Math.Sin(_currentDegreeX);

            _transform.Left = Operataion.RotateY(_transform.Left, deltaX);
            _transform.Backward = Operataion.RotateY(_transform.Backward, deltaX);
            _transform.Down = Operataion.RotateY(_transform.Down, deltaX);
            vpMatrix.InitMatrix();
        }

        public void Render()
        {            
            _graphics.Clear(Color.White);
            foreach (var polygon in _model.Polygons)
            {
                PointF[] points = new PointF[polygon.Vertices.Count];
                double zValue = 0;
                for (int i = 0; i < polygon.Vertices.Count; i++)
                {
                    var normPoint = GetNormilizedPoint(polygon.Vertices[i]);
                    zValue += normPoint.Z;
                    points[i] = GetPointOnScreen(normPoint);                    
                    
                }
                zValue /= polygon.Vertices.Count;

                double colorValue = zValue > 1 ? 1 : zValue;
                colorValue = colorValue < 0 ? 0 : colorValue;
                int colorV = (int)(colorValue * 255);
                Color color = Color.FromArgb(colorV, colorV, colorV);

                if(zValue>-1 && zValue<1)
                _graphics.FillPolygon(new SolidBrush(color), points);
            }
        }
        private Vector GetNormilizedPoint(Vector vector)
        {
            var camPoint = vpMatrix.TransformToViewPoint(vector);
            var normPoint = _parameters.NormalizableMatrix.Normalize(camPoint);
            return normPoint;
        }
        private PointF GetPointOnScreen(Vector vector)
        {            
            var pointOnScreen = _parameters.ProjectionMatrix.Project(vector);

            pointOnScreen.X = _parameters.Canvas.Width / 2 + (pointOnScreen.X * (float)_minSide);
            pointOnScreen.Y = _parameters.Canvas.Height / 2 + (pointOnScreen.Y * (float)_minSide);
            return pointOnScreen;
        }
        
    }
}
