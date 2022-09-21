using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Lab1{ 
    internal class Program{        
        static IList<string> words = new List<string>();     
        static void Main(string[] args)
        {              
            bool choice = true;
            //Creating a menu for user to select an option
            while (choice){
                Console.WriteLine("1 - Import Words from File");
                Console.WriteLine("2 - Bubble Sort words");
                Console.WriteLine("3 - LINQ/Lambda sort words");
                Console.WriteLine("4 - Count the Distinct Words");
                Console.WriteLine("5 - Take the first 10 words");
                Console.WriteLine("6 - Get the number of words that start with 'j' and display the count");
                Console.WriteLine("7 - Get and display of words that end with 'd' and display the count");
                Console.WriteLine("8 - Get and display of words that are greater than 4 characters long, and display the count");
                Console.WriteLine("9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count");
                Console.WriteLine("x – Exit");
                Console.Write("Select an option: ");
                
                String? userChoice  = Console.ReadLine();
                
                switch (userChoice) { 

                    case "1":
                        Program.importWords();
                        break;
                    
                    case "2":
                        DateTime timeCase2 = DateTime.Now;
                        Program.BubbleSort(Program.words);   
                        Console.WriteLine("Time used to sort: " + (object)(DateTime.Now - timeCase2).Milliseconds + "ms");                       
                        break; 

                    case "3":    
                        DateTime timeCase3 = DateTime.Now;
                        Program.LINQSort(Program.words);   
                        Console.WriteLine("Time used to sort: " + (object)(DateTime.Now - timeCase3).Milliseconds + "ms");                       
                        break;                        

                    case "4":
                        Console.WriteLine("There are " + (object)Program.words.Distinct<string>().Count<string>() + " distinct words.");
                        break;

                    case "5":
                        Console.WriteLine("The first 10 words in the list are: ");
                        Program.printList(Program.words.Take<string>(10).ToList<string>());
                        break;

                    case "6":                        
                        Program.printList(Program.words.Where(w => w.StartsWith("j")).ToList<string>());
                        Console.WriteLine("There are "+ Program.words.Where(w => w.StartsWith("j")).Count<string>() + " words that start with 'j'.");
                        break;

                    case "7":
                        Program.printList(Program.words.Where(w => w.EndsWith("d")).ToList<string>());
                        Console.WriteLine("There are "+ Program.words.Where(w => w.EndsWith("d")).Count<string>() + " words that end with 'd'.");
                        break;

                    case "8":
                        Program.printList(Program.words.Where(w => w.Length > 4).ToList<string>());
                        Console.WriteLine("There are "+ Program.words.Where(w => w.Length > 4).ToList<string>().Count<string>() + " words that are greater than 4 characters long.");
                        break;

                    case "9":
                        Program.printList(Program.words.Where(w => w.Length < 3 && w.StartsWith("a")).ToList<string>());
                        Console.WriteLine("There are "+ Program.words.Where(w => w.Length < 3 && w.StartsWith("a")).Count<string>() + " that are less than 3 characters long and start with the letter ‘a’.");
                        break;

                    case "x":
                        choice = false;
                        break;

                    default:                        
                        Console.WriteLine("Invalid option");
                        Console.Write("Please make a valid selection.");
                        break;
                }
                Console.WriteLine();
                }
            }

        //Private method to import words from a text file

            private static void importWords(){
           
                using (StreamReader reader = new StreamReader("Words.txt")) {
                    string? wordsFromFile;
                    while ((wordsFromFile = reader.ReadLine()) != null) {
                        wordsFromFile = wordsFromFile.Trim();
                        Program.words.Add(wordsFromFile);                 
                     }
                }                
                Console.WriteLine("Finished reading words from the file.");
                Console.WriteLine("The number of words read from the file are: " + Program.words.Count() +" words.");
            }

        private static IList<string> LINQSort(IList<string> words){
            List<string>localWords  = words.ToList();
            localWords.Sort();            
            return localWords;
        }

        //Private method to pass a list as an argument and print the words on the console 
        private static void printList(List<string> words)
        {            
            if (words == null)
            {
                return;
            }
            foreach (string singleW in words)
            Console.WriteLine(singleW);
        }

        //Private method to bubble sort a list
       private static IList<string> BubbleSort(IList<string> words)
        {
            String[] array = words.ToArray();
            for (int i = 0; i < array.Length; ++i)
            {
                for (int i2 = 0; i2 < array.Length - 1 ; ++i2)
                {
                      if (array[i2 + 1].CompareTo(array[i2]) < 0)
                    {                     
                    string temp = array[i2];
                    array[i2] = array[i2 + 1];
                    array[i2 + 1] = temp;
                    }
                 }
            }           
             
             return array;
        }        
    }
}