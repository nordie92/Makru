using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    public partial class FormPixelColorHelper : Form
    {
        public ConditionPixelColor ConditionPixelColor;

        public FormPixelColorHelper(ConditionPixelColor pixelColor)
        {
            InitializeComponent();

            ConditionPixelColor = pixelColor;

            nudPixelX.Value = pixelColor.m_nudPixelX.Value;
            nudPixelY.Value = pixelColor.m_nudPixelY.Value;
            nudMaxDIfference.Value = pixelColor.m_nudMaxDifference.Value;

            pbPreview.Image = Makru.Properties.Resources.icon_command;
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbImage.Image = new Bitmap(ofd.FileName);
            }
        }

        private void pbImage_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap bm = new Bitmap(pbImage.Image);
            nudPixelX.Value = e.X;
            nudPixelY.Value = e.Y;
            plColor.BackColor = bm.GetPixel(e.X, e.Y);
            pbPreview.Image = OutputOCR.CropImage(bm, new Rectangle(e.X - 11, e.Y - 11, 21, 21));

            PreviewColorDif();
        }

        private void nudMaxDIfference_ValueChanged(object sender, EventArgs e)
        {
            PreviewColorDif();
        }

        private void PreviewColorDif()
        {
            Bitmap bm = new Bitmap(pbColorDif.Width, pbColorDif.Height);
            float delta = ((float)nudMaxDIfference.Value * 2f) / pbColorDif.Width;
            int height = pbColorDif.Height / 3;
            using (Graphics g = Graphics.FromImage(bm))
            {
                for (int i = 0; i < pbColorDif.Width; i++)
                {
                    SolidBrush brushR = new SolidBrush(
                        Color.FromArgb(Math.Max(0, Math.Min(255, (int)((plColor.BackColor.R - (int)nudMaxDIfference.Value) + delta * (float)i))),
                        Math.Max(0, Math.Min(255, (int)plColor.BackColor.G)),
                        Math.Max(0, Math.Min(255, (int)plColor.BackColor.B))));
                    g.FillRectangle(brushR, i, 0, 1, height);
                    SolidBrush brushG = new SolidBrush(
                        Color.FromArgb(Math.Max(0, Math.Min(255, (int)plColor.BackColor.R)),
                        Math.Max(0, Math.Min(255, (int)((plColor.BackColor.G - (int)nudMaxDIfference.Value) + delta * (float)i))),
                        Math.Max(0, Math.Min(255, (int)plColor.BackColor.B))));
                    g.FillRectangle(brushG, i, height, 1, height);
                    SolidBrush brushB = new SolidBrush(
                        Color.FromArgb(Math.Max(0, Math.Min(255, (int)plColor.BackColor.R)),
                        Math.Max(0, Math.Min(255, (int)plColor.BackColor.G)),
                        Math.Max(0, Math.Min(255, (int)((plColor.BackColor.B - (int)nudMaxDIfference.Value) + delta * (float)i)))));
                    g.FillRectangle(brushB, i, height * 2, 1, height);
                }
                pbColorDif.Image = bm;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ConditionPixelColor.m_nudPixelX.Value = nudPixelX.Value;
            ConditionPixelColor.m_nudPixelY.Value = nudPixelY.Value;
            ConditionPixelColor.m_nudMaxDifference.Value = nudMaxDIfference.Value;
            ConditionPixelColor.m_plPixelColor.BackColor = plColor.BackColor;
            DialogResult = DialogResult.OK;
        }

        private void btnPickColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = plColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                plColor.BackColor = cd.Color;
            }
        }
    }
}
