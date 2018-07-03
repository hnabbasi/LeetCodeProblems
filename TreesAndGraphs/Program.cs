using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TreesAndGraphs
{
    class TreeNode
    {
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
            //ClosestPathProblem();
            //VerticalOrderProblem();
            MissingPercentageProblem();
        }

        private static void MissingPercentageProblem()
        {
            var input = new int[10] { 0, 9, 6, 8, 5, 45, 87, 54, 44, 23 };
            Console.WriteLine($"Missing: {ReturnMissingRanges(input)}");
        }

        #region Percent Missing
        // We have a large list of percentages as integers (from 0 to 100). Want a function that describes the missing numbers in the list.
        // The report should be of the form "1-4,9,18-43,95" if the missing numbers were 1, 2, 3, 4, 9, 18, 19, 20, etc. The function should return
        // the description as a string.

        static string ReturnMissingRanges(int[] percents)
        {
            if (percents.Length == 0)
                return string.Empty;

            var retVal = string.Empty;
            Array.Sort(percents);
            var missingQueue = new Queue<int>();

            for (int i = 0; i <= 100; i++)
            {
                if (!percents.Contains(i))
                    missingQueue.Enqueue(i);
            }
            var retString = new StringBuilder();
            var first = -1;
            var last = -1;

            first = missingQueue.Dequeue();
            last = first;
            while (missingQueue.Count > 0)
            {
                if (last + 1 == missingQueue.Peek())
                {
                    last = missingQueue.Dequeue();
                    continue;
                }

                if (last == first)
                {
                    retString.Append(first);
                }
                else
                {
                    retString.Append($"{first}-{last}");
                }
                retString.Append(",");

                first = missingQueue.Dequeue();
                last = first;
            }
            retString.Append($"{first}-{last}");

            return retString.ToString();
        }
        #endregion

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

        static TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            var right = InvertTree(root.right);
            var left = InvertTree(root.left);

            root.left = right;
            root.right = left;
            return root;
        }

        static void PrintTree(TreeNode tree)
        {
            if (tree == null)
                return;

            Console.Write($"{tree.val} ");
            PrintTree(tree.left);
            PrintTree(tree.right);
        }
        #endregion

        #region Find Ladders
        static void FindLaddersProblem()
        {
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

        static IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {

            // Remove beginWord if exists
            if (wordList.Contains(beginWord))
                wordList.Remove(beginWord);

            // Add endWord if doesn't exist
            if (!wordList.Contains(endWord))
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
            var tree2 = new TreeNode(5)
            {
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

        #region DFS Vertical Level Traversal
        static void VerticalOrderProblem()
        {
            var tree = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };
            var output = VerticalOrder(tree);
            Debug.WriteLine("Result:");
            foreach (var item in output)
            {
                foreach (var item2 in item)
                {
                    Debug.Write($"{item2} ");
                }
                Debug.WriteLine("");
            }
        }
        static IList<IList<int>> VerticalOrder(TreeNode root)
        {
            var retVal = new List<IList<int>>();

            if (root == null)
                return retVal;

            var nodeQueue = new Queue<TreeNode>();
            var orderQueue = new Queue<int>();
            var dict = new Dictionary<int, List<int>>();
            var hDistLeft = 0;
            var hDistRight = 0;

            //1. enqu
            nodeQueue.Enqueue(root);
            orderQueue.Enqueue(hDistLeft);

            //2. deq
            while (nodeQueue.Any())
            {
                var currentOrder = orderQueue.Dequeue();
                var node = nodeQueue.Dequeue();
                List<int> currentList;

                if (!dict.TryGetValue(currentOrder, out currentList))
                    currentList = new List<int>();

                currentList.Add(node.val);
                dict[currentOrder] = currentList;

                if(node.left != null) {
                    hDistLeft = Math.Min(hDistLeft, currentOrder - 1);
                    nodeQueue.Enqueue(node.left);
                    orderQueue.Enqueue(currentOrder - 1);
                }

                if(node.right != null) {
                    hDistRight = Math.Max(hDistRight, currentOrder + 1);
                    nodeQueue.Enqueue(node.right);
                    orderQueue.Enqueue(currentOrder + 1);
                }
            }

            for (int i = hDistLeft; i <= hDistRight; i++)
            {
                retVal.Add(dict[i]);
            }

            return retVal;
        }
        #endregion
    }
}
