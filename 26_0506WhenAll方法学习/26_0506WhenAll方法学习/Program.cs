namespace _26_0506WhenAll方法学习
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Task<string> s1 =  File.ReadAllTextAsync(@"E:\A NEW LIFE\杨中科\yzk_asp.netcore\resources\1.txt");
            // Task<string> s2 = File.ReadAllTextAsync(@"E:\A NEW LIFE\杨中科\yzk_asp.netcore\resources\2.txt");
            // Task<string> s3 = File.ReadAllTextAsync(@"E:\A NEW LIFE\杨中科\yzk_asp.netcore\resources\3.txt");
            // string result =await  await Task.WhenAny(s1, s2, s3);

            //     Console.WriteLine(result);

            string[] files =Directory.GetFiles(@"E:\A NEW LIFE\杨中科\yzk_asp.netcore\resources");
            Task<int>[] tasks = new Task<int>[files.Length];
            for (int i = 0; i < files.Length; i++) { 
                string filename = files[i];
                Task<int> task = ReadCharsCount(filename);
                tasks[i] = task;

            }
            int[] counts =await Task.WhenAll(tasks);
            int c = counts.Sum();


        }
        static async Task<int> ReadCharsCount(string filename)
        {
            string s = await File.ReadAllTextAsync(filename);
            return s.Length;
        }
    }
}
