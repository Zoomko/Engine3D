using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    public class Polygon
    {
        private List<Vector> _vertices = new List<Vector>();
        public List<Vector> Vertices { get => _vertices; }
        PointF[] _points;        
        public PointF[] Points { get => _points;}        
        public double ValueMidZ { get; set; }
        public PointF MiddlePoint { get; set; }

        private Vector _poligonSide = new Vector(0, 0);
        private Vector _pointVector = new Vector(0, 0);        
        public Color GetColorByZValue()
        {
            double colorValue = ValueMidZ > 1 ? 1 : ValueMidZ;
            colorValue = colorValue < -1 ? -1 : colorValue;
            int colorV = 255 - (int)((colorValue + 1) / 2 * 255);
            Color color = Color.FromArgb(colorV, colorV, colorV);
            return color;
        }
        public Polygon(List<Vector> vertices)
        {
            _vertices = vertices;
            _points = new PointF[vertices.Count];            
        }

        public bool IsPolygonBehind(Polygon polygon)
        {
            for (int point = 0; point < polygon.Points.Count(); point++)
            {
                bool IsPointInPolygon = true;

                for (int firstPoint = 0; firstPoint < _points.Count(); firstPoint++)
                {
                    int secondPoint = firstPoint + 1;
                    if (firstPoint == _points.Count() - 1)
                    {
                        secondPoint = 0;
                    }

                    _poligonSide.X = _points[secondPoint].X - _points[firstPoint].X;
                    _poligonSide.Y = _points[secondPoint].Y - _points[firstPoint].Y;

                    _pointVector.X = polygon.Points[point].X - _points[firstPoint].X;
                    _pointVector.Y = polygon.Points[point].Y - _points[firstPoint].Y;

                    var vecProduct = _poligonSide.VectorProduct(_pointVector);
                    if (vecProduct.Z > 0)
                    {
                        IsPointInPolygon = false;
                        break;
                    }
                }
                if(IsPointInPolygon == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
