using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumDepthОfBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node6 = new Node(6);
            var node7 = new Node(7);
            var node8 = new Node(8);

            root.Left = node2;
            root.Right = node3;
            node2.Left = node4;
            node2.Right = node5;
            node3.Right = node5;
            node4.Right = node8;

            var minDepth = GetTreeMinDepth(root);
            Console.WriteLine(minDepth);
            Console.ReadKey();
        }

        private static int GetTreeMinDepth(Node root)
        {
            var minDepth = int.MaxValue;
            var currentDepth = 1;
            GetTreeMinDepthRec(root, currentDepth, ref minDepth);
            return minDepth;
        }

        private static void GetTreeMinDepthRec(Node node, int currentDepth, ref int minDepth)
        {
            // leaf
            if (node.Left == null && node.Right == null)
            {
                if(minDepth > currentDepth)
                {
                    minDepth = currentDepth;
                }

                return;
            }

            if (node.Left != null)
            {
                GetTreeMinDepthRec(node.Left, currentDepth + 1, ref minDepth);
            }
            if (node.Right != null)
            {
                GetTreeMinDepthRec(node.Right, currentDepth + 1, ref minDepth);
            }
        }

        class Node
        {
            public Node(int value)
            {
                this.Value = value;
            }

            public int Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }
        }
    }
}
