using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Engine3D
{
    public static class ObjReader
    {
        
        public static Model OpenFile()
        {            
            OpenFileDialog openFileDialog = new OpenFileDialog();            
            openFileDialog.Filter = "obj files (*.obj)|*.obj|All files (*.*)|*.*";

            Model model = new Model();
            List<Vector> vertices = new List<Vector>();
            List<Polygon> polygons = new List<Polygon>();
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName, System.Text.Encoding.Default))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var values = line.Split(' ');
                            var id = values.First();

                            if (id == "v")
                            {
                                vertices.Add(GetVectorFromStringValues(values));
                            }
                            else if(id == "f")
                            {
                                polygons.Add(GetPolygonFromStringValues(values,vertices));
                            }
                        }
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
                model = new Model(vertices, polygons);
            }
            return model;
        }   

        private static Vector GetVectorFromStringValues(string[] values)
        {
            var x = double.Parse(values[1],System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowDecimalPoint);
            var y = double.Parse(values[2], System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowDecimalPoint);
            var z = double.Parse(values[3], System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowDecimalPoint);
            
            return new Vector(x, y, z);
        }

        private static Polygon GetPolygonFromStringValues(string[] values, List<Vector> vertices)
        {
            List<Vector> verticesPolygan = new List<Vector>();
            for (int i = 1; i <values.Length; i++)
            {
                var triangleValues = values[i].Split('/');

                int index = int.Parse(triangleValues[0]);               

                Vector vector = new Vector();              

                try
                {
                    vector = vertices[index - 1];                    
                }
                catch(ArgumentOutOfRangeException e)
                {
                    throw new Exception($"index = {index - 1}, length = {vertices.Count}");
                }

                verticesPolygan.Add(vector);
            }
            return new Polygon(verticesPolygan);
        }

    }
}
