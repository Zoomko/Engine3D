using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    class OrthographicNormalizeMatrix : INormalizableMatrix
    {
        private double _minX;
        private double _maxX;
        private double _minY;
        private double _maxY;
        private double _minZ;
        private double _maxZ;

        public double MinX { get => _minX; set => _minX = value; }
        public double MaxX { get => _maxX; set => _maxX = value; }
        public double MinY { get => _minY; set => _minY = value; }
        public double MaxY { get => _maxY; set => _maxY = value; }
        public double MinZ { get => _minZ; set => _minZ = value; }
        public double MaxZ { get => _maxZ; set => _maxZ = value; }

        private Matrix _orthographicMatrix;

        public OrthographicNormalizeMatrix()
        {

        }
        public void SetMatrix(List<Vector> vert)
        {
            MinX = vert.Min(x => x.X);
            MaxX = vert.Max(x => x.X);
            MinY = vert.Min(x => x.Y);
            MaxY = vert.Max(x => x.Y);
            MinZ = vert.Min(x => x.Z);
            MaxZ = vert.Max(x => x.Z);

            _orthographicMatrix = new Matrix(4, 4, new double[4, 4]
            {
            {2/(MaxX-MinX), 0, 0, -(MaxX +MinX)/(MaxX -MinX)},
            {0, 2/(MaxY-MinY), 0,-(MaxY +MinY)/(MaxY -MinY)},
            {0, 0, 2/(MaxZ-MinZ), -(MaxZ +MinZ)/(MaxZ -MinZ)},
            {0, 0, 0, 1}
            });
            
        }
        public Vector Normalize(Vector vec)
        {
            var result = OperataionHelper.MultiplyMatrixByVector(_orthographicMatrix,vec);
            return result;
        }
    }
}
