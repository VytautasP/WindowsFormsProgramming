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
        private DateTime _dateTaken;
        private string _photographer;
        private string _notes;

        public delegate Photograph ReadDelegate(StreamReader sr);

        #endregion

        #region Constructors

        public Photograph(string fileName)
        {
            _fileName = fileName;
            _bitmap = null;
            _caption = Path.GetFileNameWithoutExtension(fileName);
            _dateTaken = DateTime.Now;
            _photographer = "uknown";
            _notes = "no notes provided";
        }

        #endregion

        #region Properties

        public DateTime DateTaken
        {
            get => _dateTaken;
            set => _dateTaken = value;
        }

        public string Photographer
        {
            get => _photographer;
            set => _photographer = value;
        }

        public string Notes
        {
            get => _notes;
            set => _notes = value;
        }

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

        public void Write(StreamWriter sw)
        {
            sw.WriteLine(this.FileName);
            sw.WriteLine(this.Caption);

            sw.WriteLine(this.DateTaken.Ticks);
            sw.WriteLine(this.Photographer);

            sw.WriteLine(this.Notes.Length);
            sw.WriteLine(this.Notes.ToCharArray());
            sw.WriteLine();
        }

        public static Photograph ReadVersion66(StreamReader sr)
        {
            string name = sr.ReadLine();
            if (name != null)
                return new Photograph(name);
            else
                return null;
        }

        public static Photograph ReadVersion83(StreamReader sr)
        {
            string name = sr.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
                return null;

            Photograph p = new Photograph(name);
            p.Caption = sr.ReadLine();
            return p;
        }

        public static Photograph ReadVersion92(StreamReader sr)
        {
            Photograph p = ReadVersion83(sr);

            if (p == null)
                return null;

            string data = sr.ReadLine();
            long ticks = Convert.ToInt64(data);
            p.DateTaken = new DateTime(ticks);

            p.Photographer = sr.ReadLine();

            data = sr.ReadLine();
            int len = Convert.ToInt32(data);
            char[] noteArray = new char[len];
            sr.Read(noteArray, 0, len);
            p.Notes = new string(noteArray);

            sr.ReadLine();
            sr.ReadLine();

            return p;

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
