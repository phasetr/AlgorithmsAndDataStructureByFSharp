#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 5,[|(30,50);(10,30);(40,10);(50,20);(40,60)|]
let N,Ia = 9,[|(10,90);(20,80);(30,70);(40,60);(50,50);(60,40);(70,30);(80,20);(90,10)|]
*)
let solve N Ia =
  let bisectLeft x (Xa:'a[]) =
    let rec bsearch l r =
      if r<=l then l
      else let m = l+(r-l)/2 in if Xa.[m] < x then bsearch (m+1) r else bsearch l m
    Xa |> Array.length |> bsearch 0
  let Ja = Ia |> Array.map (fun (x,y) -> (x,-y)) |> Array.sort
  Array.create N (System.Int32.MaxValue)
  |> fun Ea ->
    for i in 0..N-1 do let y = - (snd Ja.[i]) in let j = bisectLeft y Ea in Ea.[j] <- y
    bisectLeft (System.Int32.MaxValue) Ea

let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Ia |> stdout.WriteLine

solve 5 [|(30,50);(10,30);(40,10);(50,20);(40,60)|] |> should equal 3
solve 9 [|(10,90);(20,80);(30,70);(40,60);(50,50);(60,40);(70,30);(80,20);(90,10)|] |> should equal 1
