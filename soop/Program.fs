module Program

open Print
open Printf

type expr =
    | Foo of string * expr * int list
    | Cat

       
let f = Foo ("lol", Foo("bar", Cat, [4;5;6]), [1; 2; 3])
printfn "%s" (fmt f)
printfn "%s" (fmt Cat)