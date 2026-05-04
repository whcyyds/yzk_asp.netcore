namespace _0504_没有async的异步方法
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string s = await ReadAsync(1);
            Console.WriteLine(s);
        }
        /*
         static async Task<string> ReadAsync(int num)
        {
            switch (num)
            {
                case 1:
                    string s1 = await File.ReadAllTextAsync(@"E:\A NEW LIFE\杨中科\yzk_asp.netcore\resources\1.txt"); return s1;
                case 2:
                    string s2 = await File.ReadAllTextAsync(@"E:\A NEW LIFE\杨中科\yzk_asp.netcore\resources\2.txt"); return s2;
                default: throw new ArgumentException();

            }
        }
         */

        static  Task<string> ReadAsync(int num)
        {
            switch (num)
            {
                case 1:
                    return File.ReadAllTextAsync(@"E:\A NEW LIFE\杨中科\yzk_asp.netcore\resources\1.txt");  
                case 2:
                    return File.ReadAllTextAsync(@"E:\A NEW LIFE\杨中科\yzk_asp.netcore\resources\2.txt"); 
                default: throw new ArgumentException();

            }
        }


    }
}
