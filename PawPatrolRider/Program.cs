using PawPatrolRider.Services;

try
{
    Console.WriteLine("Enter grid size (eg., 5x5, 3x4, etc):");
    var dimensionInput = Console.ReadLine();

    var dimension = dimensionInput.Split('x');

    Console.WriteLine("Enter commands (eg., FFRFLFLF):");
    var directions = Console.ReadLine();

    var riderOnMoveService = new RiderOnMoveService();
    var riderFinalPosition = riderOnMoveService.NavigateAndReturnPosition(int.Parse(dimension[0]), int.Parse(dimension[1]), directions);

    Console.WriteLine($"Final Position: {riderFinalPosition.X},{riderFinalPosition.Y},{riderFinalPosition.Direction}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Enter any key to exit..");
    Console.ReadLine();
}
