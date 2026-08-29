using SillyClicker.Domain;

namespace SillyClicker.Traversals;

internal class StateEnumerator
{
    /// <summary>
    /// Walks every reachable <see cref="GameState"/> for the given layout using a breadth-first search (BFS),
    /// starting from the initial state and stopping exploration at any win or loss.
    /// </summary>
    /// <param name="layout">The layout whose states should be enumerated.</param>
    /// <param name="layoutId">The identifier used to tag every generated state with its owning layout.</param>
    /// <returns>Every <see cref="GameState"/> reachable through legal play, including terminal win/loss states.</returns>
    internal List<GameState> EnumerateAllStates(GameLayout layout, string layoutId)
    {
        var results = new List<GameState>();
        var queue =  new Queue<GameState>();
        
        queue.Enqueue(GameState.Initial(layoutId));

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            results.Add(current);

            if (current.IsLoss || current.IsWin(layout))
            {
                continue;
            }
            
            for (int i = 0; i < layout.BoxCount; i++)
            {
                if (!current.IsBoxClicked(i))
                {
                    var next = current.ApplyClick(layout, i);
                    queue.Enqueue(next);
                }
            }
        }
        return results;
    }
}