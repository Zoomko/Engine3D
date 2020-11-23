using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    public class Triangle
    {
        public Vector A { set; get; }
        public Vector B { set; get; }
        public Vector C { set; get; }
        public Triangle(Vector a, Vector b, Vector c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }
    }
}
