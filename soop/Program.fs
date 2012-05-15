module Program

open Print
open Printf
open Lexer
open Parser
open Microsoft.FSharp.Text.Lexing
open System
open System.IO


let fileToLexbuf file =
    let stream = File.OpenText(file)
    LexBuffer<_>.FromTextReader stream

let stringToLexbuf str = 
    LexBuffer<_>.FromString str

let lex (lexbuf:LexBuffer<_>) =
    while not lexbuf.IsPastEndOfStream do
        printf "%s " (Lexer.token lexbuf |> fmt)

let parse lexbuf =
    try
        Parser.program Lexer.token lexbuf
    with
        | ex ->
            printfn "Parse error at line %d, column %d at token %s" lexbuf.StartPos.Line lexbuf.StartPos.Column (Lexer.lexeme lexbuf)
            Tree.Program []


let file = "../../tests/expr.soop"

lex (fileToLexbuf file)
printfn "\n"
printfmt (parse <| fileToLexbuf file)
