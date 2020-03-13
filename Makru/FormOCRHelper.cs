using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace Makru
{
    public partial class FormOCRHelper : Form
    {
        private Bitmap m_originalImage;
        private Bitmap m_editedImage;
        private Point m_mouseMoveOffset;
        private Point m_positionMouseDown;
        private DateTime m_lastMouseMove;
        private bool m_changes = true;
        public OutputOCR OutputOCR { get; }

        public FormOCRHelper(OutputOCR conditionOCR)
        {
            InitializeComponent();

            OutputOCR = conditionOCR;

            nudImageX.Value = OutputOCR.TextRectangle.X;
            nudImageY.Value = OutputOCR.TextRectangle.Y;
            nudImageWidth.Value = Math.Max(1, OutputOCR.TextRectangle.Width);
            nudImageHeight.Value = Math.Max(1, OutputOCR.TextRectangle.Height);
            cbImageEditGray2.Checked = OutputOCR.TextGray;
            nudImageEditContrast.Value = (decimal)OutputOCR.TextContrast;
            nudImageEditSizeFactor.Value = Math.Max(1, OutputOCR.TextScale);
            rbLettersActive.Checked = OutputOCR.LetterSpacingActive;
            rbLettersDeavtive.Checked = !OutputOCR.LetterSpacingActive;
            nudLetterWidth.Value = Math.Max(1, OutputOCR.LetterSize.Width);
            nudLetterHeight.Value = Math.Max(1, OutputOCR.LetterSize.Height);
            nudLetterBorderX.Value = OutputOCR.LetterBorder.Width;
            nudLetterBorderY.Value = OutputOCR.LetterBorder.Height;
        }

        private void FormOCRHelper_Load(object sender, EventArgs e)
        {
            m_mouseMoveOffset = new Point(0, 0);
            m_lastMouseMove = DateTime.Now;
            //m_letterBitmaps = new List<Bitmap>();
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                m_originalImage = new Bitmap(ofd.FileName);
                pbOriginal.Image = m_originalImage;
            }
        }

        private void PrintImage(object sender, EventArgs e)
        {
            pbOriginal.Refresh();
            m_changes = true;
        }

        private void pbEditedChanged(object sender, EventArgs e)
        {
            m_changes = true;
        }

        private void pbOriginal_MouseDown(object sender, MouseEventArgs e)
        {
            m_positionMouseDown = new Point(e.Location.X - (int)nudImageX.Value, e.Location.Y - (int)nudImageY.Value);
        }

        private void pbOriginal_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle recText = new Rectangle(
                (int)nudImageX.Value,
                (int)nudImageY.Value,
                (int)nudImageWidth.Value,
                (int)nudImageHeight.Value
                );

            if (recText.IntersectsWith(new Rectangle(e.Location, new Size(1, 1))))
            {
                Cursor = Cursors.SizeAll;

                if (e.Button == MouseButtons.Left)
                {
                    m_mouseMoveOffset.X = e.X - m_positionMouseDown.X;
                    m_mouseMoveOffset.Y = e.Y - m_positionMouseDown.Y;

                    nudImageX.Value = Math.Min(Math.Max(m_mouseMoveOffset.X, 0), pbOriginal.Width - (int)nudImageWidth.Value);
                    nudImageY.Value = Math.Min(Math.Max(m_mouseMoveOffset.Y, 0), pbOriginal.Height - (int)nudImageHeight.Value);
                }
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void DoTextPictureBox()
        {
            Bitmap bm1 = OutputOCR.CropImage(m_originalImage, new Rectangle(
                (int)nudImageX.Value,
                (int)nudImageY.Value,
                (int)nudImageWidth.Value,
                (int)nudImageHeight.Value
                ));

            Bitmap bm2 = (cbImageEditGray2.Checked ? OutputOCR.MakeGrayscale(bm1) : bm1);

            Bitmap bm3 = OutputOCR.AdjustContrast(bm2, (float)nudImageEditContrast.Value);

            Bitmap bm4 = bm3;
            try
            {
                if (rbLettersActive.Checked)
                {
                    Rectangle textRec = new Rectangle((int)nudImageX.Value, (int)nudImageY.Value, (int)nudImageWidth.Value, (int)nudImageHeight.Value);
                    Size letterSize = new Size((int)nudLetterWidth.Value, (int)nudLetterHeight.Value);
                    Size letterBorder = new Size((int)nudLetterBorderX.Value, (int)nudLetterBorderY.Value);

                    bm4 = OutputOCR.BuildLettersBack(OutputOCR.GetLetters(bm3, textRec, letterSize, letterBorder), textRec, letterSize, letterBorder);
                }
                else if (rbLettersShowLines.Checked)
                {
                    bm4 = DrawLetterRectangles(bm3);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in OCR: " + ex.Message);
            }

            Bitmap bm5 = OutputOCR.ResizeBitmap(bm4, bm4.Width * (int)nudImageEditSizeFactor.Value, bm4.Height * (int)nudImageEditSizeFactor.Value);

            Bitmap bm6 = OutputOCR.CreateBorder(bm5, 1, Brushes.Black);

            m_editedImage = new Bitmap(bm6);
            pbText.Image = m_editedImage;

            Page page = OutputOCR.GetTesseractEngine().Process(bm6);
            lbDetectedText.Text = page.GetText().Trim();
            page.Dispose();
            if (lbDetectedText.Text.Trim().Length == 0)
            {
                OutputOCR.GetTesseractEngine().DefaultPageSegMode = PageSegMode.SingleChar;
                page = OutputOCR.GetTesseractEngine().Process(bm6);
                lbDetectedText.Text = page.GetText().Trim();
                page.Dispose();
            }

            bm1.Dispose();
            bm2.Dispose();
            bm3.Dispose();
            bm4.Dispose();
            bm5.Dispose();
            bm6.Dispose();
        }

        private void pbOriginal_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(
                Pens.Red,
                (float)nudImageX.Value - 1,
                (float)nudImageY.Value - 1,
                (float)nudImageWidth.Value + 1,
                (float)nudImageHeight.Value + 1);
        }

        private void timerRenderTextImage_Tick(object sender, EventArgs e)
        {
            if (m_originalImage != null && m_changes)
            {
                DoTextPictureBox();
                m_changes = false;
            }
        }

        private Bitmap DrawLetterRectangles(Bitmap bitmap)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Rectangle textRec = new Rectangle((int)nudImageX.Value, (int)nudImageY.Value, (int)nudImageWidth.Value, (int)nudImageHeight.Value);
                Size letterSize = new Size((int)nudLetterWidth.Value, (int)nudLetterHeight.Value);
                Size letterBorder = new Size((int)nudLetterBorderX.Value, (int)nudLetterBorderY.Value);

                foreach (Rectangle rec in OutputOCR.GetLettersRectangles(textRec, letterSize, letterBorder))
                {
                    g.DrawRectangle(
                        Pens.Red,
                        rec.X,
                        rec.Y,
                        rec.Width - 1,
                        rec.Height - 1);
                }
            }
            return bitmap;
        }

        private void cbImageEditGray(object sender, EventArgs e)
        {
            m_changes = true;
        }

        private void cbImageEditGray2_CheckedChanged(object sender, EventArgs e)
        {
            m_changes = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OutputOCR.TextRectangle = new Rectangle((int)nudImageX.Value, (int)nudImageY.Value, (int)nudImageWidth.Value, (int)nudImageHeight.Value);
            OutputOCR.TextGray = cbImageEditGray2.Checked;
            OutputOCR.TextContrast = (int)nudImageEditContrast.Value;
            OutputOCR.TextScale = (int)nudImageEditSizeFactor.Value;
            OutputOCR.LetterSpacingActive = rbLettersActive.Checked;
            OutputOCR.LetterSize = new Size((int)nudLetterWidth.Value, (int)nudLetterHeight.Value);
            OutputOCR.LetterBorder = new Size((int)nudLetterBorderX.Value, (int)nudLetterBorderY.Value);

            DialogResult = DialogResult.OK;
        }
    }
}
