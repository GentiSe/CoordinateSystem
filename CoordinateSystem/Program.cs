using CoordinateSystem;

class Program
{
    static void Main()
    {
        bool continueProcessing = false;

        do
        {
            Console.Write("Enter the X point: ");
            var inputX = Console.ReadLine();

            Console.Write("Enter the Y point: ");
            var inputY = Console.ReadLine();

            if (int.TryParse(inputX, out var pointX) && int.TryParse(inputY, out var pointY))
            {

                int validPaths = CountValidPaths(pointX, pointY);

                Console.WriteLine("Number of valid paths: " + validPaths);

                if (validPaths > 0)
                {
                    Console.WriteLine("Routes for each valid path :");
                    var routes = new List<string>();

                    FindValidRoutes(pointX, pointY);
                    foreach (var route in routes)
                    {
                        Console.WriteLine(route);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter valid integer values for X and Y.");
            }


            Console.Write("Do you want to continue (y/n): ");
            string response = Console.ReadLine();

            if (!response.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                continueProcessing = false; // Set to false to exit the loop
            }
            else
            {
                continueProcessing = true; // Set to true to continue processing
            }

        } while (continueProcessing); //stay in the loop until the continueprocessing flag is set to false.

    }


    static int CountValidPaths(int pointX, int pointY)
    {
        if (pointX == 0 || pointY == 0) //test
            return 1;

        return CountValidPaths(pointX - 1, pointY) + CountValidPaths(pointX, pointY - 1);

    }

    static void FindValidRoutes(int pointX, int pointY)
    {
        var validRoutes = new List<string>();

        var stack = new Stack<(int, int, string)>();
        stack.Push((pointX, pointY, ""));

        var iteration = 0;
        while (stack.Count > 0)
        {
            iteration++;
            var (i, j, route) = stack.Pop();

            if (i == 0 && j == 0)
            {
                var routeContainsThreeConsecutiveSteps = CheckForThreeConsecutiveSteps(route);
                if (!routeContainsThreeConsecutiveSteps)
                {
                    validRoutes.Add(route);
                    continue;

                }
            }

            if (i > 0)
            {
                stack.Push((i - 1, j, route + "E"));
            }

            if (j > 0)
            {
                stack.Push((i, j - 1, route + "N"));
            }
        }

        Console.WriteLine("Number of valid routes: " + validRoutes.Count);
        Console.WriteLine("Valid routes: ");
        foreach (string route in validRoutes)
        {
            Console.WriteLine(route);
        }
    }

    static bool CheckForThreeConsecutiveSteps(string route)
    {
        int consecutiveCount = 1; 

        for (int i = 1; i < route.Length; ++i)
        {
            if (route[i] == route[i - 1]) // Check if next character is same as the current one.
            {
                consecutiveCount++;
                if (consecutiveCount == 3)
                {
                    if (i + 1 >= route.Length || route[i + 1] != route[i]) //Check if the next following character is the same as last one.
                    {
                        return true; // Found three consecutive characters without being broken then return true
                    }
                }
            }
            else
            {
                consecutiveCount = 1; // Reset the count
            }
        }

        return false; // return
    }


}