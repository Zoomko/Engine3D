using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

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
        private double degreeY = 50;

        private double _minSide;      
        
        private double _horizontalRadius;
        private readonly double _verticalRadius;

        private ZBuffer _zBuffer;
       
        public Camera(CameraParameters parameters)
        {
            _parameters = parameters;

            _horizontalRadius = parameters.Radius;
            _verticalRadius = parameters.Radius;

            _transform = new Transform(new Vector(0, -5, -parameters.Radius)); ;
            vpMatrix = new ViewPointMatrix(_transform);            

            _minSide = (parameters.Canvas.Height < parameters.Canvas.Width ? parameters.Canvas.Height : parameters.Canvas.Width) /2;
            
            _graphics = _parameters.Canvas.CreateGraphics();

            _zBuffer = new ZBuffer(_graphics);

            _parameters.NormalizableMatrix.Settings = _parameters.SvvSettings;
            _parameters.NormalizableMatrix.SetMatrix();
            RotateOnInit();
        }
        public double CurrentDegreeX { get => _currentDegreeX; }
        public Model Model { get => _model; set => _model = value; }
        public Transform Transform { get => _transform; }        
        

        public void RotateOnInit()
        {
            _transform.Left = Operataion.RotateX(_transform.Left, degreeY);
            _transform.Backward = Operataion.RotateX(_transform.Backward, degreeY);
            _transform.Down = Operataion.RotateX(_transform.Down, degreeY);
            vpMatrix.InitMatrix();
        }

        public void TranslateByDegree(double deltaX, double deltaY)
        {
            _currentDegreeX += deltaX; 

            _transform.Left = Operataion.RotateY(_transform.Left, deltaX);
            _transform.Backward = Operataion.RotateY(_transform.Backward, deltaX);
            _transform.Down = Operataion.RotateY(_transform.Down, deltaX);
            vpMatrix.InitMatrix();
        }

        public void Render(double coof)
        {           
            _graphics.Clear(Color.White);
            double minZValue = 9999;
            double maxZValue = -9999;
            foreach (var polygon in _model.Polygons)
            {  
                polygon.ValueMidZ = SetScreenPointsAndGetZValue(polygon);

                if (polygon.ValueMidZ > maxZValue)
                    maxZValue = polygon.ValueMidZ;
                if (polygon.ValueMidZ < minZValue)
                    minZValue = polygon.ValueMidZ; 
            }

            _model.Polygons = _model.Polygons.OrderByDescending(x => x.ValueMidZ).ToList();

            var midZValue = minZValue + (maxZValue - minZValue)* (coof/100);

            DrawPolygons(midZValue);
        }
        
        private double SetScreenPointsAndGetZValue(Polygon polygon)
        {
            double zValue = 0;
            for (int i = 0; i < polygon.Vertices.Count; i++)
            {
                var normPoint = GetNormilizedPoint(polygon.Vertices[i]);
                polygon.Points[i] = GetPointOnScreen(normPoint);
                zValue += normPoint.Z;

            }
            zValue /= polygon.Vertices.Count;
            return zValue;
        }
        private void DrawPolygons(double midZValue)
        {
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                foreach (Polygon polygon in _model.Polygons)
                {

                    if (polygon.ValueMidZ < midZValue)
                    {
                        brush.Color = polygon.GetColorByZValue();
                        _graphics.FillPolygon(brush, polygon.Points);
                    }

                }
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
