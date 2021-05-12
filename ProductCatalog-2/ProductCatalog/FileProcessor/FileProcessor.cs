using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileProcess
{
    public class FileProcessor
    {
        private static readonly string BackupDirectoryName = "backup";
        private static readonly string InProcessDirectoryName = "processing";
        private static readonly string CompletedDirectoryName = "complete";

        protected string InputFilePath { get; }
        private string rootDirectory { get { return Path.GetDirectoryName(InputFilePath); } }
        private string fileName { get { return Path.GetFileName(InputFilePath); } } //with extension
        private string fileExtension { get { return Path.GetExtension(InputFilePath); } }

        public FileProcessor(string filePath)
        {
            InputFilePath = filePath;
            this.StartUp();
        }

        private void StartUp() {
            //var rootDirectory = new DirectoryInfo(InputFilePath).Parent.FullName;

            if (!Directory.Exists(rootDirectory)) {
                Directory.CreateDirectory(rootDirectory);
            }

            if (!File.Exists(InputFilePath)) {
                File.Create(InputFilePath).Close();
            }

            this.Backup();
        }
        private void Backup() {
            var backupDirectory = Path.Combine(rootDirectory, BackupDirectoryName);
            var backupFilePath = Path.Combine(backupDirectory, fileName);
            if (!Directory.Exists(backupDirectory))
            {
                Directory.CreateDirectory(backupDirectory);
            }
            File.Copy(InputFilePath, backupFilePath, true);
        }
        private void StartProccessing() {
            var inProgressDirectory = Path.Combine(rootDirectory, InProcessDirectoryName);
            var inProgressFilePath = Path.Combine(inProgressDirectory, fileName);
            if (!Directory.Exists(inProgressDirectory))
            {
                Directory.CreateDirectory(inProgressDirectory);
            }
            File.Copy(InputFilePath, inProgressFilePath, true);
        }
        private void ProcessCompleted() {
            var inProgressDirectory = Path.Combine(rootDirectory, InProcessDirectoryName);
            var inProgressFilePath = Path.Combine(inProgressDirectory, fileName);

            var completedDirectory = Path.Combine(rootDirectory, CompletedDirectoryName);
            var completedFileName = $"{Path.GetFileNameWithoutExtension(InputFilePath)}--{Guid.NewGuid()}{fileExtension}";
            var completedFilePath = Path.Combine(completedDirectory, completedFileName);
            if (!Directory.Exists(completedDirectory))
            {
                Directory.CreateDirectory(completedDirectory);
            }
            File.Move(inProgressFilePath, completedFilePath);
            File.Copy(completedFilePath, InputFilePath, true); //Replacing back the original file
            Directory.Delete(inProgressDirectory);
        }
    
        protected List<string> GetAllData()
        {
            List<string> data = new List<string>(); 
            using (StreamReader reader = new StreamReader(InputFilePath)) {
                while (!reader.EndOfStream)
                {
                    data.Add(reader.ReadLine());
                }
            }
            return data;
        }
        protected void AppendData(string data) {
            this.StartProccessing();

            var inProgressFilePath = Path.Combine(rootDirectory, InProcessDirectoryName, fileName);

            var lastLine = File.ReadAllText(inProgressFilePath).Split('\n').Last();
            using (StreamWriter writer = new StreamWriter(inProgressFilePath, true)) {
                if (lastLine == ""){
                    writer.Write(data);
                }
                else {
                    writer.Write("\n" + data);
                }
            }

            this.ProcessCompleted();
        }

        protected void OverwriteAll(List<string> data) {
            this.StartProccessing();

            var inProgressFilePath = Path.Combine(rootDirectory, InProcessDirectoryName, fileName);

            using (StreamWriter writer = new StreamWriter(inProgressFilePath))
            {
                data.ForEach(x => writer.WriteLine(x));
            }

            this.ProcessCompleted();
        }
    }
}