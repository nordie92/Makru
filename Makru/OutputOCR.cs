using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace Makru
{
    public class OutputOCR : Output
    {
        public Rectangle TextRectangle { get; set; }
        public bool TextGray { get; set; }
        public float TextContrast { get; set; }
        public int TextScale { get; set; }
        public Size LetterSize { get; set; }
        public Size LetterBorder { get; set; }
        public bool LetterSpacingActive { get; set; }

        private static TesseractEngine m_ocr;

        private static Bitmap m_screenshoot;
        private static DateTime m_lastScreenshootTime = DateTime.MinValue;

        public OutputOCR()
        {
            CreateUI();
        }

        public OutputOCR(Rectangle textRectangle, bool grayscale, float contrast, int scale, bool letterSpacingActive, Size letterSize, Size letterBorder)
        {
            TextRectangle = textRectangle;
            TextGray = grayscale;
            TextContrast = contrast;
            TextScale = scale;
            LetterSpacingActive = letterSpacingActive;
            LetterSize = letterSize;
            LetterBorder = letterBorder;

            CreateUI();
        }

        private void CreateUI()
        {
            Height = 84;
            Width = 271;

            LinkLabel ll = new LinkLabel();
            ll.Text = "Bild-Texterkennung";
            ll.Top = 0;
            ll.Left = 0;
            ll.Height = Height;
            ll.Width = Width;
            ll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ll.Click += Ll_Click;
            Controls.Add(ll);
        }

        private void Ll_Click(object sender, EventArgs e)
        {
            FormOCR frm = new FormOCR(this);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TextRectangle = frm.OutputOCR.TextRectangle;
                TextGray = frm.OutputOCR.TextGray;
                TextContrast = frm.OutputOCR.TextContrast;
                TextScale = frm.OutputOCR.TextScale;
                LetterSpacingActive = frm.OutputOCR.LetterSpacingActive;
                LetterSize = frm.OutputOCR.LetterSize;
                LetterBorder = frm.OutputOCR.LetterBorder;
            }
        }

        public static TesseractEngine GetTesseractEngine()
        {
            if (m_ocr == null)
            {
                m_ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                m_ocr.SetVariable("tessedit_char_whitelist", "01234567890");
                m_ocr.SetVariable("tessedit_char_blacklist", "l");
                return m_ocr;
            }
            else
            {
                return m_ocr;
            }
        }

        private static string ReplaceCharWithDigit(string value)
        {
            string ret = value;
            ret = ret.Replace("l", "1");
            ret = ret.Replace("I", "1");
            ret = ret.Replace("O", "0");
            ret = ret.Replace("o", "0");
            ret = ret.Replace("S", "5");
            ret = ret.Replace("s", "5");
            return ret;
        }

        public static Bitmap Screenshot()
        {
            if ((DateTime.Now - m_lastScreenshootTime).Milliseconds > (int)(Macros.Settings.ScreenshootsPerSecond / (float)1000) || m_screenshoot == null)
            {
                //Create a new bitmap.
                var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                               Screen.PrimaryScreen.Bounds.Height,
                                               PixelFormat.Format32bppArgb);

                // Create a graphics object from the bitmap.
                var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

                // Take the screenshot from the upper left corner to the right bottom corner.
                gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                            Screen.PrimaryScreen.Bounds.Y,
                                            0,
                                            0,
                                            Screen.PrimaryScreen.Bounds.Size,
                                            CopyPixelOperation.SourceCopy);

                m_lastScreenshootTime = DateTime.Now;

                m_screenshoot = bmpScreenshot;
                Macros.AddLog("New screenshoot");
                return m_screenshoot;
            }
            else
            {
                Macros.AddLog("Old screenshoot");
                return m_screenshoot;
            }
        }

        public static Bitmap CreateBorder(Bitmap source, int borderSize, Brush brush)
        {
            Bitmap bitmap = new Bitmap(source.Width + 2 * borderSize, source.Height + 2 * borderSize);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
                g.DrawImage(source, borderSize, borderSize);
                return bitmap;
            }
        }

        public static Bitmap CropImage(Bitmap source, Rectangle section)
        {
            var bitmap = new Bitmap(section.Width, section.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(new Bitmap(source), 0, 0, section, GraphicsUnit.Pixel);
                return bitmap;
            }
        }

        public static Bitmap ResizeBitmap(Bitmap source, int width, int height)
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

        public static Bitmap AdjustContrast(Bitmap source, float Value)
        {
            Value = (100.0f + Value) / 100.0f;
            Value *= Value;
            Bitmap NewBitmap = new Bitmap(source);
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

        public static Bitmap MakeGrayscale(Bitmap original)
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

        public static Bitmap[][] GetLetters(Bitmap source, Rectangle textRec, Size letterSize, Size letterBorder)
        {
            int rows = (textRec.Height - letterSize.Height) / (letterSize.Height + letterBorder.Height) + 1;
            int cols = (textRec.Width - letterSize.Width) / (letterSize.Width - letterBorder.Width) + 1;

            Bitmap[][] bitmaps = new Bitmap[rows][];

            int xIndex = 0;
            int yIndex = 0;
            for (int y = 0; y + letterSize.Height <= textRec.Height; y += letterSize.Height + letterBorder.Height)
            {
                bitmaps[yIndex] = new Bitmap[cols];
                xIndex = 0;

                for (int x = 0; x + letterSize.Width <= textRec.Width; x += letterSize.Width + letterBorder.Width)
                {
                    bitmaps[yIndex][xIndex] = OutputOCR.CropImage(source, new Rectangle(x, y, letterSize.Width, letterSize.Height));
                    xIndex++;
                }
                yIndex++;
            }

            return bitmaps;
        }

        public static List<Rectangle> GetLettersRectangles(Rectangle textRec, Size letterSize, Size letterBorder)
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            for (int y = 0; y + letterSize.Height <= textRec.Height; y += letterSize.Height + letterBorder.Height)
            {
                for (int x = 0; x + letterSize.Width <= textRec.Width; x += letterSize.Width + letterBorder.Width)
                {
                    rectangles.Add(new Rectangle(x, y, letterSize.Width, letterSize.Height));
                }
            }

            return rectangles;
        }

        public static Bitmap BuildLettersBack(Bitmap[][] letters, Rectangle textRec, Size letterSize, Size letterBorder)
        {
            Point border = new Point(1, 3);

            int rows = (textRec.Height - letterSize.Height) / (letterSize.Height + letterBorder.Width) + 1;
            int cols = (textRec.Width - letterSize.Width) / (letterSize.Width - letterBorder.Width) + 1;

            int width = cols * (letterSize.Width + border.X) + border.X;
            int height = rows * (letterSize.Height + border.Y) + border.Y;

            Bitmap bm = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bm))
            {
                g.FillRectangle(Brushes.Black, 0, 0, width, height);
                for (int y = 0; y < letters.Length; y++)
                {
                    for (int x = 0; x < letters[y].Length; x++)
                    {
                        g.DrawImage(letters[y][x], border.X + (x * (letterSize.Width + border.X)), border.Y + (y * (letterSize.Height + border.Y)));
                    }
                }
            }

            return bm;
        }

        public string DoOCR()
        {
            string result = "";

            //do ocr
            try
            {
                DateTime dt = DateTime.Now;

                Bitmap bm = new Bitmap(Screenshot());
                //bm.Save(@".\pictures\" + dt.ToString("hh_mm_ss_fff") + "_1_full.jpg");

                bm = CropImage(new Bitmap(bm), TextRectangle);
                //bm.Save(@".\pictures\" + dt.ToString("hh_mm_ss_fff") + "_2_crop.jpg");

                if (TextGray)
                    bm = MakeGrayscale(bm);
                //bm.Save(@".\pictures\" + dt.ToString("hh_mm_ss_fff") + "_3_gray.jpg");

                bm = AdjustContrast(bm, TextContrast);
                //bm.Save(@".\pictures\" + dt.ToString("hh_mm_ss_fff") + "_4_contrast.jpg");

                if (LetterSpacingActive)
                {
                    Bitmap[][] bmLetters = GetLetters(bm, TextRectangle, LetterSize, LetterBorder);
                    if (bmLetters.Length > 0 && bmLetters[0].Length > 0)
                        bm = BuildLettersBack(bmLetters, TextRectangle, LetterSize, LetterBorder);
                }
                //bm.Save(@".\pictures\" + dt.ToString("hh_mm_ss_fff") + "_5_letterSpacing.jpg");

                bm = ResizeBitmap(bm, bm.Width * TextScale, bm.Height * TextScale);
                //bm.Save(@".\pictures\" + dt.ToString("hh_mm_ss_fff") + "_6_resize.jpg");

                bm = CreateBorder(bm, 1, Brushes.Black);
                bm.Save(@".\pictures\" + dt.ToString("hh_mm_ss_fff") + "_7_border.jpg");

                Page page = GetTesseractEngine().Process(bm);
                result = ReplaceCharWithDigit(page.GetText()).Trim();
                page.Dispose();

                if (result.Trim().Length == 0)
                {
                    GetTesseractEngine().DefaultPageSegMode = PageSegMode.SingleChar;
                    page = GetTesseractEngine().Process(bm);
                    result = ReplaceCharWithDigit(page.GetText()).Trim();
                    page.Dispose();
                }
                //Console.WriteLine(dt.ToString("HH_mm_ss_fff") + ": " + TextRectangle + ", " + TextGray + ", " + TextContrast + ", " + LetterSpacingActive + ": " + result);
            }
            catch (Exception ex)
            {
                Macros.AddLog("Exception in OCR: " + ex.Message);
            }

            return result;
        }

        public override Variable GetOutput()
        {
            string result = DoOCR();
            Macros.AddLog("Play: Texterkennung: Result: " + result);
            return new Variable("temp", result);
        }

        public override string JSON()
        {
            string strReturn = "";
            strReturn += "{";
            strReturn += "\"type\": \"outputOCR\",";
            strReturn += "\"x\": " + TextRectangle.X + ",";
            strReturn += "\"y\": " + TextRectangle.Y + ",";
            strReturn += "\"width\": " + TextRectangle.Width + ",";
            strReturn += "\"height\": " + TextRectangle.Height + ",";
            strReturn += "\"grayscale\": " + (TextGray ? "true" : "false") + ",";
            strReturn += "\"contrast\": " + TextContrast + ",";
            strReturn += "\"scale\": " + TextScale + ",";
            strReturn += "\"letterSpacingActive\": " + (LetterSpacingActive ? "true" : "false") + ",";
            strReturn += "\"letterWidth\": " + LetterSize.Width + ",";
            strReturn += "\"letterHeight\": " + LetterSize.Height + ",";
            strReturn += "\"letterBorderX\": " + LetterBorder.Width + ",";
            strReturn += "\"letterBorderY\": " + LetterBorder.Height;
            strReturn += "}";
            return strReturn;
        }

        public override string GetText()
        {
            return "Output Bild-Texterkennung";
        }
    }
}
