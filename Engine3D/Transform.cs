﻿
namespace Engine3D
{
    public class Transform
    {
        #region RotationBasisVectors

        private Vector _down;
        private Vector _backward;
        private Vector _left;

        #endregion

        private Vector _position;
        private Matrix _transformMatrix;

        public Transform(Vector position)
        {
            _down = new Vector(0, -1, 0);
            _backward = new Vector(0, 0, -1);
            _left = new Vector(-1, 0, 0);

            _position = position;            
        }
        
        public Vector Position { get => _position; set => _position = value; }
        public Vector Backward { get => _backward; set => _backward = value; }
        public Vector Left { get => _left; set => _left = value; }
        public Vector Down { get => _down; set => _down = value; }
    }
}
