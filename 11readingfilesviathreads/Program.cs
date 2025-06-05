namespace _11readingfilesviathreads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var FilesPath = "../../../documents";
            var Files = Directory.GetFiles(FilesPath);

            var TotalFiles = 0;
            var TotalWords = 0;

            List<Task> ReadingTasks = new List<Task>();
            object LockObject = new object();

            foreach (var CurrentFile in Files)
            {
                ReadingTasks.Add(Task.Run(() =>
                {
                    var Text = File.ReadAllText(CurrentFile);
                    var Words = Text.Split(' ').Length;

                    using var Stream = File.Create($"{FilesPath}/{Path.GetFileNameWithoutExtension(CurrentFile)}_result.txt");
                    using var Writer = new StreamWriter(Stream);
                    { Writer.Write($"Текст из файла: {Text}\nКоличество слов в файле: {Words}"); }

                    lock (LockObject)
                    {
                        Console.WriteLine($"Текст из файла: {Text}");
                        Console.WriteLine($"Количество слов в файле: {Words}");
                        Console.WriteLine();

                        Interlocked.Increment(ref TotalFiles);
                        Interlocked.Add(ref TotalWords, Words);
                    }
                }));
            }
            Task.WaitAll(ReadingTasks.ToArray());

            Console.WriteLine($"Общее количество файлов: {TotalFiles}");
            Console.WriteLine($"Общее количество слов в файлах: {TotalWords}");
        }
    }
}
