using SillyClicker.Domain;
using SillyClicker.Models;
using SillyClicker.Rendering;

var layout = GameLayout.Create(
    new List<BoxPosition>
    {
        new BoxPosition(20, 55, 85, 85),
        new BoxPosition(115, 55, 85, 85),
        new BoxPosition(210, 55, 85, 85),
        new BoxPosition(305, 55, 85, 85),
        new BoxPosition(400, 55, 85, 85),
        new BoxPosition(495, 55, 85, 85),
    },
    correctBoxIndex: 3
);

var state = GameState.Initial("layout1");
state = state.ApplyClick(layout, 0);
var renderer = new SvgRenderer();



string svg = renderer.Render(layout, state);
Console.WriteLine(svg);   