using System.Collections;

namespace OOP_Object
{
    class MyList<T> : IEnumerable  // where T : class
    {
        private ArrayList _arraylist = new ArrayList();

        public void Add(T p)
        {
            _arraylist.Add(p);
        }

        public int Count
        {
            get
            {
                return _arraylist.Count;
            }
        }
        public T this[int index]
        {
            get
            {

                //return _arraylist[index] as T;
                return (T)_arraylist[index];
            }
        }

        public void Remove(T p)
        {
            _arraylist.Remove(p);
        }

        public void RemoveAt(int index)
        {
            _arraylist.RemoveAt(index);
        }

        public void Clear()
        {
            _arraylist.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return _arraylist.GetEnumerator();
        }
    }


}
