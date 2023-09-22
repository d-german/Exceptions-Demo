﻿using System;
using System.Text;
using NUnit.Framework;

namespace TryParseExamples;

public class NullableTests
{
    [Test]
    public void NullCoalescingTest() //??
    {
        string s1 = null;
        var s2 = s1 == null ? "nothing" : s1;
        Assert.AreEqual("nothing", s2);

        var s3 = s1 ?? "nothing";
        Assert.AreEqual("nothing", s3);
    }

    [Test]
    public void PropertyAccessErrorTest()
    {
        StringBuilder sb = null;
        Assert.Throws<NullReferenceException>(() =>
        {
            _ = sb.Length;
        });
            
    }

    [Test]
    public void NullConditionalTest() //?.
    {
        StringBuilder sb = null;
        var s = sb?.ToString()?.ToUpper();
        int? length = s?.Length;

        Assert.AreEqual(0, length.GetValueOrDefault());
    }

    [Test]
    public void PropertyAccessHappyPathTest()
    {
        var sb2 = new StringBuilder("hello world!");
        string s2 = sb2?.ToString().ToUpper();
        Assert.AreEqual("HELLO WORLD!", s2);
        Assert.AreEqual(12, s2.Length);
    }

    [Test]
    public void NullCoalescingNullConditionalTest() // ?? smd ?.
    {
        StringBuilder sb = null;
        var s = sb?.ToString().ToUpper() ?? "nothing"; 
        Assert.AreEqual("nothing", s);
    }
}