﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB6.Storage
{
    internal class MyList<T> : IEnumerable
    {
        private int Size;
        public int GetSize() { return Size; }
        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }
        public IEnumerator GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.pNext;
            }
        }
        public T this[int index]
        {
            get
            {
                int counter = 0;
                Node<T> current = Head;
                while (current != null)
                {
                    if (counter == index)
                        return current.Data;
                    current = current.pNext;
                    counter++;
                }
                return default;
            }

        }
        public void push_back(T data)
        {
            if (Head == null)
            {
                Head = new Node<T>(data);
                Tail = Head;
            }
            else
            {
                Tail.pNext = new Node<T>(data);
                Tail = Tail.pNext;
            }
            Size++;

        }
        public T pop_front()
        {
            if (Head == null)
                return default;
            else if (Head.pNext == null)
            {
                T tempData = Head.Data;
                Head = null;
                Tail = null;
                Size--;
                return tempData;
            }
            else
            {
                Node<T> tempNode = Head;
                T tempData = Head.Data;
                Head = Head.pNext;
                tempNode = null;
                Size--;
                return tempData;
            }
        }
        public T remove(int index)
        {
            if (index < 0 || index - Size > -1)
            {
                return default;
            }
            else if (index == 0 || Head == null)
            {
                return pop_front();
            }
            else
            {
                Node<T> previous = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    previous = previous.pNext;
                }
                Node<T> ToDeleteNode = previous.pNext;
                T ToDeleteData = ToDeleteNode.Data;
                previous.pNext = ToDeleteNode.pNext;
                if (previous.pNext == null)
                    Tail = previous;
                ToDeleteNode = null;
                Size--;
                return ToDeleteData;
            }
        }
        public void clear()
        {
            while (Size != 0)
            {
                T temp = pop_front();
                temp = default;
            }
        }
        internal class Node<T>
        {
            public Node(T data)
            {
                Data = data;
                pNext = null;
            }

            public T Data { get; }
            public Node<T> pNext { get; set; }
        }
    }
}
