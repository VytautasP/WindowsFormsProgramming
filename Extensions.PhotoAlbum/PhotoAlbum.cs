using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        #endregion

        #region Methods
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

        public void Dispose()
        {
            if (!_disposing)
            {
                _disposing = true;
                foreach (Photograph photograph in this)
                {
                    photograph.Dispose();;
                }

                Clear();
            }
        }
    }
}
