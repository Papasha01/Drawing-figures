using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Drawing_figures.Logic
{
    internal class Square : Figure
    {
        static public int local_id;
        public float side;
        private float half_side;

        public Square()
        {
            local_id++;
            id = "Square" + local_id.ToString();
            setSide(100.0f);
        }

        public override bool test(float x, float y)
        {
            float xmin = pos_x - half_side;
            float ymin = pos_y - half_side;
            float xmax = pos_x + half_side;
            float ymax = pos_y + half_side;

            if (x < xmin || y < ymin) return false;
            if (x > xmax || y > ymax) return false;
            return true;
        }

        override public void draw(Graphics g)
        {
            float x0 = pos_x - half_side;
            float y0 = pos_y - half_side;
            Pen p = Pens.Black;
            if (selected == true) p = Pens.Red;
            g.DrawRectangle(p, x0, y0, side, side);
        }

        public void setSide(float new_side)
        {
            side = new_side;
            half_side = side * 0.5f;
        }
    }
}
