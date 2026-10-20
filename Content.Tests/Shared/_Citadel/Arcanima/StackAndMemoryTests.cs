using System;
using Content.Shared._Citadel.Arcanima.Engine;
using Content.Shared._Citadel.Arcanima.Engine.Errors;
using Content.Shared._Citadel.Arcanima.Engine.Interfaces;
using Content.Shared._Citadel.Arcanima.Engine.Values;
using Content.Shared._Citadel.Arcanima.Glyph.Arithmetic;
using Content.Shared._Citadel.Arcanima.Glyph.Flow;
using Content.Shared._Citadel.Arcanima.Glyph.Memory;
using NUnit.Framework;
using Context = Content.Shared._Citadel.Arcanima.Engine.ExecutionContext;
using VmProgram = Content.Shared._Citadel.Arcanima.Engine.Program;
using VmStack = Content.Shared._Citadel.Arcanima.Engine.Stack;
using Pop = Content.Shared._Citadel.Arcanima.Glyph.Stack.Pop;
using Push = Content.Shared._Citadel.Arcanima.Glyph.Stack.Push;

namespace Content.Tests.Shared._Citadel.Arcanima;

#warning ai slop check this over

[TestFixture]
public sealed class StackAndMemoryTests
{
    private static VmStack Stack(params ValueBase[] values)
    {
        var stack = new VmStack();
        foreach (var value in values)
        {
            stack.Push(new ValueRef(value));
        }

        return stack;
    }

    private static ValueRef MemoryCopy(Memory memory, Identifier id)
    {
        Assert.That(memory.TryGetValueCopy(id, out var value), Is.True);
        return value;
    }

    private static ValueRef Peek(VmStack stack, int index)
    {
        Assert.That(stack.TryPeek(index, out var value), Is.True);
        return value;
    }

    private static ValueRef PeekFromTop(VmStack stack, int index)
    {
        Assert.That(stack.TryPeekFromTop(index, out var value), Is.True);
        return value;
    }

    [Test]
    public void PushSnapshotsItsConstantAndCopiesEveryExecution()
    {
        var source = new Number(3);
        var push = new Push(new ValueRef(source));
        source.Value = 9;
        push.GetValueCopy().GetRef<Number>().Value = 10;
        var stack = new VmStack();
        Assert.That(push.Execute(new Context { Stack = stack }).Error, Is.Null);
        var first = stack.Peek().GetRef<Number>();
        first.Value = 20;
        Assert.That(push.Copy().Execute(new Context { Stack = stack }).Error, Is.Null);
        Assert.That(stack.Peek().GetRef<Number>().Value, Is.EqualTo(3));
        Assert.That(stack.Peek().GetRef<Number>(), Is.Not.SameAs(first));
    }

    [Test]
    public void PopChecksUnderflowAndConsumesOneValue()
    {
        var stack = Stack(new Number(1), new Number(2));
        var pop = new Pop();
        Assert.That(pop.Copy().Execute(new Context { Stack = stack }).Error, Is.Null);
        Assert.That(stack.Size, Is.EqualTo(1));
        Assert.That(stack.Peek().GetRef<Number>().Value, Is.EqualTo(1));
        pop.Execute(new Context { Stack = stack });
        Assert.That(pop.Execute(new Context { Stack = stack }).Error, Is.TypeOf<InsufficientArgumentsError>());
        Assert.That(stack.Size, Is.Zero);
    }

    [Test]
    public void ValueRefCopyDetachesTheValue()
    {
        var source = new ValueRef(new Vec3(2, 3, 4));
        var copy = source.Copy();
        copy.GetRef<Vec3>().X = 10;
        Assert.That(source.GetRef<Vec3>().X, Is.EqualTo(2));
        source.Get<Vec3>(out var original);
        Assert.That(original, Is.SameAs(source.GetRef<Vec3>()));
    }

    [Test]
    public void RetainedStackValuesSurviveGrowthAndRemoval()
    {
        var stack = Stack(new Number(1));
        var retained = Peek(stack, 0);
        for (var i = 0; i < 128; i++)
            stack.Push(new ValueRef(new Number(i)));
        stack.Pop(128);
        var popped = stack.Pop();
        stack.Push(new ValueRef(new Number(9)));
        Assert.That(retained.GetRef<Number>().Value, Is.EqualTo(1));
        Assert.That(popped.GetRef<Number>().Value, Is.EqualTo(1));
        Assert.That(stack.Peek().GetRef<Number>().Value, Is.EqualTo(9));
        stack.Clear();
        Assert.That(stack.Size, Is.Zero);
        Assert.That(retained.GetRef<Number>().Value, Is.EqualTo(1));
    }

    [Test]
    public void ReplacingTheTopHandleDoesNotOverwriteItsAliases()
    {
        var stack = Stack(new Number(1), new Number(2));
        var top = PeekFromTop(stack, 0);
        stack.Pop();
        stack.Push(new ValueRef(new Number(6)));
        Assert.That(top.GetRef<Number>().Value, Is.EqualTo(2));
        Assert.That(Peek(stack, 0).GetRef<Number>().Value, Is.EqualTo(1));
        Assert.That(stack.Peek().GetRef<Number>().Value, Is.EqualTo(6));
    }

    [TestCase(-1)]
    [TestCase(2)]
    [TestCase(int.MinValue)]
    [TestCase(int.MaxValue)]
    public void InvalidStackIndicesReturnFalse(int index)
    {
        var stack = Stack(new Number(1), new Number(2));
        Assert.That(stack.TryPeek(index, out var bottom), Is.False);
        Assert.That(bottom, Is.EqualTo(default(ValueRef)));
        Assert.That(stack.TryPeekFromTop(index, out var top), Is.False);
        Assert.That(top, Is.EqualTo(default(ValueRef)));
        Assert.That(stack.Size, Is.EqualTo(2));
    }

    [Test]
    public void TryPeekChecksActiveSizeAfterPoppingAndClearing()
    {
        var stack = Stack(new Number(1), new Number(2));
        Assert.That(stack.TryPeek(0, out var bottom), Is.True);
        Assert.That(bottom.GetRef<Number>().Value, Is.EqualTo(1));
        Assert.That(stack.TryPeekFromTop(0, out var top), Is.True);
        Assert.That(top.GetRef<Number>().Value, Is.EqualTo(2));
        stack.Pop();
        Assert.That(stack.TryPeek(1, out _), Is.False);
        Assert.That(stack.TryPeekFromTop(1, out _), Is.False);
        stack.Clear();
        Assert.That(stack.TryPeek(0, out _), Is.False);
        Assert.That(stack.TryPeekFromTop(0, out _), Is.False);
    }

    [Test]
    public void LoadAndStoreCopyNestedAndOpaqueValues()
    {
        foreach (var source in new ValueBase[] { new Option<Number>(new Number(3)), new Opaque(new Payload(3)) })
        {
            var memory = new Memory();
            var id = new Identifier("value");
            var stack = Stack(new Number(99), new Ident(id), source);
            Assert.That(new Store().Copy().Execute(new Context { Stack = stack, Memory = memory }).Error, Is.Null);
            Assert.That(stack.Size, Is.EqualTo(1));
            SetPayload(source, 10);
            stack.Push(new ValueRef(new Ident(id)));
            Assert.That(new Load().Copy().Execute(new Context { Stack = stack, Memory = memory }).Error, Is.Null);
            var loaded = stack.Peek().GetRef<ValueBase>();
            Assert.That(GetPayload(loaded), Is.EqualTo(3));
            SetPayload(loaded, 20);
            Assert.That(GetPayload(MemoryCopy(memory, id).GetRef<ValueBase>()), Is.EqualTo(3));
            Assert.That(Peek(stack, 0).GetRef<Number>().Value, Is.EqualTo(99));
        }
    }

    [Test]
    public void MemoryCopiesSurviveGrowthAndReplacementIndependently()
    {
        var memory = new Memory();
        var id = new Identifier("value");
        memory.StoreValueCopy(id, new ValueRef(new Number(3)));
        var snapshot = MemoryCopy(memory, id);
        for (var i = 0; i < 1024; i++)
            memory.StoreValueCopy(new Identifier(i.ToString()), new ValueRef(new Number(i)));
        memory.StoreValueCopy(id, new ValueRef(new Vec4(1, 2, 3, 4)));
        Assert.That(snapshot.GetRef<Number>().Value, Is.EqualTo(3));
        var first = MemoryCopy(memory, id);
        first.GetRef<Vec4>().W = 10;
        Assert.That(MemoryCopy(memory, id).GetRef<Vec4>().W, Is.EqualTo(4));
    }

    [Test]
    public void LoadConsumesTheIdentifierAndLeavesMemoryIndependent()
    {
        var memory = new Memory();
        var id = new Identifier("value");
        memory.StoreValueCopy(id, new ValueRef(new Number(3)));
        var identifier = new Ident(id);
        var stack = Stack(identifier);
        Assert.That(new Load().Execute(new Context { Stack = stack, Memory = memory }).Error, Is.Null);
        Assert.That(stack.Size, Is.EqualTo(1));
        Assert.That(identifier.Value, Is.SameAs(id));
        stack.Peek().GetRef<Number>().Value = 8;
        Assert.That(MemoryCopy(memory, id).GetRef<Number>().Value, Is.EqualTo(3));
    }

    [TestCase("Add", 10)]
    [TestCase("Subtract", 6)]
    [TestCase("Multiply", 16)]
    [TestCase("Divide", 4)]
    public void ScalarResultsLeaveRetainedOperandsAndMemoryUnchanged(string operation, double expected)
    {
        Glyph glyph = operation switch
        {
            "Add" => new ScalarAdd(),
            "Subtract" => new ScalarSubtract(),
            "Multiply" => new ScalarMultiply(),
            _ => new ScalarDivide(),
        };
        foreach (var source in new ValueBase[] { new Number(8), new Vec2(8, 12), new Vec3(8, 12, 16), new Vec4(8, 12, 16, 20) })
        {
            var memory = new Memory();
            var id = new Identifier("value");
            memory.StoreValueCopy(id, new ValueRef(source));
            var first = MemoryCopy(memory, id);
            var second = new ValueRef(new Number(2));
            var stack = Stack(new Number(99));
            stack.Push(first);
            stack.Push(second);
            Assert.That(glyph.Execute(new Context { Stack = stack, Memory = memory }).Error, Is.Null);
            Assert.That(stack.Size, Is.EqualTo(2));
            var result = stack.Peek().GetRef<ValueBase>();
            Assert.That(FirstComponent(result), Is.EqualTo(expected));
            Assert.That(result, Is.Not.SameAs(first.GetRef<ValueBase>()));
            Assert.That(FirstComponent(first.GetRef<ValueBase>()), Is.EqualTo(8));
            Assert.That(second.GetRef<Number>().Value, Is.EqualTo(2));
            Assert.That(FirstComponent(MemoryCopy(memory, id).GetRef<ValueBase>()), Is.EqualTo(8));
        }
    }

    private static double FirstComponent(ValueBase value) => value switch
    {
        Number v => v.Value, Vec2 v => v.X, Vec3 v => v.X, Vec4 v => v.X, _ => double.NaN,
    };

    [Test]
    public void ProductsAndNormalizationPushNewResults()
    {
        var first = new Vec3(1, 0, 0);
        var stack = Stack(first, new Vec3(0, 1, 0));
        Assert.That(new VectorCrossProduct().Execute(new Context { Stack = stack }).Error, Is.Null);
        var cross = stack.Peek().GetRef<Vec3>();
        Assert.That(cross.Z, Is.EqualTo(1));
        Assert.That(first.Z, Is.Zero);
        stack.Push(new ValueRef(new Vec3(0, 0, 5)));
        Assert.That(new VectorDotProduct().Execute(new Context { Stack = stack }).Error, Is.Null);
        Assert.That(stack.Peek().GetRef<Number>().Value, Is.EqualTo(5));
        Assert.That(cross.Z, Is.EqualTo(1));
        stack.Pop();
        var vector = new Vec2(3, 4);
        stack.Push(new ValueRef(vector));
        stack.Push(new ValueRef(new Number(10)));
        Assert.That(new VectorNorm().Execute(new Context { Stack = stack }).Error, Is.Null);
        Assert.That(stack.Peek().GetRef<Vec2>().X, Is.EqualTo(6).Within(1e-10));
        Assert.That(stack.Peek().GetRef<Vec2>().Y, Is.EqualTo(8).Within(1e-10));
        Assert.That(vector.X, Is.EqualTo(3));
        Assert.That(vector.Y, Is.EqualTo(4));
        Assert.That(stack.Size, Is.EqualTo(1));
    }

    [Test]
    public void SharedOperandsAreReadWithoutBeingOverwritten()
    {
        var operand = new ValueRef(new Vec3(1, 2, 3));
        var stack = new VmStack();
        stack.Push(operand);
        stack.Push(operand);
        Assert.That(new VectorDotProduct().Execute(new Context { Stack = stack }).Error, Is.Null);
        Assert.That(stack.Peek().GetRef<Number>().Value, Is.EqualTo(14));
        Assert.That(operand.GetRef<Vec3>().Z, Is.EqualTo(3));
        var cloned = (VmStack)stack.Clone();
        stack.Peek().GetRef<Number>().Value = 20;
        Assert.That(cloned.Peek().GetRef<Number>().Value, Is.EqualTo(14));
    }

    [Test]
    public void StoreAndPushSnapshotTheirSources()
    {
        var source = new ValueRef(new Number(3));
        var memory = new Memory();
        var id = new Identifier("value");
        var push = new Push(source);
        var stack = Stack(new Ident(id));
        stack.Push(source);
        Assert.That(new Store().Execute(new Context { Stack = stack, Memory = memory }).Error, Is.Null);
        source.GetRef<Number>().Value = 7;
        Assert.That(MemoryCopy(memory, id).GetRef<Number>().Value, Is.EqualTo(3));
        Assert.That(push.Execute(new Context { Stack = stack }).Error, Is.Null);
        Assert.That(stack.Peek().GetRef<Number>().Value, Is.EqualTo(3));
    }

    [TestCase("Scalar")]
    [TestCase("Dot")]
    [TestCase("Cross")]
    [TestCase("Norm")]
    public void FailedArithmeticPreservesTheOperands(string operation)
    {
        Glyph glyph = operation switch
        {
            "Scalar" => new ScalarAdd(),
            "Dot" => new VectorDotProduct(),
            "Cross" => new VectorCrossProduct(),
            _ => new VectorNorm(),
        };
        ValueBase source = operation switch
        {
            "Cross" => new Vec3(1, 2, 3),
            "Norm" => new Vec2(3, 4),
            _ => new Vec4(1, 2, 3, 4),
        };
        var memory = new Memory();
        var id = new Identifier("result");
        memory.StoreValueCopy(id, new ValueRef(source));
        var alias = MemoryCopy(memory, id);
        var before = alias.GetRef<ValueBase>();
        var stack = new VmStack();
        stack.Push(alias);
        stack.Push(new ValueRef(new Text("invalid")));
        Assert.That(glyph.Execute(new Context { Stack = stack }).Error, Is.TypeOf<BadInputTypeError>());
        Assert.That(stack.Size, Is.EqualTo(2));
        Assert.That(alias.GetRef<ValueBase>(), Is.SameAs(before));
        Assert.That(PeekFromTop(stack, 1).GetRef<ValueBase>(), Is.SameAs(before));
    }

    [Test]
    public void CopyingValueRefHandlesDoesNotAllocateWrappers()
    {
        Assert.That(typeof(ValueRef).IsValueType, Is.True);
        var source = new ValueRef(new Number(3));
        var before = GC.GetAllocatedBytesForCurrentThread();
        var found = 0;
        for (var i = 0; i < 10000; i++)
        {
            var value = source;
            if (value.GetRef<Number>().Value == 3)
                found++;
        }
        var allocated = GC.GetAllocatedBytesForCurrentThread() - before;
        Assert.That(found, Is.EqualTo(10000));
        Assert.That(allocated, Is.Zero);
    }

    [Test]
    public void FailedMemoryOperationsPreserveTheStackAndMemory()
    {
        var memory = new Memory();
        var id = new Identifier("missing");
        foreach (var glyph in new Glyph[] { new Load() })
        {
            var stack = new VmStack();
            Assert.That(glyph.Execute(new Context { Stack = stack, Memory = memory }).Error,
                Is.TypeOf<InsufficientArgumentsError>());
            stack.Push(new ValueRef(new Number(1)));
            Assert.That(glyph.Execute(new Context { Stack = stack, Memory = memory }).Error,
                Is.TypeOf<BadInputTypeError>());
            Assert.That(stack.Size, Is.EqualTo(1));
            stack.Pop();
            stack.Push(new ValueRef(new Ident(id)));
            Assert.That(glyph.Execute(new Context { Stack = stack, Memory = memory }).Error,
                Is.TypeOf<BadIdentifierError>());
            Assert.That(stack.Peek().GetRef<Ident>().Value, Is.SameAs(id));
        }

        var badStore = Stack(new Number(1), new Number(2));
        Assert.That(new Store().Execute(new Context { Stack = badStore, Memory = memory }).Error,
            Is.TypeOf<BadInputTypeError>());
        Assert.That(badStore.Size, Is.EqualTo(2));
        Assert.That(memory.TryGetValueCopy(id, out _), Is.False);
    }

    [Test]
    public void JumpsConsumeTheirOperandsOnlyOnSuccess()
    {
        var id = new Identifier("chain");
        var chain = new GlyphChain(id, [new Pop(), new Pop()]);
        var builder = new ProgramBuilder();
        builder.GlyphChains.Add(id, chain);
        var program = new VmProgram(builder);
        foreach (var glyph in new[] { new ShortJump().Copy(), new LongJump().Copy() })
        {
            var stack = glyph is LongJump
                ? Stack(new Number(99), new Ident(id), new Number(1.9))
                : Stack(new Number(99), new Number(1.9));
            var context = new Context { Stack = stack, Chain = chain, Program = program };
            var result = glyph.Execute(context);
            Assert.That(result.Error, Is.Null);
            Assert.That(result.JumpTo!.Value.GlyphIndex, Is.EqualTo(1));
            Assert.That(stack.Size, Is.EqualTo(1));
            if (glyph is LongJump)
                stack.Push(new ValueRef(new Ident(id)));
            stack.Push(new ValueRef(new Number(2)));
            var count = stack.Size;
            Assert.That(glyph.Execute(context).Error, Is.TypeOf<IntegerOutOfRange>());
            Assert.That(stack.Size, Is.EqualTo(count));
            stack.Clear();
            Assert.That(glyph.Execute(context).Error, Is.TypeOf<InsufficientArgumentsError>());
        }
    }

    private static double GetPayload(ValueBase value)
    {
        return value is Option<Number> option ? option.Value!.Value : ((Payload)((Opaque)value).Value).Value;
    }

    private static void SetPayload(ValueBase value, double number)
    {
        if (value is Option<Number> option)
            option.Value!.Value = number;
        else
            ((Payload)((Opaque)value).Value).Value = number;
    }

    private sealed class Payload(double value) : IOpaqueData
    {
        public double Value = value;

        public object Copy()
        {
            return new Payload(Value);
        }

        public ulong GetMemoryUnits()
        {
            return 1;
        }
    }
}
