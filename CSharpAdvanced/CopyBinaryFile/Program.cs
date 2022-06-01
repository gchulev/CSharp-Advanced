namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {

            using (var fs = new FileStream(inputFilePath, FileMode.Open))
            {
                using (var output = new FileStream(outputFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        var readData = fs.Read(buffer, 0, buffer.Length);
                        if (readData == 0)
                        {
                            break;
                        }
                        output.Write(buffer, 0, readData);
                    }
                }
            }
        }
    }
}

