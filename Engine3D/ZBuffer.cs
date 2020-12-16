using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine3D
{
    class ZBuffer
    {
        private double _radius = 0.65;
        private Polygon[,] _buffer;
        private Graphics _graphics;

        private int _countOfUnits = 30;

        private double _step;

        public ZBuffer(Graphics graphics)
        {            
            _buffer = new Polygon[_countOfUnits, _countOfUnits];
            _step = _radius*2 / _countOfUnits;
            _graphics = graphics;
        }
        public void AddToBuffer(Polygon polygon)
        {
            //var middleX = polygon.NormPoints.Max(obj => obj.X) - polygon.NormPoints.Min(obj => obj.X);
            //var middleY = polygon.NormPoints.Max(obj => obj.Y) - polygon.NormPoints.Min(obj => obj.Y);            

            //int i = (int)((middleX + _radius) / _step);
            //int j = (int)((middleY + _radius) / _step);

            //if(i>=_countOfUnits || j>=_countOfUnits || i <0 || j <0)
            //{
            //    throw new IndexOutOfRangeException();
            //}
            //else
            //{
            //    if (_buffer[i, j] == null || polygon.ValueMidZ < _buffer[i, j].ValueMidZ)
            //        _buffer[i, j] = polygon;
            //}
        }

        public void Draw()
        {
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                for (int i = 0; i < _countOfUnits; i++)
                {
                    for (int j = 0; j < _countOfUnits; j++)
                    {
                        if (_buffer[i, j] != null)
                        {
                            brush.Color = _buffer[i, j].GetColorByZValue();
                            _graphics.FillPolygon(brush, _buffer[i, j].Points);
                        }
                    }
                }
            }
        }
        public void Clear()
        {
            _buffer = new Polygon[_countOfUnits, _countOfUnits];
        }
    }
}
