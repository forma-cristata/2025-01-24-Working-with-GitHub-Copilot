namespace AVLTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestAVLTree();
        }

        static void TestAVLTree()
        {
            AVLTree<int> avlTree = new AVLTree<int>();

            // Adding elements
            avlTree.Insert(10);
            Console.WriteLine("Inserted 10");
            Console.WriteLine("In-order traversal after insert:");
            avlTree.PrintInOrder();
            Console.WriteLine("------------------------------");

            avlTree.Insert(20);
            Console.WriteLine("Inserted 20");
            Console.WriteLine("In-order traversal after insert:");
            avlTree.PrintInOrder();
            Console.WriteLine("------------------------------");

            avlTree.Insert(30);
            Console.WriteLine("Inserted 30");
            Console.WriteLine("In-order traversal after insert:");
            avlTree.PrintInOrder();
            Console.WriteLine("------------------------------");

            avlTree.Insert(40);
            Console.WriteLine("Inserted 40");
            Console.WriteLine("In-order traversal after insert:");
            avlTree.PrintInOrder();
            Console.WriteLine("------------------------------");

            avlTree.Insert(50);
            Console.WriteLine("Inserted 50");
            Console.WriteLine("In-order traversal after insert:");
            avlTree.PrintInOrder();
            Console.WriteLine("------------------------------");

            avlTree.Insert(25);
            Console.WriteLine("Inserted 25");
            Console.WriteLine("In-order traversal after insert:");
            avlTree.PrintInOrder();
            Console.WriteLine("------------------------------");

            // Removing elements
            avlTree.Remove(40);
            Console.WriteLine("Removed 40");
            Console.WriteLine("In-order traversal after removal:");
            avlTree.PrintInOrder();
            Console.WriteLine("------------------------------");

            avlTree.Remove(50);
            Console.WriteLine("Removed 50");
            Console.WriteLine("In-order traversal after removal:");
            avlTree.PrintInOrder();
            Console.WriteLine("------------------------------");
        }
    }
}
