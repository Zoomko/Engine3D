using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    public class OrthographicProjectionMatrix : IProjectableMatrix
    {
        private Matrix _orthographicMatrix = new Matrix(4, 4, new double[4, 4]
            {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 1}
        });

        public PointF Project(Vector vec)
        {
            var result = OperataionHelper.MultiplyMatrixByVector(_orthographicMatrix, vec);
            return new PointF((float)result.X, (float)result.Y);
        }
    }
}
