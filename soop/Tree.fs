﻿module Tree

open System


type stype = string


type op =
    | Plus | Minus | Times | Divide


type expr =
    | Int of int
    | String of string
    | Binop of op * expr * expr
    (* namespace, class, methodName, args*)
    | MethodCall of string * string * string * string list

type stmt =
    (* condition, ifpart, elsepart *)
    | If of expr * stmt list * stmt list
    (* condition, loop code *)
    | While of expr * stmt list

type accessModifer =
    | Public | Private | Protected

(* name, type, initial value *)
type arg = Arg of string * stype

(* name, params, return type, stmts *)
type methodDecl = Method of string * arg list * stype * stmt list

type classDecl = 
    | LocalVar of string * accessModifer * stype * Object
    | Method of string * accessModifer * arg list * stype * stmt list
    | Constructor of arg list * stmt list

type classInterfaceDecl = 
    (* local vars, constructors, methods *)
    | Class of string * classDecl list
    (* methods *)
    | Interface of methodDecl list

type namespaceDecl = Namespace of string * classInterfaceDecl list

type program = Program of namespaceDecl list