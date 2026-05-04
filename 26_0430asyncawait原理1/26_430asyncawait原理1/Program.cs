namespace _26_430asyncawait原理1
{
    internal class Program
    {
        static async Task  Main(string[] args)
        {
            using(HttpClient httpClient = new HttpClient())
            {
               string html = await httpClient.GetStringAsync("https://www.taobao.com");
                Console.WriteLine(html);
            }
            string txt = "小文要努力";
            string filename = @"e:\temp\a.txt";
            await File.WriteAllTextAsync(filename, txt);
            Console.WriteLine("写入成功");
            string s =await File.ReadAllTextAsync(filename);
            Console.WriteLine("文件内容："+s);
        }
    }
}
