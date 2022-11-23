#r "nuget: FsUnit"
open FsUnit

let N,A,B,Xa = 4L,2L,5L,[|1L;2L;5L;7L|]
let solve N (A:int64) B Xa =
  Xa |> Array.pairwise |> Array.sumBy (fun (x,y) -> let c = (y-x)*A in min c B)

let N,A,B = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1],x.[2])
let Xa = stdin.ReadLine().Split() |> Array.map int64
solve N A B Xa |> stdout.WriteLine

solve 4L 2L 5L [|1L;2L;5L;7L|] |> should equal 11L
solve 7L 1L 100L [|40L;43L;45L;105L;108L;115L;124L|] |> should equal 84L
solve 7L 1L 2L [|24L;35L;40L;68L;72L;99L;103L|] |> should equal 12L
