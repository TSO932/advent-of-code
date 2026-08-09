namespace AoC2020.Tests

open NUnit.Framework
open AoC2020

[<TestFixture>] 
type CommonFunctions () =

    [<Test>]
    member this.splitByBlankLine() = 
        let actual = CommonFunctions.splitByBlankLine (seq {"a"; "b"; ""; "c"; "d"; "e"; ""; "f"; "g"; "h"})
        let expected = seq (seq {seq {"b"}; seq {"d"; "e"}; seq {"g"; "h"}})
        Assert.AreEqual(expected, actual)

    [<Test>]
    member this.splitByBlankLineWithBlankAtEnd() = 
        let actual = CommonFunctions.splitByBlankLine (seq {"a"; "b"; ""; "c"; "d"; "e"; ""; "f"; "g"; "h"; ""})
        let expected = seq (seq {seq {"a"; "b"}; seq {"c"; "d"; "e"}; seq {"f"; "g"; "h"}})
        Assert.AreEqual(expected, actual)

    [<Test>]
    member this.splitByBlankLineWithMultipleBlanks() = 
        let actual = CommonFunctions.splitByBlankLine (seq {"a"; "b"; ""; "c"; "d"; "e"; ""; ""; "f"; "g"; "h"; ""; ""})
        let expected = seq (seq {seq {"a"; "b"}; seq {"c"; "d"; "e"}; seq {"f"; "g"; "h"}})
        Assert.AreEqual(expected, actual)
