module Tests

open System
open Xunit
open Calc.MyFsCalculator


[<Theory>]
[<InlineData(1 ,"+", -1, 0)>]
[<InlineData(2 ,"-", 0, 2)>]
[<InlineData(3 ,"*", 1, 3)>]
[<InlineData(4 ,"/", 2, 2)>]

let ``CalculateSuccess`` (arg1 ,operation, arg2, expect) =
    let res = Calculate arg1 operation arg2
    Assert.Equal(res, Some expect)
    
    
[<Theory>]
[<InlineData(1 ,"/", 0, "DividingByZero")>]
[<InlineData(2 ,"/", 0, "DividingByZero")>]

let ``DividingByZero`` (arg1 ,operation, arg2, expect) =
    
    let res = Calculate arg1 operation arg2
    
    Assert.Equal(res, None expect)
    
[<Theory>]
[<InlineData("2", "+", "3", 2, "+", 3 )>]
[<InlineData("2", "-", "1.1", 2, "-", 1.1 )>]
[<InlineData("2", "*", "0.002", 2, "*", 0.002 )>]
[<InlineData("2", "/", "100", 2, "/", 100 )>]
let ``ParseValidArgsAndOperations``(val1, operation, val2, expectArg1, expectOp, expectArg2) =
    let arg1, op, arg2 = TryParseArgs [|val1; operation; val2|]
    Assert.Equal(arg1, Some expectArg1)
    Assert.Equal(op, Some expectOp)
    Assert.Equal(arg2, Some expectArg2)

[<Theory>]
[<InlineData("2", "aaa", "3", 2, "aaa", 3 )>]
[<InlineData("2", "", "1.1", 2, "", 1.1 )>]
let ``ParseInvalidOperations``(val1, operation, val2, expectArg1, expectOp, expectArg2) =
    let arg1, op, arg2 = TryParseArgs [|val1; operation; val2|]
    Assert.Equal(op, None "NotSupportedOperation")
    
[<Theory>]
[<InlineData("aa", "+", "3", "?", "+", 3 )>]
[<InlineData("", "-", "3", "?", "-", 3 )>]
let ``ParseInvalidArgs``(val1, operation, val2, expectArg1, expectOp, expectArg2) =
    let arg1, op, arg2 = TryParseArgs [|val1; operation; val2|]
    Assert.Equal(arg1, None "InvalidArgument")