using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ROMZOOM.Logic;

namespace ROMZOOM.ControlLib
{
    public class ZListView : Control
    {
        private readonly List<ListItem> m_items;
        private int m_lineHeight;
        private int m_selected = -1;
        private int m_lastSelected = -1;
        private int m_hovered = -1;
        private readonly ItemTextAlign m_textAlign = ItemTextAlign.Center;
        private int m_lastHovered = -1;

        private Color m_backColor;
        private Color m_hoveredItemColor;
        private Color m_selectedItemColor;
        private Color m_textColor;

        public event EventHandler OnSelectionChanged;


        [DefaultValue(typeof(Color), "45,45,45")]
        public new Color BackColor
        {
            get => m_backColor;
            set
            {
                m_backColor = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "SteelBlue")]
        public Color HoveredItemColor
        {
            get => m_hoveredItemColor;
            set
            {
                m_hoveredItemColor = value;
                Invalidate();
            }
        }




        [DefaultValue(typeof(Color), "DodgerBlue")]
        public Color SelectedItemColor
        {
            get => m_selectedItemColor;
            set
            {
                m_selectedItemColor = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "WhiteSmoke")]
        public Color TextColor
        {
            get => m_textColor;
            set
            {
                m_textColor = value;
                Invalidate();
            }
        }

        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListItem SelectedItem => m_selected != -1 ? m_items[m_selected] : null;


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get => m_selected;
            set
            {
                m_selected = value;

                Utils.Clamp(m_selected, 0, m_items.Count - 1);
                Invalidate();
            }
        }
        

        [DefaultValue(17)]
        public int LineHeight
        {
            get => m_lineHeight;
            set
            {
                m_lineHeight = value;
                Invalidate();
            }
        }

        

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ItemsCount => m_items.Count;


        public ZListView()
        {
            
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint|
                     ControlStyles.OptimizedDoubleBuffer, true);

            m_backColor = Color.FromArgb(45, 45, 45);
            m_hoveredItemColor = Color.SteelBlue;
            m_selectedItemColor = Color.DodgerBlue;
            m_textColor = Color.WhiteSmoke;


            m_lineHeight = 17;

            m_items = new List<ListItem>();

            
        }

        public void AddItem(string text, object data)
        {
            m_items.Add(new ListItem(m_items.Count,text, data));

            if (m_items.Count == 1)
            {
                m_selected = 0;
            }
            
            ResizeBounds();
        }

        public void Clear()
        {
            m_items.Clear();
            m_selected = -1;
            ResizeBounds();
        }

        private void ResizeBounds()
        {
            int newHeight = m_items.Count*m_lineHeight;

            if (newHeight == 0)
            {
                newHeight = m_lineHeight;
            }

            SetClientSizeCore(ClientRectangle.Width, newHeight);


        }

        
        

        protected override void OnPaint(PaintEventArgs e)
        {
            

            using (SolidBrush backBrush = new SolidBrush(m_backColor))
            {
                e.Graphics.FillRectangle(backBrush, ClientRectangle);
            }

            
            

            SolidBrush textBrush = new SolidBrush(m_textColor);

            for (int i = 0; i < m_items.Count; i++)
            {
                ListItem item = m_items[i];

                Rectangle itemRect = new Rectangle(0, i * m_lineHeight, ClientRectangle.Width, m_lineHeight);

                if (i == m_selected)
                {
                    using (SolidBrush selectedBrush = new SolidBrush(m_selectedItemColor))
                    {
                        e.Graphics.FillRectangle(selectedBrush, itemRect);
                    }
                }

                else if (i == m_hovered)
                {
                    using (SolidBrush hoveredBrush = new SolidBrush(m_hoveredItemColor))
                    {
                        e.Graphics.FillRectangle(hoveredBrush, itemRect);
                    }
                }

                

                if (m_textAlign == ItemTextAlign.TopLeft)
                {
                    
                    e.Graphics.DrawString(item.Text, Font, textBrush, itemRect);
                    
                }
                else
                {
                    RectangleF textRect = new RectangleF();
                    SizeF textSize = e.Graphics.MeasureString(item.Text, Font);
                    float midWidth = itemRect.Width / 2f;
                    float midHeight = itemRect.Height / 2f;
                    float textMidWidth = textSize.Width / 2f;
                    float textMidHeight = textSize.Height / 2f;
                    switch (m_textAlign)
                    {
                        case ItemTextAlign.Left:
                            {
                                textRect = new RectangleF(itemRect.Left, midHeight - textMidHeight + itemRect.Top, textSize.Width, textSize.Height);
                            }
                            break;
                        case ItemTextAlign.Top:
                            {
                                textRect = new RectangleF(midWidth - textMidWidth, itemRect.Top, textSize.Width, textSize.Height);
                            }
                            break;
                        case ItemTextAlign.TopRight:
                            {
                                textRect = new RectangleF(itemRect.Right - textSize.Width, itemRect.Top, textSize.Width, textSize.Height);
                            }
                            break;
                        case ItemTextAlign.Center:
                            {
                                textRect = new RectangleF(midWidth - textMidWidth, midHeight - textMidHeight + itemRect.Top, textSize.Width, textSize.Height);
                            }
                            break;
                        case ItemTextAlign.Right:
                            {
                                textRect = new RectangleF(itemRect.Right - textSize.Width, midHeight - textMidHeight + itemRect.Top, textSize.Width, textSize.Height);
                            }
                            break;
                        case ItemTextAlign.BottomLeft:
                            {
                                textRect = new RectangleF(itemRect.Left, itemRect.Bottom - textSize.Height, textSize.Width, textSize.Height);
                            }
                            break;
                        case ItemTextAlign.Bottom:
                            {
                                textRect = new RectangleF(midWidth - textMidWidth, itemRect.Bottom - textSize.Height, textSize.Width, textSize.Height);
                            }
                            break;
                        case ItemTextAlign.BottomRight:
                            {
                                textRect = new RectangleF(itemRect.Right - textSize.Width, itemRect.Bottom - textSize.Height, textSize.Width, textSize.Height);
                            }
                            break;
                    }



                    
                    e.Graphics.DrawString(item.Text, Font, textBrush, textRect);
                    
                }
                
                    
            }

            textBrush.Dispose();
        }

        

        protected override void OnMouseMove(MouseEventArgs e)
        {
            m_hovered = (e.Y/m_lineHeight)%(m_items.Count);

            if (m_hovered != m_lastHovered)
            {
                Invalidate();
            }

            m_lastHovered = m_hovered;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            m_hovered = -1;
            m_lastHovered = -1;
            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            m_selected = m_hovered;

            if (m_selected != m_lastSelected)
            {
                TriggerSelected();
                Invalidate();
            }

            m_lastSelected = m_selected;


        }

        protected override void OnResize(EventArgs e)
        {
            ResizeBounds();
            
            
        }

        private void TriggerSelected()
        {
            if (OnSelectionChanged != null)
            {
                OnSelectionChanged(this, EventArgs.Empty);
            }
        }
    }
}
