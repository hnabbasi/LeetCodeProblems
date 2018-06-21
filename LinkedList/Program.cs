namespace LinkedList
{
    class Program
    {
        static SingleNode _head;
        static SingleNode _first;
        static SingleNode _last;

        static void Main(string[] args)
        {
            System.Diagnostics.Debug.WriteLine("Linked list");
            Initialize(new int[] { 2, 3, 5, 6, 6, 7, 8 });
            PrintList();
            InsertBegin(1);
            PrintList();
            InsertEnd(9);
            PrintList();
            InsertAt(4, 3);
            PrintList();
            Delete(6);
            PrintList();
        }

        static void Initialize(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                var newNode = new SingleNode(values[i]);

                if (_head == null)
                {
                    _head = newNode;
                    _first = newNode;
                    _last = newNode;
                }

                _last.link = newNode;
                _last = newNode;
            }
        }

        static void InsertBegin(int data)
        {
            System.Diagnostics.Debug.WriteLine($"\nInsert begin: {data}");
            var newNode = new SingleNode(data);

            if (_head == null)
            {
                _head = newNode;
            } else
            {
                newNode.link = _head;
                _head = newNode;
            }
        }

        static void InsertEnd(int data)
        {
            System.Diagnostics.Debug.WriteLine($"\nInsert end: {data}");
            SingleNode current;

            if (_head == null)
            {
                InsertBegin(data);
            }
            else
            {
                current = _head;

                while (current.link != null)
                {
                    current = current.link;
                }

                var newNode = new SingleNode(data);
                current.link = newNode;
            }
        }

        static void InsertAt(int data, int position)
        {
            System.Diagnostics.Debug.WriteLine($"\nInsert {data} at {position}");
            SingleNode current;
            int pos = 0;

            if (_head == null || pos == position)
            {
                InsertBegin(data);
            }
            else
            {
                current = _head;

                while (current.link != null)
                {
                    if (pos == position - 1)
                        break;

                    current = current.link;
                    pos++;
                }

                var newNode = new SingleNode(data);
                newNode.link = current.link;
                current.link = newNode;
            }
        }

        static void Delete(int data)
        {
            System.Diagnostics.Debug.WriteLine($"\nDelete {data}");

            if (_head == null)
                return;

            SingleNode current;
            current = _head;

            while (current.link != null)
            {
                if (data == int.Parse(current.link.data.ToString())) {
                    current.link = current.link.link;
                    return;
                }
                current = current.link;
            }
        }

        static void PrintList()
        {
            SingleNode current;

            if (_head == null)
            {
                System.Diagnostics.Debug.WriteLine("List is empty.");
                return;
            }

            current = _head;

            while (current != null)
            {
                System.Diagnostics.Debug.Write($"| {current.data} ");
                current = current.link;
            }
            System.Diagnostics.Debug.WriteLine("|");
        }
    }

    class SingleNode
    {
        public object data;
        public SingleNode link;
        public SingleNode(object data)
        {
            this.data = data;
        }
    }
}