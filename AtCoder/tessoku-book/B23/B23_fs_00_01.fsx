#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 4,[|(0.0,0.0);(0.0,1.0);(1.0,0.0);(1.0,1.0)|]
let N,Ia = 7,[|(2.0,5.0);(2.0,3.0);(4.0,1.0);(1.0,1.0);(7.0,2.0);(5.0,3.0);(6.0,5.0)|]
*)
let solve N (Ia:(float*float)[]) =
  let M = 1<<<N
  let K = System.Double.MaxValue / 2.0
  let d a b = (fst Ia.[a] - fst Ia.[b])**2.0 + (snd Ia.[a] - snd Ia.[b])**2.0 |> sqrt
  Array2D.create M N K
  |> fun dp ->
    dp.[0,0] <- 0.0
    for S in 0..M-1 do
      for i in 0..N-1 do
        if dp.[S,i] < K then
          for j in 0..N-1 do
            if (j<<<S)&&&1 = 0 then dp.[S|||(1<<<j),j] <- min dp.[S|||(1<<<j),j] (dp.[S,i] + d i j)
    dp.[M-1,0]

let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map float |> fun x -> x.[0],x.[1])
solve N Ia |> stdout.WriteLine

solve 4 [|(0.0,0.0);(0.0,1.0);(1.0,0.0);(1.0,1.0)|]
// 4.000000000000
solve 7 [|(2.0,5.0);(2.0,3.0);(4.0,1.0);(1.0,1.0);(7.0,2.0);(5.0,3.0);(6.0,5.0)|]
// 18.870481592668
