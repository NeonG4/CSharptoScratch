using System.Reflection;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace CSharptoScratch.Tests;

public class CSParserTests
{
    private static Type GetParserType()
    {
        return typeof(CSharptoScratch.Form1).Assembly.GetType("CSharptoScratch.CSParser", throwOnError: true)!;
    }

    private static object CreateParser(string code)
    {
        var type = GetParserType();
        return Activator.CreateInstance(
            type,
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
            binder: null,
            args: new object[] { code },
            culture: null)!;
    }

    private static T GetPrivateField<T>(object instance, string fieldName)
    {
        var field = instance.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
        Assert.NotNull(field);
        return (T)field!.GetValue(instance)!;
    }

    private static object InvokePrivate(object instance, string methodName, params object[] args)
    {
        var method = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
        Assert.NotNull(method);
        return method!.Invoke(instance, args)!;
    }

    [Fact]
    public void ResolveUsingDirectives_ReturnsDirectivesAndRemovesUsingLines()
    {
        var code = "using System;\nusing System.Collections.Generic;\nnamespace Demo { class Foo { } }";
        var parser = CreateParser(code);

        var result = (List<string>)InvokePrivate(parser, "ResolveUsingDirectives");

        Assert.Equal(new[] { "System", "System.Collections.Generic" }, result);
        var remainingCode = GetPrivateField<string>(parser, "csCode");
        Assert.DoesNotContain("using ", remainingCode);
        Assert.Contains("namespace Demo", remainingCode);
    }

    [Fact]
    public void ResolveNamespace_ReturnsNamespaceAndStripsDeclaration()
    {
        var code = "namespace Demo { class Foo { } }";
        var parser = CreateParser(code);

        var remaining = (string)InvokePrivate(parser, "ResolveNamespace", code);

        var ns = GetPrivateField<string>(parser, "nameSpace");
        Assert.Equal("Demo", ns);
        Assert.DoesNotContain("namespace ", remaining);
        Assert.Contains("class Foo", remaining);
    }

    [Fact]
    public void ResolveBodyCode_ReturnsClassBodyStartingBrace()
    {
        var code = "class Foo { int x; }";
        var parser = CreateParser(code);

        var body = (string)InvokePrivate(parser, "ResolveBodyCode");

        Assert.StartsWith("{", body.TrimStart());
        Assert.Contains("int x", body);
    }

    [Fact]
    public void ResolveBodyCode_ThrowsWhenClassMissing()
    {
        var parser = CreateParser("namespace Demo { } ");

        var ex = Assert.Throws<TargetInvocationException>(() => InvokePrivate(parser, "ResolveBodyCode"));

        Assert.IsType<Exception>(ex.InnerException);
        Assert.Equal("Class not found", ex.InnerException!.Message);
    }

    [Fact]
    public void ResolveNamespace_ThrowsWhenNamespaceMissing()
    {
        var parser = CreateParser("class Foo { } ");

        var ex = Assert.Throws<TargetInvocationException>(() => InvokePrivate(parser, "ResolveNamespace", "class Foo { }"));

        Assert.IsType<Exception>(ex.InnerException);
        Assert.Equal("Namespace not found", ex.InnerException!.Message);
    }
}
