using System.Drawing;
using System.Windows.Forms;
using BrightIdeasSoftware;
using ROMZOOM.Model;
using ROMZOOM.Properties;

namespace ROMZOOM.Components
{
    public class RomListTileRendererColors
    {
        public Color BgColor { get; set; }
        public Color SelectedColor { get; set; }
        public Color TextBgColor { get; set; }
        public Color TextColor { get; set; }
        public Color SelectedTextColor { get; set; }

    }

    public class RomListTileRenderer : AbstractRenderer
    {
        private readonly Image _place_holder;

        public RomListTileRenderer(RomListTileRendererColors colors)
        {
            _back_brush = new SolidBrush(colors.BgColor);
            _selected_back_brush = new SolidBrush(colors.SelectedColor);
            _clear_color = Color.FromKnownColor(KnownColor.MidnightBlue);
            _text_brush = new SolidBrush(colors.TextColor);
            _selected_text_brush = new SolidBrush(colors.SelectedTextColor);
            _text_back_brush = new SolidBrush(colors.TextBgColor);
            _selected_color_pen = new Pen(_selected_back_brush, 2.5f);

            _text_font = new Font(familyName: "Input", emSize: 10,FontStyle.Bold);

            _place_holder = Resources.rom_image_place_holder;

            _text_str_format = new StringFormat(StringFormatFlags.NoWrap)
            {
                Trimming = StringTrimming.EllipsisCharacter,
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            _back_brush?.Dispose();
            _selected_back_brush?.Dispose();
            _text_brush?.Dispose();
            _text_font?.Dispose();
        }

        private readonly Color _clear_color;
        private readonly Brush _back_brush;
        private readonly Brush _text_back_brush;
        private readonly Brush _selected_back_brush;
        private readonly Pen _selected_color_pen;
        private readonly Brush _selected_text_brush;
        private readonly Brush _text_brush;
        private readonly Font _text_font;
        private readonly StringFormat _text_str_format;

        private const int _rom_title_area_height = 20;

        public override bool RenderItem(DrawListViewItemEventArgs e, Graphics g, Rectangle itemBounds, object rowObject)
        {
            void DrawBg(Graphics g_ref)
            {
                g_ref.FillRectangle(_back_brush, itemBounds);

                if (e.Item.Selected)
                {
                    g_ref.DrawRectangle(_selected_color_pen, Rectangle.Inflate(itemBounds, -2, -2));
                }
            }

            void DrawRomImage(Graphics g_ref, Rom rom_obj)
            {
                Rectangle image_bounds = itemBounds;

                Image rom_image;

                if (Library.RomsImages.ContainsKey(rom_obj.Md5))
                {
                    rom_image = Library.RomsImages[rom_obj.Md5];
                }
                else
                {
                    rom_image = _place_holder;
                }

                image_bounds.Inflate(-10, -10);

                g_ref.DrawImage(rom_image, image_bounds);
            }

            void DrawRomTitle(Graphics g_ref, Rom rom_obj)
            {
                RectangleF textBoxRect = itemBounds;
                textBoxRect.Height = _rom_title_area_height;
                textBoxRect.Y += itemBounds.Height - _rom_title_area_height;

                if (!e.Item.Selected)
                {
                    g_ref.FillRectangle(_text_back_brush, textBoxRect);
                    g_ref.DrawString(rom_obj.Name, _text_font, this._text_brush, textBoxRect, _text_str_format);
                }
                else
                {
                    textBoxRect = RectangleF.Inflate(textBoxRect, -2, 0);
                    g_ref.FillRectangle(_selected_back_brush, textBoxRect);
                    g_ref.DrawString(rom_obj.Name, _text_font, this._selected_text_brush, textBoxRect, _text_str_format);
                }
            }

            if (!(e.Item.ListView is ObjectListView rom_list) || rom_list.View != View.Tile)
            {
                return false;
            }

            var rom = rowObject as Rom;

            var draw_buffer = BufferedGraphicsManager.Current.Allocate(g, itemBounds); 

            var gfx = draw_buffer.Graphics;

            gfx.SmoothingMode = ObjectListView.SmoothingMode;
            gfx.TextRenderingHint = ObjectListView.TextRenderingHint;

            gfx.Clear(_clear_color);

            DrawBg(gfx);

            gfx.Clip = new Region(itemBounds);

            DrawRomImage(gfx, rom);

            // Draw Rom Title

            DrawRomTitle(gfx, rom);

            draw_buffer.Render();

            draw_buffer.Dispose();

            return true;
        }
    }
}
