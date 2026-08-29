using SillyClicker.Domain;

namespace SillyClicker.Sorting;

/// <summary>
/// Insertion Sort implementation because I want to.
/// </summary>
internal static class LayoutSorter
{
    internal static void SortByBoxCount(List<GameLayout> layouts)
    {
        for (int i = 1; i < layouts.Count; i++) // Starts at 1 because index 0 is trivially "already sorted"
        {
            var key = layouts[i];
            int j = i - 1;
            
            // while j >=0 AND layouts[j].BoxCount > key.BoxCount
            while (j >= 0 && layouts[j].BoxCount > key.BoxCount)
            {
                // - shift layouts[j] one position to the right (into layouts[ j + 1 ]
                layouts[j + 1] = layouts[j];
                // - decrement j
                j--;
            }
            // after the loop ends, insert 'key' into its correct resting spot
            layouts[j + 1] = key;
        }
    }
}