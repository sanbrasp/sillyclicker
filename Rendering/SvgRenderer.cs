using System.Text;
using SillyClicker.Domain;

namespace SillyClicker.Rendering;

internal class SvgRenderer
{
    /// <summary>
    /// Renders a <see cref="GameLayout"/> and its current <see cref="GameState"/> as a static SVG image,
    /// drawing each box in a different color depending on whether it has been clicked.
    /// </summary>
    /// <param name="layout">The layout describing where each box sits on the canvas.</param>
    /// <param name="gameState">The current state, used to determine which boxes have been clicked.</param>
    /// <returns>A complete SVG document as a string, ready to be saved to a file or served as an image.</returns>
    internal string Render(GameLayout layout, GameState gameState)
    {
        var sb = new StringBuilder();

        sb.Append("<svg width=\"600\" height=\"200\" xmlns=\"http://www.w3.org/2000/svg\">");

        for (int i = 0; i < layout.BoxCount; i++)
        {
            var box = layout.GetBox(i);
            
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