using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TreesAndGraphs
{
    class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int data) { val = data; }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            //FindLaddersProblem();
            //InvertTreeProblem();
            //ValidateBSTProblem();
            ClosestPathProblem();
        }

        #region Invert Tree
        private static void InvertTreeProblem()
        {
            var tree = new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(7)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(9)
                }
            };

            PrintTree(tree);
            Console.WriteLine("");
            PrintTree(InvertTree(tree));
        }

        static TreeNode InvertTree(TreeNode root) {
            if (root == null)
                return null;

            var right = InvertTree(root.right);
            var left = InvertTree(root.left);

            root.left = right;
            root.right = left;
            return root;
        }

        static void PrintTree(TreeNode tree) {
            if (tree == null) 
                return;
            
            Console.Write($"{tree.val} ");
            PrintTree(tree.left);
            PrintTree(tree.right);
        }
        #endregion

        #region Find Ladders
        static void FindLaddersProblem() {
            var input = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };
            Console.WriteLine($"Result:");

            var result = FindLadders("hit", "cog", input);

            foreach (var item in result)
            {
                foreach (var item2 in item)
                {
                    Console.Write($"{item2} -> ");
                }
                Console.WriteLine("");
            }
        }

        static IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {

            // Remove beginWord if exists
            if(wordList.Contains(beginWord))
                wordList.Remove(beginWord);

            // Add endWord if doesn't exist
            if(!wordList.Contains(endWord))
                wordList.Add(endWord);

            // Initialize ladder with beginWord as key
            var laddersDict = new Dictionary<string, List<List<string>>>
            {
                { beginWord, new List<List<string>> { new List<string> { beginWord } } }
            };

            // Initialize To Visit queue
            var toVisitQueue = new Queue<string>();
            toVisitQueue.Enqueue(beginWord);

            while (toVisitQueue.Count > 0)
            {
            }

            return new List<IList<string>> { (System.Collections.Generic.List<string>)wordList };
        }
        #endregion

        #region Validate BST

        static void ValidateBSTProblem()
        {
            var tree = new TreeNode(2) { left = new TreeNode(1), right = new TreeNode(3) };
            var tree2 = new TreeNode(5) {
                left = new TreeNode(1),
                right = new TreeNode(4)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(6)
                }
            };

            Console.WriteLine($"2->1->3 Is valid: {IsValidBST(tree)}");
            Console.WriteLine($"5->1->4->3->6 Is valid: {IsValidBST(tree2)}");
            Console.Read();
        }

        static bool IsValidBST(TreeNode root)
        {
            return IsValidBSTInner(root, null, null);
        }

        static bool IsValidBSTInner(TreeNode root, int? least, int? most)
        {
            if (root == null)
                return true;

            if (least.HasValue && root.val < least || most.HasValue && root.val > most)
                return false;
            
            return IsValidBSTInner(root.left, least, root.val) && IsValidBSTInner(root.right, root.val, most);
        }
        #endregion

        #region Shortest Path
        static void ClosestPathProblem()
        {
            var tree = new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(5)
            };

            Console.WriteLine($"Result: {ClosestPath(tree, 3.714286)}");
            Console.ReadKey();
        }
        static int ClosestPath(TreeNode root, double target)
        {
            var retVal = root.val;

            if (root.val == target)
            {
                return retVal;
            }

            while (root != null)
            {
                if (Math.Abs(target - root.val) < Math.Abs(target - retVal))
                {
                    retVal = root.val;
                }

                root = root.val > target ? root.left : root.right;
            }
            return retVal;
        }
        #endregion
    }
}
