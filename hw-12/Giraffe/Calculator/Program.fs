namespace Calculator
open System
open System.Runtime.CompilerServices
module Calculate =
    
    type Valid<'a> =
        | Correct of 'a 
        | Error of string
    
    type HelperBuilder() =
        member this.Bind(b, f) =
            match b with
            | Correct value -> f value
            | Error error -> Error error
        member this.ReturnFrom value =
            Correct value
        member this.Return value = value
            
    let helper = HelperBuilder()
            
    let Parse (m:string[]) =        
        let ParseValues (value:string) =
            try Correct (value|>decimal) with
            | _ -> Error "Incorrect argument"
            
        let ParseOperation op =
            match op with
            | "plus" -> Correct "+"
            | "subtract" -> Correct "-"
            | "multiply"  -> Correct "*"
            | "divide"  -> Correct "/"
            | _ -> Error "OperationNotSupported"
        
        ParseValues m.[0], ParseOperation m.[1], ParseValues m.[2]
        
    let Compute (v1:decimal) (oper:string) (v2:decimal) =
            match oper with
            | "+" -> $"{v1 + v2}"
            | "-" -> $"{v1 - v2}"
            | "*" -> $"{v1 * v2}" 
            | "/" ->
                let v = v2 |> int32
                match v with
                | 0 -> "DividingByZero"
                | _ -> $"{v1 / v2}"
    
    
    let myCalc (args: string[]) =
        let result = helper{
            let a, op, b = Parse args
            let! v1 = a
            let! v2 = b
            let! oper = op
            let res = Compute v1 oper v2
            return! res
        }
        
        match result with
        | Correct result -> result
        | Error error -> error
        
    let go (args: string[]) =
        $"{myCalc args}"
    
    [<EntryPoint>]
    let main args =
        printf $"{myCalc args}" 
        0