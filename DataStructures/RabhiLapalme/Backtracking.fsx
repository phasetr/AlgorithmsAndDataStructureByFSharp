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
// TODO: 実装正しい?
let rec delHeap: int -> Heap<'a> -> 'a * Heap<'a> = fun k node ->
  match (k,node) with
    | (1, Node(v, Empty, Empty)) -> (v, Empty)
    | (_, Node(v,lf,rt)) ->
      if k%2 = 0 then let (v',rest) = delHeap (k/2) lf in (v', Node(v,rt,rest))
      else let (v',rest) = delHeap (k/2) rt in (v', Node(v,lf,rest))
    | _ -> failwith "TODO: need to reconsider"
let rec pdown: 'a * Heap<'a> -> Heap<'a> = function
  | (v, Empty) -> Empty
  | (v, Node(k, Empty, Empty)) -> Node(v, Empty, Empty)
  | (v, Node(k, Node(a, lf, rt), Empty)) ->
    if a<v then Node(a, Node(v, lf, rt), Empty)
    else Node(v, Node(a, lf, rt), Empty)
  | (v, Node(n, Node(a, lfa, rta), Node(b, lfb, rtb))) ->
    let n1 = Node(a, lfa, rta)
    let n2 = Node(b, lfb, rtb)
    if v<b then Node(v, n1, n2) else Node(b, n1, pdown(v, n2))
  | _ -> failwith "undefined"

type PQueue<'a> = int * Heap<'a>
let emptyPQ: PQueue<'a> = (0, emptyHeap)
let pqEmpty: PQueue<'a> -> bool = fun (_,t) -> heapEmpty t
let enPQ: 'a -> PQueue<'a> -> PQueue<'a> = fun k (s,t) -> (s+1, insHeap (s+1,k) t)
let frontPQ: PQueue<'a> -> 'a = fun (_,t) -> findHeap 1 t
let dePQ: PQueue<'a> -> PQueue<'a> = fun (s,t) ->
  let (k,t') = delHeap s t in (s-1, pdown(k,t'))

let rec searchDfs: ('a -> Stack<'a>) -> ('a -> bool) -> 'a -> Stack<'a> = fun succ goal x ->
  let rec search s =
    if stackEmpty s then []
    else if goal (top s) then s :: search (pop s)
    else let x = top s in search (List.foldBack push (pop s) (succ x))
  search (push x emptyStack)

// TODO: dfs, pfs

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
  delHeap 1 (Node(1,Empty,Empty)) |> should equal ((1, Empty):(int * Heap<int>))
  delHeap 1 (Node(2,Empty,Empty)) |> should equal ((2, Empty):(int * Heap<int>))
  // TODO: pdown
