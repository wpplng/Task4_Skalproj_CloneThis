using System;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
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

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
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

            // 1.Skriv klart implementationen av ExamineList-metoden så att undersökningen blir genomförbar.
            // Svar: Implementerad nedan.

            // 2.När ökar listans kapacitet ? (Alltså den underliggande arrayens storlek)
            // Svar: Listans kapacitet får ett värde när listan skapas. Den ökas sedan när antalet element
            // överstiger den nuvarande kapaciteten. En ny större array skapas.

            // 3.Med hur mycket ökar kapaciteten?
            // Svar: Kapaciteten ökar med det dubbla värdet av den nuvarande kapaciteten när den överskrids.
            // Om kapaciteten är 4, blir den 8 när den ökas.

            // 4.Varför ökar inte listans kapacitet i samma takt som element läggs till?
            // Svar: Det vore ineffektivt att öka kapaciteten med varje nytt element, eftersom det skulle
            // leda till många minnesallokeringar. Att göra det i större steg (t.ex. dubbla kapaciteten)
            // minskar antalet allokeringar och förbättrar prestandan.

            // 5.Minskar kapaciteten när element tas bort ur listan?
            // Svar: Nej, kapaciteten minskar inte automatiskt när element tas bort.

            // 6.När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
            // Svar: Det är fördelaktigt att använda en egendefinierad array när man har en fast storlek på datamängden,
            // dvs när man vet antalet element i förväg.

            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine("Enter +Name to add or -Name to remove. Enter 0 to return to main menu.");
                string input = Console.ReadLine() ?? string.Empty;

                if (input == "0") break; // Exit to main menu
                if (string.IsNullOrEmpty(input) || input.Length < 2)
                {
                    Console.WriteLine("Invalid input. Please enter +Name or -Name.");
                    continue;
                }

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Added '{value}' to the list. Count: {theList.Count}, Capacity: {theList.Capacity}");
                        break;
                    case '-':
                        if (theList.Remove(value))
                        {
                            Console.WriteLine($"Removed '{value}' from the list. Count: {theList.Count}, Capacity: {theList.Capacity}");
                        }
                        else
                        {
                            Console.WriteLine($"'{value}' not found in the list.");
                        }
                        break;
                    default:
                        Console.WriteLine("Please use '+' to add or '-' to remove items from the list.");
                        break;
                }

            }
           
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Queue<string> theQueue = new Queue<string>();

            while (true)
            {
                Console.WriteLine("Enter +Name to enqueue or - to dequeue. Enter 0 to return to main menu.");
                string input = Console.ReadLine() ?? string.Empty;

                if (input == "0") break;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid input. Please enter +Name or -.");
                    continue;
                }

                char nav = input[0];

                switch (nav)
                {
                    case '+':
                        if(input.Length < 2)
                        {
                            Console.WriteLine("Please provide a value to enqueue.");
                            continue;
                        }

                        string value = input.Substring(1).Trim(); // Get the rest of the input after the first character
                        theQueue.Enqueue(value);
                        Console.WriteLine($"Enqueued '{value}'. Count: {theQueue.Count}");
                        Console.WriteLine($"Queue contents: {string.Join(", ", theQueue)}");
                        break;
                    case '-':
                        if (theQueue.Count > 0)
                        {
                            string dequeuedValue = theQueue.Dequeue();
                            Console.WriteLine($"Dequeued '{dequeuedValue}'. Count: {theQueue.Count}");
                            Console.WriteLine($"Queue contents: {string.Join(", ", theQueue)}");
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty, nothing to dequeue.");
                        }
                        break;
                    default:
                        Console.WriteLine("Please use '+' to enqueue or '-' to dequeue items from the queue.");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            // 1.Simulera ännu en gång ICA-kön på papper. Denna gång med en stack.
            // Varför är det inte så smart att använda en stack i det här fallet?
            // Svar: Eftersom en stack är LIFO (Last In, First Out) så skulle den inte fungera bra för en kö där.
            // Den som kommer sist till kön blir först att betjänas.

            // 2.Implementera en ReverseText-metod som läser in en sträng från användaren och med hjälp av en stack
            // vänder ordning på teckenföljden för att sedan skriva ut den omvända strängen till användaren.
            // Svar: Se implementering nedan

            Stack<string> theStack = new Stack<string>();

            while (true)
            {
                Console.WriteLine("Enter +Name to push or - to pop. Enter x for reverse text. Enter 0 to return to main menu.");
                string input = Console.ReadLine() ?? string.Empty;

                if (input == "0") break;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid input. Please enter +Name or -.");
                    continue;
                }

                char nav = input[0];

                switch (nav)
                {
                    case '+':
                        if(input.Length < 2)
                        {
                            Console.WriteLine("Please provide a value to push.");
                            continue;
                        }
                        string value = input.Substring(1).Trim(); // Get the rest of the input after the first character
                        theStack.Push(value);
                        Console.WriteLine($"Pushed '{value}' onto the stack. Count: {theStack.Count}");
                        Console.WriteLine($"Stack contents: {string.Join(", ", theStack)}");
                        break;
                    case '-':
                        if (theStack.Count > 0)
                        {
                            string poppedValue = theStack.Pop();
                            Console.WriteLine($"Popped '{poppedValue}' from the stack. Count: {theStack.Count}");
                            Console.WriteLine($"Stack contents: {string.Join(", ", theStack)}");
                        }
                        else
                        {
                            Console.WriteLine("Stack is empty, nothing to pop.");
                        }
                        break;
                    case 'x':
                        ReverseText();
                        break;
                    default:
                        Console.WriteLine("Please use '+' to push or '-' to pop items from the stack, or x to reverse text.");
                        break;
                }
            }
        }

        static void ReverseText()
        {
            Console.WriteLine("Enter a text to reverse:");
            string input = Console.ReadLine() ?? string.Empty; 
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("No text provided to reverse.");
                return;
            }

            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                stack.Push(c);
            }

            Console.Write("Reversed: ");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            // 1.Skapa med hjälp av er nya kunskap funktionalitet för att kontrollera en välformad sträng på papper.
            // Du ska använda dig av någon eller några av de datastrukturer vi precis gått igenom.Vilken datastruktur använder du?
            // Svar: Jag använder en stack för att kontrollera välformade parenteser, eftersom den följer LIFO-principen.

            // 2.Implementera funktionaliteten i metoden CheckParentheses. Låt programmet läsa in en sträng från användaren och
            // returnera ett svar som reflekterar huruvida strängen är välformad eller ej.
            // Svar: Se implementering nedan

            Console.WriteLine("Enter a string to check for balanced parentheses:");
            string input = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("No input provided.");
                return;
            }

            Stack<char> stack = new Stack<char>();
            bool isBalanced = true;

            foreach (char c in input)
            { 
                // om öppnande parantes, lägg till i stacken
                if(c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                // om stängande parantes - kolla om stacken innehåller något isf gör en kontroll om de matchar
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }
                    char top = stack.Pop();
                    if ((c == ')' && top != '(') ||
                        (c == '}' && top != '{') ||
                        (c == ']' && top != '['))
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            // om stacken fortfarande innehåller något är den inte balanserad
            if (stack.Count > 0)
            {
                isBalanced = false ; 
            }

            Console.WriteLine(isBalanced ? "The parantheses in the string is balanced" : "The parantheses is not balanced.");
        }
    }
}

//Frågor:
// 1.Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion.
// Svar: Stacken är en minnesstruktur som lagrar data i en LIFO-ordning (Last In, First Out). Den används för att lagra lokala
// variabler och funktionsanrop. Den kan ses som en mängd boxar som är staplade på varandra.
// Heap är en annan minnesstruktur, en trädstruktur, som används för dynamisk minnesallokering. Det är en struktur där allt är tillgängligt
// på en gång och med enkel åtkomst där objekt kan skapas och förstöras under programmets gång. Stacken har en fast storlek medan heapen kan
// växa och krympa dynamiskt.

// 2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
// Svar: Value Types är datatyper som lagrar värden direkt där de deklareras (t.ex. int, float, bool). De kan lagras både på stacken och
// heapen beroende på var de deklareras. Reference Types är datatyper som alltid lagras på heapen och innehåller en referens till objektet
// i heapen (t.ex. string, class, object). Det som skiljer dem åt är att Value Types lagrar värdet direkt medan Reference Types lagrar en referens.

// 3. Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?
// Svar: Den första metoden returnerar 3 eftersom den returnerar värdet av x som är 3. y sätts till värdet av x men x förändras aldrig.
// Den andra metoden returnerar 4 eftersom den skapas som en referens till x. När y ändras till 4, ändras även x eftersom de refererar till
// samma minnesadress då de sätts till samma objekt genom y = x. Det första exemplet är en value type (int) och det andra är en reference type (object).

