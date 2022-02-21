using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Drawing_figures.Logic
{
    internal class Circle : Figure
    {
        static public int local_id;
        public float radius;
        public float radius_squared;
        public float diametr;

        public Circle()
        {
            local_id++;
            id = "Circle" + local_id.ToString();
            setRadius(50.0f);
        }

        override public bool test(float x, float y)
        {
            float dx = x - pos_x;
            float dy = y - pos_y;

            if (dx * dx + dy * dy <= radius_squared) return true;
            return false;
        }

        public override void draw(Graphics g)
        {
            float x0 = pos_x - radius;
            float y0 = pos_y - radius;
            Pen p = Pens.Black;
            if (selected == true) p = Pens.Red;
            g.DrawEllipse(p, x0, y0, diametr, diametr);
        }

        public void setRadius(float new_radius)
        {
            radius = new_radius;
            radius_squared = radius * radius;
            diametr = radius * 2.0f;
        }
    }
}
