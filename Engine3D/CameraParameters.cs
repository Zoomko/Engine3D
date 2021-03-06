﻿using System.Windows.Forms;

namespace Engine3D
{
    public class CameraParameters
    {       
        private PictureBox _canvas;
        private svvSettings _svvSettings;
        private IProjectableMatrix _projectionMatrix;
        private INormalizableMatrix _normalizableMatrix;
        private float _scale;        
        private double _radius;
        
        public PictureBox Canvas { get => _canvas; set => _canvas = value; }
        public svvSettings SvvSettings { get => _svvSettings; set => _svvSettings = value; }
        public IProjectableMatrix ProjectionMatrix { get => _projectionMatrix; set => _projectionMatrix = value; }
        public INormalizableMatrix NormalizableMatrix { get => _normalizableMatrix; set => _normalizableMatrix = value; }
        public float Scale { get => _scale; set => _scale = value; }        
        public double Radius { get => _radius; set => _radius = value; }
    }
}
