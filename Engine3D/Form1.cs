using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Engine3D
{
    public partial class Form1 : Form
    {
        private Camera _camera;
        private svvSettings _svvSettings;

        private double svvSideX = 30;
        private double svvSideY = 30;
        private double svvNearPlane = 0.1;
        private double svvFarPlane = 100;

        private double scale = 100;
        
        public Form1()
        {
            InitializeComponent();
            InitializeAdditionalComponents();            
        }        

        private void InitializeAdditionalComponents()
        {
            _svvSettings = new svvSettings()
            {
                MinX = -svvSideX,
                MaxX = svvSideX,
                MinY = -svvSideY,
                MaxY = svvSideY,
                MinZ = svvNearPlane,
                MaxZ = svvFarPlane
            };
            _camera = new Camera(new CameraParameters
            {
                ProjectionMatrix = new OrthographicProjectionMatrix(),
                NormalizableMatrix = new OrthographicNormalizeMatrix(),
                SvvSettings = _svvSettings,
                Canvas = pictureBox1,
                Scale = 100f
            }
                );                    
        }
        
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _camera.Model = ObjReader.OpenFile();
            _camera.Render();
        }      

    }
}
