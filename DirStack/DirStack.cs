using System.Collections.Generic;
using System.Linq;

namespace DirStack
{
    public class DirStack
    {
        private readonly LinkedList<string> list = new LinkedList<string>();
        private readonly Dictionary<string, LinkedListNode<string>> dict = new Dictionary<string, LinkedListNode<string>>();
        private readonly int maxSize;
        private bool dirty = true;
        private string[] array;
        public DirStack(int maxSize)
        {
            this.maxSize = maxSize;
        }
        public void Add(string dir)
        {
            dirty = true;
            if (dict.TryGetValue(dir, out var node))
            {
                list.Remove(node);
                list.AddFirst(node);
            }
            else
            {
                dict.Add(dir, list.AddFirst(dir));
            }
            if (list.Count > maxSize)
            {
                string last = list.Last();
                list.RemoveLast();
                dict.Remove(last);
            }
        }

        public int Count => list.Count();
        public string[] GetList(int n)
        {
            if (dirty)
            {
                array = list.Take(n).ToArray();
                dirty = false;
            }
            return array;
        }
    }
}
