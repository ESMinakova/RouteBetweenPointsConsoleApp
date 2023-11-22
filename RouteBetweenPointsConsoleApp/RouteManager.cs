using System.Text;
using System.Xml.Linq;

namespace RouteBetweenPointsConsoleApp
{
    internal class RouteManager
    {
        public List<PathFromTo> Paths;

        public RouteManager()
        {
            Paths = new List<PathFromTo>();
        }

        public List<string> CreateRoute()
        {
            var startPoint = GetStartPoint();
            var visitedCities = VisitCity(Paths, startPoint);
   
            return visitedCities;
        }

        private List<string> VisitCity(List<PathFromTo> paths, string pathTo)
        {
            var visited = new List<string>();
            var stack = new Stack<string>();
            visited.Add(pathTo);
            stack.Push(pathTo);
            while (stack.Count != 0)
            {
                var city = stack.Pop();
                
                foreach (var path in paths.Where(n => n.From == city))
                {
                    visited.Add(path.To);
                    stack.Push(path.To);
                }
            }
            return visited;
        }
    

        public void Print(List<string> points)
        {
            var exceptEndPoints = points.Take(points.Count - 1).ToList();
            Console.Write("(");
            exceptEndPoints.ForEach(x => Console.Write($"{x}, "));
            Console.Write($"{points.Last()})");
        }

        public string GetStartPoint()
        {
            var startPoint = "";
            var isUnique = false;
            for (int i = 0; i < Paths.Count; i++)
            {
                for (int j = 0; j < Paths.Count; j++)
                {
                    if (Paths[i].From == Paths[j].To)
                    {
                        isUnique = false;
                        break;
                    }
                    isUnique = true;
                }
                if (isUnique) 
                    startPoint = Paths[i].From;
            }
            return startPoint;
        }

    }
}
