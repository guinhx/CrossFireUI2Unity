using System;
using System.IO;
using Nekko.Extension;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static Nekko.UI.UIScript;

namespace Nekko.UI.Element
{
    [Serializable]
    public class UIImageElement : UIElement
    {
        
        public string TexPath { get; set; }
        public bool UseAlpha { get; set; }
        public int Transparency { get; set; }
        public string FxFileName { get; set; }

        public override void Create(Transform parent)
        {
            var imageObj = new GameObject(Id) { transform = { parent = parent } };
            var image = imageObj.GetOrAddComponent<UnityEngine.UI.Image>();
            var texture = GetTexture();
            image.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f),
                100.0f);
            image.SetNativeSize();
            var rect = image.GetOrAddComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(PositionX, PositionY);
            Debug.Log($"Load Texture {TexPath.WithoutFileExtension()}");
        }

        public override void Create(VisualElement parent)
        {
            var image = new Image
            {
                name = Id,
                image = GetTexture(),
                style =
                {
                    width = Width,
                    height = Height,
                    top = PositionY,
                    left = PositionX
                }
            };
            parent.Add(image);
            Debug.Log($"{GetType().Name}::Create");
        }

        public override void SetAttribute(string attribute, string value)
        {
            switch (attribute.Replace("-", ""))
            {
                case Attributes.TexPath:
                    TexPath = value.Replace("\"", "");
                    break;
                case Attributes.UseAlpha:
                    UseAlpha = !value.Equals("FALSE");
                    break;
                case Attributes.Transparency:
                    Transparency = int.Parse(value);
                    break;
                case Attributes.FxFileName:
                    FxFileName = value.Replace("\"", "");
                    break;
                default:
                    base.SetAttribute(attribute, value);
                    break;
            }
        }

        public Texture2D GetTexture()
        {
            if (string.IsNullOrEmpty(TexPath))
                return new Texture2D((int)Width, (int)Height);
            
            return (Texture2D)Resources.Load(TexPath.Replace("\\\\", "\\").WithoutFileExtension(), typeof(Texture2D));
        }
    }
}