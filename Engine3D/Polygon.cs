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
    }
}
