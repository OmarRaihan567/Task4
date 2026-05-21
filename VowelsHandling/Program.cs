namespace VowelsHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a word: ");
                string word = Console.ReadLine().ToLower();
                StringHandle(word);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
        static void StringHandle(string s) 
        {
            if (!(s.Contains('a') || s.Contains('e') || s.Contains('i') || s.Contains('o') || s.Contains('u')))
                throw new Exception("The word should contain vowels");
        }
    }
}
