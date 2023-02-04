#r "nuget: FsUnit"
open FsUnit

type Heap<'a when 'a: comparison> = | Empty | HP of 'a * int * 'a Heap * 'a Heap

let empty = Empty
let isEmpty = function | Empty -> true | _ -> false
let singleton x = HP(x,1,Empty,Empty)
let find = function
  | Empty -> failwith "find: empty heap"
  | HP (x,_,_,_) -> x
let rank = function | Empty -> 0 | HP (_,r,_,_) -> r
let create x a b = if rank a >= rank b then HP(x, rank b + 1, a, b) else HP(x, rank a + 1, b, a)
let rec merge h1 h2 =
  match h1, h2 with
    | h1, Empty -> h1
    | Empty, h2 -> h2
    | HP (x1, _, a1, b1), HP (x2, _, a2, b2) ->
      if x1 <= x2 then create x1 a1 (merge b1 h2) else create x2 a2 (merge h1 b2)
let insert x h = merge (singleton x) h
let delete = function | Empty -> failwith "delete: empty heap" | HP (x,_,a,b) -> merge a b
let ofList xs = (Empty,xs) ||> List.fold (fun h x -> insert x h)
let rec toList = function | Empty -> [] | h -> let x = find h in x::(delete h |> toList)

let test =
  Empty |> printfn "%A"
  Empty |> isEmpty |> should be True

  insert 1 Empty |> should equal (HP(1,1,Empty,Empty))
  insert 1 Empty |> insert 2 |> should equal (HP(1,1,HP (2,1,Empty,Empty),Empty))
  insert 1 Empty |> insert 2 |> insert 3 |> should equal (HP(1,2,HP (2,1,Empty,Empty),HP (3,1,Empty,Empty)))
  insert 1 Empty |> insert 2 |> insert 3 |> insert 4 |> should equal (HP(1,2,HP (2,1,Empty,Empty),HP (3,1,HP (4,1,Empty,Empty),Empty)))
