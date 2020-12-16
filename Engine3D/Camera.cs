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
        private double degreeY = 50;

        private double _minSide;      
        
        private double _horizontalRadius;
        private readonly double _verticalRadius;
       
        public Camera(CameraParameters parameters)
        {
            _parameters = parameters;

            _horizontalRadius = parameters.Radius;
            _verticalRadius = parameters.Radius;

            _transform = new Transform(new Vector(0, -5, -parameters.Radius)); ;
            vpMatrix = new ViewPointMatrix(_transform);            

            _minSide = (parameters.Canvas.Height < parameters.Canvas.Width ? parameters.Canvas.Height : parameters.Canvas.Width) /2;
            
            _graphics = _parameters.Canvas.CreateGraphics();

            _parameters.NormalizableMatrix.Settings = _parameters.SvvSettings;
            _parameters.NormalizableMatrix.SetMatrix();
            RotateOnInit();
        }
        public double CurrentDegreeX { get => _currentDegreeX; }
        public Model Model { get => _model; set => _model = value; }
        public Transform Transform { get => _transform; }

        private List<Polygon> _zBuffer = new List<Polygon>();
        

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

        public void Render()
        {
            _graphics.Clear(Color.White);
            foreach (var polygon in _model.Polygons)
            {
                
                double zValue = 0;
                for (int i = 0; i < polygon.Vertices.Count; i++)
                {
                    var normPoint = GetNormilizedPoint(polygon.Vertices[i]);
                    zValue += normPoint.Z;
                    polygon.Points[i] = GetPointOnScreen(normPoint);

                }
                zValue /= polygon.Vertices.Count;

                polygon.ValueMidZ = zValue;

            }
            
            _model.Polygons = _model.Polygons.OrderBy(x => x.ValueMidZ).ToList();
            //var first = new Polygon(new List<Vector>() { new Vector(), new Vector(), new Vector(), new Vector()});
            //first.Points[0] = new PointF(1, 1);
            //first.Points[1] = new PointF(1, 2);
            //first.Points[2] = new PointF(2, 2);
            //first.Points[3] = new PointF(2, 1);

            //var sec = new Polygon(new List<Vector>() { new Vector(), new Vector(), new Vector(), new Vector() });
            //sec.Points[0] = new PointF(1.1f, 1.1f);
            //sec.Points[1] = new PointF(1.1f, 1.2f);
            //sec.Points[2] = new PointF(1.2f, 1.2f);
            //sec.Points[3] = new PointF(1.2f, 1.1f);

            //first.IsPolygonBehind(sec);
            _zBuffer.Clear();
            _zBuffer.Add(_model.Polygons.First());
            for (int i = 1; i < _model.Polygons.Count(); i++)
            {
                bool willRender = true;

                foreach (var renderPolygon in _zBuffer)
                {
                    if (renderPolygon.IsPolygonBehind(_model.Polygons[i]))
                    {
                        willRender = false;
                        break;
                    }
                }
                if (willRender)
                {
                    _zBuffer.Add(_model.Polygons[i]);
                }
            }
            Console.WriteLine(_zBuffer.Count());
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {                
                foreach (var polygon in _zBuffer)
                {
                    brush.Color = polygon.GetColorByZValue();
                    _graphics.FillPolygon(brush, polygon.Points);
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
