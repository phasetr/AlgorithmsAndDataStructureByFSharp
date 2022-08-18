#r "nuget: FsUnit"
open FsUnit

type Table<'a,'b> = Table of ('b * 'a) list

let newTable: ('b * 'a) list -> Table<'a,'b> = Table
let toList: Table<'a,'b> -> ('b*'a) list = function Table r -> r

let rec findTable: Table<'a,'b> -> 'b -> 'a when 'b: comparison = fun table i ->
  match table with
    | Table [] -> failwith "item not found in table"
    | Table ((j,v) :: r) ->
      if i=j then v else findTable (Table r) i

let rec updTable: 'b*'a -> Table<'a,'b> -> Table<'a,'b> = fun e table ->
  match (e,table) with
    | e, Table [] -> Table [e]
    | ((i,_), Table (x::r)) ->
      let (j,_) = x
      if i=j then Table (e::r)
      else let r' = updTable e (Table r) |> toList in Table (x :: r')

let () =
  newTable [("a",1);("b",2)] |> should equal (Table [("a",1);("b",2)])
  let t = newTable [("a",1);("b",2)]
  findTable (newTable [("a",1);("b",2)]) "a" |> should equal 1
  findTable (newTable [("a",1);("b",2)]) "b" |> should equal 2
  (fun () -> findTable (newTable [("a",1);("b",2)]) "c" |> ignore) |> should throw typeof<System.Exception>
  updTable ("c",3) t |> should equal (Table [("a",1);("b",2);("c",3)])
