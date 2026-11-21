using System;
using Content.Shared._Citadel.Random;
using NUnit.Framework;

namespace Content.Tests.Shared._Citadel.Random;

[TestFixture]
[TestOf(typeof(ICitadelRandom))]
public sealed class CitadelRandomTests
{

    [Test]
    public void Typed64BitMethodsCoverTheFullSignedAndUnsignedRanges()
    {
        ICitadelRandom random = new ScriptedRandom(0, long.MaxValue, 1UL << 63, ulong.MaxValue, 0, ulong.MaxValue);

        Assert.That(random.NextI64(), Is.Zero);
        Assert.That(random.NextI64(), Is.EqualTo(long.MaxValue));
        Assert.That(random.NextI64(), Is.EqualTo(long.MinValue));
        Assert.That(random.NextI64(), Is.EqualTo(-1L));
        Assert.That(random.NextU64(), Is.Zero);
        Assert.That(random.NextU64(), Is.EqualTo(ulong.MaxValue));
    }

    [Test]
    public void Typed128BitMethodsCoverTheFullSignedAndUnsignedRanges()
    {
        var source = new ScriptedRandom(
            // first is high, second is low
            0,
            0,
            long.MaxValue,
            ulong.MaxValue,
            1UL << 63,
            0,
            ulong.MaxValue,
            ulong.MaxValue,
            0,
            0,
            ulong.MaxValue,
            ulong.MaxValue);
        ICitadelRandom random = source;

        Assert.That(random.NextI128(), Is.EqualTo(Int128.Zero));
        Assert.That(random.NextI128(), Is.EqualTo(Int128.MaxValue));
        Assert.That(random.NextI128(), Is.EqualTo(Int128.MinValue));
        Assert.That(random.NextI128(), Is.EqualTo(-Int128.One));
        Assert.That(random.NextU128(), Is.EqualTo(UInt128.Zero));
        Assert.That(random.NextU128(), Is.EqualTo(UInt128.MaxValue));
        Assert.That(source.DrawCount, Is.EqualTo(12));
    }

    [Test]
    public void FloatUses24BitsAndExcludesOne()
    {
        ICitadelRandom random = new ScriptedRandom(0, 1UL << 63, ulong.MaxValue);

        Assert.That(random.NextFloat(), Is.Zero);
        Assert.That(random.NextFloat(), Is.EqualTo(0.5f));
        Assert.That(random.NextFloat(), Is.EqualTo(float.BitDecrement(1)));
    }

    [Test]
    public void EqualBoundsReturnLowWithoutConsumingRandomness()
    {
        var source = new ScriptedRandom();
        ICitadelRandom random = source;

        Assert.That(random.NextBoundedI64(-7, -7), Is.EqualTo(-7L));
        Assert.That(random.NextBoundedU64(7, 7), Is.EqualTo(7UL));
        Assert.That(random.NextBoundedFloat(-7, -7), Is.EqualTo(-7f));
        Assert.That(random.NextBoundedDouble(7, 7), Is.EqualTo(7.0));
        Assert.That(source.DrawCount, Is.Zero);
    }

    [Test]
    public void ReversedBoundsThrowWithoutConsumingRandomness()
    {
        var source = new ScriptedRandom();
        ICitadelRandom random = source;

        Assert.Throws<ArgumentOutOfRangeException>(() => random.NextBoundedI64(2, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => random.NextBoundedU64(2, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => random.NextBoundedFloat(2, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => random.NextBoundedDouble(2, 1));
        Assert.That(source.DrawCount, Is.Zero);
    }

    [TestCase(double.NaN, 1)]
    [TestCase(0, double.NaN)]
    [TestCase(double.NegativeInfinity, 1)]
    [TestCase(0, double.PositiveInfinity)]
    public void FloatingBoundsMustBeFinite(double low, double high)
    {
        var source = new ScriptedRandom();
        ICitadelRandom random = source;

        Assert.Throws<ArgumentOutOfRangeException>(() => random.NextBoundedFloat((float)low, (float)high));
        Assert.Throws<ArgumentOutOfRangeException>(() => random.NextBoundedDouble(low, high));
        Assert.That(source.DrawCount, Is.Zero);
    }

    [Test]
    public void FloatingBoundsIncludeLowAndMidpoint()
    {
        ICitadelRandom random = new ScriptedRandom(0, 1UL << 63, 0, 1UL << 63);

        Assert.That(random.NextBoundedFloat(-10, 10), Is.EqualTo(-10f));
        Assert.That(random.NextBoundedFloat(-10, 10), Is.Zero);
        Assert.That(random.NextBoundedDouble(-10, 10), Is.EqualTo(-10.0));
        Assert.That(random.NextBoundedDouble(-10, 10), Is.Zero);
    }

    /// <summary>
    /// Tests that total scaled width turning into infinity
    /// will still work with the scaling system to produce finite results
    /// </summary>
    [Test]
    public void FloatingBoundsDoNotOverflowWhenTheIntervalWidthIsInfinite()
    {
        ICitadelRandom random = new ScriptedRandom(0, 1UL << 63, ulong.MaxValue, 0, 1UL << 63, ulong.MaxValue);

        Assert.That(random.NextBoundedFloat(-float.MaxValue, float.MaxValue), Is.EqualTo(-float.MaxValue));
        Assert.That(random.NextBoundedFloat(-float.MaxValue, float.MaxValue), Is.Zero);
        Assert.That(random.NextBoundedFloat(-float.MaxValue, float.MaxValue), Is.LessThan(float.MaxValue));
        Assert.That(random.NextBoundedDouble(-double.MaxValue, double.MaxValue), Is.EqualTo(-double.MaxValue));
        Assert.That(random.NextBoundedDouble(-double.MaxValue, double.MaxValue), Is.Zero);
        Assert.That(random.NextBoundedDouble(-double.MaxValue, double.MaxValue), Is.LessThan(double.MaxValue));
    }

    [Test]
    public void FloatingBoundsExcludeHighEvenForAdjacentEndpoints()
    {
        ICitadelRandom random = new ScriptedRandom(ulong.MaxValue, ulong.MaxValue);

        Assert.That(random.NextBoundedFloat(1, float.BitIncrement(1)), Is.EqualTo(1f));
        Assert.That(random.NextBoundedDouble(1, double.BitIncrement(1)), Is.EqualTo(1.0));
    }

    [Test]
    public void DoubleUsesAnExclusiveUpperBound()
    {
        ICitadelRandom random = new ScriptedRandom(0, 1UL << 63, ulong.MaxValue);

        Assert.That(random.NextDouble(), Is.Zero);
        Assert.That(random.NextDouble(), Is.EqualTo(0.5));
        Assert.That(random.NextDouble(), Is.EqualTo(double.BitDecrement(1)));
    }

    private sealed class ScriptedRandom(params ulong[] values) : ICitadelRandom
    {
        public int DrawCount { get; private set; }

        public ulong Next()
        {
            return values[DrawCount++];
        }

        public ICitadelRandom Clone()
        {
            return (ScriptedRandom)MemberwiseClone();
        }
    }
}
