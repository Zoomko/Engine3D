using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    public static class OperataionHelper
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
    }
}
