using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowMan
{
    public class Circle
    {
        public int x { get; set; }
        public int y { get; set; }
        public int diameter { get; set; }
        public Color fillColor { get; set; }
        public Color borderColor { get; set; }
        public bool IsSelected { get; set; }
        public void Draw(Graphics g)
        {
            Brush fill = new SolidBrush(fillColor);
            Pen border = new Pen(borderColor, IsSelected ? 4 : 2);

            g.FillEllipse(fill, x, y, diameter, diameter);
            g.DrawEllipse(border, x, y, diameter, diameter);
        }
        public bool CheckClick(int mx, int my)
        {
            int center_x = x + diameter / 2;
            int center_y = y + diameter / 2;

            int distance_x = mx - center_x;
            int distance_y = my - center_y;

            // (x − a)² + (y − b)² ≤ r²
            int our_click = distance_x * distance_x + distance_y * distance_y;
            int our_radius = (diameter / 2) * (diameter / 2);

            return (our_click <= our_radius);
        }
    }
    class Sun
    {
    public int pos_x { set; get; }
    public int pos_y { set; get; }
    public int sun_width { set; get; }
    public int sun_height { set; get; }

        public void Sun_draw(Graphics g)
        {
            g.FillEllipse(Brushes.Yellow, pos_x, pos_y, sun_width, sun_height);
            g.DrawEllipse(Pens.Goldenrod, pos_x, pos_y, sun_width, sun_height);
        }
        public void Sun_move()
        {
            pos_x += 15;
            pos_y += 3;
            sun_width += 9;
            sun_height += 9;
        }
    }
    
    class SnowHead
    {
        public Circle head;
        public ImageItem right_eye;
        public ImageItem left_eye;

        public SnowHead(Circle head, ImageItem right_eye, ImageItem left_eye)
        {
            this.head = head;
            this.right_eye = right_eye;
            this.left_eye = left_eye;
        }
        public void Move(int x, int y)
        {
            head.x += x;
            head.y += y;

            right_eye.Left += x;
            right_eye.Top += y;
            
            left_eye.Left += x;
            left_eye.Top += y;
        }
        public void Jump(int jumpPower)
        {
            head.y -= jumpPower;
            right_eye.Top -= jumpPower;
            left_eye.Top -= jumpPower;
        }
        public void Fall(int fallPower)
        {
            head.y += fallPower;
            right_eye.Top += fallPower;
            left_eye.Top += fallPower;
        }
    }
    internal class AnimationClasses
    {
    }
}
