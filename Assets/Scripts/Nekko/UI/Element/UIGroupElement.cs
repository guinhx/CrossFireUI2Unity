using System;
using System.Collections.Generic;

namespace Nekko.UI.Element
{
    [Serializable]
    public class UIGroupElement
    {
        public string Name;
        public List<UIElement> Elements = new();
    }
}