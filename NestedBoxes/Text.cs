using System.Collections.Generic;

namespace CodeGolf.NestedBoxes
{
    public class Text : IBoxItem
    {
        private readonly string message;

        public Text(string message)
        {
            this.message = message;
        }
        
        public IEnumerable<string> Render(int size)
        {
            return new[] { message };
        }

        public int MaxLength
        {
            get { return message.Length; }
        }
    }
}
