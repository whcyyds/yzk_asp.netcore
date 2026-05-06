namespace _26_0505Cancellation学习
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //await Download1Async("https://www.yuque.com/", 10);
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken cancellationToken = cts.Token;
             Download2Async("https://www.yuque.com/", 100, cancellationToken);
            while (Console.ReadLine() != "w")
            {

            }
            cts.Cancel();
            Console.ReadLine();
        }
        static async Task Main1(string[] args)
        {
            //await Download1Async("https://www.yuque.com/", 10);
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5000);
            await Download2Async("https://www.yuque.com/", 100,cts.Token);
        }

        static private async Task Download1Async(string url,int n)
        {
            using (var client = new HttpClient()) {
                for(int i = 0; i < n; i++)
                {
                    string html = await client.GetStringAsync(url);
                    Console.WriteLine($"{DateTime.Now}:{html}");
                }
            }

        }

        static private async Task Download2Async(string url, int n,CancellationToken cancellationToken)
        {
            using (var client = new HttpClient())
            {
                for (int i = 0; i < n; i++)
                {
                    string html = await client.GetStringAsync(url);
                    Console.WriteLine($"{DateTime.Now}:{html}");
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }

        }

        static private async Task Download3Async(string url, int n, CancellationToken cancellationToken)
        {
            using (var client = new HttpClient())
            {
                for (int i = 0; i < n; i++)
                {
                    var resp = await client.GetAsync(url,cancellationToken);
                    string html =await resp.Content.ReadAsStringAsync();
                    Console.WriteLine($"{DateTime.Now}:{html}");
                    
                }
            }

        }
    }
}
