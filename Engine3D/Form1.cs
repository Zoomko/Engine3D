﻿using System;
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
        public Form1()
        {
            InitializeComponent();
            InitializeAdditionalComponents();
        }

        private void InitializeAdditionalComponents()
        {
           
        }
        
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObjReader.OpenFile();
        }      

    }
}