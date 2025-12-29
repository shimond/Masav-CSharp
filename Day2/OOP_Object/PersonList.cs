using System.Collections;

namespace OOP_Object
{
    class PersonList : IEnumerable
    {
        private ArrayList _arraylist = new ArrayList();

        public void Add(Person p)
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
        public Person this[int index]
        {
            get
            {

                return _arraylist[index] as Person;
            }
        }

        public void Remove(Person p)
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
