#r "nuget: FsUnit"
open FsUnit

(*
let N,Xa = 3,[|(10L,10L);(20L,20L);(30L,30L)|]
let N,Xa = 3,[|(20L,10L);(20L,20L);(20L,30L)|]
let N,Xa = 6k[|(1,1000000000);(1,1000000000);(1,1000000000);(1,1000000000);(1,1000000000);(1,1000000000)|]

*)
let solve Xa =
  let bSum = Xa |> Array.sumBy snd
  Xa
  |> Array.sortByDescending (fun (a,b) -> a+b)
  |> Array.fold (fun (acc,i) (a,b) -> ((if i%2=0 then acc+a+b else acc), i+1)) (0L,0)
  |> fun (s,_) -> s-bSum

let N = stdin.ReadLine() |> int
let Xa = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int64 |> fun x -> x.[0],x.[1])
solve Xa |> stdout.WriteLine

solve [|(10L,10L);(20L,20L);(30L,30L)|] |> should equal 20L
solve [|(20L,10L);(20L,20L);(20L,30L)|] |> should equal 20L
solve [|(1,1000000000);(1,1000000000);(1,1000000000);(1,1000000000);(1,1000000000);(1,1000000000)|] |> should equal (-2999999997L)
