namespace RouteBetweenPointsConsoleApp
{
    internal class PathFromTo
    {
        public string From { get; set; }
        public string To { get; set; }

        public PathFromTo(string from, string to)
        {
            From = from;
            To = to;
        }
    }
}
