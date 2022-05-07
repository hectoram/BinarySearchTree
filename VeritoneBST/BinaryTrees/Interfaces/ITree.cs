namespace VeritoneBST.BinaryTrees.Interfaces
{
    public interface ITree<T> where T : IComparable
    {
        public void Add(T item);
        public void Remove(T item);
        public void Clear();
        public INode<T> Find(T item);
    }
}
