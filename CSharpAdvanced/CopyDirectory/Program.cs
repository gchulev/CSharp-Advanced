namespace CopyDirectory
{
    using System;
    using System.Linq;
    using System.IO;
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"H:\Temp";
            string outputPath = @$"H:\Temp\Output";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            var inputDir = new DirectoryInfo(inputPath);
            var files = inputDir.GetFiles();


            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
            Directory.CreateDirectory(outputPath);

            foreach (FileInfo file in files)
            {
                File.Copy(file.FullName, Path.Combine(outputPath, file.Name));
            }
        }
    }
}
