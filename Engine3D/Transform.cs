using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    public class Transform
    {
        #region RotationBasisVectors

        private Vector _up;
        private Vector _forward;
        private Vector _right;

        #endregion

        private Vector _position;
        private Matrix _transformMatrix;

        public Transform()
        {
            _up = new Vector(0, -1, 0);
            _forward = new Vector(0, 0, -1);
            _right = new Vector(-1, 0, 0);

            _position = new Vector(-10, -30, -10);            
        }
        
        public Vector Position { get => _position; set => _position = value; }
        public Vector Forward { get => _forward; set => _forward = value; }
        public Vector Right { get => _right; set => _right = value; }
        public Vector Up { get => _up; set => _up = value; }
    }
}
