namespace Calc
module Calculator =
    let Calculate operation arg1 arg2 =
        match operation with
        | "+" -> arg1 + arg2
        | "-" -> arg1 - arg2 
        | "*" -> arg1 * arg2 
        | "/" -> arg1 / arg2
        | _ -> 0