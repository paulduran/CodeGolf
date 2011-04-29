using System.Collections.Generic;

namespace CodeGolf.NestedBoxes
{
    public interface IBoxItem
    {
        IEnumerable<string> Render(int size);
        int MaxLength { get; }
    }
}