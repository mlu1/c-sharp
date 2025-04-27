using System;
namespace app{
    class Program{
        static bool StringTest(string xmlStr){
            //Check if input string is empty or not
            int strLen = xmlStr.Length;
            if (strLen == 0){
                Console.WriteLine("NO STRING DETECTED");
                return false;
            }
            //Check the open and close should match (<,>)
            if (xmlStr[0] != '<' || xmlStr[xmlStr.Length - 1] != '>')
                {
                    return false;
                }
            //Cannot start with a closing tag
            if (xmlStr[1] == '/')
                {
                    return false;
                }

            return true;
        }
        
        static List<int> StoreArrays(string xml_input,char bracket_type){    
            List<int> BracketsPos = new List<int>();
            for (int i = 0;i<xml_input.Length;i++){
                if (xml_input[i] == bracket_type){
                    BracketsPos.Add(i);  
                }
            }
            return BracketsPos; 
        }
        static bool matchingTagNum(List<int> a  ,List<int> b){
            if ((a.Count) % 2 >0) {
                return false;
            }
            else if (a.Count != b.Count){
                return false;
            }
            else 
                return true;
            
        }
        
        static bool CompareTag(string s4){
                if (s4[1] =='/'){
                    return true;
                }
                else
                    return false;      
        }

        static bool spaceInTagName(string testStr){
            bool stringSpaceResult = testStr.Contains(" ");
            return stringSpaceResult;
        }

        static string TagText(string mainStr , string beginStr, string endStr){     
            string outString;     
            int Pos1 = mainStr.IndexOf(beginStr) + beginStr.Length;
            int Pos2 = mainStr.IndexOf(endStr);
            outString = mainStr.Substring(Pos1, Pos2 - Pos1);
            return outString;
        }

        static string TagChecker(List<int> c  ,List<int> d,string xml_str){
            string s1;
            string Tagsuccess = "false";
            List<string> Tags_ListOpen = new List<string>();
            List<string> Tags_ListClose = new List<string>();
            for (int i = 0; i < c.Count; i++)
                {
                    s1 = (xml_str.Substring(c[i],(d[i]-c[i]+1)));  
                    if (spaceInTagName(s1)){
                       break;
                    }
                    if (CompareTag(s1)){
                        Tags_ListClose.Add(s1); 
                    }
                    else{
                       Tags_ListOpen.Add(s1); 
                    }
                    
                }
            int k = Tags_ListClose.Count; 
            for (int j = 0; j < Tags_ListOpen.Count; j++)
                {
                    if (TagText(Tags_ListOpen[j],"<", ">") == TagText(Tags_ListClose[k-1],"</", ">")){
                            Tagsuccess = "true";
                        }
                    else{
                            Tagsuccess = "false";
                    }
                    k--;
                }
            return Tagsuccess;
        }

        static void Main(string[] args){
            string inputstr = Console.ReadLine();
            List<int> b1 = new List<int>();   
            List<int> b2 = new List<int>();  

            if (StringTest(inputstr)){
                b1 = StoreArrays(inputstr,'<');
                b2 = StoreArrays(inputstr,'>');
                if (matchingTagNum(b1,b2)){
                    Console.WriteLine(TagChecker(b1,b2,inputstr));
                }
            }
            else{
                Console.WriteLine("Program Terminated:Invalid xml");
                Console.WriteLine(StringTest(inputstr));
                }
            
        }
    }

}

