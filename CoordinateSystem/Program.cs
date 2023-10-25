using CoordinateSystem;

class Program
{
    static void Main()
    {
        bool continueProcessing = false;

        int maxConsecutiveSteps = 3; // Allow up to 3 consecutive steps


        int pointX = 0; 
        int pointY = 0; 

        do
        {
            Console.Write("Enter the X point: ");
            var inputX = Console.ReadLine();

            Console.Write("Enter the Y point: ");
            var inputY = Console.ReadLine();

            if (int.TryParse(inputX, out pointX) && int.TryParse(inputY, out pointY))
            {
                var coordinateSystemPoints = new Point
                {
                    PointX = pointX,
                    PointY = pointY
                };

                int validPaths = CountValidPaths(coordinateSystemPoints.PointX, coordinateSystemPoints.PointY);
                Console.WriteLine("Number of valid paths: " + validPaths);

                if (validPaths > 0)
                {
                    Console.WriteLine("Routes for each valid path :");
                    List<string> routes = new List<string>();
                    FindValidRoutes(coordinateSystemPoints.PointX, coordinateSystemPoints.PointY, "", routes, 0, 0);
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

    static int CountValidPaths(int X, int Y)
    {
        if (X == 0 || Y == 0) //test
            return 1;

        return CountValidPaths(X - 1, Y) + CountValidPaths(X, Y - 1);
    }

    static void FindValidRoutes(int pointX, int pointY, string currentRoute, List<string> routes, int consecutiveEastSteps, int consecutiveNorthSteps)
    {
        if (pointX == 0 && pointY == 0)
        {
            routes.Add(currentRoute);
            return;
        }

        if (pointX > 0 && consecutiveEastSteps !=  3)
        {
            //if (currentRoute.Length < 2 || currentRoute.Substring(currentRoute.Length - 2) != "EE")
            //{
                FindValidRoutes(pointX - 1, pointY, currentRoute + "E", routes, consecutiveEastSteps + 1, 0);
            //}
        }

        if (pointY > 0 && consecutiveNorthSteps != 3)
        {
            //if (currentRoute.Length < 2 || currentRoute.Substring(currentRoute.Length - 2) != "NN")
            //{
                FindValidRoutes(pointX, pointY - 1, currentRoute + "N", routes, 0, consecutiveNorthSteps + 1);
            //}
        }
    }
}