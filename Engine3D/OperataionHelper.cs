using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    public static class Operataion
    {
        
        public static Matrix MultiplyMatrixes(Matrix one, Matrix other)
        {            
            return one.Multiply(other);
        }
        public static Vector MultiplyVectorByMatrix(Vector vec, Matrix mat)
        {
            Matrix vecMatrix = new Matrix(1, 4, new double[1,4] { { vec.X, vec.Y, vec.Z, vec.W } });
            Matrix resMat = vecMatrix.Multiply(mat);
            Vector result = new Vector(resMat.Values[0, 0], resMat.Values[0, 1], resMat.Values[0, 2], resMat.Values[0,3]);
            return result;
        }
        public static Vector MultiplyMatrixByVector(Matrix mat, Vector vec)
        {
            Matrix vecMatrix = new Matrix(4, 1, new double[4, 1] { { vec.X }, { vec.Y }, { vec.Z },{ vec.W } });
            Matrix resMat = mat.Multiply(vecMatrix);
            Vector resVector = new Vector(resMat.Values[0, 0], resMat.Values[1, 0], resMat.Values[2, 0], resMat.Values[3, 0]);
            return resVector;
        }

        public static Vector RotateY(Vector vec,double value)
        {
            Matrix matrix = new Matrix(4, 4, new double[4, 4]
            {
                {Math.Cos(value),   0,  Math.Sin(value),    0},
                {0,                 1,  0,                  0},
                {-Math.Sin(value),   0,  Math.Cos(value),    0},
                {0,                 0,  0,                  1}}
                );
            return MultiplyMatrixByVector(matrix, vec);
        }

        public static Vector RotateX(Vector vec, double value)
        {
            Matrix matrix = new Matrix(4, 4, new double[4, 4]
            {
                {1,                 0,  0,    0},
                {0,                 Math.Cos(value),  -Math.Sin(value),                  0},
                {0,   Math.Sin(value),  Math.Cos(value),    0},
                {0,                 0,  0,                  1}}
                );
            return MultiplyMatrixByVector(matrix, vec);
        }

    }
}
