using Engine3D;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEngine3D
{
    [TestClass]
    public class TestMatrix
    {
        [TestMethod]
        public void TestEqualedMatrixes_01()
        {
            Matrix mat1 = new Matrix(2, 3, new double[2, 3] { { 1, 2, 3 }, { 1, 2, 3 } });
            Matrix mat2 = new Matrix(2, 3, new double[2, 3] { { 1, 2, 3 }, { 1, 2, 3 } });                

            Assert.IsTrue(mat1 == mat2);
        }

        [TestMethod]
        public void TestEqualedMatrixes_02()
        {
            Matrix mat1 = new Matrix(1, 5, new double[1, 5] { { 1, 2, 3, 6, 5 } });
            Matrix mat2 = new Matrix(1, 5, new double[1, 5] { { 1, 2, 3, 6, 5 } });

            Assert.IsTrue(mat1 == mat2);
        }

        [TestMethod]
        public void TestMultiplyMatrixes_01()
        {
            Matrix mat1 = new Matrix(2, 3, new double[2, 3] { { 1, 2, 3 }, { 1, 2, 3 } });
            Matrix mat2 = new Matrix(3, 2, new double[3, 2] { { 1, 2 }, { 1, 2 }, { 1, 2 } });
            Matrix expected = new Matrix(2, 2, new double[2, 2] { { 6, 12 },{ 6, 12 } });
            Matrix result = mat1.Multiply(mat2);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestMultiplyMatrixes_02()
        {
            Matrix mat1 = new Matrix(2, 2, new double[2, 2] { { 1,1 }, { 1, 1 } });
            Matrix mat2 = new Matrix(2, 2, new double[2, 2] { { 1, 0 }, { 0, 1 } });
            Matrix expected = new Matrix(2, 2, new double[2, 2] { { 1, 1 }, { 1, 1 } });
            Matrix result = mat1.Multiply(mat2);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestMultiplyVectorByMatrix_01()
        {
            Vector vector = new Vector(1, 4, 5);
            Matrix matrix = new Matrix(4, 4, new double[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 1, 2, 3 }, { 4, 5, 6, 7 } });
            Vector expected = new Vector(70, 36, 47, 58);
            Vector result = OperataionHelper.MultiplyVectorByMatrix(vector,matrix);

            Assert.IsTrue(expected == result);
        }

        [TestMethod]
        public void TestMultiplyMatrixByVector_02()
        {
            Vector vector = new Vector(1, 4, 5);
            Matrix matrix = new Matrix(4, 4, new double[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 1, 2, 3 }, { 4, 5, 6, 7 } });
            Vector expected = new Vector(1, 5, 9, 4);
            Vector result = OperataionHelper.MultiplyMatrixByVector(matrix, vector);

            Assert.IsTrue(expected == result);
        }
    }
}
