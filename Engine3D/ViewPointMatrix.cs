using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    public class ViewPointMatrix
    {
        private Matrix _transformMatrix;
        private Transform _transform;
        public ViewPointMatrix(Transform transform)
        {
            _transform = transform;
            InitMatrix();
        }
        
        public void InitMatrix()
        {
            _transformMatrix = new Matrix(4, 4, new double[4, 4]
            {
                {_transform.Left.X,    _transform.Left.Y,         _transform.Left.Z,     -_transform.Position.X },
                {_transform.Down.X,       _transform.Down.Y,      _transform.Down.Z,        -_transform.Position.Y },
                {_transform.Backward.X,  _transform.Backward.Y,   _transform.Backward.Z,   -_transform.Position.Z },
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
