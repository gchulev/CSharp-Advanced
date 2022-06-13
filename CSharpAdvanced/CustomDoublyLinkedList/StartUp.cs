using System;

namespace CustomDoublyLinkedList
{
    internal class StartUp
    {
        static void Main()
        {
            DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>();
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddLast(4);

            var listArray = linkedList.ToArray();

            Console.WriteLine($"Head -> {linkedList.Head.Value}");
            Console.WriteLine($"Tail -> {linkedList.Tail.Value}");

            Console.WriteLine($"Head NextNode: {linkedList.Head.NextNode.Value}");
            Console.WriteLine($"Tail PreviousNode: {linkedList.Tail.PreviousNode.Value}");
        }
    }
}
