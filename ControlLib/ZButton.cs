using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ROMZOOM.ControlLib
{
    public class ZButton : Button
    {
        private Color m_textColor;
        private Color m_normalColor;
        private Color m_hoveredColor;
        private Color m_pressedColor;
        private Color m_topBorderColor;
        private Color m_topBorderHoveredColor;
        private int m_borderSize;
        private int mContentOffset;
        private bool m_textInvalidated;
        private bool m_hovered;
        private bool m_pressed;
        private SizeF m_textSize;
        private PointF m_textDrawPoint;
        private ZContextMenu mContextMenu;
       

        [DefaultValue(typeof(Color), "45,45,45")]
        public Color NormalColor
        {
            get { return m_normalColor; }
            set
            {
                m_normalColor = value;
                Invalidate();
            }
        }

        

        [DefaultValue(typeof(Color), "45,45,45")]
        public Color HoveredColor
        {
            get { return m_hoveredColor; }
            set
            {
                m_hoveredColor = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "40,40,40")]
        public Color PressedColor
        {
            get { return m_pressedColor; }
            set
            {
                m_pressedColor = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "245,245,245")]
        public Color TextColor
        {
            get { return m_textColor; }
            set
            {
                m_textColor = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "70,130,180")]
        public Color TopBorderColor
        {
            get { return m_topBorderColor; }
            set
            {
                m_topBorderColor = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "0,191,255")]
        public Color TopBorderHoveredColor
        {
            get { return m_topBorderHoveredColor; }
            set
            {
                m_topBorderHoveredColor = value;
                Invalidate();
            }
        }

        [DefaultValue(4)]
        public int BorderSize
        {
            get { return m_borderSize; }
            set { m_borderSize = value; Invalidate(); }
        }


        public ZButton()
        {

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         
            this.TextChanged += OnTextChanged;

            m_borderSize = 4;

            AutoSize = false;

            m_textColor = Color.WhiteSmoke;
            m_normalColor = Color.FromArgb(45, 45, 45);
            m_hoveredColor = Color.FromArgb(45, 45, 45);
            m_pressedColor = Color.FromArgb(40, 40, 40);

            m_topBorderColor = Color.SteelBlue;
            m_topBorderHoveredColor = Color.DeepSkyBlue;
            
            mContentOffset = 0; 
            
            
            
            m_textInvalidated = true;
            
            
        }

        public new ZContextMenu ContextMenu
        {
            get => mContextMenu;
            set
            {
                mContextMenu = value;
                
               

                mContextMenu.AttachTo(this,
                                      mContextMenu.Direction == ContextMenuDirection.Down
                                          ? new Point(0 ,  Height)
                                          : new Point(0 ,  - Height));
                
            }
        }

        private void OnTextChanged(object sender, EventArgs eventArgs)
        {
            m_textInvalidated = true;
            Invalidate();
        }

      
      

        protected override void OnResize(EventArgs e)
        {
            
            m_textInvalidated = true;

            base.OnResize(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ContextMenu != null)
            {
                ContextMenu.Show();
            }
            else
            {
                base.OnMouseUp(e);
                m_pressed = false;
                Invalidate();
            }

            base.OnMouseUp(e);
            
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            m_pressed = true;
            Invalidate();
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            m_hovered = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            m_hovered = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        
        

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (m_textInvalidated && Image == null)
            {
                m_textSize = e.Graphics.MeasureString(Text, Font);
                
                m_textInvalidated = false;
            }

            Rectangle clientRect = ClientRectangle;

            mContentOffset = 0;

            if (!m_hovered)
            {
                using (SolidBrush normalBrush = new SolidBrush(m_normalColor))
                using (SolidBrush normalTopBorderBrush = new SolidBrush(m_topBorderColor))
                {
                    e.Graphics.FillRectangle(normalBrush, clientRect);
                    e.Graphics.FillRectangle(normalTopBorderBrush, new Rectangle(clientRect.Left, clientRect.Top, clientRect.Width, m_borderSize));
                }
            }
            else if(m_hovered && !m_pressed)
            {
                using (SolidBrush hoveredBrush = new SolidBrush(m_hoveredColor))
                using (SolidBrush hoveredTopBorderBrush = new SolidBrush(m_topBorderHoveredColor))
                {
                    e.Graphics.FillRectangle(hoveredBrush, clientRect);
                    e.Graphics.FillRectangle(hoveredTopBorderBrush, new Rectangle(clientRect.Left, clientRect.Top, clientRect.Width, m_borderSize));
                }
            }
            else
            {
                mContentOffset = 1;

                using (SolidBrush pressedBrush = new SolidBrush(m_pressedColor))
                {
                    e.Graphics.FillRectangle(pressedBrush, clientRect);
                }

            }

            if (Image == null)
            {
                m_textDrawPoint = new PointF(ClientSize.Width / 2f - m_textSize.Width / 2, ClientSize.Height / 2f - m_textSize.Height / 2 + mContentOffset);



                using (SolidBrush textBrush = new SolidBrush(m_textColor))
                {
                    e.Graphics.DrawString(this.Text, this.Font, textBrush, m_textDrawPoint);
                }
            }
            else
            {
                var imageDrawPoint = new Point(clientRect.Width/2 - Image.Width/2, clientRect.Height/2 - Image.Height/2 + mContentOffset);
                e.Graphics.DrawImageUnscaled(Image, imageDrawPoint);
            }

            

        }
    }
}
