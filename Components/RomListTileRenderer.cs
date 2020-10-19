using System.Drawing;
using System.Windows.Forms;
using BrightIdeasSoftware;
using ROMZOOM.Model;
using ROMZOOM.Properties;

namespace ROMZOOM.Components
{
    public class RomListTileRenderer : AbstractRenderer
    {
        private readonly Image _place_holder;

        public RomListTileRenderer(Color tile_bg_color, Color clear_color, int spacing)
        {
            _back_brush = new SolidBrush(tile_bg_color);
            _clear_color = clear_color;
            _spacing = spacing;
            _place_holder = Resources.rom_image_place_holder;
        }

        private readonly Color _clear_color;
        private readonly Brush _back_brush;
        private readonly int _spacing;

        public override bool RenderItem(DrawListViewItemEventArgs e, Graphics g, Rectangle itemBounds, object rowObject)
        {
            if (!(e.Item.ListView is ObjectListView rom_list) || rom_list.View != View.Tile)
            {
                return false;
            }

            var draw_buffer = BufferedGraphicsManager.Current.Allocate(g, itemBounds); 

            var gfx = draw_buffer.Graphics;

            gfx.SmoothingMode = ObjectListView.SmoothingMode;
            gfx.TextRenderingHint = ObjectListView.TextRenderingHint;

            gfx.Clear(_clear_color);

            itemBounds.Inflate(-2, -2);

            // Draw Bg

            gfx.FillRectangle(_back_brush, itemBounds);

            gfx.Clip = new Region(itemBounds);

            // Draw Rom Image

            Rectangle image_bounds = itemBounds;

            image_bounds.Inflate(-_spacing, -_spacing);

            var rom = rowObject as Rom;

            Image rom_image;

            if (Library.RomsImages.ContainsKey(rom.Md5))
            {
                rom_image = Library.RomsImages[rom.Md5];
            }
            else
            {
                rom_image = _place_holder;
            }

            image_bounds.Width = 128;
            image_bounds.Height = 128;

            gfx.DrawImage(rom_image, image_bounds);

            draw_buffer.Render();

            draw_buffer.Dispose();

            return true;
        }
    }
}
