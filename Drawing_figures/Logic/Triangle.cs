using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_figures.Logic
{
    internal class Triangle : Figure
    {
        static public int local_id;
        private float side, half_side;

        public Triangle()
        {
            local_id++;
            id = "Triangle" + local_id.ToString();
            SET(100.0f);
        }

        override public bool test(float x, float y)
        {
            float xmin = pos_x - half_side;
            float ymin = pos_y - half_side;
            float xmax = pos_x + half_side;
            float ymax = pos_y + half_side;

            if (x < xmin || y < ymin) return false;
            if (x > xmax || y > ymax) return false;
            return true;
        }

        public override void draw(Graphics g)
        {
            float x0 = pos_x + side / 2;
            float y0 = pos_y + side / 2;

            Point[] point =
            {
                new Point((int)(x0 - side),(int)y0),
                new Point((int)x0,(int)y0),
                new Point((int)(x0 - side/2),(int)(y0 - side)),
                new Point((int)(x0 - side),(int)y0)
            };

            Pen p = Pens.Black;
            if (selected == true) p = Pens.Red;
            g.DrawLines(p, point);
        }

        public void SET(float new_side)
        {
            side = new_side;
            half_side = side * 0.5f;
        }
    }
}
