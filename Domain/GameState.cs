namespace SillyClicker.Domain;

internal class GameState
{
    internal string LayoutId { get; }
    internal int ClickedMask { get; }
    internal int MissCount { get; }
    
    private GameState(string layoutId, int clickedMask, int missCount)
    {
        LayoutId = layoutId;
        ClickedMask = clickedMask;
        MissCount = missCount;
    }

    
    internal static GameState Initial(string layoutId)
    {
        return new GameState(layoutId, clickedMask: 0, missCount: 0);
    }

    internal GameState ApplyClick(GameLayout layout, int boxIndex)
    {
        var newMask = ClickedMask | (1 << boxIndex);
        var newMissCount = layout.IsCorrectBox(boxIndex) ? MissCount : MissCount + 1;

        return new GameState(LayoutId, newMask, newMissCount);
    }

    internal bool IsBoxClicked(int boxIndex)
    {
        var bitAtIndex = ClickedMask & (1 << boxIndex);
        
        return bitAtIndex != 0;
    }

    internal bool IsLoss => MissCount >= 3;

    internal bool IsWin(GameLayout layout, int boxIndex)
    {
        return layout.IsCorrectBox(boxIndex);
    }
}
