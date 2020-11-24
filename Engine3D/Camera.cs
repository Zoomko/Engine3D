using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Engine3D
{
    public class Camera
    {        
        private Model _model;
        private VeiwPointMatrix vpMatrix;
        private Transform _transform;
        public Camera()
        {
            _transform = new Transform();
            vpMatrix = new VeiwPointMatrix(_transform);
        }

        public Model Model { get => _model; set => _model = value; }

        public void PaintEvent(object sender, System.Windows.Forms.PaintEventArgs graphics)
        {
            graphics.Graphics.Clear(Color.White);            
        }

        public void Render()
        {

        }
    }
}
