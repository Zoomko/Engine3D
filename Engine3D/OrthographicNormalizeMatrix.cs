using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    class OrthographicNormalizeMatrix : INormalizableMatrix
    {
        svvSettings _settings;

        private Matrix _orthographicMatrix;

        public svvSettings Settings { get => _settings; set => _settings = value; }

        public OrthographicNormalizeMatrix()
        {
            
        }

        public void SetMatrix()
        {            

            _orthographicMatrix = new Matrix(4, 4, new double[4, 4]
            {
            {2/(Settings.MaxX-Settings.MinX),         0,                   0,                 -(Settings.MaxX +Settings.MinX)/(Settings.MaxX -Settings.MinX)},
            {0,                     2/(Settings.MaxY-Settings.MinY),       0,                 -(Settings.MaxY +Settings.MinY)/(Settings.MaxY -Settings.MinY)},
            {0,                     0,                   2/(Settings.MaxZ-Settings.MinZ),     -(Settings.MaxZ +Settings.MinZ)/(Settings.MaxZ -Settings.MinZ)},
            {0,                     0,                   0,                 1}
            });
            
        }
        public Vector Normalize(Vector vec)
        {
            var result = Operataion.MultiplyMatrixByVector(_orthographicMatrix,vec);
            return result;
        }
    }
}
