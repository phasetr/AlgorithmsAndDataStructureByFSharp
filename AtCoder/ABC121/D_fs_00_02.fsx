#r "nuget: FsUnit"
open FsUnit

(*
let A,B = 2L,4L
let A,B = 123L,456L
let A,B = 123456789012L,123456789012L
*)
let solve A B =
  let g0 x = Array.get [|x;1L;x+1L;0L|] (x%4L |> int)
  g0 (A-1L) ^^^ g0 B
  [|0L..12L|] |> Array.map (fun x -> sprintf "x: %d, g0 x: %d" x (g0 x))
  |> Array.iter (printfn "%A")

let solve A B =
  (0^^^1)
  (0^^^1)^^^(2)
  (0^^^1)^^^(2^^^3)
  (0^^^1)^^^(2^^^3)^^^(4)
  (0^^^1)^^^(2^^^3)^^^(4^^^5)
  (0^^^1)^^^(2^^^3)^^^(4^^^5)^^^(6)

  let g x =
  [|0L..12L|] |> Array.map (fun x -> sprintf "x: %d, g x: %d" x (g x))
  |> Array.iter (printfn "%A")

let A,B = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
solve A B |> stdout.WriteLine


[|0..12|]
|> Array.map (fun i -> (i, i%4, [|0..i|] |> Array.reduce (fun a b -> a^^^b)))
|> Array.iter (printfn "%A")

solve 2L 4L |> should equal 5L
solve 123L 456L |> should equal 435L
solve 123456789012L 123456789012L |> should equal 123456789012L
