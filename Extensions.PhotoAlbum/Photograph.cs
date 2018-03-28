using System;
using System.Collections.Generic;
using System.Drawing;
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

        #endregion

        #region Constructors

        public Photograph()
        {
            
        }

        #endregion

        #region Properties

        public static Bitmap InvalidImagePhoto
        {
            get
            {
                if (_invalidImageBitmap == null)
                {
                    //dummy photo
                    Bitmap bm = new Bitmap(100,100);
                    Graphics g = Graphics.FromImage(bm);
                    g.Clear(Color.DarkGray);

                    Pen p = new Pen(Color.Red, 5);
                    g.DrawLine(p, 0, 0, 100, 100);
                    g.DrawLine(p, 100, 0, 0, 100);

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
