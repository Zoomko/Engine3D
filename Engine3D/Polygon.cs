using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    public class Polygon
    {
        private List<Vector>  _vertices = new List<Vector>();
        public List<Vector> Vertices { get => _vertices; }
        public Polygon(List<Vector> vertices)
        {
            _vertices = vertices;
        }
    }
}
