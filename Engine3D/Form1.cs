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
        private bool _buttonIsPressed = false;

        private int _mousePostitionX;
        private int _mousePostitionY;
        private double deltaScale = 0.01;

        private readonly double _svvSideX = 30;
        private readonly double _svvSideY = 30;
        private readonly double _svvNearPlane = 0;
        private readonly double _svvFarPlane = 25;       

        private readonly double _radiusSphere = 17;
        private double coefficient;


        public Form1()
        {
            InitializeComponent();
            InitializeAdditionalComponents();            
        }        

        private void InitializeAdditionalComponents()
        {
            coefficient = trackBar1.Value;
            _svvSettings = new svvSettings()
            {
                MinX = -_svvSideX,
                MaxX = _svvSideX,
                MinY = -_svvSideY,
                MaxY = _svvSideY,
                MinZ = _svvNearPlane,
                MaxZ = _svvFarPlane
            };
            
            _camera = new Camera(new CameraParameters
            {
                ProjectionMatrix = new OrthographicProjectionMatrix(),
                NormalizableMatrix = new OrthographicNormalizeMatrix(),
                SvvSettings = _svvSettings,
                Canvas = pictureBox1,
                Scale = 100f,                
                Radius = _radiusSphere
            }
                );                    
        }
        
        private void SetMousePosition(MouseEventArgs e)
        {
            _mousePostitionX = e.X;
            _mousePostitionY = e.Y;
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _camera.Model = ObjReader.OpenFile();
            _camera.Render(coefficient);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
                _buttonIsPressed = true;

            SetMousePosition(e);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                _buttonIsPressed = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_buttonIsPressed && _camera.Model != null)
            {
                var deltaX = (e.X - _mousePostitionX) * deltaScale;
                var deltaY = (e.Y - _mousePostitionY) * deltaScale;
                _camera.TranslateByDegree(deltaX, deltaY);
                _camera.Render(coefficient);                        
                

                SetMousePosition(e);
            }

            
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            _buttonIsPressed = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            coefficient = trackBar1.Value;
            _camera.Render(coefficient);
        }
    }
}
