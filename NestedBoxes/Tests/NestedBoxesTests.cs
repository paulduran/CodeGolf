using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace CodeGolf.NestedBoxes.Tests
{
    public class NestedBoxesTests
    {
        [Theory]
        [PropertyData("TestData")]
        public void TestBoxBuilderTests(string input, string expectedResult)
        {
            Box box = BoxBuilder.Build(input);
            string result = box.ToString();
            Assert.Equal(expectedResult, result);
            Console.Out.WriteLine(result);
        }
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[]
                             {
@"3
This is some text!
Oh, more text?
Just text for now, as this is a trivial example."
                                 ,
@".--------------------------------------------------.
| This is some text!                               |
| Oh, more text?                                   |
| Just text for now, as this is a trivial example. |
'--------------------------------------------------'
"
                             };

                yield return new object[]
                             {
@"4
Extreme
nesting
3
of
boxes
4
might
lead
to
2
interesting
1
visuals.
Indeed!"
                                 ,
@".--------------------------.
| Extreme                  |
| nesting                  |
| .----------------------. |
| | of                   | |
| | boxes                | |
| | .------------------. | |
| | | might            | | |
| | | lead             | | |
| | | to               | | |
| | | .--------------. | | |
| | | | interesting  | | | |
| | | | .----------. | | | |
| | | | | visuals. | | | | |
| | | | '----------' | | | |
| | | '--------------' | | |
| | '------------------' | |
| '----------------------' |
| Indeed!                  |
'--------------------------'
"
                             };
                yield return new object[]
                             {
@"1
1
1
1
1
Extreme nesting Part Two"
                            ,
@".------------------------------------------.
| .--------------------------------------. |
| | .----------------------------------. | |
| | | .------------------------------. | | |
| | | | .--------------------------. | | | |
| | | | | Extreme nesting Part Two | | | | |
| | | | '--------------------------' | | | |
| | | '------------------------------' | | |
| | '----------------------------------' | |
| '--------------------------------------' |
'------------------------------------------'
"
                             };

                yield return new object[]
                             {
@"3
Foo
2
Bar
Baz
2
Gak
1
Another foo?"
                            ,
@".----------------------.
| Foo                  |
| .------------------. |
| | Bar              | |
| | Baz              | |
| '------------------' |
| .------------------. |
| | Gak              | |
| | .--------------. | |
| | | Another foo? | | |
| | '--------------' | |
| '------------------' |
'----------------------'
"
                             };
            }
        }
    }
}
