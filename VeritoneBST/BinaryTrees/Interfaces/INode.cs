namespace VeritoneBST.BinaryTrees.Interfaces
{
    public interface INode<T> where T : IComparable
    {
        public T Data { get; set; }
        public INode<T> Parent { get; set; }
        public INode<T> LeftNode { get; set; }
        public INode<T> RightNode { get; set; }
    }
}
