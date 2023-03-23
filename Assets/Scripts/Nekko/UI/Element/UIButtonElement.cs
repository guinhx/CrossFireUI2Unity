namespace Nekko.UI.Element
{
    public class UIButtonElement : UIElement
    {
        public bool ToolTipUp { get; set; }
        public bool ToolTipLeft { get; set; }
        public string TexUp { get; set; }
        public string TexDown { get; set; }
        public string TexFocused { get; set; }
        public string TexDisabled { get; set; }
        public string TexLed { get; set; }
        public bool KeepPressed { get; set; }
    }
}