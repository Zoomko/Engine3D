using System.Drawing;

namespace Engine3D
{
    public interface INormalizableMatrix
    {       

        svvSettings Settings { get; set; }

        Vector Normalize(Vector vec);

        void SetMatrix();
    }
    public interface IProjectableMatrix
    {
        PointF Project(Vector vec);
    }
    
}
