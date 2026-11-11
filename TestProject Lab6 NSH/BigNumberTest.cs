using System;
using NUnit.Framework;
using lab_2_ShN.Data;

namespace TestProject_Lab6_NSH
{
    [TestFixture]
    public class BigNumberTest
    {
        [TestCase("3712117", "15512900", "19225017")]
        [TestCase("1000000000", "999999999", "1999999999")]
        [TestCase("0", "12345", "12345")]
        [TestCase("999", "1", "1000")]
        public void AddTest(string a, string b, string expected)
        {
            var n1 = new BigNumber(a);
            var n2 = new BigNumber(b);
            Assert.That((n1 + n2).ToString(), Is.EqualTo(expected));
        }

        [TestCase("3712117", "1911900", "1800217")]
        [TestCase("1000000000", "1", "999999999")]
        [TestCase("12345", "12345", "0")]
        [TestCase("1000", "1", "999")]
        public void SubTest(string a, string b, string expected)
        {
            var n1 = new BigNumber(a);
            var n2 = new BigNumber(b);
            Assert.That((n1 - n2).ToString(), Is.EqualTo(expected));
        }

        [TestCase("5", "10")]
        [TestCase("100", "1000000")]
        public void SubTest_WhenMinusGreaterThanPlus_ReturnsZero(string a, string b)
        {
            var n1 = new BigNumber(a);
            var n2 = new BigNumber(b);
            Assert.That((n1 - n2).ToString(), Is.EqualTo("0"));
        }

        [TestCase("7135654", "23", "164120042")]
        [TestCase("12345", "0", "0")]
        [TestCase("999", "999", "998001")]
        public void MulTest(string a, string b, string expected)
        {
            var n1 = new BigNumber(a);
            var n2 = new BigNumber(b);
            Assert.That((n1 * n2).ToString(), Is.EqualTo(expected));
        }

        [TestCase("12345", 2, "24690")]
        [TestCase("999", 1000, "999000")]
        [TestCase("12345", 0, "0")]
        public void MulByIntTest(string a, int multiplier, string expected)
        {
            var n = new BigNumber(a);
            Assert.That((n * multiplier).ToString(), Is.EqualTo(expected));
        }

        [TestCase("10014217", "3", "3338072")]
        [TestCase("10", "3", "3")]
        [TestCase("100", "10", "10")]
        [TestCase("5", "10", "0")]
        public void DivTest(string a, string b, string expected)
        {
            var n1 = new BigNumber(a);
            var n2 = new BigNumber(b);
            Assert.That((n1 / n2).ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void DivTest_ThrowsOnZeroDivisor()
        {
            var n1 = new BigNumber("100");
            var n2 = new BigNumber("0");
            Assert.Throws<DivideByZeroException>(() => { var _ = n1 / n2; });
        }

        [Test]
        public void Equality_SameValue_IsEqual()
        {
            var a = new BigNumber("123456789");
            var b = new BigNumber("123456789");
            Assert.That(a == b, Is.True);
            Assert.That(a.Equals(b), Is.True);
        }

        [Test]
        public void Equality_DifferentValue_IsNotEqual()
        {
            var a = new BigNumber("123456789");
            var b = new BigNumber("123456780");
            Assert.That(a != b, Is.True);
        }

        [TestCase("1000", "999", true)]
        [TestCase("999", "1000", false)]
        [TestCase("123", "123", false)]
        public void GreaterThanTest(string a, string b, bool expected)
        {
            Assert.That(new BigNumber(a) > new BigNumber(b), Is.EqualTo(expected));
        }
    }
}