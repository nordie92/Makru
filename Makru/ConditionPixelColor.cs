using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Makru
{
    public class ConditionPixelColor : Condition
    {
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        public override event OnConditionChangedEvent OnConditionChanged;
        public NumericUpDown m_nudPixelX;
        public NumericUpDown m_nudPixelY;
        public NumericUpDown m_nudMaxDifference;
        public Panel m_plPixelColor;
        private Button m_btnChooseColor;
        private LinkLabel m_llPixelColorHelper;

        public ConditionPixelColor()
        {
            CreateUI();
        }

        public ConditionPixelColor(int pixelX, int pixelY, Color pixelColor, int maxDifference)
        {
            CreateUI();

            m_nudPixelX.Value = pixelX;
            m_nudPixelY.Value = pixelY;
            m_plPixelColor.BackColor = pixelColor;
            m_nudMaxDifference.Value = maxDifference;
        }

        Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
        public Color GetColorAt(Point location)
        {
            using (Graphics gdest = Graphics.FromImage(screenPixel))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            return screenPixel.GetPixel(0, 0);
        }

        private void CreateUI()
        {
            Height = 84;
            Width = 271;

            Label lb1 = new Label();
            lb1.Text = "Pixel X";
            lb1.Top = 2;
            lb1.Left = 8;
            lb1.Width = 64;
            lb1.Height = 13;
            Controls.Add(lb1);

            m_nudPixelX = new NumericUpDown();
            m_nudPixelX.Maximum = 99999;
            m_nudPixelX.Top = 16;
            m_nudPixelX.Left = 8;
            m_nudPixelX.Width = 64;
            Controls.Add(m_nudPixelX);

            Label lb2 = new Label();
            lb2.Text = "Pixel Y";
            lb2.Top = 41;
            lb2.Left = 8;
            lb2.Width = 64;
            lb2.Height = 13;
            Controls.Add(lb2);

            m_nudPixelY = new NumericUpDown();
            m_nudPixelY.Maximum = 99999;
            m_nudPixelY.Top = 55;
            m_nudPixelY.Left = 8;
            m_nudPixelY.Width = 64;
            Controls.Add(m_nudPixelY);

            Label lb5 = new Label();
            lb5.Text = "ist gleich";
            lb5.Top = 33;
            lb5.Left = 87;
            lb5.Width = 88;
            lb5.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lb5);

            Label lb3 = new Label();
            lb3.Text = "Farbe";
            lb3.Top = 2;
            lb3.Left = 193;
            lb3.Width = 64;
            lb3.Height = 13;
            Controls.Add(lb3);

            m_plPixelColor = new Panel();
            m_plPixelColor.BackColor = Color.White;
            m_plPixelColor.BorderStyle = BorderStyle.FixedSingle;
            m_plPixelColor.Top = 16;
            m_plPixelColor.Left = 193;
            m_plPixelColor.Width = 50;
            m_plPixelColor.Height = 21;
            Controls.Add(m_plPixelColor);

            Label lb4 = new Label();
            lb4.Text = "Abweichung";
            lb4.Top = 41;
            lb4.Left = 193;
            lb4.Width = 74;
            lb4.Height = 13;
            Controls.Add(lb4);

            m_nudMaxDifference = new NumericUpDown();
            m_nudMaxDifference.Maximum = 255 + 255 + 255;
            m_nudMaxDifference.Value = 10;
            m_nudMaxDifference.Top = 55;
            m_nudMaxDifference.Left = 193;
            m_nudMaxDifference.Width = 72;
            Controls.Add(m_nudMaxDifference);

            m_btnChooseColor = new Button();
            m_btnChooseColor.Text = "...";
            m_btnChooseColor.Top = 15;
            m_btnChooseColor.Left = 241;
            m_btnChooseColor.Width = 24;
            m_btnChooseColor.Height = 23;
            m_btnChooseColor.Click += M_btnChooseColor_Click;
            Controls.Add(m_btnChooseColor);

            m_llPixelColorHelper = new LinkLabel();
            m_llPixelColorHelper.Text = "Pixel anhand von Beispielbild ermitteln";
            m_llPixelColorHelper.Top = 64;
            m_llPixelColorHelper.Left = 74;
            m_llPixelColorHelper.Width = Width - 148;
            m_llPixelColorHelper.Click += M_llPixelColorHelper_Click;
            Controls.Add(m_llPixelColorHelper);
        }

        private void M_llPixelColorHelper_Click(object sender, EventArgs e)
        {
            FormPixelColorHelper frm = new FormPixelColorHelper(this);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                m_nudPixelX.Value = frm.ConditionPixelColor.m_nudPixelX.Value;
                m_nudPixelY.Value = frm.ConditionPixelColor.m_nudPixelY.Value;
                m_nudMaxDifference.Value = frm.ConditionPixelColor.m_nudMaxDifference.Value;
                m_plPixelColor.BackColor = frm.ConditionPixelColor.m_plPixelColor.BackColor;
            }
        }

        private void M_btnChooseColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = m_plPixelColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                m_plPixelColor.BackColor = cd.Color;
            }
        }

        public override bool GetResult()
        {
            Color color = GetColorAt(new Point((int)m_nudPixelX.Value, (int)m_nudPixelY.Value));

            int r_dif = Math.Abs(color.R - m_plPixelColor.BackColor.R);
            int g_dif = Math.Abs(color.G - m_plPixelColor.BackColor.G);
            int b_dif = Math.Abs(color.B - m_plPixelColor.BackColor.B);
            int total_dif = r_dif + g_dif + b_dif;
            bool result = total_dif <= (int)m_nudMaxDifference.Value;

            Macros.AddLog("Play: Bedingung: PixelColor(" + (int)m_nudPixelX.Value + "/" + (int)m_nudPixelY.Value + ") " + (result ? "gleich" : "ungleich") + " rgb(" + 
                m_plPixelColor.BackColor.R + ", " + m_plPixelColor.BackColor.G + ", " + m_plPixelColor.BackColor.B + ") diff=" + total_dif);

            return result;
        }

        public override string GetText()
        {
            return "Pixel(" + (int)m_nudPixelX.Value + "/" + (int)m_nudPixelY.Value + ") = rgb(" +
                m_plPixelColor.BackColor.R + ", " + m_plPixelColor.BackColor.G + ", " + m_plPixelColor.BackColor.B + ") +- " + (int)m_nudMaxDifference.Value;
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{";
            strReturn += "\"type\": \"conditionPixelColor\",";
            strReturn += "\"x\": " + (int)m_nudPixelX.Value + ",";
            strReturn += "\"y\": " + (int)m_nudPixelY.Value + ",";
            strReturn += "\"color\": " + m_plPixelColor.BackColor.ToArgb() + ",";
            strReturn += "\"maxColorifference\": " + (int)m_nudMaxDifference.Value;
            strReturn += "}";
            return strReturn;
        }
    }
}
