using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    public class Model
    {
        private List<Vector> _vertices = new List<Vector>();
        private List<Polygon> _polygons = new List<Polygon>();
        private Transform _transform;        
        public Transform Transform { get => _transform; set => _transform = value; }
        public List<Polygon> Polygons { get => _polygons; set => _polygons = value; }

        public Model(List<Vector> vertices, List<Polygon> polygons)
        {
            _vertices = vertices;
            _polygons = polygons;            
        }      
        
        public Model()
        {

        }
    }
}
