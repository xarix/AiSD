using System;

namespace Lab2
{
    public class AccessTimeComparisonResults
    {
        public uint NumberOfElements { get; set; }
        public int BSTInsert { get; set; }
        public int LinkedListInsert { get; set; }
        public int BSTSearch { get; set; }
        public int LinkedListSearch { get; set; }
        public int BSTDestroy { get; set; }
        public int LinkedListDestroy { get; set; }

        public static string HeaderToString()
        {
            return "Number of elements | BSTInsert | LinkedListInsert | BSTSearch | LinkedListSearch | BSTDestroy | LinkedListDestroy";
        }

        public string DataToString()
        {
            string result = "";
            result += NumberOfElements.ToString();
            result += Spaces(19 - (int)NumberOfElements.ToString().Length);
            result += "| ";
            result += BSTInsert.ToString();
            result += "ms";
            result += Spaces(8 - BSTInsert.ToString().Length);
            result += "| ";
            result += LinkedListInsert.ToString();
            result += "ms";
            result += Spaces(15 - LinkedListInsert.ToString().Length);
            result += "| ";
            result += BSTSearch.ToString();
            result += "ms";
            result += Spaces(8 - BSTSearch.ToString().Length);
            result += "| ";
            result += LinkedListSearch.ToString();
            result += "ms";
            result += Spaces(15 - LinkedListSearch.ToString().Length);
            result += "| ";
            result += BSTDestroy.ToString();
            result += "ms";
            result += Spaces(9 - BSTDestroy.ToString().Length);
            result += "| ";
            result += LinkedListDestroy.ToString();
            result += "ms";
            return result;
        }

        private string Spaces(int numberOfSpaces)
        {
            var result = "";
            for (int i = 0; i < numberOfSpaces; i++)
            {
                result += " ";
            }
            return result;
        }
    }
}