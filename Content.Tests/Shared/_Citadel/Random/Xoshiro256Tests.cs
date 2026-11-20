using Content.Shared._Citadel.Random;
using NUnit.Framework;

namespace Content.Tests.Shared._Citadel.Random;

[TestFixture(0UL)]
[TestFixture(1UL)]
[TestFixture(0x0123456789ABCDEFUL)]
[TestFixture(ulong.MaxValue)]
[TestOf(typeof(Xoshiro256))]
public sealed class Xoshiro256Tests(ulong seed)
{
    [Test]
    public void SameSeedProducesSameSequence()
    {
        var first = new Xoshiro256(seed);
        var second = new Xoshiro256(seed);

        AssertSameSequence(first, second);
    }

    [TestCase(5UL)]
    [TestCase(10UL)]
    [TestCase(20UL)]
    public void JumpNMatchesManualAdvance(ulong amount)
    {
        var manual = new Xoshiro256(seed);
        var jumped = manual;

        for (ulong i = 0; i < amount; i++)
        {
            manual.NextInt();
        }

        jumped.JumpN(amount, 0, 0, 0);

        AssertSameSequence(manual, jumped);
    }

    [TestCase(5UL)]
    [TestCase(10UL)]
    [TestCase(20UL)]
    public void JumpCEMatchesManualAdvance(ulong amount)
    {
        var manual = new Xoshiro256(seed);
        var jumped = manual;

        for (ulong i = 0; i < amount; i++)
        {
            manual.NextInt();
        }

        jumped.JumpCE(amount, 0);

        AssertSameSequence(manual, jumped);
    }

    [Test]
    public void ThreeJumpsMatchJumpCE()
    {
        var repeated = new Xoshiro256(seed);
        var combined = repeated;

        for (var i = 0; i < 3; i++)
        {
            repeated.Jump();
        }

        combined.JumpCE(3, 128);

        AssertSameSequence(repeated, combined);
    }

    [Test]
    public void ThreeLongJumpsMatchJumpCE()
    {
        var repeated = new Xoshiro256(seed);
        var combined = repeated;

        for (var i = 0; i < 3; i++)
        {
            repeated.LongJump();
        }

        combined.JumpCE(3, 192);

        AssertSameSequence(repeated, combined);
    }

    private static void AssertSameSequence(Xoshiro256 expected, Xoshiro256 actual)
    {
        for (var i = 0; i < 16; i++)
        {
            Assert.That(actual.NextInt(), Is.EqualTo(expected.NextInt()), $"Output {i} differs.");
        }
    }
}
