module Print

open Microsoft.FSharp.Reflection
open System

let rec fmt(x):string =
    let t = x.GetType()
    if t.Name.StartsWith("FSharpList") then
        x.ToString()
    else if FSharpType.IsUnion(t) then
        let union, fields = FSharpValue.GetUnionFields(x, t)
        if fields.Length = 0 then
            union.Name
        else
            let fieldsStr = String.Join(" ", Array.map fmt fields)
            let unionStr = sprintf "%s %s" union.Name fieldsStr       
            sprintf "(%s)" unionStr
    else
        x.ToString()