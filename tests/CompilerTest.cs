using System;
using System.IO;
using NUnit.Framework;
using SuperXML;

namespace SuperXml.Tests;

public class Tests
{
    [Test]
    public void CompileString()
    {
        var inputFileData = File.ReadAllText("./TestFiles/testFile.xml");
        var expected = File.ReadAllText("./TestFiles/testFile_output.xml");
        var compiler = new Compiler();
        compiler.AddKey("m", new
        {
            Name = "Test Name",
            Date = new DateTime(2023, 6, 5, 13, 40, 05),
            Width = 80.1,
            Height = 40,
            Bounds = new [] { "one", "two" },
            Users = new []
            {
                new {
                    Name = "John",
                    Age = 15,
                },
                new {
                    Name = "Mary",
                    Age = 26,
                },
                new {
                    Name = "Eddie",
                    Age = 27,
                },
            },
            NullUser = new {
                Name = null as string,
                Age = null as int?,
                Date = null as DateTime?
            }
        });
        
        var actual = compiler.CompileString(inputFileData);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}