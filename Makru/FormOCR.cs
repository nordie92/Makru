using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace Makru
{
    public partial class FormOCR : Form
    {
        private TesseractEngine m_ocr;
        public OutputOCR OutputOCR;

        public FormOCR(OutputOCR ocr)
        {
            InitializeComponent();

            m_ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
            m_ocr.SetVariable("tessedit_char_whitelist", "0123456789");

            OutputOCR = ocr;

            nudImageX.Value = ocr.TextRectangle.X;
            nudImageY.Value = ocr.TextRectangle.Y;
            nudImageWidth.Value = Math.Max(ocr.TextRectangle.Width, 1);
            nudImageHeight.Value = Math.Max(ocr.TextRectangle.Height, 1);
            cbImageEditGray.Checked = ocr.TextGray;
            nudImageEditContrast.Value = (decimal)ocr.TextContrast;
            nudImageEditSizeFactor.Value = Math.Max(ocr.TextScale, 4);
            cbLetterSpacingActive.Checked = ocr.LetterSpacingActive;
            nudLetterWidth.Value = Math.Max(ocr.LetterSize.Width, 1);
            nudLetterHeight.Value = Math.Max(ocr.LetterSize.Height, 1);
            nudLetterBorderX.Value = ocr.LetterBorder.Width;
            nudLetterBorderY.Value = ocr.LetterBorder.Height;
        }

        private Bitmap CreateSpaceBetweenLetters(Bitmap source, int border)
        {
            Bitmap bm = new Bitmap(source.Width + 4 * border, source.Height + 2 * border);
            Bitmap bm1 = CropImage(source, new Rectangle(new Point(14, 0), new Size(7, 8)));
            Bitmap bm2 = CropImage(source, new Rectangle(new Point(7, 0), new Size(7, 8)));
            Bitmap bm3 = CropImage(source, new Rectangle(new Point(0, 0), new Size(7, 8)));

            using (var g = Graphics.FromImage(bm))
            {
                g.FillRectangle(Brushes.Black, 0, 0, bm.Width, bm.Height);
                g.DrawImage(bm1, (bm.Width - 7) - border, border);
                g.DrawImage(bm2, (bm.Width - 14) - 2 * border, border);
                g.DrawImage(bm3, (bm.Width - 21) - 3 * border, border);
            }

            return bm;
        }

        private Bitmap AddZero(Bitmap source)
        {
            Bitmap bm = new Bitmap(source.Width + 8, source.Height);
            Bitmap zero = new Bitmap(@".\zero.jpg");
            zero = new Bitmap(zero);

            using (var g = Graphics.FromImage(bm))
            {
                g.DrawImage(source, 0, 0);
                g.DrawImage(zero, 25, 2);
            }

            return bm;
        }

        private Bitmap CreateBorder(Bitmap source, int borderSize)
        {
            Bitmap bitmap = new Bitmap(source.Width + 2 * borderSize, source.Height + 2 * borderSize);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.Black, 0, 0, bitmap.Width, bitmap.Height);
                g.DrawImage(source, borderSize, borderSize);
                return bitmap;
            }
        }

        private Bitmap CropImage(Bitmap source, Rectangle section)
        {
            var bitmap = new Bitmap(section.Width, section.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
                return bitmap;
            }
        }

        private Bitmap ResizeBitmap(Bitmap source, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.High;
                g.FillRectangle(Brushes.Black, 0, 0, width, height);
                g.DrawImage(source, 0, 0, width, height);
            }

            return result;
        }

        public static Bitmap AdjustContrast(Bitmap Image, float Value)
        {
            Value = (100.0f + Value) / 100.0f;
            Value *= Value;
            Bitmap NewBitmap = (Bitmap)Image.Clone();
            BitmapData data = NewBitmap.LockBits(
                new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
                ImageLockMode.ReadWrite,
                NewBitmap.PixelFormat);
            int Height = NewBitmap.Height;
            int Width = NewBitmap.Width;

            unsafe
            {
                for (int y = 0; y < Height; ++y)
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < Width; ++x)
                    {
                        byte B = row[columnOffset];
                        byte G = row[columnOffset + 1];
                        byte R = row[columnOffset + 2];

                        float Red = R / 255.0f;
                        float Green = G / 255.0f;
                        float Blue = B / 255.0f;
                        Red = (((Red - 0.5f) * Value) + 0.5f) * 255.0f;
                        Green = (((Green - 0.5f) * Value) + 0.5f) * 255.0f;
                        Blue = (((Blue - 0.5f) * Value) + 0.5f) * 255.0f;

                        int iR = (int)Red;
                        iR = iR > 255 ? 255 : iR;
                        iR = iR < 0 ? 0 : iR;
                        int iG = (int)Green;
                        iG = iG > 255 ? 255 : iG;
                        iG = iG < 0 ? 0 : iG;
                        int iB = (int)Blue;
                        iB = iB > 255 ? 255 : iB;
                        iB = iB < 0 ? 0 : iB;

                        row[columnOffset] = (byte)iB;
                        row[columnOffset + 1] = (byte)iG;
                        row[columnOffset + 2] = (byte)iR;

                        columnOffset += 4;
                    }
                }
            }

            NewBitmap.UnlockBits(data);

            return NewBitmap;
        }

        private static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            using (Graphics g = Graphics.FromImage(newBitmap))
            {

                //create the grayscale ColorMatrix
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][]
                   {
             new float[] {.3f, .3f, .3f, 0, 0},
             new float[] {.59f, .59f, .59f, 0, 0},
             new float[] {.11f, .11f, .11f, 0, 0},
             new float[] {0, 0, 0, 1, 0},
             new float[] {0, 0, 0, 0, 1}
                   });

                //create some image attributes
                using (ImageAttributes attributes = new ImageAttributes())
                {

                    //set the color matrix attribute
                    attributes.SetColorMatrix(colorMatrix);

                    //draw the original image on the new image
                    //using the grayscale color matrix
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return newBitmap;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Rectangle textRec = new Rectangle((int)nudImageX.Value, (int)nudImageY.Value, (int)nudImageWidth.Value, (int)nudImageHeight.Value);
            Size letterSize = new Size((int)nudLetterWidth.Value, (int)nudLetterHeight.Value);
            Size letterBorder = new Size((int)nudLetterBorderX.Value, (int)nudLetterBorderY.Value);

            OutputOCR = new OutputOCR(textRec, cbImageEditGray.Checked,
                (float)nudImageEditContrast.Value, (int)nudImageEditSizeFactor.Value,
                cbLetterSpacingActive.Checked, letterSize, letterBorder);

            DialogResult = DialogResult.OK;
        }

        private void llOCRHelper_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormOCRHelper frm = new FormOCRHelper(OutputOCR);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                OutputOCR = frm.OutputOCR;

                nudImageX.Value = OutputOCR.TextRectangle.X;
                nudImageY.Value = OutputOCR.TextRectangle.Y;
                nudImageWidth.Value = OutputOCR.TextRectangle.Width;
                nudImageHeight.Value = OutputOCR.TextRectangle.Height;
                cbImageEditGray.Checked = OutputOCR.TextGray;
                nudImageEditContrast.Value = (decimal)OutputOCR.TextContrast;
                nudImageEditSizeFactor.Value = OutputOCR.TextScale;
                cbLetterSpacingActive.Checked = OutputOCR.LetterSpacingActive;
                nudLetterWidth.Value = OutputOCR.LetterSize.Width;
                nudLetterHeight.Value = OutputOCR.LetterSize.Height;
                nudLetterBorderX.Value = OutputOCR.LetterBorder.Width;
                nudLetterBorderY.Value = OutputOCR.LetterBorder.Height;
            }
        }
    }
}
