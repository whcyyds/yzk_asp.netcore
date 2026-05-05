namespace 异步方法不等于多线程
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
            Console.WriteLine("before:" + Thread.CurrentThread.ManagedThreadId);
            double r = await CalcAsync(10);
            Console.WriteLine($"r={r}");
            Console.WriteLine("after:" + Thread.CurrentThread.ManagedThreadId);
             

        }


        public static async Task<double> CalcAsync(int n)
        {
            /*同一个线程
            Console.WriteLine("CalcAsync:"+Thread.CurrentThread.ManagedThreadId);
            double result = 0;
            Random rand = new Random();
            for(int i = 0; i < n * n; i++)
            {
                result += rand.NextDouble();
            }
            return result;
            */
            //不同线程
            return await Task.Run(() => {
                Console.WriteLine("CalcAsync:" + Thread.CurrentThread.ManagedThreadId);
                double result = 0;
                Random rand = new Random();
                for (int i = 0; i < n * n; i++)
                {
                    result += rand.NextDouble();
                }
                return result;
            });
        }
    }
}
