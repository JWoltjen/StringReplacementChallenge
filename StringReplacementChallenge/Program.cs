using System;

namespace StringReplacementChallenge
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
