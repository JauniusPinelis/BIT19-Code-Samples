namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // Data types
            int number = 5;
            string text = "Text" + " Test";
            char singleChar = 'A';
            bool boolValue = false;
            double doubleValue = 5.432;

            var arrayOfInts2 = new List<int> { 1, 2, 3, 4, 5 };

            // Console commands



            // String manipulation example: 5 + 4, 4 - 5;

            ////Get first two number
            //consoleInput.Substring(0, 2);

            ////Get first number
            //consoleInput.FirstOrDefault();




            //// forloop
            //for (int i = 0; i < consoleElements.Length; i++)
            //{
            //    Console.WriteLine(consoleElements[i]);
            //}

            ////forEach loop
            //foreach (var consoleElement in consoleElements)
            //{
            //    Console.WriteLine(consoleElement);
            //}

            var isFinished = false;

            while (!isFinished)
            {
                Console.WriteLine("Enter your input or enter 'Exit' to exit");

                var consoleInput = Console.ReadLine();

                if (consoleInput == "Exit")
                {
                    isFinished = true;
                }
                else
                {
                    var consoleElements = consoleInput.Split(" ");

                    // try/catch
                    try
                    {
                        var firstInput = consoleElements[0];
                        var mathOperator = consoleElements[1];
                        var secondInput = consoleElements[2];

                        var firstNumber = Convert.ToInt32(firstInput);
                        var secondNumber = Convert.ToInt32(consoleElements[2]);

                        // if statements 
                        if (mathOperator == "+")
                        {
                            Console.WriteLine(firstNumber + secondNumber);
                        }
                        if (mathOperator == "-")
                        {
                            Console.WriteLine(firstNumber - secondNumber);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The input is incorrectly formatted");
                    }
                }

                // Split string into smaller string by spaces

            }
        }
    }
}