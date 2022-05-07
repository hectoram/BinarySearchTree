namespace VeritoneBST.BinaryTrees.Interfaces
{
    public interface IBinarySearchTree<T> where T : IComparable
    {
        public string GetDeepestNodes();

        public INode<T> FindMinNode();

        public INode<T> FindMaxNode();
    }
}
