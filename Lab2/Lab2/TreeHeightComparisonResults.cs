namespace Lab2
{
    public class TreeHeightComparisonResults
    {
        public uint NumberOfElements { get; set; }
        public int BSTHeight { get; set; }
        public int AVLHeight { get; set; }

        public static string HeaderToString()
        {
            return "Number of elements | BSTHeight | AVLHeight";
        }

        public string DataToString()
        {
            string result = "";
            result += NumberOfElements.ToString();
            result += Spaces(19 - (int)NumberOfElements.ToString().Length);
            result += "| ";
            result += BSTHeight.ToString();
            result += Spaces(10 - BSTHeight.ToString().Length);
            result += "| ";
            result += AVLHeight.ToString();
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