using System;
using System.Collections.Generic;

namespace App
{
    class Program
    {
        
        static bool IsExactTagMatch(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml)) return false;
            if (xml[0] != '<' || xml[^1] != '>') return false;

            var stack = new Stack<string>();

            for (int i = 0; i < xml.Length;)
            {
                
                if (xml[i] != '<') { i++; continue; }

                int closeIdx = xml.IndexOf('>', i);
                if (closeIdx == -1) return false;              // “>” missing

                // Everything between '<' and '>'
                string raw = xml.Substring(i + 1, closeIdx - i - 1).Trim();
                bool isClosing     = raw.StartsWith("/");
                bool isSelfClosing = raw.EndsWith("/");

               
                string identity = (isClosing ? raw[1..] : raw).TrimEnd('/');
                if (identity.Length == 0) return false;  
                if (isClosing)
                {
                    if (stack.Count == 0 || stack.Pop() != identity) return false;
                }
                else if (!isSelfClosing)
                {
                    stack.Push(identity);
                }

                i = closeIdx + 1;                             
            }

            
            return stack.Count == 0;
        }

        static void Main()
        {
            Console.WriteLine("Enter string to validate:");
            string? input = Console.ReadLine();
            Console.WriteLine(IsExactTagMatch(input ?? "")
                              ? "true"
                              : "false");
        }
    }
}
