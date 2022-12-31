#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 4,[|(4,20);(3,30);(2,20);(1,10)|]
let N,Ia = 8,[|(8,100);(7,100);(6,100);(5,100);(4,100);(3,100);(2,100);(1,100)|]
*)
let solve N Ia =
  (Array2D.create N N 0, [|1..N-1|])
  ||> Array.fold (fun dp c ->
    [|0..(N-c-1)|] |> Array.iter (fun i ->
      let l = let (p,a) = Ia.[i]   in if i<p && p<=i+c+1 then a else 0
      let r = let (p,a) = Ia.[i+c] in if i<p && p<=i+c+1 then a else 0
      dp.[i,i+c] <- max (l+dp.[i+1,i+c]) (r+dp.[i,i+c-1]))
    dp)
  |> fun dp -> dp.[0,N-1]

let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Ia |> stdout.WriteLine

solve 4 [|(4,20);(3,30);(2,20);(1,10)|] |> should equal 50
solve 8 [|(8,100);(7,100);(6,100);(5,100);(4,100);(3,100);(2,100);(1,100)|] |> should equal 400
