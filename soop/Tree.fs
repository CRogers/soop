module Tree

open System


type stype = string


type op =
    | Plus | Minus | Times | Divide


type expr =
    | Int of int
    | String of string
    | Binop of op * expr * expr
    | Var of string
    // methodName, args
    | MethodCall of string * expr list

type stmt =
    | NewAssign of stype * string * expr
    | Assign of string * expr
    // condition, ifpart, elsepart
    | If of expr * stmt list * stmt list
    // condition, loop code
    | While of expr * stmt list

type accessModifier =
    | Public | Private | Protected

// name, type, initial value
type arg = Arg of string * stype

// name, params, return type, stmts
type methodDecl = Method of string * arg list * stype * stmt list

type classDecl = 
    | LocalVar of string * accessModifier * stype * expr
    | Method of string * accessModifier * arg list * stype * stmt list
    | Constructor of accessModifier * arg list * stmt list

type classInterfaceDecl = 
    // local vars, constructors, methods 
    | Class of string * classDecl list
    // methods
    | Interface of methodDecl list

type namespaceDecl = Namespace of string * classInterfaceDecl list

type program = Program of namespaceDecl list