using SillyClicker.Models;

namespace SillyClicker.Domain;

internal class GameLayout
{
    private readonly IReadOnlyList<BoxPosition> _boxPositions;
    private readonly int _correctBoxIndex;
    internal int BoxCount => _boxPositions.Count;

    
    private GameLayout(IReadOnlyList<BoxPosition> boxPositions, int correctBoxIndex)
    {
        _boxPositions = boxPositions;
        _correctBoxIndex = correctBoxIndex;
    }


    internal static GameLayout Create(IReadOnlyList<BoxPosition> boxPositions, int correctBoxIndex)
    {
        if (boxPositions.Count < 2) // Must be more than 1
        {
            throw new ArgumentException("Layout needs more than 1 box.");
        }

        if (correctBoxIndex < 0 || correctBoxIndex >= boxPositions.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(correctBoxIndex));
        }
        
        return new GameLayout(boxPositions, correctBoxIndex);
    }

    internal bool IsCorrectBox(int boxIndex)
    {
        return boxIndex == _correctBoxIndex;
    }

    internal bool IsWinningMask(int clickedMask)
    {
        var bitAtCorrectBox = clickedMask & (1 << _correctBoxIndex);
        
        return bitAtCorrectBox != 0;
    }
}