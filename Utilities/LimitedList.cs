using RpgTextGame.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.Utilities
{
    internal class LimitedList<T>
    {
        private int _capacity;
        private List<T> _items;

        public LimitedList(int capacity)
        {
            _capacity = capacity;
            _items = new List<T>(capacity);  
        }

        public void Add(T item) { 
             if(_items.Count < _capacity){
                _items.Add(item);
             } else{
                throw new InvalidOperationException("List has reached its maximum capacity.");
             }
        }
        public int Count => _items.Count;
        public T this[int index] => _items[index];
        public void IncreaseCapacity(int newCapacity)
        {
            if (newCapacity > _capacity)
            {
                _capacity = newCapacity;
            }
            else
            {
                throw new InvalidOperationException("New capacity must be greater than current capacity.");
            }
        }
    }
}
