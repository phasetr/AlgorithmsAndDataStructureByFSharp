#r "nuget: FsUnit"
open FsUnit

// cf. https://en.wikibooks.org/wiki/F_Sharp_Programming/Advanced_Data_Structures

/// List difference, リストの差, オリジナルでは`(\\)`
let (-.) xs ys =
  let rec del xs y =
    match xs with
      | [] -> []
      | z::zs -> if z=y then zs else z::(del zs y)
  List.fold del xs ys

let flatten xss = List.concat xss

type Stack<'a> = 'a list
let emptyStack: Stack<'a> = []
let stackEmpty: Stack<'a> -> bool = function
  | [] -> true
  | _  -> false

let push: 'a -> Stack<'a> -> Stack<'a> = fun x xs -> x::xs
let pop: Stack<'a> -> Stack<'a> = function
  | [] -> failwith "no stack"
  | _::xs -> xs
let top: Stack<'a> -> 'a = function
  | [] -> failwith "no stack"
  | x::_ -> x

type Heap<'a> = Empty | Node of 'a * Heap<'a> * Heap<'a>
let emptyHeap: Heap<'a> = Empty
let heapEmpty: Heap<'a> -> bool = function
  | Empty -> true
  | _ -> false
let rec findHeap: int -> Heap<'a> -> 'a = fun n node ->
  match node with
    | Empty -> failwith "Empty heap"
    | Node(v,lf,rt) ->
      if n=1 then v
      else if n%2=0 then findHeap (n/2) lf
      else findHeap (n/2) rt
let rec insHeap: (int * 'a) -> Heap<'a> -> Heap<'a> = fun (n,k) -> function
  | Empty -> Node(k,Empty,Empty)
  | Node(v,lf,rt) ->
    if v<k then if n%2=0 then Node(v, insHeap (n/2,k) lf, rt) else Node(v,lf,insHeap (n/2,k) rt)
    else if n%2=0 then Node(k,insHeap (n/2,v) lf, rt) else Node(k,lf,insHeap (n/2,v) rt)

let () =
  [1..3] -. [1] |> should equal [2;3]
  [1..3] -. [4] |> should equal [1..3]
let stackTest () =
  flatten [[1..2];[3..4]] |> should equal [1..4]
  stackEmpty emptyStack |> should be True
  stackEmpty [1..2] |> should be False
  push 1 emptyStack |> should equal [1]
  (fun () -> pop [] |> ignore) |> should throw typeof<System.Exception>
  pop [1] |> should equal (emptyStack: Stack<int>)
  pop [1..2] |> should equal [2]
  (fun () -> top [] |> ignore) |> should throw typeof<System.Exception>
  top [1] |> should equal 1
  top [1..3] |> should equal 1
let heapTest() =
  emptyHeap |> should equal (Empty: Heap<'int>)
  heapEmpty emptyHeap |> should be True
  insHeap (1,1) Empty |> should equal (Node(1,Empty,Empty))
  let two = insHeap (1,2) Empty
  insHeap (1,1) two |> should equal (Node (1, Empty, Node (2, Empty, Empty)))
  insHeap (1,3) two |> should equal (Node (2, Empty, Node (3, Empty, Empty)))
  findHeap 1 two
  (fun () -> findHeap 2 two |> ignore) |> should throw typeof<System.Exception>
