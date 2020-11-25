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

        private INormalizableMatrix _normalizableMatrix;       

        public INormalizableMatrix NormalizableMatrix { get => _normalizableMatrix; set => _normalizableMatrix = value; }        
        public List<Vector> Vertices { get => _vertices; set => _vertices = value; }

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
