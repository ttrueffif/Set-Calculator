using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SetCalculator.Sets
{
    internal class Set<T> : IEnumerable<T>
    {
        private List<T> _elements = new List<T>();
        private char _letter;

        public Set(char letter) 
        {
            _letter = letter;
        }

        public Set(char letter, params T[] elements) : this(letter)
        {
            foreach (T el in elements) 
                _elements.Add(el);

            ClearFromDublictates();
        }
        
        public T this[int index]
        {
            get
            {
                if (IndexIsOk(index))
                    throw new ArgumentOutOfRangeException("index");

                return _elements[index];
            }
            
            set
            {
                if (!IndexIsOk(index))
                    throw new ArgumentOutOfRangeException("index");

                _elements[index] = value;

                ClearFromDublictates();

                return;
            }
        }

        private bool IndexIsOk(int index)
        {
            return index >= 0 && index < _elements.Count;
        }

        private void ClearFromDublictates()
        {
            for (int i = 0; i < _elements.Count; ++i)
            {
                for (int j = _elements.Count - 1; j > i; --j)
                    if (_elements[i].Equals(_elements[j])) 
                        _elements.RemoveAt(j);
            }
        }

        // Добавление элемента в конец
        public void Add(T element)
        {
            if (!_elements.Contains(element)) _elements.Add(element);
        }

        // Удаление элемента с конца
        public T Pop()
        {
            T popped = _elements[_elements.Count - 1];

            _elements.Remove(_elements[_elements.Count - 1]);

            return popped;
        }

        // Оператор пересечения множеств
        public static Set<T> operator &(Set<T> s1, Set<T> s2)
        {
            Set<T> result = new Set<T>('&');
            var query = from val1 in s1
                        from val2 in s2
                        where val1.Equals(val2)
                        select val1;

            foreach (T value in query) 
                result.Add(value);
            
            return result;
        }

        // Оператор объединения множеств
        public static Set<T> operator |(Set<T> s1, Set<T> s2)
        {
            Set<T> result = new Set<T>('|');
            var query = from val1 in s1
                        from val2 in s2
                        select new { val1, val2 };

            foreach (var value in query)
            {
                result.Add(value.val1);
                result.Add(value.val2);
            }

            return result;
        }

        // Оператор разности множеств
        public static Set<T> operator /(Set<T> s1, Set<T> s2)
        {
            Set<T> result = new Set<T>('/');



            return result;
        }

        public override string ToString()
        {
            if (_elements.Count == 0) 
                return string.Format("Множество {0}: {{}}", _letter);

            string result = string.Format("Множество {0}: {{ ", _letter);

            foreach (var el in _elements)
                result += el + ", ";

            return result += "\b\b }";
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (T el in _elements) yield return el;
        }
    }
}
