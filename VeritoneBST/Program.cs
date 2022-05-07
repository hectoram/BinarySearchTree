using VeritoneBST.BinaryTrees.BinarySearchTree;
using VeritoneBST.Models;

namespace VeritoneBST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(12);
            binarySearchTree.Add(11);
            binarySearchTree.Add(90);
            binarySearchTree.Add(82);
            binarySearchTree.Add(7);
            binarySearchTree.Add(9);
            var result = binarySearchTree.GetDeepestNodes();

            binarySearchTree.Clear();
            binarySearchTree.Add(26);
            binarySearchTree.Add(82);
            binarySearchTree.Add(16);
            binarySearchTree.Add(92);
            binarySearchTree.Add(33);
            var secondResult = binarySearchTree.GetDeepestNodes();

            var carBinarySearchTree = new BinarySearchTree<Car>();
            carBinarySearchTree.Add(new Car { Year = 1972, Model = "Ford" });
            carBinarySearchTree.Add(new Car { Year = 1962, Model = "Jeep" });
            carBinarySearchTree.Add(new Car { Year = 1992, Model = "Honda" });
            var carResults = carBinarySearchTree.GetDeepestNodes();

            Console.WriteLine(carResults);
            Console.WriteLine(result);
            Console.WriteLine(secondResult);
        }
    }
}
