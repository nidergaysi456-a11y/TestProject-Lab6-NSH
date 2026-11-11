using System;
using NUnit.Framework;

namespace TestProject_Lab6_NSH
{
    [TestFixture]
    public class MathFunctionsTest
    {
        private MathFunctions math;

        [SetUp]
        public void Setup()
        {
            math = new MathFunctions();
        }

        [TestCase(0, 0.0)]
        [TestCase(1, 2.54)]
        [TestCase(10, 25.4)]
        [TestCase(2.5, 6.35)]
        public void InchesToCentimeters_NormalCases(double inches, double expected)
        {
            Assert.That(math.InchesToCentimeters(inches), Is.EqualTo(expected).Within(1e-9));
        }

        [Test]
        public void InchesToCentimeters_ThrowsOnNegative()
        {
            var ex = Assert.Throws<ArgumentException>(() => math.InchesToCentimeters(-1));
            Assert.That(ex.Message, Is.EqualTo("Дюймы не могут быть отрицательными"));
        }

        [TestCase(4)]
        [TestCase(0)]
        [TestCase(-2)]
        public void IsEven_EvenNumbers(int n)
        {
            Assert.That(math.IsEven(n), Is.True);
        }

        [TestCase(3)]
        [TestCase(-7)]
        [TestCase(1)]
        public void IsEven_OddNumbers(int n)
        {
            Assert.That(math.IsEven(n), Is.False);
        }

        [TestCase(new[] { 1, 5, 3 }, 5)]
        [TestCase(new[] { -1, -5, -3 }, -1)]
        [TestCase(new[] { 42 }, 42)]
        [TestCase(new[] { 7, 7, 7 }, 7)]
        public void Max_NormalCases(int[] array, int expected)
        {
            Assert.That(math.Max(array), Is.EqualTo(expected));
        }

        [Test]
        public void Max_ThrowsOnNull()
        {
            var ex = Assert.Throws<ArgumentException>(() => math.Max(null!));
            Assert.That(ex.Message, Is.EqualTo("Массив не может быть null"));
        }

        [Test]
        public void Max_ThrowsOnEmpty()
        {
            var ex = Assert.Throws<ArgumentException>(() => math.Max(Array.Empty<int>()));
            Assert.That(ex.Message, Is.EqualTo("Массив не может быть пустым"));
        }

        [TestCase(10, 3, 1)]
        [TestCase(3, 10, 3)]
        [TestCase(7, 7, 0)]
        [TestCase(0, 5, 0)]
        public void Mod_NormalCases(int a, int b, int expected)
        {
            Assert.That(math.Mod(a, b), Is.EqualTo(expected));
        }

        [Test]
        public void Mod_ThrowsOnZeroDivisor()
        {
            var ex = Assert.Throws<ArgumentException>(() => math.Mod(10, 0));
            Assert.That(ex.Message, Is.EqualTo("Делитель должен быть положительным числом"));
        }

        [Test]
        public void Mod_ThrowsOnNegativeDivisor()
        {
            var ex = Assert.Throws<ArgumentException>(() => math.Mod(10, -3));
            Assert.That(ex.Message, Is.EqualTo("Делитель должен быть положительным числом"));
        }

        [Test]
        public void Mod_DoesNotThrowOnPositiveDivisor()
        {
            Assert.DoesNotThrow(() => math.Mod(10, 3));
        }
    }
}