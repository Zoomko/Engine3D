using System.Collections.Generic;
using System.Drawing;

namespace Engine3D
{
    public interface INormalizableMatrix
    {       

        double MinX { get; set; }
        double MaxX { get; set; }
        double MinY { get; set; }
        double MaxY { get; set; }
        double MinZ { get; set; }
        double MaxZ { get; set; }

        Vector Normalize(Vector vec);

        void SetMatrix();
    }
    public interface IProjectableMatrix
    {
        PointF Project(Vector vec);
    }
    
}
