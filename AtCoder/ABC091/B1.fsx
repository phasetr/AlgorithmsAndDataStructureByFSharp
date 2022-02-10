@"https://atcoder.jp/contests/abc091/tasks/abc091_b"
#r "nuget: FsUnit"
open FsUnit

let solve N Ss M Ts =
    let ps = Ss |> Array.groupBy id |> Array.map (fun (x,ys) -> (x, ys |> Array.length))
    let ms = Ts |> Array.groupBy id |> Array.map (fun (x,ys) -> (x, ys |> Array.length |> fun x -> x * (-1)))
    Array.append ps ms
    |> Array.groupBy (fun (x,_) -> x)
    |> Array.map (fun (x,ys) -> (x, ys |> Array.fold (fun acc (_,n) -> acc+n) 0))
    |> Array.maxBy (fun (_,m) -> m)
    |> fun (_,n) -> if 0 <= n then n else 0

let N = stdin.ReadLine() |> int
let Ss = [| for i in 1..N do stdin.ReadLine() |]
let M = stdin.ReadLine() |> int
let Ts = [| for i in 1..M do stdin.ReadLine() |]
solve N Ss M Ts |> stdout.WriteLine

solve 3 [|"apple";"orange";"apple"|] 1 [|"grape"|] |> should equal 2
solve 3 [|"apple";"orange";"apple"|] 5 [|"apple";"apple";"apple";"apple";"apple"|] |> should equal 1
solve 1 [|"voldemort"|] 10 [|"voldemort";"voldemort";"voldemort";"voldemort";"voldemort";"voldemort";"voldemort";"voldemort";"voldemort";"voldemort"|] |> should equal 0
solve 6 [|"red";"red";"blue";"yellow";"yellow";"red"|] 5 [|"red";"red";"yellow";"green";"blue"|] |> should equal 1
