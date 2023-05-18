using System;

namespace DerevoProMaxSuper
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(2);
            tree.Add(4);
            tree.Add(6);

            Console.WriteLine("Breadth-First Traversal:");
            tree.BreadthFirstTraversal();

            Console.ReadLine();
        }
    }
}
