namespace Calc


module MyFsCalculator =
    type Valid<'a> =
        | Some of 'a
        | None of string

    type ValidBuilder() =
        member this.Bind(x, f) = 
            match x with
            | Some x -> f x
            | None x -> None x
         member this.Return x = x
         member this.ReturnFrom x = Some x

    let maybe = ValidBuilder()

    let TryParseArgs (args: string[])  =
        let ParseValue (x: string)  =
            try Some (x |> decimal) with
            | _ -> None "InvalidArgument"
            
        let IsOperationSupported operation =
            match operation with
            | "+" -> Some "+"
            | "-" -> Some "-"
            | "*"  -> Some "*"
            | "/"  -> Some "/"
            | _ -> None "NotSupportedOperation"
        ParseValue args.[0], IsOperationSupported args.[1], ParseValue args.[2]
        
    let Calculate (arg1: decimal) (operation: string) (arg2: decimal) =
            match operation with
            | "+" -> arg1 + arg2
            | "-" -> arg1 - arg2 
            | "*" -> arg1 * arg2 
            | "/" -> arg1 / arg2
           
    [<EntryPoint>]
    let main args =
        
        let result = maybe{
            let arg1, operation, arg2 = TryParseArgs args
            let! val1 = arg1
            let! val2 = arg2
            let! op = operation
            let res = Calculate val1 op val2
            return! res
        }
        match result with
        | Some result -> printfn  $"{args.[0]} {args.[1]} {args.[2]} = {result}"
        | None result  -> printfn  $"Program has ended with {result} exception" 
        0