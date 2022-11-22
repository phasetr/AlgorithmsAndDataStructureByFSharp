// https://atcoder.jp/contests/abc088/submissions/2112052
namespace global
  open System
  open System.Collections
  open System.Collections.Generic

  type Color = | Black | White

  [<AutoOpen>]
  module Operators =
    let read f = Console.ReadLine().Split([|' '|]) |> Array.map f

  module Program =
    [<EntryPoint>]
    let main _ =
      let stoa (str: string) = str.ToCharArray()
      let neigh = [|
        1, 0
        0, -1
        -1, 0
        0, 1
      |]

      match read int with
      | [|H; W|] ->
        let board =
          [|
            for _ in 0..(H + 2) ->
              Array.replicate (W + 2) Black
          |]
        for y in 1..H do
          let line = Console.ReadLine()
          for i in 0..(W - 1) do
            if line.[i] = '.' then
              board.[y].[i + 1] <- White
        let whiteCount =
          board |> Seq.collect id |> Seq.sumBy (fun t -> if t = White then 1 else 0)

        let set = HashSet<_>()
        let queue = Queue<_>()
        queue.Enqueue(((1, 1), 1))
        let rec go () =
          if queue.Count = 0 then
            -1
          else
            let ((y, x), d) = queue.Dequeue()
            if board.[y].[x] = Black then
              go ()
            else if (y, x) = (H, W) then
              whiteCount - d
            else
              for (dy, dx) in neigh do
                let y' = y + dy
                let x' = x + dx
                if set.Add((y', x')) then
                  queue.Enqueue(((y', x'), d + 1))
              go ()
        let dist = go ()
        printfn "%d" dist
      | _ -> ()
      0
