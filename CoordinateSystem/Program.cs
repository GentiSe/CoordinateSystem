class Program
{
    static void Main()
    {
        int X = 0;
        int Y = 7;

        int validPaths = CountValidPaths(X, Y);
        Console.WriteLine("Number of valid paths: " + validPaths);

        if (validPaths > 0)
        {
            Console.WriteLine("Routes for each valid path (Optional):");
            List<string> routes = new List<string>();
            FindValidRoutes(X, Y, "", routes);
            foreach (var route in routes)
            {
                Console.WriteLine(route);
            }
        }
    }

    static int CountValidPaths(int X, int Y)
    {
        if (X == 0 || Y == 0) //test
            return 1;

        return CountValidPaths(X - 1, Y) + CountValidPaths(X, Y - 1);
    }

    static void FindValidRoutes(int X, int Y, string currentRoute, List<string> routes)
    {
        if (X == 0 && Y == 0)
        {
            routes.Add(currentRoute);
            return;
        }

        if (X > 0)
        {
            if (currentRoute.Length < 2 || currentRoute.Substring(currentRoute.Length - 2) != "EE")
            {
                FindValidRoutes(X - 1, Y, currentRoute + "E", routes);
            }
        }

        if (Y > 0)
        {
            if (currentRoute.Length < 2 || currentRoute.Substring(currentRoute.Length - 2) != "NN")
            {
                FindValidRoutes(X, Y - 1, currentRoute + "N", routes);
            }
        }
    }
}