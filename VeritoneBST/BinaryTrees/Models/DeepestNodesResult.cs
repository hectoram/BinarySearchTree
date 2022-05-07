using VeritoneBST.BinaryTrees.Interfaces;

namespace VeritoneBST.BinaryTrees.Models
{
    internal class DeepestNodesResult<T> where T : IComparable
    {
        public int Level { get; set; }
        public List<INode<T>> Nodes { get; set; }
    }
}
