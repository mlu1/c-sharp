using System;
using System.Collections.Generic;
namespace SimpleXMLValidatorLibrary

{
   
    public class SimpleXmlValidator
    {
        public static bool DetermineXml(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))        return false;
            if (xml[0] != '<' || xml[^1] != '>')       return false;

            var stack = new Stack<string>();

            for (int i = 0; i < xml.Length;)
            {
                // Skip anything that isn't a tag starter
                if (xml[i] != '<') { i++; continue; }

                int closeIdx = xml.IndexOf('>', i);
                if (closeIdx == -1) return false;      // malformed: no '>'

                // Grab everything between the angle brackets
                string raw = xml.Substring(i + 1, closeIdx - i - 1).Trim();
                bool isClosing     = raw.StartsWith('/');
                bool isSelfClosing = raw.EndsWith('/');

                // Tag identity is "everything after the initial '/' (if any),
                // minus a trailing '/' (if any), with whitespace trimmed."
                string identity = (isClosing ? raw[1..] : raw).TrimEnd('/').Trim();
                if (identity.Length == 0) return false; // empty tag name

                if (isClosing)
                {
                    // Closing tag must match the most recent unmatched opener
                    if (stack.Count == 0 || stack.Pop() != identity)
                        return false;
                }
                else if (!isSelfClosing)
                {
                    // Remember the opener to match later
                    stack.Push(identity);
                }

                i = closeIdx + 1;                      // advance beyond '>'
            }

            // Valid iff every opener has been matched
            return stack.Count == 0;
        }
    }
}
