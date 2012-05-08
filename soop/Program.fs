open System
open Printf
open Microsoft.FSharp.Reflection

type expr =
    | Foo of string * expr * int list
    | Cat


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
       


let f = Foo ("lol", Foo("bar", Cat, [4;5;6]), [1; 2; 3])
printfn "%s" (fmt f)
printfn "%s" (fmt Cat)