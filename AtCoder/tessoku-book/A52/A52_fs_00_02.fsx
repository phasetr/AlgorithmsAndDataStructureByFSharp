#r "nuget: FsUnit"
open FsUnit

(*
let Q,Qa = 5,[|[|"1";"taro"|];[|"1";"hanako"|];[|"2"|];[|"3"|];[|"2"|]|]
*)
type Queue<'a> = Queue of list<'a> * list<'a>
let solve Q (Qa:string[][]) =
  let empty = Queue ([],[])
  let enqueue = fun x -> function
    | Queue([],[]) -> Queue ([x],[])
    | Queue(xs,ys) -> Queue (xs, x::ys)
  let dequeue = function
    | Queue([],[]) -> failwith "dequeue: empty queue."
    | Queue([],ys) -> Queue(ys |> List.rev |> List.tail, [])
    | Queue(x::xs,ys) -> Queue(xs,ys)
  let peek = function
    | Queue([],[]) -> failwith "front: empty queue."
    | Queue([], ys) -> List.last ys
    | Queue(x::xs,ys) -> x
  (empty,Qa) ||> Array.fold (fun q qa ->
    match qa.[0] with
      | "1" -> q |> enqueue qa.[1]
      | "2" -> q |> peek |> stdout.WriteLine; q
      | _   -> q |> dequeue)

let Q = stdin.ReadLine() |> int
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split())
solve Q Qa

(*
taro
hanako
*)
