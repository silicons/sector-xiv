#nullable enable
using System;
using Content.Shared._Citadel.Types.Result;
using NUnit.Framework;

namespace Content.Tests.Shared._Citadel.Types;

[TestFixture]
public sealed class ResultTests
{
    [Test]
    public void SuccessExposesOnlyItsValue()
    {
        var result = Result<int, string>.Ok(42);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.IsFailure, Is.False);
        Assert.That(result.Value, Is.EqualTo(42));
        Assert.That(result.TryGetValue(out var value), Is.True);
        Assert.That(value, Is.EqualTo(42));
        Assert.That(result.TryGetError(out var error), Is.False);
        Assert.That(error, Is.Null);
        Assert.Throws<InvalidOperationException>(() => { _ = Result<int, string>.Ok(42).Error; });
    }

    [Test]
    public void FailureExposesOnlyItsError()
    {
        var result = Result<int, string>.Err("failed");

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.IsFailure, Is.True);
        Assert.That(result.Error, Is.EqualTo("failed"));
        Assert.That(result.TryGetError(out var error), Is.True);
        Assert.That(error, Is.EqualTo("failed"));
        Assert.That(result.TryGetValue(out var value), Is.False);
        Assert.That(value, Is.Zero);
        Assert.Throws<InvalidOperationException>(() => { _ = Result<int, string>.Err("failed").Value; });
    }

    [Test]
    public void DefaultIsFailureWithDefaultError()
    {
        var result = default(Result<int, string?>);

        Assert.That(result.IsFailure, Is.True);
        Assert.That(result.TryGetError(out var error), Is.True);
        Assert.That(error, Is.Null);
        Assert.That(result.Error, Is.Null);
        Assert.That(result.TryGetValue(out _), Is.False);
    }

    [Test]
    public void NullAndDefaultPayloadsDoNotDetermineState()
    {
        var success = Result<string?, string?>.Ok(null);
        var failure = Result<string?, string?>.Err(null);

        Assert.That(success.TryGetValue(out var value), Is.True);
        Assert.That(value, Is.Null);
        Assert.That(failure.TryGetError(out var error), Is.True);
        Assert.That(error, Is.Null);
        Assert.That(Result<int, int>.Ok(0).IsSuccess, Is.True);
        Assert.That(Result<int, int>.Err(0).IsFailure, Is.True);
    }

    [Test]
    public void MatchInvokesOnlyTheActiveHandler()
    {
        Assert.That(Result<int, string>.Ok(42).Match(
            value => value.ToString(),
            _ => throw new InvalidOperationException()), Is.EqualTo("42"));
        Assert.That(Result<int, string>.Err("failed").Match(
            _ => throw new InvalidOperationException(),
            error => error), Is.EqualTo("failed"));
    }

    [Test]
    public void MatchRejectsNullHandlers()
    {
        Assert.Throws<ArgumentNullException>(() => Result<int, string>.Ok(42).Match<string>(null!, error => error));
        Assert.Throws<ArgumentNullException>(() => Result<int, string>.Err("failed").Match(value => value.ToString(), null!));
    }

    [Test]
    public void InterfaceCanBeUsedWithoutBoxing()
    {
        Assert.That(ReadResult(Result<int, string>.Ok(42)), Is.EqualTo("42"));
        Assert.That(ReadResult(Result<int, string>.Err("failed")), Is.EqualTo("failed"));
    }

    private static string ReadResult<TResult>(TResult result)
        where TResult : IResult<int, string>, allows ref struct
    {
        return result.Match(value => value.ToString(), error => error);
    }
}
