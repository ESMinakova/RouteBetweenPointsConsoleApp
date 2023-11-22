// See https://aka.ms/new-console-template for more information

using RouteBetweenPointsConsoleApp;

var quantityCityNodes = Convert.ToInt32(Console.ReadLine());
var cityPairs = new List<string>();
for (int i = 0; i < quantityCityNodes; i++)
{
    cityPairs.Add(Console.ReadLine());
}

var cityNodes = cityPairs.Select(x => x.Split()).ToList();
RouteManager routeManager = new();
cityNodes.ForEach(x => routeManager.Paths.Add(new PathFromTo(x[0], x[1])));

var route = routeManager.CreateRoute();
routeManager.Print(route);