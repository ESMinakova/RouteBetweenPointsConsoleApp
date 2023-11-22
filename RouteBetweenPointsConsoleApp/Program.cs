// See https://aka.ms/new-console-template for more information

using RouteBetweenPointsConsoleApp;


var inputData = Console.ReadLine(); // Вводятся данные формата "((‘Москва’, ‘Тюмень’), (‘Тюмень’, ‘Сочи’), (‘Ростов - на - Дону’, ‘Москва’))"
var routeList = inputData.Split(')', StringSplitOptions.RemoveEmptyEntries).ToList();
var pointsList = routeList.Select(x => x.Trim(new char[] {',', '(', ' '}))
    .Select(x => x.Split(','))
    .Select(x => x.Select(y => y.Trim()).ToList())
    .ToList();

RouteManager routeManager = new();
pointsList.ForEach(x => routeManager.Paths.Add(new PathFromTo(x[0], x[1])));

var route = routeManager.CreateRoute();
routeManager.Print(route);