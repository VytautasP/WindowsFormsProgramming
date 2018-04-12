using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.PhotoAlbum
{
    /// <summary>
    /// A class that represents collection of Photographs
    /// </summary>
    public class PhotoAlbum : CollectionBase, IDisposable
    {
        #region Fields
        /// <summary>
        /// tracks the current position when displaying the album
        /// </summary>
        private int _currentPos;

        private string _fileName;

        private bool _disposing = false;

        private static string _defaultDir = null;

        private static bool _initializeDir = true;

        private static int _currVer = 92;

        #endregion

        public PhotoAlbum()
        {
            //Nothing to do
        }

        #region Properties

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        public int CurrentPosition
        {
            get { return _currentPos; }
            set
            {
                if (value <= 0)
                    _currentPos = 0;
                else if (value >= this.Count)
                    _currentPos = this.Count - 1;
                else
                    _currentPos = value;
            }
        }

        public Photograph CurrentPhotograph
        {
            get
            {
                if (this.Count == 0)
                    return null;

                return this[CurrentPosition];
            }
        }

        public virtual bool IsSynchronized => false;

        public virtual object SyncRoot => List.SyncRoot;

        public virtual bool IsFixedSize => false;

        public virtual bool IsReadOnly => false;

        public virtual Photograph this[int index]
        {
            get { return (Photograph) List[index]; }
            set { List[index] = value; }
        }

        public static string DefaultDir
        {
            get
            {
                if (_initializeDir)
                {
                    InitializeDefaultDir();
                    _initializeDir = false;
                }

                return _defaultDir;
            }

            set
            {
                _defaultDir = value;
                _initializeDir = false;
            }
        }

        #endregion

        #region Methods

        private static void InitializeDefaultDir()
        {
            if (_defaultDir == null)
            {
                _defaultDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                _defaultDir += @"\Albums";
                Directory.CreateDirectory(_defaultDir);
            }
        }

        public bool CurrentNext()
        {

            if (CurrentPosition + 1 < this.Count)
            {
                CurrentPosition++;
                return true;
            }

            return false;

        }

        public bool CurrentPrev()
        {
            if (CurrentPosition > 0)
            {
                CurrentPosition--;
                return true;
            }

            return false;
        }

        public virtual void CopyTo(Photograph[] array, int index)
        {
            List.CopyTo(array, index);
        }
        public virtual void Add(Photograph photo)
        {
            List.Add(photo);
        }
        public virtual bool Contains(Photograph photo)
        {
            return List.Contains(photo);
        }

        public virtual int IndexOf(Photograph photo)
        {
            return List.IndexOf(photo);
        }

        public virtual void Insert(int index, Photograph photo)
        {
            List.Insert(index, photo);
        }

        public virtual void Remove(Photograph photo)
        {
            List.Remove(photo);
        }

        public void Dispose()
        {
            if (!_disposing)
            {
                _disposing = true;
                foreach (Photograph photograph in this)
                {
                    photograph.Dispose(); ;
                }

                Clear();
            }
        }

        public void Open(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            int version;

            try
            {
                version = Int32.Parse(sr.ReadLine());
            }
            catch
            {
                version = 0;
            }

            try
            {
                this.Clear();
                this.FileName = fileName;

                Photograph.ReadDelegate readPhoto;

                switch (version)
                {
                    case 66:
                        readPhoto = new Photograph.ReadDelegate(Photograph.ReadVersion66);
                        break;
                    case 83:
                        readPhoto = new Photograph.ReadDelegate(Photograph.ReadVersion83);
                        break;
                    case 92:
                        readPhoto = new Photograph.ReadDelegate(Photograph.ReadVersion92);
                        break;
                    default:
                        throw new IOException("Unrecognized album version");
                }

                Photograph p = readPhoto(sr);
                while (p != null)
                {
                    this.Add(p);
                    p = readPhoto(sr);
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

        }

        public void Save(string fileName)
        {

            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(_currVer);

                    foreach (Photograph photograph in this)
                    {
                        photograph.Write(sw);
                    }

                    this._fileName = fileName;
                }
            }

        }

        public void Save()
        {
            Save(this.FileName);
        }

        #endregion

        #region Overrides

        protected override void OnClear()
        {
            _currentPos = 0;
            _fileName = null;
            Dispose();
            base.OnClear();
        }

        protected override void OnRemoveComplete(int index, object value)
        {
            CurrentPosition = _currentPos;
            base.OnRemoveComplete(index, value);
        }

        #endregion

    }
}
