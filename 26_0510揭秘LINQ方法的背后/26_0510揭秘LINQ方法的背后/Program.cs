namespace _26_0510揭秘LINQ方法的背后
{
    // 自定义扩展方法 MyWhere，模拟 LINQ 的 Where
    public static class MyLinqExtensions
    {
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> result = nums.MyWhere(n => n > 3);
            foreach (int n in result)
            {
                Console.WriteLine(n);
            }
        }
    }
}
