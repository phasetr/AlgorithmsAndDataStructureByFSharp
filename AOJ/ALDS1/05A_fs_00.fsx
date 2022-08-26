#r "nuget: FsUnit"
open FsUnit

let solve Aa Ma =
  let judge m =
    let rec iter s = function
      | [] -> if s=m then true else false
      | x::xs ->
        if s>m then false
        else if s=m then true
        else (iter s xs || iter (s+x) xs)
    iter 0 (Aa |> Array.toList)
  Ma |> Array.map (fun x -> if judge x then "yes" else "no")

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
let Q = stdin.ReadLine() |> int
let Ma = stdin.ReadLine().Split() |> Array.map int
solve Aa Ma |> Array.map stdout.WriteLine

solve [|1;5;7;10;21|] [|2;4;17;8|] |> should equal [|"no";"no";"yes";"yes"|]
