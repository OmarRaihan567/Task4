namespace ExceptionHandling1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = new List<int>();
            Console.Write("How many numbers? ");
            int size = Convert.ToInt32(Console.ReadLine());

            while (numbers.Count < size)
            {
                try
                {
                    Console.Write("Enter number: ");
                    int num = Convert.ToInt32(Console.ReadLine());

                    if (numbers.Contains(num))
                        throw new Exception("Can't accept duplicate numbers");

                    numbers.Add(num);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            
            //List<int> nums = new List<int>(6);
            //int num = 0;
            //try
            //{
            //    while (!nums.Contains(num))
            //    {
            //        Console.Write("enter: ");
            //        num = Convert.ToInt32(Console.ReadLine());
            //        nums.Add(num);
            //    }
            //}
            //catch(DuplicateWaitObjectException)
            //{
            //    Console.WriteLine("can't enter duplicates, try again");
            //}





        }
    }
}
