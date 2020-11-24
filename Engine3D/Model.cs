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
        private List<Vector> noralizedVertices = new List<Vector>();

        private INormalizableMatrix _normalizableMatrix;       

        public INormalizableMatrix NormalizableMatrix { get => _normalizableMatrix; set => _normalizableMatrix = value; }

        public Model(List<Vector> vertices, List<Polygon> polygons, INormalizableMatrix normalizableMatrix)
        {
            _vertices = vertices;
            _polygons = polygons;
            _normalizableMatrix = normalizableMatrix;

            _normalizableMatrix.SetMatrix(vertices);            
            NormalizeVertices(vertices);
        }
        
        private void NormalizeVertices(List<Vector> verts)
        {
            foreach(var vert in verts)
            {
                noralizedVertices.Add(_normalizableMatrix.Normalize(vert));
            }            
        }
        
        public Model()
        {

        }
    }
}
