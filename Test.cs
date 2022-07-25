namespace TestApp
{
    class Test
    {
        public static void Main(string[] args)
        {
            Console.Write("Method1, 2 examples \n\n");
            Method1();

            Console.Write("Method2, 2 examples \n\n");
            Method2();

            Console.Write("Method3, 2 examples \n\n");
            Method3();

            Console.ReadLine();
        }

        public static List<B> Map<A, B>(List<A> list, Func<A, B> f)
        {
            var result = new List<B>();

            foreach (var item in list)
            {
                result.Add(f(item));
            }

            return result;
        }

        public static B Fold<A, B>(List<A> list, B initial, Func<B, A, B> folder)
        {
            foreach (var item in list)
            {
                initial = folder(initial, item);
            }

            return initial;
        }

        public static List<B> Map2<A, B>(List<A> list, Func<A, B> f)
        {
            return Fold(list, new List<B>(), (newList, x) =>
            {
                newList.Add(f(x));
                return newList;
            });
        }

        private static void Method1()
        {
            var list = new List<int>() { 1, 2, 3 };
            var results1 = Map(list, x => x + 1);

            Print(list, results1);

            List<int> chars = new List<int>() { 1, 2, 3 };
            List<String> result2 = Map<int, String>(chars, x => (String.Format("\"{0}\"", x.ToString())));

            Print(chars, result2);
        }

        private static void Method2()
        {
            List<int> iList = new List<int>() { 1, 2, 3 };
            String result = Fold<int, String>(iList, "", (s, n) => s + n.ToString());

            Print(iList, new List<String>() { result });

            List<int> iList2 = new List<int>() { 1, 2, 3 };
            int result2 = Fold<int, int>(iList2, 0, (s, n) => (s + n));

            Print(iList2, new List<String>() { result2.ToString() });
        }

        private static void Method3()
        {
            List<int> iList = new List<int>() { 1, 2, 3 };
            List<int> result = Map2(iList, x => x + 1);

            Print(iList, result);

            List<int> cList = new List<int>() { 1, 2, 3 };
            List<String> result2 = Map2<int, String>(cList, x => (String.Format("\"{0}\"", x.ToString())));

            Print(cList, result2);
        }

        static void Print<A, B>(List<A> input, List<B> output)
        {
            Console.Write("input list: ");
            input.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            Console.Write("output list: ");
            output.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
