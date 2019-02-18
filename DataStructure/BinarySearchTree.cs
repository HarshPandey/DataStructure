using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class BinarySearchTree
    {
        public class Node
        {
            public Node Left;
            public int Data;
            public Node Right;
        }

        public static Node GetNode(int data){
            Node temp = new Node();
            temp.Left = null;
            temp.Data = data;
            temp.Right = null;
            return temp;
        }

        static Node Root;

        public static void TestBinarySearchTree()
        {
            Console.WriteLine("BinarySearchTree Test");
            Root = null;

            Insert(ref Root, 15);
            Insert(ref Root, 10);
            Insert(ref Root, 20);
            Insert(ref Root, 25);
            Insert(ref Root, 8);
            Insert(ref Root, 12);

            Console.WriteLine("Search Result : "+ Search(ref Root, 20));
        }

        public static Node Insert(ref Node root, int data)
        {
            Node node = GetNode(data);
            if(root == null){
                root = node; // adding some data at root.
            }
            else if(data <= root.Data) {
                root.Left = Insert(ref root.Left, data);
            }
            else if(data > root.Data){
                root.Right = Insert(ref root.Right, data);
            }
            return root;
        }

        static bool Search(ref Node root, int data)
        {
            if (root == null)
                return false;
            else if (root.Data == data)
                return true;
            else if (data <= root.Data)
                return Search(ref root.Left, data);
            else {
                return Search(ref root.Right, data);
            }
        }

        static int FindTheHeightOfBST(Node root)
        {
            // Write your code here.
            if (root == null)
            {
                return -1;
            }

            int leftLength = FindTheHeightOfBST(root.Left);
            int rightLength = FindTheHeightOfBST(root.Right);

            if (leftLength > rightLength)
            {
                return leftLength + 1;
            }
            return rightLength + 1;
        }

        static void LevelOrderOfBSt(Node root)
        {
            if (root == null)
            {
                return;
            }

            // Create an empty queue for level order traversal
            Stack<Node> q = new Stack<Node>();

            // Enqueue Root and initialize height
            q.Push(root);

            while (q.Count == 0)
            {
                // Print front of queue and remove it from queue
                Node n = q.Peek();
                Console.Write(n.Data + " ");
                q.Pop();

                /* Enqueue left child */
                if (n.Left != null)
                    q.Push(n.Left);

                /*Enqueue right child */
                if (n.Right != null)
                    q.Push(n.Right);
            }
        }

        // Code works but written in java while practising on GFG
        //void mirror(Node node)
        //{
        //    if (node == null)
        //    {
        //        return;
        //    }
        //    mirror(node.left);
        //    mirror(node.right);
        //    Node temp = node.left;
        //    node.left = node.right;
        //    node.right = temp;
        //}

        // It prints the node who does not have sibling
        // Code works but written in java while practising on GFG
        //void printNodes(Node node)
        //{
        //    if (node == null)
        //    {
        //        return;
        //    }
        //    else if (node.left == null && node.right == null)
        //    {
        //        return;
        //    }
        //    else if (node.left != null && node.right == null)
        //    {
        //        linkedlist.add(node.left.data);
        //        //System.out.print(node.left.data + " ");
        //    }
        //    else if (node.left == null && node.right != null)
        //    {
        //        linkedlist.add(node.right.data);
        //        //System.out.print(node.right.data + " ");
        //    }
        //    printNodes(node.left);
        //    printNodes(node.right);
        //}



        //static bool isBST(Node node)
        //{
        //    /* Returns true if a binary tree is a binary search tree */
        //    if (node == null)
        //    {
        //        return true;
        //    }

        //    /* false if the max of the left is > than us */
        //    if (node.left != null && maxValue(node->left) > node->data)
        //        return (false);

        //    /* false if the min of the right is <= than us */
        //    if (node->right != NULL && minValue(node->right) < node->data)
        //        return (false);

        //    /* false if, recursively, the left or right is not a BST */
        //    if (!isBST(node->left) || !isBST(node->right))
        //        return (false);

        //    /* passing all that, it's a BST */
        //    return (true);
        //}

        static bool IsValidBST(Node root)
        {
            long previous = long.MinValue;

            if (root != null)
            {
                if (!IsValidBST(root.Left))
                {
                    return false;
                }
                if (root.Data <= previous)
                {
                    return false;
                }

                previous = root.Data;

                return IsValidBST(root.Right);
            }
            return true;
        }

        static bool IsBST(Node rootNode)
        {
            return IsBSTRecursion(rootNode, long.MinValue, long.MaxValue);
        }

        static bool IsBSTRecursion(Node rootNode, long min, long max)
        {
            if (rootNode == null)
            {
                return true;
            }
            
            if (rootNode.Data <= min || rootNode.Data >= max)
            {
                return false;
            }

            return IsBSTRecursion(rootNode.Left, min, rootNode.Data) &&
                   IsBSTRecursion(rootNode.Right, rootNode.Data, max);
        }
    }
}