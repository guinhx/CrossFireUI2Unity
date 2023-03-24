using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;
using static Nekko.UI.UIScript;

namespace Nekko.UI
{
    [Serializable]
    public class UIElement
    {
        public UIElementType Type  = UIElementType.Undefined;
        public string Id;
        public float PositionX;
        public float PositionY;
        public float Width;
        public float Height;
        public int ChangeResolution;

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