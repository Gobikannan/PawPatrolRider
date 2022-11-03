using PawPatrolRider.Services;
// ReSharper disable StringLiteralTypo

namespace PawPatrolRider.Tests;

public class RiderOnMoveServiceTests
{
    [Theory]
    [InlineData(5, 5, "FFRFLFLF", "1,4,West")]
    [InlineData(1, 5, "FFRFLFLF", "1,4,West")]
    [InlineData(5, 1, "FFRFLFLF", "1,1,West")]
    [InlineData(3, 4, "FFRFRFF", "2,1,South")]
    [InlineData(6, 6, "FFRFLFF", "2,5,North")]
    [InlineData(5, 3, "RRF", "1,1,South")]
    [InlineData(4, 4, "RFFFF", "4,1,East")]
    [InlineData(4, 4, "RFFFFL", "4,1,North")]
    [InlineData(4, 4, "LFFF", "1,1,West")]
    [InlineData(10, 10, "FRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRF", "10,10,East")]
    [InlineData(100, 100, "LFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRRFLFRFFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRRFLFRFFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFRLFFRRFFFRFLFRFFFRFLFLFLFRFLFRFLFRFLFFFRFLFFRFLFRFLFRFLFRFFLFFRFLFRFLFRFLFRFR", "18,8,North")]
    public void NavigateAndReturnPositionTests(int xMax, int yMax, string directions, string output)
    {
        var riderOnMoveService = new RiderOnMoveService();

        var riderFinalPosition = riderOnMoveService.NavigateAndReturnPosition(xMax, yMax, directions);
        
        Assert.Equal(output, $"{riderFinalPosition.X},{riderFinalPosition.Y},{riderFinalPosition.Direction}");
    }
}
