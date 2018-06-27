using System;
using System.Collections.Generic;

namespace TreesAndGraphs
{
    class TreeNode {
        public int Data;
        public TreeNode Left;
        public TreeNode Right;
        public TreeNode(int data) { Data = data; }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            //FindLaddersProblem();
            InvertTreeProblem();
        }

        #region Invert Tree
        private static void InvertTreeProblem()
        {
            var tree = new TreeNode(4)
            {
                Left = new TreeNode(2)
                {
                    Left = new TreeNode(1),
                    Right = new TreeNode(3)
                },
                Right = new TreeNode(7)
                {
                    Left = new TreeNode(6),
                    Right = new TreeNode(9)
                }
            };

            PrintTree(tree);
            Console.WriteLine("");
            PrintTree(InvertTree(tree));
        }

        static TreeNode InvertTree(TreeNode root) {
            if (root == null)
                return null;

            var right = InvertTree(root.Right);
            var left = InvertTree(root.Left);

            root.Left = right;
            root.Right = left;
            return root;
        }

        static void PrintTree(TreeNode tree) {
            if (tree == null) 
                return;
            
            Console.Write($"{tree.Data} ");
            PrintTree(tree.Left);
            PrintTree(tree.Right);
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

    }
}
