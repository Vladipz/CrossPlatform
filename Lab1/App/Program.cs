using App;

internal class Program
{
    private static void Main(string[] args)
    {
        int x, y;
        try
        {
            (x, y) = IOHandler.ReadCoordinates();
            Console.WriteLine($"x: {x}, y: {y}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        int countOfRectangles;
        try
        {
            countOfRectangles = RectanglesService.GetCountOfRectangles(x, y);
            Console.WriteLine($"Count of rectangles: {countOfRectangles}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        try
        {
            IOHandler.WriteResult(countOfRectangles);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
    }
}
