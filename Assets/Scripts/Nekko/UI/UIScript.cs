using System;
using System.Collections.Generic;
using Nekko.UI.Element;

namespace Nekko.UI
{
    [Serializable]
    public class UIScript
    {
        public class ElementKey
        {
            public const string Image = "IMAGE";
            public const string Edit = "EDIT";
            public const string Static = "STATIC";
            public const string Window = "WINDOW";
            public const string RadioButton = "RADIOBUTTON";
        }
        
        public class Attributes
        {   
            // Attributes
            public const string PositionX = "POSITIONX";
            public const string PositionY = "POSITIONY";
            public const string Width = "WIDTH";
            public const string Height = "HEIGHT";
            public const string FxFileName = "FXFILENAME";
            public const string TexPath = "TEX_PATH";
            public const string UseAlpha = "USE_ALPHA";
            public const string Transparency = "TRANSPARENCY";
            public const string ChangeResolution = "CHANGERESOLUTION";
            public const string FontColor = "FONTCOLOR";
            public const string FontName = "FONTNAME";
            public const string FontSize = "FONTSIZE";
            public const string FontBold = "FONTBOLD";
            public const string FontItalic = "FONTITALIC";
            public const string FontFormat = "FONTFORMAT";
            public const string Outline = "OUTLINE";
            public const string OutlineColor = "OUTLINECOLOR";
            public const string NumberOnly = "FONTCOLOR"; // - RRRGGGBBB: Color Pattern
        }
        
        public List<UIGroupElement> Groups = new();
    }
}