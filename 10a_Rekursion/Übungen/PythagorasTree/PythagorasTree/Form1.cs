using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PythagorasTree
{
    public partial class Pythagorastree : Form
    {
        double tanphi = 0.6;
        public Pythagorastree()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            PaintTree(e.Graphics, 200, 400, 320, 400);
        }

        void PaintTree(Graphics g, 
            double bottomLeftX, double bottomLeftY,
            double bottomRightX, double bottomRightY)
        {
            // (1) Eckpunkte bestimmen
            double distanceX = bottomRightX - bottomLeftX;
            double distanceY = bottomLeftY - bottomRightY;
            double topLeftX = bottomLeftX - distanceY;
            double topLeftY = bottomLeftY - distanceX;
            double topRightX = bottomRightX - distanceY;
            double topRightY = bottomRightY - distanceX;

            Pen p = new Pen(Color.Green, 1);

            // (2) vollständiges Quadrat zeichnen
            g.DrawLine(p, (int)bottomLeftX, (int)bottomLeftY, (int)bottomRightX, (int)bottomRightY);
            g.DrawLine(p, (int)bottomRightX, (int)bottomRightY, (int)topRightX, (int)topRightY);
            g.DrawLine(p, (int)topRightX, (int)topRightY, (int)topLeftX, (int)topLeftY);
            g.DrawLine(p, (int)bottomLeftX, (int)bottomLeftY, (int)topLeftX, (int)topLeftY);

            // (3) Koordinaten des neuen Eckpunktes errechnen
            double splitPointX = (topLeftX + topRightX) / 2 - (distanceY / 2 * tanphi);
            double splitPointY = (topLeftY + topRightY) / 2 - (distanceX / 2 * tanphi);

            if (distanceX * distanceX + distanceY * distanceY > 2)
            {
                // (4) kleine Teilbäume zeichnen
                PaintTree(g, topLeftX, topLeftY, splitPointX, splitPointY);
                PaintTree(g, splitPointX, splitPointY, topRightX, topRightY);
            }
        }
    }
}
