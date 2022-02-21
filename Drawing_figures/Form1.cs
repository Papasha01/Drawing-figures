using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing_figures
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int w = 50, h = 50;
        int old_x, old_y;
        List<Logic.Figure> lst = new List<Logic.Figure>();
        SolidBrush br = new SolidBrush(Color.FromArgb(255, 255, 255));
        int index;
        int buf;

        Logic.Figure createFigure(string fig_type)
        {
            switch (fig_type)
            {
                case "Circle": return new Logic.Circle();
                case "Square": return new Logic.Square();
                case "Triangle": return new Logic.Triangle();
            }
            return null;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Logic.Figure fig = createFigure(comboBoxFigure.SelectedItem.ToString());
            if (fig == null) return;
            fig.pos_x = 100.0f;
            fig.pos_y = 100.0f;
            ListFigure.Items.Add(fig.id);
            lst.Add(fig);
            Pictures.Invalidate();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            buf = 0;
            for (int j = lst.Count - 1; j >= 0; j--)
            {
                if (j == index)
                {
                    lst.RemoveAt(index);
                    ListFigure.Items.RemoveAt(index);
                }
            }

            int i = 0;
            while (i < lst.Count)
            {
                if (lst[i].selected == true)
                {
                    lst.RemoveAt(i);
                    ListFigure.Items.RemoveAt(i);
                }
                i++;
            }
            if (ListFigure.Items.Count != 0)
            ListFigure.SelectedIndex = 0;
            
            Pictures.Invalidate();
        }

        private void ListFigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = ListFigure.SelectedIndex;
            selectList(index);
        }

        private void Pictures_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(br, 0, 0, Pictures.Width, Pictures.Height);
            foreach (Logic.Figure fig in lst)
                fig.draw(e.Graphics);
        }

        private void Pictures_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Logic.Figure fig in lst)
                fig.selected = false;

            for (int i = lst.Count - 1; i >= 0; i--)
            {
                ListFigure.SetSelected(buf, false);
                Logic.Figure fig = lst[i];
                fig.selected |= fig.test(e.X, e.Y);
                if (fig.selected == true)
                {
                    ListFigure.SetSelected(i, true);
                    buf = i;
                    break;
                }
            }
            Pictures.Invalidate();
        }

        private void Pictures_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.X - old_x;
                int dy = e.Y - old_y;

                foreach (Logic.Figure fig in lst)
                {
                    if (fig.selected == false) continue;
                    fig.pos_x += dx;
                    fig.pos_y += dy;
                }
                Pictures.Invalidate();
            }
            old_x = e.X;
            old_y = e.Y;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(br, 0, 0, Pictures.Width, Pictures.Height);
            foreach (Logic.Figure fig in lst)
                fig.draw(e.Graphics);
        }

        private void selectList(int index)
        {
            foreach (Logic.Figure fig in lst)
                fig.selected = false;

            for (int i = lst.Count - 1; i >= 0; i--)
            {
                Logic.Figure fig = lst[i];
                if (i == index)
                {
                    fig.selected = true;
                }
            }
            Pictures.Invalidate();
        }
    }
}
