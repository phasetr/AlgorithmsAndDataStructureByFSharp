#r "nuget: FsUnit"
open FsUnit

(*
let N,H,W,Ia = 1,3,5,[|(2,4)|]
let N,H,W,Ia = 2,8,4,[|(6,4);(7,1)|]
*)
let solve N H W Ia =
  (0,Ia) ||> Array.fold (fun x (a,b) -> x^^^(a-1)^^^(b-1))
  |> fun x -> if x=0 then "Second" else "First"
let N,H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N H W Ia |> stdout.WriteLine

solve 1 3 5 [|(2,4)|] |> should equal "First"
solve 2 8 4 [|(6,4);(7,1)|] |> should equal "Second"
