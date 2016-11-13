using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace RetroMusicSite.WebUI.Models.Identity
{
    public class CaptchaImage
    {
        public const string CaptchaValueKey = "CaptchaImageText";

        public string Text
        {
            get { return text; }
        }

        public Bitmap Image
        {
            get { return image; }
        }

        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }

        string text, familyName;
        Bitmap image;
        int width, height;

        Random random = new Random();

        public CaptchaImage(string s, int widht, int height)
        {
            text = s;
            SetDimensions(widht, height);
            GenerateImage();
        }

        public CaptchaImage(string s, int widht, int height, string familyName)
        {
            text = s;
            SetDimensions(widht, height);
            SetFamilyName(familyName);
            GenerateImage();
        }

        ~CaptchaImage()
        {
            Dispoise(false);
        }

        public void Dispoise()
        {
            GC.SuppressFinalize(this);
            Dispoise(true);
        }

        public void Dispoise(bool disposing)
        {
            if (disposing)
                image.Dispose();
        }
        private void SetDimensions(int aWidth, int aHeight)
        {
            // Check the aWidth and aHeight.
            if (aWidth <= 0)
                throw new ArgumentOutOfRangeException("aWidth", aWidth, "Argument out ofrange, must be greater than zero.");
            if (aHeight <= 0)
                throw new ArgumentOutOfRangeException("aHeight", aHeight, "Argument outof range, must be greater than zero.");
            width = aWidth;
            height = aHeight;
        }
        void SetFamilyName(string aFamilyName)
        {
            // If the named font is not installed, default to a system font.
            try
            {
                Font font = new Font(aFamilyName, 12F);
                familyName = aFamilyName;
                font.Dispose();
            }
            catch (Exception)
            {
                familyName = FontFamily.GenericSerif.Name;
            }
        }

        void GenerateImage()
        {
            // Create a new 32-bit bitmap image.
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            // Create a graphics object for drawing.
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, width, height);

            // Fill in the background.
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti, Color.LightGray, Color.White);
            graphics.FillRectangle(hatchBrush, rect);

            // Set up the text font.
            SizeF sizeF;
            float fontSize = rect.Height + 1;
            Font font;

            // Adjust the font size until the text fits within the image.
            do
            {
                fontSize--;
                font = new Font(familyName, fontSize, FontStyle.Bold);
                sizeF = graphics.MeasureString(text, font);
            } while (sizeF.Width > rect.Width);

            // Set up the text format.
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            // Create a path using the text and warp it randomly.
            GraphicsPath path = new GraphicsPath();
            path.AddString(text, font.FontFamily, (int)font.Style, font.Size, rect, format);
            float v = 4F;
            PointF[] points =
            {
                new PointF(random.Next(rect.Width)/v, random.Next(rect.Height) /v), 
                new PointF(rect.Width - random.Next(rect.Width) /v, random.Next(rect.Height)/v), 
                new PointF(random.Next(rect.Width)/v, rect.Height - random.Next(rect.Height) /v), 
                new PointF(rect.Width - random.Next(rect.Width) /v, rect.Height - random.Next(rect.Height) /v)
            };

            Matrix matrix = new Matrix();
            matrix.Translate(0F, 0F);
            path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);

            // Draw the text.
            hatchBrush = new HatchBrush(HatchStyle.LargeConfetti, Color.LightGray, Color.DarkGray);
            graphics.FillPath(hatchBrush, path);

            // Add some random noise.
            int m = Math.Max(rect.Width, rect.Height);
            for (int i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
            {
                int x = random.Next(rect.Width);
                int y = random.Next(rect.Height);
                int w = random.Next(m / 50);
                int h = random.Next(m / 50);
                graphics.FillEllipse(hatchBrush, x, y, w, h);
            }

            // Clean up.
            font.Dispose();
            hatchBrush.Dispose();
            graphics.Dispose();

            // Set the image.
            image = bitmap;
        }
    }
}