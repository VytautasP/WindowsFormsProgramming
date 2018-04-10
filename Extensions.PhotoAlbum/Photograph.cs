using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.PhotoAlbum
{
    /// <summary>
    /// A class that represents single Photograps
    /// and its properties
    /// </summary>
    public class Photograph: IDisposable
    {
        #region Fields

        private static Bitmap _invalidImageBitmap;
        private string _fileName;
        private Bitmap _bitmap;
        private string _caption;

        #endregion

        #region Constructors

        public Photograph(string fileName)
        {
            _fileName = fileName;
            _bitmap = null;
            _caption = Path.GetFileNameWithoutExtension(fileName);
        }

        #endregion

        #region Properties

        public string Caption
        {
            get => _caption;
            set => _caption = string.IsNullOrEmpty(value) ? Path.GetFileNameWithoutExtension(_fileName) : value;
        }

        public static Bitmap InvalidImagePhoto
        {
            get
            {
                if (_invalidImageBitmap == null)
                {
                    //dummy photo
                    Bitmap bm = new Bitmap(1920,1080);
                    Graphics g = Graphics.FromImage(bm);
                    g.Clear(Color.DarkGray);

                    Pen p = new Pen(Color.Red, 5);
                    g.DrawLine(p, 0, 0, 1920, 1080);
                    g.DrawLine(p, 1920, 0, 0, 1080);
                    g.DrawString("Invalid file", new Font(family: FontFamily.GenericMonospace, emSize: 54, style:FontStyle.Bold),
                        new SolidBrush(Color.Brown), bm.Width/2 - 200, bm.Height/2 - 40);

                    _invalidImageBitmap = bm;
                }

                return _invalidImageBitmap;
            }
        }
        public string FileName => _fileName;

        public Bitmap Image
        {
            get
            {
                if (_bitmap == null)
                {
                    try
                    {
                        _bitmap = new Bitmap(_fileName);
                    }
                    catch
                    {
                        _bitmap = InvalidImagePhoto;
                    }
                }

                return _bitmap;
            }
        }

        public bool IsImageValid => _bitmap != InvalidImagePhoto;

        #endregion

        #region Methods

        public Rectangle ScaleToFit(Rectangle targetArea)
        {
            Rectangle result = new Rectangle(targetArea.Location, targetArea.Size);

            if (result.Height * Image.Width > result.Width * Image.Height)
            {
                result.Height = result.Height * Image.Height / Image.Width;
                result.Y += (targetArea.Height - result.Height) / 2;
            }
            else
            {
                result.Width = result.Width * Image.Width / Image.Height;
                result.X += (targetArea.Width - result.Width) / 2;
            }

            return result;
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            if (obj is Photograph)
            {
                Photograph p = (Photograph) obj;
                return _fileName.ToLower().Equals(p.FileName.ToLower());
            }
            return false;
        }

        public override int GetHashCode()
        {
            return FileName.GetHashCode();
        }

        public void Dispose()
        {
            if (_bitmap != null && _bitmap != InvalidImagePhoto)
            {
                _bitmap.Dispose();
            }

            _bitmap = null;
        }

        public override string ToString()
        {
            return FileName;
        }

        #endregion
    }
}
