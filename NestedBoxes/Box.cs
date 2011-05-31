using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGolf.NestedBoxes
{
    public class Box : IBoxItem
    {
        private const char VerticalEdge = '\u007c';
        private const char HorizontalEdge = '\u002d';
        private const char LowerCorner = '\u0027';
        private const char UpperCorner = '\u002e';

        private readonly IEnumerable<IBoxItem> boxItems;

        public Box(IEnumerable<IBoxItem> boxItems)
        {
            this.boxItems = boxItems;
        }

        public int MaxLength
        {
            get { return boxItems.Max(x => x.MaxLength) + 4; }
        }

        public IEnumerable<string> Render(int size)
        {
            int innerSize = size - 4;
            var renderedItems = new List<string>();
            foreach (IBoxItem boxItem in boxItems)
            {
                renderedItems.AddRange(boxItem.Render(innerSize));
            }
            yield return RenderHorizontalLine(size, UpperCorner);
            foreach (string renderedItem in renderedItems)
            {
                var line = new StringBuilder();
                line.Append(VerticalEdge);
                line.Append(' ');
                line.Append(renderedItem);
                line.Append(' ');
//                if (innerSize - renderedItem.Length > 0)
                    line.Append(' ', innerSize - renderedItem.Length);
                line.Append(VerticalEdge);
                yield return line.ToString();
            }
            yield return RenderHorizontalLine(size, LowerCorner);
        }

        public IEnumerable<string> Render()
        {
            return Render(MaxLength);
        }

        private static string RenderHorizontalLine(int maxLength, char corner)
        {
            var line = new StringBuilder();
            line.Append(corner);
            line.Append(HorizontalEdge, maxLength - 2);
            line.Append(corner);
            return line.ToString();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (string line in Render())
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }
    }
}