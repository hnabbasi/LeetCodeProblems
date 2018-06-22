using System.Text;

namespace LinkedList
{
    public static class CrudOps
    {
        static ListNode _head;
        static ListNode _first;
        static ListNode _last;

        public static void Run() {
            System.Diagnostics.Debug.WriteLine("Linked list");
            Initialize(new int[] { 2, 3, 5, 6, 6, 7, 8 });
            PrintListInternal();
            InsertBegin(1);
            PrintListInternal();
            InsertEnd(9);
            PrintListInternal();
            InsertAt(4, 3);
            PrintListInternal();
            Delete(6);
            PrintListInternal();
        }
        static void Initialize(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                var newNode = new ListNode(values[i]);

                if (_head == null)
                {
                    _head = newNode;
                    _first = newNode;
                    _last = newNode;
                }

                _last.next = newNode;
                _last = newNode;
            }
        }

        static void InsertBegin(int data)
        {
            System.Diagnostics.Debug.WriteLine($"\nInsert begin: {data}");
            var newNode = new ListNode(data);

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                newNode.next = _head;
                _head = newNode;
            }
        }

        static void InsertEnd(int data)
        {
            System.Diagnostics.Debug.WriteLine($"\nInsert end: {data}");
            ListNode current;

            if (_head == null)
            {
                InsertBegin(data);
            }
            else
            {
                current = _head;

                while (current.next != null)
                {
                    current = current.next;
                }

                var newNode = new ListNode(data);
                current.next = newNode;
            }
        }

        static void InsertAt(int data, int position)
        {
            System.Diagnostics.Debug.WriteLine($"\nInsert {data} at {position}");
            ListNode current;
            int pos = 0;

            if (_head == null || pos == position)
            {
                InsertBegin(data);
            }
            else
            {
                current = _head;

                while (current.next != null)
                {
                    if (pos == position - 1)
                        break;

                    current = current.next;
                    pos++;
                }

                var newNode = new ListNode(data);
                newNode.next = current.next;
                current.next = newNode;
            }
        }

        static void Delete(int data)
        {
            System.Diagnostics.Debug.WriteLine($"\nDelete {data}");

            if (_head == null)
                return;

            ListNode current;
            current = _head;

            while (current.next != null)
            {
                if (data == current.next.val)
                {
                    current.next = current.next.next;
                    return;
                }
                current = current.next;
            }
        }

        static void PrintListInternal()
        {
            if (_head == null)
            {
                System.Diagnostics.Debug.WriteLine("List is empty.");
                return;
            }

            var current = _head;
            var logMsg = new StringBuilder();

            while (current != null)
            {
                logMsg.Append($" {current.val} >");
                current = current.next;
            }
            System.Diagnostics.Debug.WriteLine($"{logMsg?.ToString()?.Trim()?.TrimEnd('>')}");
        }

        public static void PrintList(ListNode list)
        {
            if (list == null)
            {
                System.Diagnostics.Debug.WriteLine("List is empty.");
                return;
            }

            var current = list;
            var logMsg = new StringBuilder();

            while (current != null)
            {
                logMsg.Append($"{current.val} > ");
                current = current.next;
            }
            System.Diagnostics.Debug.WriteLine($"{logMsg?.ToString()?.Trim()?.TrimEnd('>')}");
        }
    }
}
