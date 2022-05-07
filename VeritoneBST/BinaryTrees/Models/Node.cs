using VeritoneBST.BinaryTrees.Interfaces;

namespace VeritoneBST.BinaryTrees.Models
{
    public class Node<T> : INode<T> where T : IComparable
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Node()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Node(T data)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Data = data;    
        }

        public T Data { get; set; }
        public INode<T> Parent { get; set; }
        public INode<T> LeftNode { get; set; }
        public INode<T> RightNode { get; set; }
    }
}
