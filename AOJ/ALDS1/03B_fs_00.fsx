#r "nuget: FsUnit"
open FsUnit

let rec solve q t acc tq = function
  | [] -> if List.isEmpty tq then List.rev acc else solve q t acc [] (List.rev tq)
  | (n0,t0)::pqs ->
    if t0 > q then solve q (t+q) acc ((n0,t0-q)::tq) pqs
    else solve q (t+t0) ($"{n0} {t+t0}" :: acc) tq pqs

let N,q = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let As = [ for i in 1..N do (stdin.ReadLine().Split() |> (fun x -> x.[0], int x.[1])) ]
solve q 0 [] As [] |> String.concat "\n" |> stdout.WriteLine

solve 100 0 [] [] [("p1",150);("p2",80);("p3",200);("p4",350);("p5",20)] |> should equal ["p2 180";"p5 400";"p1 450";"p3 550";"p4 800"]
