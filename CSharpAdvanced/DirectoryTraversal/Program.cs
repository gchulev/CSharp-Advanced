namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @$"{Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\desktop\report.txt")}";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            DirectoryInfo drInfo = new DirectoryInfo(inputFolderPath);
            var result = new Dictionary<string, List<FileInfo>>();

            foreach (FileInfo file in drInfo.GetFiles())
            {
                string fileExtension = file.Extension.ToLower();

                if (!result.ContainsKey(fileExtension))
                {
                    result.Add(fileExtension, new List<FileInfo>());
                }
                result[fileExtension].Add(file);
            }

            Dictionary<string, List<FileInfo>> grouppedDict = result.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(y => y.Key, y => y.Value);
            var sb = new StringBuilder();

            foreach (var kvp in grouppedDict)
            {
                sb.AppendLine(kvp.Key);

                foreach (var item in kvp.Value.OrderByDescending(x => x.Length))
                {
                    string formattedSize = string.Empty;
                    if (item.Length >= 100000)
                    {
                        decimal size = (decimal)item.Length / (1024 * 1000);
                        formattedSize = string.Format("{0:#.###}", size);
                    }
                    else
                    {
                        decimal size = (decimal)item.Length / 1024;
                        formattedSize = string.Format("{0:#.###}", size);
                    }

                    sb.AppendLine($"--{item.Name} - {formattedSize}kb");
                }

            }
            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            File.WriteAllTextAsync(reportFileName, textContent);
        }
    }
}
