using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ROMZOOM.ControlLib
{
    public enum ContextMenuDirection
    {
        Up,
        Down
    }

    public class ZContextMenu : Control
    {
        private Control mHost;
        private readonly Popup mPopup;
        private readonly List<ListItem> mItems;
        private int mHoveredItem = -1;
        private ContextMenuDirection mDirection;
        private int mItemHeight;
        private Color mHoverColor;
        private Color mTextColor;
        private Color mBgColor;
        private int mWidth;
        private Point mPosition;

        [DefaultValue(typeof(Color), "SteelBlue")]
        public Color HoverColor
        {
            get { return mHoverColor; }
            set { mHoverColor = value; Invalidate();}
        }

        [DefaultValue(typeof(Color), "WhiteSmoke")]
        public Color TextColor
        {
            get { return mTextColor; }
            set { mTextColor = value; Invalidate(); }
        }

        [DefaultValue(typeof(Color), "50,50,50")]
        public new Color BackColor
        {
            get { return mBgColor; }
            set { mBgColor = value; Invalidate(); }
        }

        public ContextMenuDirection Direction
        {
            get { return mDirection; }
            set
            {
                mDirection = value;
                mPopup.ShowingAnimation = mDirection == ContextMenuDirection.Down ? 
                    PopupAnimations.TopToBottom : 
                    PopupAnimations.BottomToTop;
            }
        }

        public class ItemSelectedEventArgs : EventArgs
        {
            public ListItem SelectedItem;
            
            public ItemSelectedEventArgs(ListItem item)
            {
                SelectedItem = item;
            }
        }

        public event EventHandler<ItemSelectedEventArgs> OnItemSelected; 

        public ZContextMenu() 
        {

            this.SetStyle(ControlStyles.UserPaint | 
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            

            mHoverColor = Color.SteelBlue;
            mTextColor = Color.WhiteSmoke;
            mBgColor = Color.FromArgb(50, 50, 50);

            mPopup = new Popup(this);

            Direction = ContextMenuDirection.Down;

            mItems = new List<ListItem>();
        }

        public void AttachTo(Control control, Point position)
        {
            mHost = control;
            mPosition = position;
        }

        public void AddItem(string text, object data)
        {
            AddItem(new ListItem(mItems.Count, text, data));

            
        }

        public void AddItem(ListItem item)
        {
            mItems.Add(item);

            SizeF itemSize;

            using (Graphics g = CreateGraphics())
            {
                itemSize = g.MeasureString(item.Text, Font);
            }

            mItemHeight = (int)itemSize.Height;

            mWidth = (int)(itemSize.Width + 50);

            SetClientSizeCore(mWidth, mItems.Count * mItemHeight);

            mPopup.Width = Width;

            mPopup.Height = Height;

            Invalidate();
        }

        public new void Show()
        {
            var hostAbsPos = mHost.AbsoluteLocation();
            var showPos = new Point(mPosition.X + hostAbsPos.X, mPosition.Y + hostAbsPos.Y);
            mPopup.Show(showPos);
        }

        public new void Hide()
        {
            mPopup.Hide();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            mHoveredItem = e.Y/mItemHeight;
            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (mHoveredItem != -1)
            {
                TriggerItemSelected();
            }
            Hide();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            using (SolidBrush backBrush = new SolidBrush(mBgColor))
            {
                pe.Graphics.FillRectangle(backBrush, ClientRectangle);
            }

            using (SolidBrush textBrush = new SolidBrush(mTextColor))
            {
                for (int i = 0; i < mItems.Count; i++)
                {
                    ListItem item = mItems[i];

                    Rectangle itemRect = new Rectangle(0, i * mItemHeight, ClientRectangle.Width, mItemHeight);

                    if (mHoveredItem == i)
                    {
                        using (SolidBrush hoveredBrush = new SolidBrush(mHoverColor))
                        {
                            pe.Graphics.FillRectangle(hoveredBrush, itemRect);
                        }
                    }

                    var textSize = pe.Graphics.MeasureString(item.Text, Font);

                    float textX = itemRect.Width/2f - textSize.Width/2f;

                    float textY = itemRect.Top + itemRect.Height/2f - textSize.Height/2f;

                    pe.Graphics.DrawString(item.Text, Font, textBrush, textX, textY);
                }
            }

            
        }


        private void TriggerItemSelected()
        {
            if (OnItemSelected != null)
            {
                 OnItemSelected(this, new ItemSelectedEventArgs(mItems[mHoveredItem]));
            }
        }
    }
}
