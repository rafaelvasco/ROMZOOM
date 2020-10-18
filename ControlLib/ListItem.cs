using System;
using System.Drawing;

namespace ROMZOOM.ControlLib
{
    public class ListItem : IDisposable
    {
        public string Text;
        public object Data;
        public Bitmap Image;
        public int Index;
        public bool Enabled = true;

        public ListItem(int index, string text, object data)
        {
            this.Index = index;
            this.Text = text;
            this.Data = data;
            this.Image = null;
        }

        public override string ToString()
        {
            return Text;
        }

        public void Dispose()
        {
            Image?.Dispose();
        }

        public void SetImage(Bitmap image)
        {
            this.Image = image;
        }
    }

    public enum ItemTextAlign
    {
        TopLeft,
        Top,
        TopRight,
        Left,
        Center,
        Right,
        BottomLeft,
        Bottom,
        BottomRight
    }
}
