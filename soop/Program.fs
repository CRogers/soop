module Program

open Print
open Printf
open Lexer
open Parser
open Microsoft.FSharp.Text.Lexing
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
    Parser.program Lexer.token lexbuf


let file = "tests/class.soop"

lex (fileToLexbuf file)
printfn "\n"
printfmt (parse <| fileToLexbuf file)
