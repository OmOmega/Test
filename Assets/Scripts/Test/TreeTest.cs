using System;
using UnityEngine;

namespace Test
{
    public class TreeTest : MonoBehaviour
    {
        public int[] preorder = new int[] { 2, 11, 10, 15, 23, 7, 12, 13, 14 };
        public int[] inorder = new int[] { 10, 11, 15, 2, 7, 13, 12, 23, 14 };
        private Question2.Tree _tree;

        private void Awake()
        {
            _tree = new Question2.Tree(preorder, inorder);
        }

        public void Start()
        {
            _tree.VisitLeftMostNode();
        }
    }
}