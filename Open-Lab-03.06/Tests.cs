using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;

namespace Open_Lab_03._06
{
    [TestFixture]
    public class Tests
    {

        private Checker checker;

        private const int RandWordMinSize = 1;
        private const int RandWordMaxSize = 10;
        private const int RandSeed = 306306306;
        private const int RandTestCasesCount = 95;

        [OneTimeSetUp]
        public void Init() => checker = new Checker();

        //Original test had an example with null as an input, should it be one of the test cases?
        //TODO: remove these comments or add test case for null as input

        [TestCase("hello", false)]
        [TestCase("hello, world", true)]
        [TestCase(" ", true)]
        [TestCase("", false)]
        [TestCase(",./!@#", false)]
        [TestCaseSource(nameof(GetRandom))]
        public void HasSpacesTest(string str, bool expectedOutput) =>
            Assert.That(checker.HasSpaces(str), Is.EqualTo(expectedOutput));

        private static IEnumerable GetRandom()
        {
            var random = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var arr = new char[random.Next(RandWordMinSize, RandWordMaxSize + 1)];

                for (var j = 0; j < arr.Length; j++)
                    arr[j] = (char) random.Next(' ', 'Z' + 1);

                yield return new TestCaseData(new string(arr), arr.Contains(' '));
            }
        }

    }
}
