using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    public class Matrix
    {
        private int _columns;
        private int _rows;
        private double[,] _values;
        public int Columns { get => _columns; }
        public int Rows { get => _rows; }
        public double[,] Values { get => _values; }

        public Matrix(int r, int c, double[,] numb)
        {
            _rows = r;
            _columns = c;
            _values = numb;
        }
        public Matrix(int r, int c)
        {
            _rows = r;
            _columns = c;
            _values = new double[r, c];
        }
        public Matrix Multiply(Matrix mat)
        {
            Matrix result = new Matrix(this.Rows, mat.Columns);
            if (this.Columns != mat.Rows)
                throw new ArgumentException("Number of columns has to be equal number of rows");
            else
            {

                for (var i = 0; i < result.Rows; i++)
                {
                    for (var j = 0; j < result.Columns; j++)
                    {
                        result.Values[i, j] = 0;

                        for (var k = 0; k < this.Columns; k++)
                        {
                            result.Values[i, j] += this.Values[i, k] * mat.Values[k, j];
                        }
                    }
                }
            }
            return result;
        }

    }
}
