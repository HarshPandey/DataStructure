using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class TestLinkedList
    {
        public class Node
        {
            public int Data;
            public Node Next;
        }

        public static Node headGlobal;
        private static bool MakeIntersection;
        private static Node v_TempNode;

        //Problem 1 Swap nodes in a linked list without swapping data
        //Given a linked list and two keys in it, swap nodes for two given keys. Nodes should be swapped by changing links. Swapping data of nodes may be expensive in many situations when data contains many fields.
        //It may be assumed that all keys in linked list are distinct.

        public static void TestLinkedListFunctions()
        {
            Console.WriteLine("Test LinkedListFunctions");
            Node head = null;
            head = Insert(head, 2);
            PrintList(head);

            head = Insert(head, 3);
            PrintList(head);

            head = Insert(head, 4);
            PrintList(head);

            head = Insert(head, 6);
            PrintList(head);

            head = Insert(head, 1, 1);
            PrintList(head);

            head = Insert(head, 5, 5);
            PrintList(head);

            head = Insert(head, 7, 7);
            PrintList(head);

            head = Delete(head, 5);
            PrintList(head);

            head = Delete(head, 1);
            PrintList(head);

            Console.Write(Environment.NewLine);
            Console.WriteLine("Reverse Iteratively :");
            head = Reverse(head);
            PrintList(head);

            Console.Write(Environment.NewLine);
            Console.WriteLine("Print Recursively :");
            PrintListRecursively(head);

            Console.Write(Environment.NewLine);
            Console.WriteLine("Print Recursively Reverse :");
            PrintListReverse(head);

            Console.Write(Environment.NewLine);
            Console.WriteLine("Reverse Recursively :");
            headGlobal = head;
            ReverseRecursively(headGlobal);
            PrintList(headGlobal);

            int length = FindLength(headGlobal);
            Console.WriteLine("Length of list :"+length);

            TestFindMergePointOfLinkedList();
        }

        static void TestFindMergePointOfLinkedList()
        {
            Console.WriteLine("Test FindMergePointOfLinkedList");
            Node head1 = null;
            head1 = Insert(head1, 2);
            head1 = Insert(head1, 3);
            head1 = Insert(head1, 4);
            MakeIntersection = true;
            head1 = Insert(head1, 6);
            MakeIntersection = false;
            head1 = Insert(head1, 1, 1);
            head1 = Insert(head1, 5, 5);
            head1 = Insert(head1, 7, 7);
            head1 = Insert(head1, 20);
            head1 = Insert(head1, 30);
            head1 = Insert(head1, 50);
            PrintList(head1);


            Node head2 = null;
            head2 = Insert(head2, 8);
            head2 = Insert(head2, 14);
            head2 = Insert(head2, 11);
            head2 = Insert(head2, 12);
            head2 = Insert(head2, 15);
            head2 = Insert(head2, 18);
            head2 = Insert(head2, 9);
            head2 = Insert(head2, 10);
            head2 = Insert(head2, -1);
            PrintList(head2);

            Node node = FindMergePoint(ref head1, ref head2);
            if (node == null) {
                Console.WriteLine("There is no intersection node");
                return;
            }
            Console.WriteLine("Print the merge node data :"+ node.Data);
        }

        static void SetNewNode(Node node)
        {
            v_TempNode = node;
        }

        static Node Insert(Node head, int data)
        {
            Node node = new Node();
            node.Data = data;
            node.Next = null;

            // Ignore the below region its for specific use-case
            #region Creating a intersection node

            if (data == -1) {
                node = v_TempNode;
            }

            if (MakeIntersection) {
                SetNewNode(node);
            }

            #endregion

            if (head != null) {
                Node temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = node;
                return head;
            }
            head = node;
            return head;
        }

        static Node Insert(Node head, int data, int position)
        {
            Node node = new Node();
            node.Data = data;
            node.Next = null;

            if(position == 1){
                node.Next = head;
                head = node;
                return head;
            }
            else {
                Node temp = head;
                for (int i = 0; i < position -2; i++)
                {
                    temp = temp.Next; // To reach at n-1 position
                }
                node.Next = temp.Next;
                temp.Next = node;
                return head;
            }

        }

        static Node Delete(Node head, int position) 
        {
            if(position == 1){
                Node firstNode = head;
                head = firstNode.Next;
                firstNode = null;
                return head;
            }

            Node temp = head;
            for (int i = 0; i < position - 2; i++) 
            {
                temp = temp.Next;
            }
            // Fix the link.
            Node nodeToDelete = temp.Next;
            temp.Next = nodeToDelete.Next;

            // Delete the node
            nodeToDelete = null; // It let the GC know that I dont need this.

            return head;
        }

        static Node Reverse(Node head){

            Node current = head;
            Node nextNode = null;
            Node prevNode = null;

            while(current != null)
            {
                nextNode = current.Next;
                current.Next = prevNode;
                prevNode = current;
                current = nextNode;
            }
            head = prevNode;
            return head;
        }

        static void ReverseRecursively(Node temp){
            if(temp.Next == null)
            {
                headGlobal = temp;
                return;
            }
            ReverseRecursively(temp.Next);
            temp.Next.Next = temp;
            temp.Next = null;
        }

        static void PrintList(Node head)
        {
            Console.WriteLine("List is : ");
            Node temp = head;
            while (temp != null){
                Console.Write(temp.Data+ " ");
                temp = temp.Next;
            }
            Console.Write(Environment.NewLine);
        }

        static void PrintListRecursively(Node head)
        {
            if(head == null){
                return;
            }
            Console.Write(head.Data + " ");
            PrintListRecursively(head.Next);
        }

        static void PrintListReverse(Node head)
        {
            if (head == null)
            {
                return;
            }
            PrintListReverse(head.Next);
            Console.Write(head.Data + " ");
        }

        // TODO test it
        static bool CheckIfLinkedListHasLoop(Node head)
        {
            Node tempNode = head;
            Node tempNode1 = head.Next;
            while (tempNode != null && tempNode1 != null) {
                if (tempNode.Equals(tempNode1)) {
                    return true;
                }

                if ((tempNode1.Next != null) && (tempNode.Next != null)) {
                    tempNode1 = tempNode1.Next.Next;
                    tempNode = tempNode.Next;
                }
                else {
                    return false;
                }
            }
            return false;
        }

        // TODO test it
        // Multiply contents of two linked lists
        static long MultiplyTwoLists(Node first, Node second)
        {
            int num1 = 0, num2 = 0;

            // Generate numbers from linked lists
            while (first != null || second != null) {
                if (first != null) {
                    num1 = num1 * 10 + first.Data;
                    first = first.Next;
                }
                if (second != null) {
                    num2 = num2 * 10 + second.Data;
                    second = second.Next;
                }
            }
            // Return multiplication of 
            // two numbers
            return num1 * num2;
        }

        static int FindLength(Node head)
        {
            int count = 0;
            if (head == null) {
                return count;
            }
            while (head != null) {
                ++count;
                head = head.Next;
            }
            return count;
        }

        static Node FindMergePoint(ref Node nodeA, ref Node nodeB)
        {
            int n = FindLength(nodeA);
            int m = FindLength(nodeB);

            int diff = n - m;
            if (m > n) {
                diff = m - n;
                Node temp = nodeA;
                nodeA = nodeB;
                nodeB = temp;
            }

            for (int i = 0; i < diff; i++) {
                nodeA = nodeA.Next;
            }

            while (nodeA != null && nodeB != null) {
                if (nodeA == nodeB) {
                    return nodeA;
                }
                nodeA = nodeA.Next;
                nodeB = nodeB.Next;
            }
            return null;
        }

        // Reverse the linked list in group e.g 1234 , 2 => 2143
        //public static Node reverse(Node node, int k)
        //{
        //Node curr = node, prev = null, next = null;
        //int count = 0;
        //    while (curr != null && count<k)
        //    {
        //        next = curr.next;
        //        curr.next = prev;
        //        prev = curr;
        //        curr = next;
        //        count++;
        //    }

        //    if (next != null)
        //        node.next = reverse(next, k);
        //    return prev;
        //}

        //
        public void rotate(Node head, int k)
        {
            // Below code is written by Harsh in Java on GFG while practice there so need to covert it into C#
            //Queue<Integer> q = new LinkedList<Integer>();
            //int move = k;
            //Node temp = head;

            //if (k == 0)
            //{
            //    PrintList(head);
            //    return;
            //}

            //while (move > 0)
            //{
            //    q.offer(temp.data);
            //    temp = temp.next;
            //    --move;
            //}
            //head = temp;
            //int completeRotation = 0; ;
            //if (temp == null)
            //{
            //    // that means we have consumed all the nodes in the list
            //    completeRotation = 1;
            //}
            //else
            //{
            //    // traverse the head to end node
            //    while (temp.next != null)
            //    {
            //        temp = temp.next;
            //    }
            //}
            //move = k;
            //while (move > 0)
            //{
            //    if (completeRotation == 1)
            //    {
            //        temp = new Node(q.remove()); // this line be executed exactly once
            //        head = temp;
            //        completeRotation = 0; //reset the flag
            //    }
            //    else
            //    {
            //        temp.next = new Node(q.remove());
            //        temp = temp.next;
            //    }
            //    --move;
            //}
            //PrintList(head);
        }

        int removeTheLoop(Node node)
        {
            Node temp = node;
            if (temp == null)
            {
                return 0; // head is null
            }
            if (temp != null && temp.Next == null)
            {
                return 0; // beacuse there is just one node
            }
            if (temp.Next.Next == node)
            {
                return 1; // there are just two node and they are linked to each other
            }

            Node fastNode = node;
            Node slowNode = node;
            Node prevFastNode = null;

            while (fastNode != null && fastNode.Next != null)
            {
                prevFastNode = fastNode;
                fastNode = fastNode.Next.Next;
                slowNode = slowNode.Next;
                if (fastNode == slowNode)
                {
                    prevFastNode.Next.Next = null;
                    return 1;
                }
            }
            return 0;
        }

        //static void GetMinimumNodeInLinkedList()
        //{
        //    LinkedListNode<Class1> minNode = null;
        //    LinkedListNode<Class1> current = list.First;
        //    while (current != null)
        //    {
        //        if ((minNode == null) || (current.Value.Process < minNode.Value.Process))
        //        {
        //            minNode = current;
        //        }
        //        current = current.Next;
        //    }
        //}


        // Problem was to remove nodes recursively which are leasser value than their next right node
        //  if that so remove the lower value node from linked list and repeat it until linkedlist have all the value sorted in reverse order.
        //        Input:
        //3
        //8
        //12 15 10 11 5 6 2 3
        //6
        //10 20 30 40 50 60
        //6
        //60 50 40 30 20 10

        //Output:

        //15 11 6 3
        //60
        //60 50 40 30 20 10

        //boolean checkReverseSorted(LinkedList l)
        //{
        //    Node current = l.head;
        //    while (current.next != null)
        //    {
        //        if (current.data < current.next.data)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            current = current.next;
        //        }
        //    }
        //    return true;
        //}

        //void compute(LinkedList l)
        //{
        //    if (checkReverseSorted(l))
        //    {
        //        return;
        //    }
        //    UpdateList(l);
        //    compute(l);
        //}

        //void UpdateList(LinkedList l)
        //{

        //    Node prev = null;
        //    Node current = l.head;

        //    if (current == null)
        //    {
        //        return;
        //    }
        //    while (current.next != null)
        //    {
        //        if (current.data < current.next.data)
        //        {
        //            if (prev != null)
        //            {
        //                prev.next = current.next;
        //            }
        //            if (prev == null)
        //            {
        //                l.head = current.next;
        //                current = l.head;
        //                continue;
        //            }
        //            else
        //            {
        //                current = prev;
        //            }
        //        }
        //        prev = current;
        //        if (current.next != null)
        //        {
        //            current = current.next;
        //        }
        //    }
        //}
    }
}
