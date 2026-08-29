using SillyClicker.Models;

namespace SillyClicker.Domain;

internal class GameLayout
{
    private readonly IReadOnlyList<BoxPosition> _boxPositions;
    private readonly int _correctBoxIndex;
    /// <summary>
    /// Total number of boxes in this layout.
    /// </summary>
    internal int BoxCount => _boxPositions.Count;

    
    private GameLayout(IReadOnlyList<BoxPosition> boxPositions, int correctBoxIndex)
    {
        _boxPositions = boxPositions;
        _correctBoxIndex = correctBoxIndex;
    }

    /// <summary>
    /// Creates a new <see cref="GameLayout"/> after validating that the box list
    /// and correct box index describe a legal layout.
    /// </summary>
    /// <param name="boxPositions">The fixed position of every box in the layout. Must contain at least two.</param>
    /// <param name="correctBoxIndex">The index within <paramref name="boxPositions"/> of the box that wins the round.</param>
    /// <returns>A fully validated, immutable <see cref="GameLayout"/>.</returns>
    /// <exception cref="ArgumentException">Throws when <paramref name="boxPositions"/> contains fewer than two boxes.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Throws when <paramref name="correctBoxIndex"/> does not point to a valid
    /// box in <paramref name="boxPositions"/>.</exception>
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

    /// <summary>
    /// Checks whether the box at the given index is the winning box of this layout.
    /// </summary>
    /// <param name="boxIndex">The index of the box to check.</param>
    /// <returns>True if <paramref name="boxIndex"/> is the correct box. Else, False.</returns>
    internal bool IsCorrectBox(int boxIndex)
    {
        return boxIndex == _correctBoxIndex;
    }

    /// <summary>
    /// Checks whether the winning box has already been clicked, based on the given clicked-box bitmask.
    /// </summary>
    /// <param name="clickedMask">A bitmask representing every box clicked so far, one bit per box index.</param>
    /// <returns>True if the winning box is set in <paramref name="clickedMask"/>. Else, false.</returns>
    internal bool IsWinningMask(int clickedMask)
    {
        var bitAtCorrectBox = clickedMask & (1 << _correctBoxIndex);
        
        return bitAtCorrectBox != 0;
    }

    /// <summary>
    /// Gets the position of a single box within this layout.
    /// </summary>
    /// <param name="boxIndex">The index of the box to retrieve.</param>
    /// <returns>The <see cref="BoxPosition"/> at <paramref name="boxIndex"/>.</returns>
    internal BoxPosition GetBox(int boxIndex) => _boxPositions[boxIndex];
}