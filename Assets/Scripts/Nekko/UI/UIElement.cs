using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;
using static Nekko.UI.UIScript;

namespace Nekko.UI
{
    [Serializable]
    public abstract class UIElement
    {
        public UIElementType Type { get; set; } = UIElementType.Undefined;
        public string Id { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public int ChangeResolution { get; set; }

        public virtual void Create(Transform parent) {}

        public virtual void Create(VisualElement parent) {}

        public virtual void SetAttribute(string attribute, string value)
        {
            switch (attribute)
            {
                case Attributes.PositionX:
                    PositionX = float.Parse(value);
                    break;
                case Attributes.PositionY:
                    PositionY = float.Parse(value);
                    break;
                case Attributes.Width:
                    Width = float.Parse(value);
                    break;
                case Attributes.Height:
                    Height = float.Parse(value);
                    break;
                case Attributes.ChangeResolution:
                    ChangeResolution = int.Parse(value);
                    break;
            }
        }

        public virtual string GetAttribute(string attribute)
        {
            return attribute switch
            {
                Attributes.PositionX => PositionX.ToString(CultureInfo.CurrentCulture),
                Attributes.PositionY => PositionY.ToString(CultureInfo.CurrentCulture),
                Attributes.Width => Width.ToString(CultureInfo.CurrentCulture),
                Attributes.Height => Height.ToString(CultureInfo.CurrentCulture),
                Attributes.ChangeResolution => ChangeResolution.ToString(CultureInfo.CurrentCulture),
                _ => Id
            };
        }
    }
}