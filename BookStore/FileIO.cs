using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookStore
{
    public class FileIO
    {
        public string ReadSpecificLine(string filePath, int lineNumber)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new Exception("Invalid File Path");
            }

            using (StreamReader file = new StreamReader(filePath))
            {
                string content = null;
                for (int i = 1; i <= lineNumber; i++)
                {
                    file.ReadLine();
                    if (file.EndOfStream)
                    {
                        break;
                    }
                }
                content = file.ReadLine();

                return content;
            }
        }
    }
}
