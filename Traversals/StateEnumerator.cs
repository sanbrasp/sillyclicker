using SillyClicker.Domain;

namespace SillyClicker.Traversals;

internal class StateEnumerator
{
    internal List<GameState> EnumerateAllStates(GameLayout layout, string layoutId)
    {
        var results = new List<GameState>();
        var queue =  new Queue<GameState>();
        
        queue.Enqueue(GameState.Initial(layoutId));

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            results.Add(current);

            if (current.IsLoss) //TODO: fix IsWin logic
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