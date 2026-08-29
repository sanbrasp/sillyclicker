using System.Text;
using SillyClicker.Domain;

namespace SillyClicker.Rendering;

internal class SvgRenderer
{
    internal string Render(GameLayout layout, GameState gameState)
    {
        var sb = new StringBuilder();

        sb.Append("<svg width=\"600\" height=\"200\" xmlns=\"http://www.w3.org/2000/svg\">");

        for (int i = 0; i < layout.BoxCount; i++)
        {
            var box = layout.GetBox(i);
            
            // TODO: decide on a fill color based on gameState.IsBoxClicked(i)
            // something like: string fill = ?? ? "some color" : "some other color";
            string clickedBoxColor = "green";
            string unclickedBoxColor = "gray";
            
            string fill = gameState.IsBoxClicked(i) ? clickedBoxColor : unclickedBoxColor;
            
            sb.Append(
                $"<rect x=\"{box.X}\" y=\"{box.Y}\" width=\"{box.Width}\" height=\"{box.Height}\" fill=\"{fill}\" />");
        }
        sb.Append("</svg>");
        return sb.ToString();
    }
}