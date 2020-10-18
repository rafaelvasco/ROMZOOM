using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ROMZOOM.ControlLib
{
    public class ZDropDown : Control
    {
        private Popup m_dropDownPanel;
        private ZListView m_dropDownList;
        
        private Rectangle m_mainArea;
        private Rectangle m_buttonArea;

        private int m_dropHeight;

        private bool m_dropPanelActive;
        

        private Color m_backColor;
        
        private Color m_buttonColor;
        private Color m_indicatorColor;
       
        private Color m_indicatorActiveColor;
        private Color m_textColor;

        public event EventHandler OnSelectionChanged;



       

        [DefaultValue(typeof(Color), "45,45,45")]
        public new Color BackColor
        {
            get { return m_backColor; }
            set
            {
                m_backColor = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "45,45,45")]
        public Color DropColor
        {
            get { return m_dropDownList.BackColor; }
            set
            {
                m_dropDownList.BackColor = value;
                Invalidate();
            }
        }

       

        [DefaultValue(typeof(Color), "45,45,45")]
        public Color ButtonColor
        {
            get { return m_buttonColor; }
            set
            {
                m_buttonColor = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "SteelBlue")]
        public Color IndicatorColor
        {
            get { return m_indicatorColor; }
            set
            {
                m_indicatorColor = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "DodgerBlue")]
        public Color IndicatorActiveColor
        {
            get { return m_indicatorActiveColor; }
            set
            {
                m_indicatorActiveColor = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "DodgerBlue")]
        public Color SelectedItemColor
        {
            get { return m_dropDownList.SelectedItemColor; }
            set
            {
                m_dropDownList.SelectedItemColor = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "SteelBlue")]
        public Color HoveredItemColor
        {
            get { return m_dropDownList.HoveredItemColor; }
            set
            {
                m_dropDownList.HoveredItemColor = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "WhiteSmoke")]
        public Color TextColor
        {
            get { return m_textColor; }
            set
            {
                m_textColor = value;
                m_dropDownList.TextColor = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListItem SelectedItem
        {
            get { return m_dropDownList.SelectedItem; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get { return m_dropDownList.SelectedIndex; }
            set { m_dropDownList.SelectedIndex = value; Invalidate();}
        }
        
        
        public ZDropDown()
        {

            m_dropDownList = new ZListView();

            MinimumSize = new Size(100, m_dropDownList.LineHeight);

            
            

            m_dropDownList.OnSelectionChanged += delegate 
                                                        {
                                                            TriggerSelectionChanged();
                                                            m_dropDownPanel.Hide();
                                                        };

            
            
            m_dropDownPanel = new Popup(m_dropDownList);

            m_dropDownPanel.VisibleChanged += delegate { m_dropPanelActive ^= true; Refresh(); };

            m_dropDownPanel.AnimationDuration = 150;

            m_dropDownPanel.Resizable = false;

            m_dropDownPanel.ShowingAnimation = PopupAnimations.Blend;

            m_dropDownPanel.HidingAnimation = PopupAnimations.Blend;

            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserMouse , true);

            
           
            m_backColor = Color.FromArgb(45, 45, 45);
            
            m_indicatorColor = Color.SteelBlue;
            
            m_buttonColor = Color.SteelBlue;
            m_indicatorActiveColor = Color.DeepSkyBlue;
            m_textColor = Color.WhiteSmoke;
           
        }

       

        public void AddItem(string text, object data)
        {
            m_dropDownList.AddItem(text,data);
            m_dropHeight += m_dropDownList.LineHeight;

        }

        public void Clear()
        {
            m_dropDownList.Clear();
            m_dropHeight = 0;
            Invalidate();
        }
        

        protected override void OnLayout(LayoutEventArgs levent)
        {
            UpdateAreas();
            

        }

        protected override void OnResize(EventArgs e)
        {
            SetClientSizeCore(ClientRectangle.Width, m_dropDownList.LineHeight);

            UpdateAreas();
            
            
        }

        private void UpdateAreas()
        {

            m_buttonArea = new Rectangle(ClientRectangle.Right - m_dropDownList.LineHeight, ClientRectangle.Top, m_dropDownList.LineHeight, ClientRectangle.Height);
            m_mainArea = new Rectangle(ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Width - m_buttonArea.Width, ClientRectangle.Height);
            
        }

       

        protected override void OnPaint(PaintEventArgs e)
        {


            using (SolidBrush backBrush = new SolidBrush(m_backColor))
            using (SolidBrush buttonBrush = new SolidBrush(m_buttonColor))
            {
                e.Graphics.FillRectangle(backBrush, m_mainArea);
                e.Graphics.FillRectangle(buttonBrush, m_buttonArea);
            }

            if (!m_dropPanelActive)
            {
                using (SolidBrush indicatorBrush = new SolidBrush(m_indicatorColor))
                {
                    e.Graphics.FillRectangle(indicatorBrush, Rectangle.Inflate(m_buttonArea, -m_buttonArea.Width / 4, -m_buttonArea.Width / 4));
                }

            }
            else
            {
                using (SolidBrush indicatorActiveBrush = new SolidBrush(m_indicatorActiveColor))
                {
                    e.Graphics.FillRectangle(indicatorActiveBrush, Rectangle.Inflate(m_buttonArea, -m_buttonArea.Width / 4, -m_buttonArea.Width / 4));
                }
            }

            if (m_dropDownList.ItemsCount == 0)
            {
                return;
            }

            using (SolidBrush textBrush = new SolidBrush(m_textColor))
            {
                e.Graphics.DrawString(m_dropDownList.SelectedItem.Text, Parent.Font, textBrush, m_mainArea);
            }

        
        }

        

       

        protected override void OnMouseClick(MouseEventArgs e)
        {
            m_dropDownPanel.Width = Width;
            m_dropDownPanel.Height = m_dropHeight;
            m_dropDownPanel.Show(this);
        }

        private void TriggerSelectionChanged()
        {
            if(OnSelectionChanged != null)
            {
                OnSelectionChanged(this, EventArgs.Empty);
            }
        }
    }
}
