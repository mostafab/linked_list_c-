using System;

namespace LinkedListProject
{
    interface LinkedListInterface<T>
    {
        void addToHead(T data);
        void addToTail(T data);
        void addAtIndex(T data, int index);
        T removeFromHead();
        T removeFromTail();
        T removeAtIndex(int index);
        T get(int index);
        int size();
        void clear();
        bool contains(T data);
    }

    public class LinkedList<T> : LinkedListInterface<T>
    {
        private LLNode<T> head;
        private LLNode<T> tail;
        private int count;

        public LinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void addToHead(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            LLNode<T> newNode = new LLNode<T>(data);
            if (count == 0)
            {
                head = newNode;
                tail = newNode;
                newNode.setNext(null);
                newNode.setPrev(null);
                count++;
            } else if (count == 1)
            {
                newNode.setNext(head);
                newNode.setPrev(null);
                newNode.getNext().setPrev(newNode);
                tail = newNode.getNext();
                head = newNode;
                count++;
            } else
            {
                newNode.setNext(head);
                newNode.setPrev(null);
                newNode.getNext().setPrev(newNode);
                head = newNode;
                count++;
            }
        }

        public void addToTail(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            LLNode<T> newNode = new LLNode<T>(data);
            if (count == 0)
            {
                head = newNode;
                tail = newNode;
                newNode.setNext(null);
                count++;
            } else if (count == 1)
            {
                newNode.setPrev(tail);
                newNode.getPrev().setNext(newNode);
                newNode.setNext(null);
                tail = newNode;
                count++;
            } else
            {
                newNode.setPrev(tail);
                newNode.getPrev().setNext(newNode);
                tail = newNode;
                newNode.setNext(null);
                count++;
            }
        }

        public void addAtIndex(T data, int index)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            } 
            if (index == 0)
            {
                addToHead(data);
            } else if (index == count - 1)
            {
                addToTail(data);
            } else
            {
                LLNode<T> newNode = new LLNode<T>(data);
                int i = 0;
                LLNode<T> current = head;
                while (i < index)
                {
                    current = current.getNext();
                    i++;
                }
                newNode.setNext(current);
                newNode.setPrev(current.getPrev());
                current.setPrev(newNode);
                current.getPrev().setNext(newNode);
                count++;
            }
        }

        public T removeFromHead()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Cannot remove from empty linked list");
            } else if (count == 1)
            {
                T data = head.getData();
                head = null;
                tail = null;
                count = 0;
                return data;
            } else
            {
                T data = head.getData();
                head = head.getNext();
                head.setPrev(null);
                count--;
                return data;
            }
        }

        public T removeFromTail()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            } else if (count == 1)
            {
                T data = tail.getData();
                head = null;
                tail = null;
                count = 0;
                return data;
            } else
            {
                T data = tail.getData();
                tail = tail.getPrev();
                tail.setNext(null);
                count--;
                return data;
            }
        }

        public T removeAtIndex(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new InvalidOperationException();
            }
            if (index == 0)
            {
                return removeFromHead();
            } else if (index == count - 1)
            {
                return removeFromTail();
            } else
            {
                int i = 0;
                LLNode<T> current = head;
                while (i < index)
                {
                    current = current.getNext();
                    i++;
                }
                T data = current.getData();
                current.getPrev().setNext(current.getNext());
                current.getNext().setPrev(current.getPrev());
                count--;
                return data;
            }
        }

        public bool contains(T data)
        {
            LLNode<T> current = head;
            while (current != null)
            {
                if (current.getData().Equals(data))
                {
                    return true;
                }
            }
            return false;
        }

        public T get(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            int i = 0;
            LLNode<T> current = head;
            while (i < index)
            {
                current = current.getNext();
                i++;
            }
            return current.getData();
        }

        public int size()
        {
            return count;
        }

        public void clear()
        {
            head = null;
            count = 0;
        }

        public override string ToString()
        {
            string s = "";
            LLNode<T> current = head;
            while (current != null)
            {
                s += current.getData() + " ";
                current = current.getNext();
            }
            return s;

        }
    }

    public class LLNode<T> {
        private LLNode<T> prev;
        private LLNode<T> next;
        private T data;

        public LLNode(T data) {
            prev = null;
            next = null;
            this.data = data;
        }

        public LLNode<T> getPrev()
        {
            return prev;
        }

        public LLNode<T> getNext()
        {
            return next;
        }

        public void setPrev(LLNode<T> prev)
        {
            this.prev = prev;
        }

        public void setNext(LLNode<T> next)
        {
            this.next = next;
        }
        
        public T getData()
        {
            return data;
        } 

        public void setData(T data)
        {
            this.data = data;
        }
    }
}
