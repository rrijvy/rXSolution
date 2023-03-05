// ReSharper disable All
#pragma warning disable CS8625
namespace ReverseLinkedList
{
    using System;

    public class ReverseLinkedListRecursive
    {

        public class Node
        {
            public Node(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }

            public int data;
            public Node next;


        }

        class LinkedList
        {
            public Node head;
            private Node tail;

            public LinkedList()
            {
                this.head = null;
            }

            public void InsertNode(int nodeData)
            {
                Node node = new Node(nodeData);
                if (this.head == null)
                {
                    this.head = this.tail = node;
                }
                this.tail.next = node;
                this.tail = node;
            }
        }

        public static void PrintSinglyLinkedList(Node node, string sep)
        {
            while (node != null)
            {
                Console.Write(node.data + sep);
                node = node.next;
            }
        }

        public static Node Reverse(Node head)
        {
            if (head == null) return head;

            var previous = head;
            var current = previous.next;
            previous.next = null;
            while (current != null)
            {
                var next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }
            return previous;
        }

        public static Node RecursivelyReverse(Node head)
        {
            if (head == null) return head;

            if (head.next == null) return head;

            var newHead = RecursivelyReverse(head.next);

            head.next.next = head;
            head.next = null;

            return newHead;
        }

        public static Node ReverseBetween(Node head, int left, int right)
        {
            if (head == null) return head;

            Node leftNode = null;
            Node rightNode = null;
            var tempHead = head;
            Node tempNode = null;
            while (tempHead != null)
            {
                if (tempHead.data == left) leftNode = tempHead;
                if (tempHead.data == right) rightNode = tempHead;
                tempHead = tempHead.next;
            }

            if (leftNode != null && rightNode != null)
            {
                tempNode = leftNode.next;
                leftNode.next = rightNode.next;
                rightNode.next = tempNode;
            }
            return head;
        }


        public static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            list.InsertNode(20);
            list.InsertNode(21);
            list.InsertNode(22);
            list.InsertNode(23);
            list.InsertNode(24);
            list.InsertNode(25);
            list.InsertNode(26);

            Console.WriteLine("Given linked list:");

            PrintSinglyLinkedList(list.head, " ");

            Console.WriteLine("");
            Console.WriteLine("Reversed Linked list:");

            //var listReverse = Reverse(list.head);

            //var listReverse = RecursivelyReverse(list.head);

            //PrintSinglyLinkedList(listReverse, " ");

            var rverseBetween = ReverseBetween(list.head, 23, 26);

            PrintSinglyLinkedList(rverseBetween, " ");

        }
    }
}