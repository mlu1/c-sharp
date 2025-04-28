using System;
using System.Collections.Generic;

namespace App
{
    class Program
    {
        
        static bool IsTagStructureValid(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml)) return false;
            if (xml[0] != '<' || xml[^1] != '>') return false;

            var stack = new Stack<string>();

            for (int i = 0; i < xml.Length;)
            {
                
                if (xml[i] != '<')
                {
                    i++;
                    continue;         
                }

                int closeIdx = xml.IndexOf('>', i);
                if (closeIdx == -1) return false;  

                string rawTag = xml[i..(closeIdx + 1)];
                bool isClosing = rawTag.StartsWith("</");
                bool isSelfClosing = rawTag.EndsWith("/>");

                
                int start = isClosing ? 2 : 1;
                int len = 0;
                while (start + len < rawTag.Length &&
                       rawTag[start + len] is not ('>' or ' ' or '/'))
                {
                    len++;
                }
                if (len == 0) return false;   
                string tagName = rawTag.Substring(start, len);

                if (isClosing)
                {
                    if (stack.Count == 0 || stack.Pop() != tagName) return false;
                }
                else if (!isSelfClosing)
                {
                    stack.Push(tagName);
                }

                i = closeIdx + 1;            
            }

            return stack.Count == 0;
        }

        static void Main()
        {
            Console.WriteLine("Enter string to validate:");
            string? input = Console.ReadLine();
            Console.WriteLine(IsTagStructureValid(input ?? "") ? "Valid" : "InValid");
        }
    }
}
