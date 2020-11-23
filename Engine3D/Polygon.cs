using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    public class Polygon
    {
        private List<Triangle> _triangles = new List<Triangle>();
        public Polygon(List<Triangle> triangle)
        {
            _triangles = triangle;
        }
    }
}
