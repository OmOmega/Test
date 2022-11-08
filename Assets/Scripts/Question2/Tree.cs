using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Question2
{
    public class Node
    {
        public Node LeftNode;
        public Node RightNode;
        public int Data;

        public Node(int data)
        {
            Data = data;
        }
    }

    struct NodeStack
    {
        public Node Node;
        public int Height;

        public NodeStack(Node node, int height)
        {
            Node = node;
            Height = height;
        }
    }
    
    public class Tree
    {
        private Node _root;

        public Tree(int[] preorder, int[] inorder)
        {
            _root = BuildTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }
        
        private Node BuildTree(int[] preorder, int pStart, int pEnd, int[] inorder, int iStart, int iEnd)
        {
            if (pStart > pEnd) return null;
            if (pStart == pEnd) return new Node(preorder[pStart]);

            Node node = new Node(preorder[pStart]);
            int k = iStart;
            // 找到根节点在中序遍历序列中的位置
            while (preorder[pStart] != inorder[k]) k++;
            node.LeftNode = BuildTree(preorder, pStart+1, pStart+k-iStart, inorder, iStart, k-1);
            node.RightNode = BuildTree(preorder, pStart+k-iStart+1, pEnd, inorder, k+1, iEnd);

            return node;

        }
        public void VisitLeftMostNode()
        {
            Dictionary<int, int> leftMostNodeDict = new Dictionary<int, int>();
            Stack<NodeStack> stack = new Stack<NodeStack>();
            leftMostNodeDict.Add(0, _root.Data);
            if(_root.RightNode != null)  
                stack.Push(new NodeStack(_root.RightNode, 1));
            if(_root.LeftNode != null) 
                stack.Push(new NodeStack(_root.LeftNode, 1));

            while (stack.Count != 0)
            {
                NodeStack temp = stack.Pop();

                leftMostNodeDict.TryAdd(temp.Height, temp.Node.Data);
                
                if(temp.Node.RightNode != null)  
                    stack.Push(new NodeStack(temp.Node.RightNode, temp.Height + 1));
                if(temp.Node.LeftNode != null) 
                    stack.Push(new NodeStack(temp.Node.LeftNode, temp.Height + 1));
            }

            foreach (var key in leftMostNodeDict.Keys)
            {
                Debug.Log(leftMostNodeDict[key]);
            }
        }
    }
}

