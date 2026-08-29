using SillyClicker.Domain;
using SillyClicker.Models;
using SillyClicker.Sorting;


var layoutA = GameLayout.Create(MakeBoxes(6), correctBoxIndex: 0);
var layoutB = GameLayout.Create(MakeBoxes(4), correctBoxIndex: 0);
var layoutC = GameLayout.Create(MakeBoxes(5), correctBoxIndex: 0);

var layouts = new List<GameLayout> { layoutA, layoutB, layoutC };

LayoutSorter.SortByBoxCount(layouts);

foreach (var layout in layouts)
{
    Console.WriteLine(layout.BoxCount);
}

return;

List<BoxPosition> MakeBoxes(int count) =>
    Enumerable.Range(0, count)
        .Select(i => new BoxPosition(0, 0, 10, 10))
        .ToList();


// var layout = GameLayout.Create(
//     new List<BoxPosition>
//     {
//         new BoxPosition(20, 55, 85, 85),
//         new BoxPosition(115, 55, 85, 85),
//         new BoxPosition(210, 55, 85, 85),
//         new BoxPosition(305, 55, 85, 85),
//         new BoxPosition(400, 55, 85, 85),
//         new BoxPosition(495, 55, 85, 85),
//     },
//     correctBoxIndex: 3
// );

// var state = GameState.Initial("layout1");
// state = state.ApplyClick(layout, 0);
// var renderer = new SvgRenderer();
//
// string svg = renderer.Render(layout, state);
// Console.WriteLine(svg);   