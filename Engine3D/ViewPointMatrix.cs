using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    public class VeiwPointMatrix
    {
        private Matrix _transformMatrix;
        private Transform _transform;
        public VeiwPointMatrix(Transform transform)
        {
            _transform = transform;
        }
        public void InitMatrix()
        {
            _transformMatrix = new Matrix(4, 4, new double[4, 4]
            {
                {_transform.Right.X,    _transform.Right.Y,     _transform.Right.Z,     -_transform.Position.X },
                {_transform.Up.X,       _transform.Up.Y,        _transform.Up.Z,        -_transform.Position.Y },
                {_transform.Forward.X,  _transform.Forward.Y,   _transform.Forward.Z,   -_transform.Position.Z },
                {0,                     0,                      0,                      1 }
            });
        }
        public Vector TransformToViewPoint(Vector vector)
        {
            var result = OperataionHelper.MultiplyMatrixByVector(_transformMatrix, vector);
            return result;
        }
    }
}
