using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    public class svvSettings
    {
        private double _minX;
        private double _maxX;
        private double _minY;
        private double _maxY;
        private double _minZ;
        private double _maxZ;

        public double MinX { get => _minX; set => _minX = value; }
        public double MaxX { get => _maxX; set => _maxX = value; }
        public double MinY { get => _minY; set => _minY = value; }
        public double MaxY { get => _maxY; set => _maxY = value; }
        public double MinZ { get => _minZ; set => _minZ = value; }
        public double MaxZ { get => _maxZ; set => _maxZ = value; }
    }
}
