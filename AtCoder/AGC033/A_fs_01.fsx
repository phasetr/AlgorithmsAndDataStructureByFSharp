// https://atcoder.jp/contests/agc033/submissions/13798674
(* Examples *)
(*
stdin.ReadLine()
printfn "%d"
printfn "%s"
*)

(* Library *)
module Library =
  type Queue<'T> (capacity : int) =
    let data = Array.create (capacity + 1) Unchecked.defaultof<'T>
    let length = capacity + 1
    let mutable head = 0
    let mutable tail = 0

    member internal this.Add x = (x + 1) % length
    member internal this.Delete x = (x - 1) % length

    member this.isEmpty =
      if head = tail then true else false

    member this.isFull =
      if this.Add tail = head then true else false

    member this.Enqueue x =
      if this.isFull then
        raise(new System.Exception("Capacity over"))
      else
        data.[tail] <- x
        tail <- this.Add tail
        ()

    member this.Peek =
      if this.isEmpty then
        None
      else
        Some data.[head]

    member this.Dequeue =
      if this.isEmpty then
        None
      else
        let result = Some data.[head]
        head <- this.Add head
        result

    member this.Clear =
      head <- 0
      tail <- 0
      ()

(* Standard Input *)
let readSplit elementFun=
  stdin.ReadLine().Split()
  |> Array.map elementFun

let read elementFun =
  stdin.ReadLine() |> elementFun

let readMap H =
  [|for i in 1..H -> stdin.ReadLine()|]
  |> Array.map(fun line ->
    line.ToCharArray()
  )
  |> array2D

(* Main *)
open Library

let [|H; W|] = readSplit int
let map = readMap H

let Q = Queue<int * int * int>(4000000)
map |> Array2D.iteri(fun i j chr ->
  if chr = '#' then
    Q.Enqueue (i, j, 0)
)

let mutable result = 0

let rec solve () =
  match Q.Dequeue with
  | Some (x, y, c) ->
    if x < 0 || x >= H || y < 0 || y >= W || map.[x, y] = 'b' then
      solve ()
    else
      map.[x, y] <- 'b'
      Q.Enqueue (x + 1, y, c + 1)
      Q.Enqueue (x, y + 1, c + 1)
      Q.Enqueue (x - 1, y, c + 1)
      Q.Enqueue (x, y - 1, c + 1)
      result <- c
      solve ()
  | _ -> ()

solve ()
result |> printfn "%d"
