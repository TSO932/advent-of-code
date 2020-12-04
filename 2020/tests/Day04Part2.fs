namespace AoC2020.Tests

open System.IO
open NUnit.Framework
open AoC2020

[<TestFixture>] 
type Day04Part2 () =

    [<Test>]
    member this.validateCredential() =
        Assert.AreEqual(true, Day04Part2.validateCredential "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980 hcl:#623a2f")

    [<Test>]
    member this.validateBYRisValid() =
        Assert.AreEqual(true, Day04Part2.validateCredential "byr:2002")

    [<Test>]
    member this.validateBYRisInvalid() =
        Assert.AreEqual(false, Day04Part2.validateCredential "byr:2003")

    [<Test>]
    member this.validateIYRisValid() =
        Assert.AreEqual(true, Day04Part2.validateCredential "iyr:2012")

    [<Test>]
    member this.validateEYRisValid() =
        Assert.AreEqual(true, Day04Part2.validateCredential "eyr:2030")

    [<Test>]
    member this.validatePIDisValid() =
        Assert.AreEqual(true, Day04Part2.validateCredential "pid:000000001")

    [<Test>]
    member this.validatePIDisInvalid() =
        Assert.AreEqual(false, Day04Part2.validateCredential "pid:0123456789")

    [<Test>]
    member this.validateHGTisValid1() =
        Assert.AreEqual(true, Day04Part2.validateCredential "hgt:60in")

    [<Test>]
    member this.validateHGTisValid2() =
        Assert.AreEqual(true, Day04Part2.validateCredential "hgt:190cm")

    [<Test>]
    member this.validateHGTisInvalid1() =
        Assert.AreEqual(false, Day04Part2.validateCredential "hgt:190in")

    [<Test>]
    member this.validateHGTisInvalid2() =
        Assert.AreEqual(false, Day04Part2.validateCredential "hgt:190")

    [<Test>]
    member this.validateHCLisValid() =
        Assert.AreEqual(true, Day04Part2.validateCredential "hcl:#123abc")

    [<Test>]
    member this.validateHCLisInvalid1() =
        Assert.AreEqual(false, Day04Part2.validateCredential "hcl:#123abz")

    [<Test>]
    member this.validateHCLisInvalid2() =
        Assert.AreEqual(false, Day04Part2.validateCredential "hcl:123abc")

    [<Test>]
    member this.validateECLLisValid() =
        Assert.AreEqual(true, Day04Part2.validateCredential "ecl:brn")

    [<Test>]
    member this.validateECLisInvalid() =
        Assert.AreEqual(false, Day04Part2.validateCredential "ecl:wat")


    [<Test>]
    member this.Example1() = Assert.AreEqual(2, Day04Part2.validateCredentials(Day04Part1.formatCredentials (File.ReadAllLines("../../../data/Day04/test1.txt"))))