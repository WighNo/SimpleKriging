using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Text;
using Core.Interfaces;

namespace Core
{
    public class LargeMatrixStorage
    {
        private const string ContentFolderName = "Temp";
        private const char Delimiter = ';';

        private readonly StringBuilder _writeFileContentBuilder = new StringBuilder();
        private readonly string _storageFilePath;

        public LargeMatrixStorage()
        {
            if (TempFileCollection == null)
            {
                CreateDirectory();
                TempFileCollection = new TempFileCollection(WorkDirectory, false);
            }
            
            _storageFilePath = GetRandomPath();
        }
        
        private static TempFileCollection TempFileCollection { get; set; }

        private string WorkDirectory { get; set; }
        
        private void CreateDirectory()
        {
            WorkDirectory = Path.Combine(Directory.GetCurrentDirectory(), ContentFolderName);

            if (Directory.Exists(ContentFolderName) == false)
                Directory.CreateDirectory(WorkDirectory);
            else
                ClearWorkDirectory();
        }

        private void ClearWorkDirectory()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(WorkDirectory);
                
            foreach (var file in directoryInfo.GetFiles())
            {
                file.Delete();
            }
        }

        private string GetRandomPath()
        {
            string fileName = Path.ChangeExtension(Path.GetRandomFileName(), "txt");
            return Path.Combine(WorkDirectory, fileName);
        }

        public void WriteFile(Action<StreamWriter> s, bool openWorkDirectoryAfterWrite = false)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (StreamWriter streamWriter = new StreamWriter(_storageFilePath))
            {
                s?.Invoke(streamWriter);
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks);
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine(stopwatch.Elapsed);

            if (openWorkDirectoryAfterWrite == true)
                Process.Start(WorkDirectory);
        }
        
        public string ReadFile(int targetRow) 
        {
            string targetLine = null;

            using (StreamReader streamReader = new StreamReader(_storageFilePath))
            {
                int line = 0;
                
                while (streamReader.EndOfStream == false)
                {
                    if (line != targetRow)
                    {
                        streamReader.ReadLine();
                    }
                    else
                    {
                        targetLine = streamReader.ReadLine();
                        break;
                    }
                    
                    line++;
                }
            }
            
            return targetLine;
        }
    }
}