using NUnit.Framework;

namespace Homework_1
{
    [TestFixture]
    public class Tests
    {
        [TestCase(0,0)]
        [TestCase(1.2f,42)]
        [TestCase(5,-10)]
        public void ConstructorTest(float abs, float arg)
        {
            var complex = new ComplexTr(abs, arg);
            Assert.That(complex.Abs, Is.EqualTo(abs));
            Assert.That(complex.Arg, Is.EqualTo(arg));
        }
        
        [Test]
        public void NegativeAbsConstructorTest()
        {
            Assert.That(() => new ComplexTr(-1, 0), Throws.ArgumentException);
        }
        
        [Test]
        public void NegativeAbsTest()
        {
            var complex = new ComplexTr();
            Assert.That(() => complex.Abs = -1, Throws.ArgumentException);
        }
        
        [TestCase(0,15, "0")]
        [TestCase(0,0, "0")]
        [TestCase(1,50.5f, "cos(50,5) + i sin(50,5)")]
        [TestCase(2.33f,-50.5f, "2,33(cos(-50,5) + i sin(-50,5))")]
        public void ToStringTest(float abs, float arg, string expected)
        {
            var complex = new ComplexTr(abs, arg);
            Assert.That(complex.ToString(), Is.EqualTo(expected));
        }

        [TestCase(0, 0, 1, 5)]
        [TestCase(5, 0, 1.2f, -5)]
        public void MultiplicationTest(float absA, float argA, float absB, float argB)
        {
            var a = new ComplexTr(absA, argA);
            var b = new ComplexTr(absB, argB);
            var expectedAbs = absA * absB;
            var expectedArg = argA + argB;
            var actualComplex = a * b;
            Assert.That(actualComplex.Abs, Is.EqualTo(expectedAbs));
            Assert.That(actualComplex.Arg, Is.EqualTo(expectedArg));
        }
        
        [TestCase(0, 0, 1, 5)]
        [TestCase(5, 0, 1.2f, -5)]
        public void DivisionTest(float absA, float argA, float absB, float argB)
        {
            var a = new ComplexTr(absA, argA);
            var b = new ComplexTr(absB, argB);
            var expectedAbs = absA / absB;
            var expectedArg = argA - argB;
            var actualComplex = a / b;
            Assert.That(actualComplex.Abs, Is.EqualTo(expectedAbs));
            Assert.That(actualComplex.Arg, Is.EqualTo(expectedArg));
        }

        [TestCase(0, 0)]
        [TestCase(1.2f, 4)]
        public void DivisionZeroTest(float abs, float arg)
        {
            var complex = new ComplexTr(abs, arg);
            Assert.That(() => complex / new ComplexTr(0, 1), Throws.ArgumentException);
        }
    }
}