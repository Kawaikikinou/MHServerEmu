using MHServerEmu.Core.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHServerEmu.Core.Tests.Collections
{
    public class BitListTests
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 6)]
        [InlineData(100, 101)]
        [InlineData(153, 154)]
        public void ExpandBitList_int_ReturnsExpectedValue(int value, int expectedValue)
        {
            BitList bitList = new();
            bitList.Expand(value);
            Assert.Equal(expectedValue, bitList.Size);
        }

        public static IEnumerable<object[]> SetBitList =>
            new List<object[]>
            {
                new object[] { null, 1, true, new List<bool> { false, true }},
                new object[] { null, 0, true, new List<bool> { true }},
                new object[] { null, 10, true, new List<bool> { false, false, false, false, false, false, false, false, false, false, true }},
                new object[] { new List<bool> { true, false }, 7, true, new List<bool> { true, false, false, false, false, false, false, true }},
                new object[] { new List<bool> { false, false, false, false, true }, 3, true, new List<bool> { false, false, false, true, true }},
                new object[] { new List<bool> { true, true, true, true, true }, 3, false, new List<bool> { true, true, true, false, true }},
                new object[] { new List<bool> { true}, 8, false, new List<bool> { true, false, false, false, false, false, false, false, false } },
            };

        [Theory]
        [MemberData(nameof(SetBitList))]
        public void SetBitList_int_int_ReturnsExpectedValue(List<bool> start, int index, bool value, List<bool> expectedValue)
        {
            BitList bitList = new();
            if(start != null)
                bitList = new(start);

            bitList.Set(index, value);
            Assert.Equal(expectedValue, bitList.Content);
        }

        public static IEnumerable<object[]> ResetBitList =>
            new List<object[]>
            {
                new object[] { null, 1, new List<bool> { false, false }},
                new object[] { null, 0, new List<bool> { false } },
                new object[] { null, 10, new List<bool> { false, false, false, false, false, false, false, false, false, false, false } },
                new object[] { new List<bool> { true, false }, 7, new List<bool> { true, false, false, false, false, false, false, false } },
                new object[] { new List<bool> { false, false, false, false, true }, 3, new List<bool> { false, false, false, false, true } },
                new object[] { new List<bool> { true, true, true, true, true }, 3, new List<bool> { true, true, true, false, true }},
                new object[] { new List<bool> { true}, 8, new List<bool> { true, false, false, false, false, false, false, false, false } },
            };

        [Theory]
        [MemberData(nameof(ResetBitList))]
        public void ResetBitList_int_int_ReturnsExpectedValue(List<bool> start, int index, List<bool> expectedValue)
        {
            BitList bitList = new();
            if (start != null)
                bitList = new(start);

            bitList.Reset(index);
            Assert.Equal(expectedValue, bitList.Content);
        }

        public static IEnumerable<object[]> AndOperatorBitList =>
            new List<object[]>
            {
                new object[] { new List<bool> { false, false }, new List<bool> { true, true }, new List<bool> { false, false }},
                new object[] { new List<bool> { true, false }, new List<bool> { true, true }, new List<bool> { true, false }},
                new object[] { new List<bool> { true, true, true }, new List<bool> { true, true , false}, new List<bool> { true, true, false } },
                new object[] { new List<bool> { true }, new List<bool> { true, true , false}, new List<bool> { true, false, false } },
                new object[] { new List<bool> { true, false, false, true, true }, new List<bool> { true, true , false}, new List<bool> { true, false, false, true, true } },
                new object[] { new List<bool> { true, true, true }, new List<bool> { true, true , false, false, false, false, false }, new List<bool> { true, true, false, false, false, false, false } },
            };

        [Theory]
        [MemberData(nameof(AndOperatorBitList))]
        public void AndOperatorBitList_int_int_ReturnsExpectedValue(List<bool> listA, List<bool> listB, List<bool> expectedValue)
        {
            BitList bitListA = new(listA);
            BitList bitListB = new(listB);
            BitList expectedBitList = new BitList(expectedValue);
            Assert.True(expectedBitList == (bitListA & bitListB));
        }

        public static IEnumerable<object[]> OrOperatorBitList =>
            new List<object[]>
            {
                new object[] { new List<bool> { false, false }, new List<bool> { true, true }, new List<bool> { true, true } },
                new object[] { new List<bool> { true, false }, new List<bool> { true, true }, new List<bool> { true, true }},
                new object[] { new List<bool> { true, true, true }, new List<bool> { true, true , false}, new List<bool> { true, true, true } },
                new object[] { new List<bool> { true, false, true }, new List<bool> { true, false , false}, new List<bool> { true, false, true } },
                new object[] { new List<bool> { true }, new List<bool> { true, true , false}, new List<bool> { true, true, false } },
                new object[] { new List<bool> { true, false, false, true, true }, new List<bool> { true, true , false}, new List<bool> { true, true, false, true, true } },
                new object[] { new List<bool> { true, true, true }, new List<bool> { true, true , false, false, false, false, false }, new List<bool> { true, true, true, false, false, false, false } },
            };

        [Theory]
        [MemberData(nameof(OrOperatorBitList))]
        public void OrOperatorBitList_int_int_ReturnsExpectedValue(List<bool> listA, List<bool> listB, List<bool> expectedValue)
        {
            BitList bitListA = new(listA);
            BitList bitListB = new(listB);
            BitList expectedBitList = new BitList(expectedValue);
            Assert.True(expectedBitList == (bitListA | bitListB));
        }

        public static IEnumerable<object[]> XOrOperatorBitList =>
            new List<object[]>
            {
                new object[] { new List<bool> { false, false }, new List<bool> { true, true }, new List<bool> { true, true } },
                new object[] { new List<bool> { true, false }, new List<bool> { true, true }, new List<bool> { false, true } },
                new object[] { new List<bool> { true, true, true }, new List<bool> { true, true , false}, new List<bool> { false, false, true } },
                new object[] { new List<bool> { true }, new List<bool> { true, true , false}, new List<bool> { false, true, false } },
                new object[] { new List<bool> { true, false, false, true, true }, new List<bool> { true, true , false}, new List<bool> { false, true, false, true, true } },
                new object[] { new List<bool> { true, true, true }, new List<bool> { true, true , false, false, false, false, false }, new List<bool> { false, false, true, false, false, false, false } },
            };

        [Theory]
        [MemberData(nameof(XOrOperatorBitList))]
        public void XOrOperatorBitList_int_int_ReturnsExpectedValue(List<bool> listA, List<bool> listB, List<bool> expectedValue)
        {
            BitList bitListA = new(listA);
            BitList bitListB = new(listB);
            BitList expectedBitList = new BitList(expectedValue);
            Assert.True(expectedBitList == (bitListA ^ bitListB));
        }
    }
}
