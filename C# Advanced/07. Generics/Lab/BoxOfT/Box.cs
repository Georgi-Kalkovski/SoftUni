using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> elements;

        public Box()
        {
            this.elements = new List<T>();
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Add(T element)
        {
            this.elements.Add(element);
        }

        public T Remove()
        {
            var element = this.elements[elements.Count - 1];
            this.elements.RemoveAt(elements.Count - 1);

            return element;
        }
    }
}
