namespace Calc
module Parser =
    let isSupported (operation : string) =
        match operation with
            | "+" -> true
            | "-" -> true
            | "*" -> true
            | "/" -> true
            | _ -> false
    let TryParseValues (args : string[]) (arg1 : outref<int>) (arg2 : outref<int>) (operation : outref<string> ) =
        let isArg1Int = System.Int32.TryParse(args.[0], &arg1)
        let isArg2Int = System.Int32.TryParse(args.[2], &arg2)
        operation <- args.[1]
        if not (isArg1Int && isArg2Int) then
             printfn $"{args.[0]} {args.[1]} {args.[2]} invalid arguments."
             1
        elif not (isSupported args.[1]) then
             printf $"{args.[0]} {args.[1]} {args.[2]} invalid arguments."
             2
        else 0