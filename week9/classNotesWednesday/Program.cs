namespace warriorGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            
            int result;
            bool success = keyValuePairs.TryGetValue("Thing", out result);

            keyValuePairs["Thing"] = 2;

            
            keyValuePairs.Remove("Cat");

            Console.WriteLine(keyValuePairs["Thing"]);
        }
    }
}
