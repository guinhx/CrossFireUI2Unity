using System;
using UnityEngine;

namespace Nekko.UI.Primitive
{
    [Serializable]
    public class UIFont
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public bool Bold { get; set; }
        public bool Italic { get; set; }
        public TextAlignment Format { get; set; }
        public bool Outline { get; set; }
        public bool NumberOnly { get; set; }
        public Color Color { get; set; }
        public Color OutlineColor { get; set; }
    }
}