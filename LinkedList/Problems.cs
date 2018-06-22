using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList
{
    public static class Problems
    {
        #region Add Two Numbers
        /// <summary>
        /// You are given two non-empty linked lists representing two non-negative integers. 
        /// The digits are stored in reverse order and each of their nodes contain a single digit. 
        /// Add the two numbers and return it as a linked list.
        /// 
        /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        /// 
        /// Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        /// Output: 7 -> 0 -> 8
        /// Explanation: 342 + 465 = 807.
        /// </summary>
        /// <returns>The calculated list</returns>
        /// <param name="l1">List 1</param>
        /// <param name="l2">List 2</param>
        public static void AddTwoNumbersProblem()
        {
            var list1 = new ListNode(2) { next = new ListNode(4) { next = new ListNode(3) } };
            var list2 = new ListNode(5) { next = new ListNode(6) { next = new ListNode(4) } };
            CrudOps.PrintList(AddTwoNumbers(list1, list2, 0));

            list1 = new ListNode(6) { next = new ListNode(4) { next = new ListNode(7) } };
            list2 = new ListNode(5) { next = new ListNode(6) { next = new ListNode(4) } };
            CrudOps.PrintList(AddTwoNumbers(list1, list2, 0));

            list1 = new ListNode(3) { next = new ListNode(4) { next = new ListNode(2) { next = new ListNode(7) } } };
            list2 = new ListNode(4) { next = new ListNode(6) { next = new ListNode(5) { next = new ListNode(1) } } };
            CrudOps.PrintList(AddTwoNumbers(list1, list2, 0));
        }

        static ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carryOver)
        {
            int l1Value = l1?.val ?? 0;
            int l2Value = l2?.val ?? 0;

            int sum = l1Value + l2Value + carryOver;

            if (sum == 0 && l1 == null && l2 == null)
                return null;

            return new ListNode(sum % 10)
            {
                next = AddTwoNumbers(l1?.next, l2?.next, sum / 10)
            };
        }
        #endregion

        #region Intersection of Two Linked Lists
        /// <summary>
        /// # 515. Gets the intersection node.
        /// </summary>
        /// <returns>The intersection node.</returns>
        /// <param name="headA">Head a.</param>
        /// <param name="headB">Head b.</param>
        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;

            var a = headA;
            var b = headB;

            while (a != b)
            {
                a = a == null ? headB : a.next;
                b = b == null ? headA : b.next;
            }

            return a;
        }
        #endregion

        #region Merged Lists
        public static void MergeKListsProblem()
        {
            var lists = new ListNode[] {
                new ListNode(1) { next = new ListNode(4) { next = new ListNode(5) } },
                new ListNode(1) { next = new ListNode(3) { next = new ListNode(4) } },
                new ListNode(2) { next = new ListNode(6) }
            };

            CrudOps.PrintList(MergeKLists(lists));
        }

        /// <summary>
        /// # 512. Merges the K Lists.
        /// </summary>
        /// <returns>Merged list</returns>
        /// <param name="lists">Lists to merge</param>
        public static ListNode MergeKLists(ListNode[] lists) {
            if (!lists.Any())
                return null;

            ListNode result = null;

            for (int i = 0; i < lists.Length; i++)
            {
                result = MergeLists(result, lists[i]);
            }

            return SortList(result);
        }

        static ListNode MergeLists(ListNode list1, ListNode list2) {
            if (list1 == null)
                return list2;

            if (list2 == null)
                return list1;

            var head1 = list1;
            var last1 = list1;

            while (head1.next != null)
            {
                head1 = head1.next;
            }
            head1.next = list2;
            last1 = head1;

            return list1;
        }

        static ListNode SortList(ListNode list)
        {
            int length = 0;
            var current = list;

            while (current != null)
            {
                current = current.next;
                length++;
            }

            var arr = new int[length];

            var index = 0;

            current = list;
            while (current != null)
            {
                arr[index] = current.val;
                current = current.next;
                index++;
            }

            Array.Sort(arr);

            current = list;
            index = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                
                while (current != null)
                {
                    current.val = arr[index];
                    current = current.next;
                    index++;
                }
            }

            return list;
        }
        #endregion

    }
}
