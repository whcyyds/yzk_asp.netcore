using System.Text;

namespace _26_503异步方法的线程问题
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <20; i++)
            {
                sb.Append("我要成为高富帅"); 
            }
            await File.WriteAllTextAsync("test.txt", sb.ToString());
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
