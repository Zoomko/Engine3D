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
        private double _w;

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
        public double Z { get => _z; set => _z = value; }
        public double W { get => _w; set => _w = value; }
        public Vector()
        {
            this._x = 0;
            this._y = 0;
            this._z = 0;
            this._w = 0;
        }
        public Vector(double x, double y)
        {
            this._x = x;
            this._y = y;
            this._z = 0;
            this._w = 0;
        }
        public Vector(double x, double y, double z)
        {
            this._x = x;
            this._y = y;
            this._z = z;
            this._w = 1;
        }
        public Vector(double x, double y, double z, double w)
        {
            this._x = x;
            this._y = y;
            this._z = z;
            this._w = w;
        }        

        public static Vector operator +(Vector vec1, Vector vec2)
        {
            return new Vector(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
        }

        public static Vector operator -(Vector vec1, Vector vec2)
        {
            return new Vector(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z);
        }

        public Vector VectorProduct(Vector vec)
        {
            double i = this.Y * vec.Z - this.Z * vec.Y;
            double j = this.X * vec.Z - this.Z * vec.X;
            double k = this.X * vec.Y - this.Y * vec.X;
            return new Vector(i, j, k);
        }

        public static bool operator ==(Vector vec1, Vector vec2)
        {
            if (vec1.X == vec2.X && vec1.Y == vec2.Y && vec1.Z == vec2.Z && vec1.W == vec2.W)
                return true;
            else return false;
        }
        public static bool operator !=(Vector vec1, Vector vec2)
        {
            return !(vec1 == vec2);
        }

        public static double DotProduct(Vector vec1, Vector vec2)
        {
            return vec1.X * vec2.X + vec1.Y * vec2.Y + vec1.Z * vec2.Z + vec1.W * vec2.W;
        }
    }
}
