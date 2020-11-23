using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    public class Model
    {
        private List<Vector> vertices = new List<Vector>();
        private List<Polygon> polygons = new List<Polygon>();
        public Model(List<Vector> vert, List<Polygon> poly)
        {
            vertices = vert;
            polygons = poly;
        }
        public Model()
        {

        }
    }
}
