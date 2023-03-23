using System;
using Nekko.UI.Primitive;
using UnityEngine;
using UnityEngine.UIElements;
using static Nekko.UI.UIScript.Attributes;

namespace Nekko.UI.Element
{
    [Serializable]
    public class UIEditElement: UIElement
    {
        public UIFont Font { get; set; } = new();

        public override void Create(VisualElement parent)
        {
            var textField = new TextField
            {
                name = Id,
                style =
                {
                    width = Width,
                    height = Height,
                    top = PositionY,
                    left = PositionX
                }
            };
            parent.Add(textField);
            Debug.Log($"{GetType().Name}::Create");
        }

        public override void SetAttribute(string attribute, string value)
        {
            switch (attribute)
            {
                case FontName:
                    Font.Name = value;
                    break;
                case FontSize:
                    Font.Size = int.Parse(value);
                    break;
                case FontBold:
                    Font.Bold = !value.Equals("FALSE");
                    break;
                case FontItalic:
                    Font.Italic = !value.Equals("FALSE");
                    break;
                case FontFormat:
                    var format = value switch
                    {
                        "DT_LEFT" => TextAlignment.Left,
                        "DT_RIGHT" => TextAlignment.Right,
                        _ => TextAlignment.Center
                    };
                    Font.Format = format;
                    break;
                default:
                    base.SetAttribute(attribute, value);
                    break;
            }
        }
    }
}