using System;
using System.Text.RegularExpressions;

namespace StringReplacementChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // PrimaryChallenge();
            BonusChallenge();

            Console.ReadLine();
        }

        private static void PrimaryChallenge()
        {
            List<string> primaryLines = File.ReadAllLines(@"C:\Users\Jeff's PC\source\repos\StringReplacementChallenge\StringReplacementChallenge\primary.txt").ToList();

            Console.Write("Please give me the text to replace: ");
            string toReplace = Console.ReadLine();

            Console.Write("Please give me the replacement text: ");
            string replacementText = Console.ReadLine();


            /*
             * foreach operates on an IEnumerable, and it does not allow you to modify the collection you're iterating over. In other words, you can't change the elements of the collection inside a foreach loop because the loop is designed to provide read-only access to the collection.
             * 
             * foreach (string line in primaryLines)
                {
                    line = line.Replace(toReplace, replacementText); // This won't work
                }

             * This code won't work because line is a local variable inside the loop, and modifying it doesn't change the corresponding element in the primaryLines list.
             * 
             * 
             * The for loop works because you're accessing the elements of the list by index and directly modifying them. This is a common pattern when you need to modify the elements of a collection while iterating over it.
             */
            for (int i = 0; i < primaryLines.Count; i++)
            {

                primaryLines[i] = primaryLines[i].Replace(toReplace, replacementText);
            }

            // if this wasn't a demo application, we'd be storing this in a variable or pulling it from an app.config file
            File.WriteAllLines(@"C:\Users\Jeff's PC\source\repos\StringReplacementChallenge\StringReplacementChallenge\primary.txt", primaryLines);

            Console.WriteLine("Text updated.");

            Console.ReadLine();
        }

        private static void BonusChallenge()
        {
            string bonusText = File.ReadAllText(@"C:\Users\Jeff's PC\source\repos\StringReplacementChallenge\StringReplacementChallenge\bonus.txt");

            

            // {FirstName}
            var results = Regex.Matches(bonusText, @"{[^{}]+}")
                // .Cast<Match>() converts the collection of matches to an enumerable sequence of Match objects.
                // Match object represents the result of a single successful pattern match within a string.
                .Cast<Match>()
                // takes each match and extracts the value inside the curly braces by using the Substring method. It removes the opening and closing curly braces, leaving just the text inside (e.g., FirstName from {FirstName}).
                .Select(x => x.Value.Substring(1, x.Value.Length -2))
                // converts the resulting sequence of strings into a HashSet<string>, which is a collection that contains no duplicate elements.
                .ToHashSet();

            foreach(var result in results)
            {
                Console.Write($"Please give me the value for {result}: ");
                bonusText = bonusText.Replace("{" + result + "}", Console.ReadLine());
            }

            File.WriteAllText(@"C:\Users\Jeff's PC\source\repos\StringReplacementChallenge\StringReplacementChallenge\bonus.txt", bonusText);

            Console.WriteLine("Text file updated");
        }
    }
}

