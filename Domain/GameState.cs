namespace SillyClicker.Domain;

internal class GameState
{
    /// <summary>
    /// The identifier of the <see cref="GameLayout"/> this state belongs to.
    /// </summary>
    internal string LayoutId { get; }
    /// <summary>
    /// A bitmask representing every box clicked so far, one bit per box index.
    /// </summary>
    internal int ClickedMask { get; }
    /// <summary>
    /// The number of incorrect clicks made so far.
    /// </summary>
    internal int MissCount { get; }
    
    
    private GameState(string layoutId, int clickedMask, int missCount)
    {
        LayoutId = layoutId;
        ClickedMask = clickedMask;
        MissCount = missCount;
    }

    
    /// <summary>
    /// Creates the starting state for a round on the given layout: nothing clicked, no misses.
    /// </summary>
    /// <param name="layoutId">The identifier of the layout this state belongs to.</param>
    /// <returns>A fresh <see cref="GameState"/> with an empty clicked mask and zero misses.</returns>
    internal static GameState Initial(string layoutId)
    {
        return new GameState(layoutId, clickedMask: 0, missCount: 0);
    }

    /// <summary>
    /// Produces a new <see cref="GameState"/> reflecting a click on the given box, updating the
    /// clicked mask and increasing the miss count if the click was wrong.
    /// </summary>
    /// <param name="layout">The layout used to determine whether the clicked box was correct.</param>
    /// <param name="boxIndex">The index of the box that was clicked.</param>
    /// <returns>A new <see cref="GameState"/> reflecting the click. The original state is left unchanged.</returns>
    internal GameState ApplyClick(GameLayout layout, int boxIndex)
    {
        var newMask = ClickedMask | (1 << boxIndex);
        var newMissCount = layout.IsCorrectBox(boxIndex) ? MissCount : MissCount + 1;

        return new GameState(LayoutId, newMask, newMissCount);
    }

    /// <summary>
    /// Checks whether the box at the given index has already been clicked in this state.
    /// </summary>
    /// <param name="boxIndex">The index of the box to check.</param>
    /// <returns>True if the box has been clicked. Otherwise, false.</returns>
    internal bool IsBoxClicked(int boxIndex)
    {
        var bitAtIndex = ClickedMask & (1 << boxIndex);
        
        return bitAtIndex != 0;
    }

    /// <summary>
    /// True once three or more incorrect clicks have been made.
    /// </summary>
    internal bool IsLoss => MissCount >= 3;

    /// <summary>
    /// Checks whether the winning box has already been clicked in this state.
    /// </summary>
    /// <param name="layout">The layout used to determine which box is the winning one.</param>
    /// <returns>True if the winning box has been clicked. Otherwise, false.</returns>
    internal bool IsWin(GameLayout layout) => layout.IsWinningMask(ClickedMask);
}
