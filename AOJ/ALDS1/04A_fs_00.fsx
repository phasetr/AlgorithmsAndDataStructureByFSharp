#r "nuget: FsUnit"
open FsUnit

let solve Sa Ta = (0,Ta) ||> Array.fold (fun c t -> if Array.contains t Sa then c+1 else c)

let N = stdin.ReadLine() |> int
let Sa = stdin.ReadLine().Split() |> Array.map int
let Q = stdin.ReadLine() |> int
let Ta = stdin.ReadLine().Split() |> Array.map int
solve Sa Ta |> stdout.WriteLine

solve [|1..5|] [|3;4;1|] |> should equal 3
solve [|3;1;2|] [|5|] |> should equal 0
solve [|1;1;2;2;3|] [|1;2|] |> should equal 2
