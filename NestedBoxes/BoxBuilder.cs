using System;
using System.Collections.Generic;
using System.IO;

namespace CodeGolf.NestedBoxes
{
    public class BoxBuilder
    {
        public static Box Build(string input)
        {
            StringReader reader = new StringReader(input);
            int numItems = Convert.ToInt32(reader.ReadLine());
            return BuildBox(numItems, reader);
        }

        private static Box BuildBox(int numItems, StringReader reader)
        {
            List<IBoxItem> items = new List<IBoxItem>();
            for (int i = 0; i < numItems; i++)
            {
                string line = reader.ReadLine();
                int count;
                if (int.TryParse(line, out count))
                {
                    items.Add(BuildBox(count, reader));
                }
                else
                    items.Add(new Text(line));
            }
            return new Box(items);
        }
    }
}