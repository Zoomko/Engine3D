using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    public class Vector
    {
        private double _x;
        private double _y;
        private double _z;
        private double _w = 1;

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
        public double Z { get => _z; set => _z = value; }
        public double W { get => _w; }

        public Vector(double x, double y, double z)
        {
            this._x = x;
            this._y = y;
            this._z = z;
        }
        public Vector(double x, double y, double z, double w)
        {
            this._x = x;
            this._y = y;
            this._z = z;
            this._w = w;
        }
        public Vector() { }
    }
}
