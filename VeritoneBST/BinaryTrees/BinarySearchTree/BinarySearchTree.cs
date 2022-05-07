using System.Text;
using VeritoneBST.BinaryTrees.Interfaces;
using VeritoneBST.BinaryTrees.Models;

namespace VeritoneBST.BinaryTrees.BinarySearchTree
{
    public class BinarySearchTree<T> : ITree<T>, IBinarySearchTree<T> where T : IComparable
    {
        private INode<T> _root;

        public BinarySearchTree()
        {
            //Empty Constructor 
        }

        public BinarySearchTree(T[] values)
        {
            ConstructTree(values);
        }

        public void Add(T item)
        {
            if (_root == null)
                _root = new Node<T>(item);
            else
                InsertIntoTree(_root, item);
        }

        public void Remove(T item)
        {
            RemoveFromTree(_root, item);
        }

        public void Clear()
        {
            _root = null;
        }

        public INode<T> Find(T item)
        {
            return FindNode(item, _root);
        }

        public INode<T> FindMaxNode()
        {
            return FindMaxNode(_root);
        }

        public INode<T> FindMinNode()
        {
            return FindMinNode(_root);
        }

        public string GetDeepestNodes()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("deepest,");

            var result = FindDeepestNodes(0, _root);

            foreach (var node in result.Nodes)
            {
                stringBuilder.Append($" {node.Data},");
            }

            //Remove extra comma at end
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append($"; depth, {result.Level}");

            return stringBuilder.ToString();
        }

        private void InsertIntoTree(INode<T> node, T item)
        {
            if (node == null)
                return;

            var shouldInsertRightSide = IsGreaterThanEqualTo(node.Data, item);

            if (shouldInsertRightSide && node.RightNode == null)
            {
                node.RightNode = new Node<T> { Data = item, Parent = node };
                return;
            }
            else if (IsLessThan(node.Data, item) && node.LeftNode == null)
            {
                node.LeftNode = new Node<T> { Data = item, Parent = node };
                return;
            }

            if (shouldInsertRightSide)
                InsertIntoTree(node.RightNode, item);
            else
                InsertIntoTree(node.LeftNode, item);

        }

        private void RemoveFromTree(INode<T> node, T item)
        {
            if (node == null)
                return;

            var nodeMatches = node.Data.CompareTo(item) == 0;
            var leftNodeIsNull = node.LeftNode == null;
            var rightNodeIsNull = node.RightNode == null;

            // No Children
            if (nodeMatches && (leftNodeIsNull && rightNodeIsNull))
            {
                if (AreEqual(node.Parent.LeftNode.Data, item))
                    node.Parent.LeftNode = null;
                else
                    node.Parent.RightNode = null;

                return;
            }

            // One Child
            if (nodeMatches && (!rightNodeIsNull && leftNodeIsNull))
            {
                node.Parent.LeftNode = node.RightNode;
                node.Parent.LeftNode.Parent = node.Parent;
                return;
            }
            else if (nodeMatches && (rightNodeIsNull && !leftNodeIsNull))
            {
                node.Parent.RightNode = node.LeftNode;
                node.Parent.RightNode.Parent = node.Parent;
                return;
            }

            //Two Children
            if (nodeMatches && (!rightNodeIsNull && !leftNodeIsNull))
            {
                var temp = FindMinNode(node.RightNode);

                Remove(temp.Data);
                node.Data = temp.Data;
                return;
            }

            var shouldBranchRight = IsGreaterThanEqualTo(node.Data, item);

            if (shouldBranchRight)
                RemoveFromTree(node.RightNode, item);
            else
                RemoveFromTree(node.LeftNode, item);
        }

        private INode<T> FindNode(T item, INode<T> node)
        {
            if(node == null)
                return null;

            if(AreEqual(node.Data, item))
                return node;

            if(IsGreaterThanEqualTo(node.Data, item))
                return FindNode(item, node.RightNode);
            else
                return FindNode(item, node.LeftNode);
        }

        private DeepestNodesResult<T> FindDeepestNodes(int currentLevel, INode<T> node)
        {
            if (node == null)
                return new DeepestNodesResult<T> { Level = currentLevel, Nodes = new List<INode<T>> { } };

            var leftSideDeepestNodes = FindDeepestNodes(currentLevel + 1, node.LeftNode);
            var rightSideDeepestNodes = FindDeepestNodes(currentLevel + 1, node.RightNode);

            //Leaf node found
            if (node.LeftNode == null && node.RightNode == null)
                return new DeepestNodesResult<T> { Level = currentLevel, Nodes = new List<INode<T>> { node } };

            if (leftSideDeepestNodes?.Level == rightSideDeepestNodes?.Level)
            {
                //Account for both sides being same level
                leftSideDeepestNodes.Nodes.AddRange(rightSideDeepestNodes.Nodes);
                return leftSideDeepestNodes;
            }
            else if (leftSideDeepestNodes?.Level > rightSideDeepestNodes?.Level)
            {
                return leftSideDeepestNodes;
            }
            else
            {
                return rightSideDeepestNodes;
            }
        }

        private INode<T> FindMinNode(INode<T> node)
        {
            if (node == null)
                return null;

            var current = node;

            while (current.LeftNode != null)
                current = current.LeftNode;

            return current;
        }

        private INode<T> FindMaxNode(INode<T> node)
        {
            if (node == null)
                return null;

            var current = node;

            while (current.RightNode != null)
                current = current.RightNode;

            return current;

        }

        private void ConstructTree(T[] values)
        {
            if (values.Length == 0)
                return;

            foreach (var value in values)
            {
                Add(value);
            }
        }

        private bool AreEqual(T first, T second)
        {
            return first.CompareTo(second) == 0;
        }

        private bool IsGreaterThanEqualTo(T first, T second)
        {
            return first.CompareTo(second) <= 0;
        }

        private bool IsLessThan(T first, T second)
        {
            return first.CompareTo(second) > 0;
        }
    }
}