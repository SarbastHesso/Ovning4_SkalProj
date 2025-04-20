using System;
using System.Diagnostics.Metrics;
using System.Xml.XPath;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        /// 

        //1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion
            //Stack: sparar små värden direkt i minnet, t.ex. int, bool, double, char.
            //Exempel: int num = 5;
            //Heap: sparar större objekt som class, array, List, string.
            //Exempel: Car volvo = new Car();

        //2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
            //Value Types sparar värdet direkt i stacken.t.ex. int, bool, double, char
            //Reference Types sparar en referens(pekare) till datan som ligger i heapen. t.ex. class, array, List, string.

        //3. Följande metoder(se bild nedan) genererar olika svar.Den första returnerar 3, den andra returnerar 4, varför?
            //för att x i den första är en valu type, alltså den sparar direkt och har ingen referens att påverkas på. medan i den andra är en class som är referens type och värdet ändras beroende referensen. 



        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        #region ExamineList
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}

            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting:"
                    + "\n+. Type + followed by some text to add the text"
                    + "\n-. Type - followed by some text to remove the text"
                    + "\nB. To back to the main menu");

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                    continue;
                }

                char nav = char.ToUpper(input[0]);

                if (input.Length < 2 && nav != 'B')
                {
                    Console.WriteLine("Please provide at least one character after + or -.");
                    continue;
                }

                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        break;
                    case '-':
                        theList.Remove(value);
                        break;
                    case 'B':
                        return;
                    default:
                        Console.WriteLine("Please use only + or - followed by a text or B to return to the main menu");
                        break;
                }

                Console.WriteLine($"Count: {theList.Count}, Capacity: {theList.Capacity}");


            }
            //2.När ökar listans kapacitet ? (Alltså den underliggande arrayens storlek)
            //Listans kapacitet ökar när antalet element blir större än nuvarande kapacitet.

            //3.Med hur mycket ökar kapaciteten?
            //Kapaciteten ökar med dubbelt 4 => 8

            //4.Varför ökar inte listans kapacitet i samma takt som element läggs till ?
            //För att undvika öka kapaciteten varje gång vi lägger en ny element, då den fördubblar den istället.

            //5.Minskar kapaciteten när element tas bort ur listan?
            //Nej

            //6.När är det då fördelaktigt att använda en egendefinierad array istället för en lista ?
            //När vi vet exakt hur många element vi kommer att ha.
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        #endregion


        #region ExamineQueue
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> icaQueue = new Queue<string>();

            void PrintQueue(Queue<string> queue)
            {
                Console.WriteLine("________ Queue list ________");
                if (queue.Count == 0)
                {
                    Console.WriteLine("The queue is empty.");
                }
                else
                {
                    foreach (string name in queue)
                    {
                        Console.WriteLine(name);
                    }
                }
            }

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting:"
                    + "\n+. Type + followed by name to enqueue the name"
                    + "\n-. Type - to dequeue the first name from the queue list"
                    + "\nB. To back to the main menu");

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                    continue;
                }

                char nav = char.ToUpper(input[0]);

                if (input.Length < 2 && nav != '-' && nav != 'B')
                {
                    Console.WriteLine("Please provide at least one character after +.");
                    continue;
                }

                string value = input.Substring(1);


                switch (nav)
                {
                    case '+':
                        icaQueue.Enqueue(value);
                        PrintQueue(icaQueue);
                        break;
                    case '-':
                        if (icaQueue.Count > 0)
                        {
                            icaQueue.Dequeue();
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty. Nothing to dequeue.");
                        }
                        PrintQueue(icaQueue);
                        break;
                    case 'B':
                        return;
                    default:
                        Console.WriteLine("Please use only + followed by a name, -  or B");
                        break;
                }


            }
        }
        #endregion


        #region ExamineStack
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            //Varför är det inte så smart att använda en stack i det här fallet?
            //En stack följer FILO(First In, Last Out) – vilket innebär att den sista personen i kön blir betjänad först och den första blir betjänad sist det stämmer inte med en riktig kö på Ica.


            Stack<string> icaQueue = new Stack<string>();


            void PrintQueue(Stack<string> queue)
            {
                Console.WriteLine("________ Queue list ________");
                if (queue.Count == 0)
                {
                    Console.WriteLine("The queue is empty.");
                }
                else
                {
                    foreach (string name in queue)
                    {
                        Console.WriteLine(name);
                    }
                }
            }

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting:"
                    + "\n+. Type + followed by name to add the name to the list"
                    + "\n-. Type - to remove the last name from the queue list"
                    + "\nR. Type R to enter some text to reverse"
                    + "\nB. To back to the main menu");

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                    continue;
                }

                char nav = char.ToUpper(input[0]);

                if (input.Length < 2 && nav != '-' && nav != 'B' && nav != 'R')
                {
                    Console.WriteLine("Please provide at least one character after +.");
                    continue;
                }

                string value = input.Substring(1);


                switch (nav)
                {
                    case '+':
                        icaQueue.Push(value);
                        PrintQueue(icaQueue);
                        break;
                    case '-':
                        if (icaQueue.Count > 0)
                        {
                            icaQueue.Pop();
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty. Nothing to remove.");
                        }
                        PrintQueue(icaQueue);
                        break;
                    case 'R':
                        ReserveText();
                        break;
                    case 'B':
                        return;
                    default:
                        Console.WriteLine("Please use only + followed by a name, -  or B");
                        break;
                }

                static void ReserveText()
                {
                    Console.WriteLine("Please enter a text (at least 2 characters) to reverse");
                    string input = Console.ReadLine();
                    Stack<char> reservedText = new Stack<char>();
                    if (input.Length < 2)
                    {
                        Console.WriteLine("Please provide at least 2 characters to reverse");
                    }

                    foreach (char c in input)
                    {
                        reservedText.Push(c);
                    }
                    while (reservedText.Count > 0)
                    {
                        Console.Write(reservedText.Pop());
                    }
                    Console.WriteLine();
                }
            }
        }
        #endregion


        #region CheckParanthesis
        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.WriteLine("Please enter some text with the different types of parentheses.");
            string input = Console.ReadLine();

            Stack<char> openedParentheses = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    openedParentheses.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (openedParentheses.Count == 0)
                    {
                        Console.WriteLine("Incorrect parentheses: Extra closing found.");
                        return;
                    }

                    char lastOpened = openedParentheses.Pop();

                    if (!IsMatching(lastOpened, c))
                    {
                        Console.WriteLine("Incorrect parentheses.");
                        return;
                    }
                }

            }

            bool IsMatching(char open, char close)
            {
                return (open == '(' && close == ')') ||
                       (open == '{' && close == '}') ||
                       (open == '[' && close == ']');
            }

            if (openedParentheses.Count == 0)
            {
                Console.WriteLine("Correct parentheses!");
            }
            else
            {
                Console.WriteLine("Incorrect parentheses: Some were not closed.");
            }

        }
        #endregion

    }
}

