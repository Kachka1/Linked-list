using System;
using System.Collections.Generic;

namespace TransportSystemsLinkedLists
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== 1 ===");
            {
                ListNode? l1 = CreateList(new[] { 1, 2, 4 });
                ListNode? l2 = CreateList(new[] { 1, 3, 4 });
                Console.Write("1: list1 = [1, 2, 4], list2 = [1, 3, 4] -> Output: ");
                PrintList(MergeTwoLists(l1, l2));

                Console.Write("2: list1 = [], list2 = [] -> Output: ");
                PrintList(MergeTwoLists(null, null));
            }
            Console.WriteLine();

            Console.WriteLine("=== 2 ===");
            {
                ListNode? head1 = CreateList(new[] { 1, 1, 2 });
                Console.Write("1: head = [1, 1, 2] -> Output: ");
                PrintList(DeleteDuplicates(head1));

                ListNode? head2 = CreateList(new[] { 1, 1, 2, 3, 3 });
                Console.Write("2: head = [1, 1, 2, 3, 3] -> Output: ");
                PrintList(DeleteDuplicates(head2));
            }
            Console.WriteLine();

            Console.WriteLine("=== 3 ===");
            {
                ListNode head = CreateList(new[] { 3, 2, 0, -4 })!;
                ListNode tail = head.next!.next!.next!;
                tail.next = head.next;
                Console.WriteLine($"1: Input: head = [3, 2, 0, -4], pos = 1 -> Output: {HasCycle(head).ToString().ToLower()}");

                ListNode head2 = CreateList(new[] { 1, 2 })!;
                head2.next!.next = head2;
                Console.WriteLine($"2: Input: head = [1, 2], pos = 0 -> Output: {HasCycle(head2).ToString().ToLower()}");

                ListNode head3 = CreateList(new[] { 1 })!;
                Console.WriteLine($"3: Input: head = [1], pos = -1 -> Output: {HasCycle(head3).ToString().ToLower()}");
            }
            Console.WriteLine();

            Console.WriteLine("=== 4 ===");
            {
                ListNode? head = CreateList(new[] { 1, 2, 3, 4 });
                Console.Write("1: head = [1, 2, 3, 4] -> Output: ");
                ReorderList(head);
                PrintList(head);

                ListNode? head2 = CreateList(new[] { 1, 2, 3, 4, 5 });
                Console.Write("2: head = [1, 2, 3, 4, 5] -> Output: ");
                ReorderList(head2);
                PrintList(head2);
            }
            Console.WriteLine();

            Console.WriteLine("=== 5 ===");
            {
                ListNode? head = CreateList(new[] { 4, 5, 1, 9 });
                ListNode? nodeToDelete = head!.next;
                Console.Write("1: head = [4, 5, 1, 9], node = 5 -> Output: ");
                DeleteNode(nodeToDelete!);
                PrintList(head);
            }
            Console.WriteLine();

            Console.WriteLine("=== 6 ===");
            {
                ListNode? head1 = CreateList(new[] { 1, 8, 9 });
                Console.Write("1: head = [1, 8, 9] -> Output: ");
                PrintList(DoubleIt(head1));

                ListNode? head2 = CreateList(new[] { 9, 9, 9 });
                Console.Write("2: head = [9, 9, 9] -> Output: ");
                PrintList(DoubleIt(head2));
            }
            Console.WriteLine();

            Console.WriteLine("=== 7 ===");
            {
                ListNode?[] lists = new ListNode?[] {
                    CreateList(new[] { 1, 4, 5 }),
                    CreateList(new[] { 1, 3, 4 }),
                    CreateList(new[] { 2, 6 })
                };
                Console.Write("1: lists = [[1,4,5],[1,3,4],[2,6]] -> Output: ");
                PrintList(MergeKLists(lists));
            }
            Console.WriteLine();

            Console.WriteLine("=== 8 ===");
            {
                ListNode? head1 = CreateList(new[] { 1, 2, 3, 4, 5 });
                Console.Write("1: head = [1, 2, 3, 4, 5], k = 2 -> Output: ");
                PrintList(ReverseKGroup(head1, 2));

                ListNode? head2 = CreateList(new[] { 1, 2, 3, 4, 5 });
                Console.Write("2: head = [1, 2, 3, 4, 5], k = 3 -> Output: ");
                PrintList(ReverseKGroup(head2, 3));
            }
            Console.WriteLine();

            Console.WriteLine("=== 9. Розділити список ===");
            {
                ListNode? head1 = CreateList(new[] { 1, 4, 3, 2, 5, 2 });
                Console.Write("Приклад 1: head = [1, 4, 3, 2, 5, 2], x = 3 -> Output: ");
                PrintList(Partition(head1, 3));

                ListNode? head2 = CreateList(new[] { 2, 1 });
                Console.Write("Приклад 2: head = [2, 1], x = 2 -> Output: ");
                PrintList(Partition(head2, 2));
            }
        }

        public static ListNode? CreateList(int[] arr)
        {
            if (arr == null || arr.Length == 0) return null;
            ListNode dummy = new ListNode(0);
            ListNode curr = dummy;
            foreach (int val in arr)
            {
                curr.next = new ListNode(val);
                curr = curr.next;
            }
            return dummy.next;
        }

        public static void PrintList(ListNode? head)
        {
            List<int> result = new List<int>();
            int maxNodes = 20000;
            while (head != null && maxNodes-- > 0)
            {
                result.Add(head.val);
                head = head.next;
            }
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }

        public static ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
        {
            ListNode dummy = new ListNode();
            ListNode current = dummy;

            while (list1 != null && list2 != null)
            {
                if (list1.val < -100 || list1.val > 100 || list2.val < -100 || list2.val > 100)
                    throw new ArgumentException("Значення вузла виходить за межі [-100, 100].");

                if (list1.val <= list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }
                current = current.next;
            }

            current.next = list1 ?? list2;
            return dummy.next;
        }

        public static ListNode? DeleteDuplicates(ListNode? head)
        {
            ListNode? current = head;
            while (current != null && current.next != null)
            {
                if (current.val < -100 || current.val > 100)
                    throw new ArgumentException("Значення вузла виходить за межі [-100, 100].");

                if (current.val == current.next.val)
                {
                    current.next = current.next.next;
                }
                else
                {
                    if (current.val > current.next.val)
                        throw new ArgumentException("Список не відсортований за зростанням.");
                    current = current.next;
                }
            }
            return head;
        }

        public static bool HasCycle(ListNode? head)
        {
            if (head == null || head.next == null)
                return false;

            ListNode? slow = head;
            ListNode? fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow!.next;
                fast = fast.next.next;

                if (slow == fast)
                    return true;
            }
            return false;
        }

        public static void ReorderList(ListNode? head)
        {
            if (head == null || head.next == null) return;

            ListNode? slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow!.next;
                fast = fast.next.next;
            }
            ListNode? prev = null;
            ListNode? curr = slow!.next;
            slow.next = null;

            while (curr != null)
            {
                ListNode? nextTemp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextTemp;
            }

            ListNode? first = head;
            ListNode? second = prev;

            while (second != null)
            {
                ListNode? temp1 = first!.next;
                ListNode? temp2 = second.next;

                first.next = second;
                second.next = temp1;

                first = temp1;
                second = temp2;
            }
        }

        public static void DeleteNode(ListNode node)
        {
            if (node == null || node.next == null)
                throw new ArgumentException("Вузол не може бути останнім або null.");

            if (node.val < -1000 || node.val > 1000)
                throw new ArgumentException("Значення вузла виходить за межі [-1000, 1000].");

            node.val = node.next.val;
            node.next = node.next.next;
        }

        public static ListNode? DoubleIt(ListNode? head)
        {
            if (head == null) return null;

            ListNode? reversed = ReverseList(head);

            ListNode? curr = reversed;
            ListNode? prev = null;
            int carry = 0;

            while (curr != null)
            {
                if (curr.val < 0 || curr.val > 9)
                    throw new ArgumentException("Цифра має бути в межах [0, 9].");

                int sum = curr.val * 2 + carry;
                curr.val = sum % 10;
                carry = sum / 10;
                prev = curr;
                curr = curr.next;
            }

            if (carry > 0)
            {
                prev!.next = new ListNode(carry);
            }
            return ReverseList(reversed);
        }

        private static ListNode? ReverseList(ListNode? head)
        {
            ListNode? prev = null, curr = head;
            while (curr != null)
            {
                ListNode? nextTemp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextTemp;
            }
            return prev;
        }

        public static ListNode? MergeKLists(ListNode?[] lists)
        {
            if (lists == null || lists.Length == 0) return null;
            PriorityQueue<ListNode, int> pq = new PriorityQueue<ListNode, int>();

            foreach (var node in lists)
            {
                if (node != null)
                    pq.Enqueue(node, node.val);
            }

            ListNode dummy = new ListNode(0);
            ListNode tail = dummy;

            while (pq.Count > 0)
            {
                ListNode curr = pq.Dequeue();
                tail.next = curr;
                tail = tail.next;

                if (curr.next != null)
                    pq.Enqueue(curr.next, curr.next.val);
            }

            return dummy.next;
        }
        public static ListNode? ReverseKGroup(ListNode? head, int k)
        {
            if (head == null || k <= 1) return head;

            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode curr = dummy, nex = dummy, pre = dummy;
            int count = 0;

            while (curr.next != null)
            {
                curr = curr.next;
                count++;
            }

            while (count >= k)
            {
                curr = pre.next!;
                nex = curr.next!;
                for (int i = 1; i < k; i++)
                {
                    curr.next = nex.next;
                    nex.next = pre.next;
                    pre.next = nex;
                    nex = curr.next!;
                }
                pre = curr;
                count -= k;
            }
            return dummy.next;
        }

        public static ListNode? Partition(ListNode? head, int x)
        {
            if (x < -200 || x > 200)
                throw new ArgumentException("x має бути в межах [-200, 200].");

            ListNode lessDummy = new ListNode(0);
            ListNode greaterDummy = new ListNode(0);
            ListNode less = lessDummy;
            ListNode greater = greaterDummy;

            while (head != null)
            {
                if (head.val < -100 || head.val > 100)
                    throw new ArgumentException("Значення вузла виходить за межі [-100, 100].");

                if (head.val < x)
                {
                    less.next = head;
                    less = less.next;
                }
                else
                {
                    greater.next = head;
                    greater = greater.next;
                }
                head = head.next;
            }
            greater.next = null;
            less.next = greaterDummy.next;

            return lessDummy.next;
        }
    }
}