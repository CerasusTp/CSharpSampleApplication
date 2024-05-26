using Microsoft.EntityFrameworkCore;
using SampleApplication.Models;
using SampleApplication.Models.DB;

namespace SampleApplication.Samples
{
    public static class DBContextSample
    {
        public static void Main()
        {
            // 継続するかどうか
            bool isContinue = true;

            // エラーハンドラー
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            Console.WriteLine("配信者検索システム 起動");
            
            while (isContinue)
            {
                Console.WriteLine("\nどの機能を使用しますか？ 数字で選択してください");
                Console.WriteLine("[0]検索 / [1]追加 / [9]終了");
                int selectedNumber;
                if (int.TryParse(Console.ReadLine(), out selectedNumber))
                {
                    switch (selectedNumber)
                    {
                        case 0:
                            Find();
                            break;
                        case 1:
                            throw new NotImplementedException("この機能は実装されていません");
                        case 9:
                            Environment.Exit(0);
                            break;
                        default:
                            throw new NotImplementedException("この機能は実装されていません");
                    }
                }
                else
                {
                    Console.WriteLine("想定外の入力がされました");
                }
            }
        }

        private static void Find()
        {
            Console.WriteLine("検索する配信者の名前を入力してください");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("名前が入力されませんでした");
                return;
            }
            using (DBModelContext context = new())
            {
                Streamer? streamer = context.Streamers.Where(x => x.Name.Contains(input)).Include(x => x.StreamerURLs).FirstOrDefault();

                if (streamer is null)
                {
                    Console.WriteLine("\n該当する配信者は存在しません");
                    return;
                }
                    
                Console.WriteLine($"\n名前：{streamer.Name} 説明：{streamer.Explanation}");
                foreach (StreamerURL url in streamer.StreamerURLs ?? [])
                {
                    Console.WriteLine($"サイト：{url.Site} URL：{url.Url}");
                }
            }
        }

        public static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                Console.WriteLine($"エラーが発生しました");
                Console.WriteLine($"エラー：{ex.GetType()}");
                Console.WriteLine($"メッセージ：{ex.Message}");
            }
            finally
            {
                Environment.Exit(1);
            }    
        }
    }
}
