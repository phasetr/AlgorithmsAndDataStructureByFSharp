@"https://atcoder.jp/contests/abc136/tasks/abc136_c"
#r "nuget: FsUnit"
open FsUnit

@"右から比べる."
let solve N As =
    Array.foldBack (fun h (h0,b) ->
        if h <= h0 then (h, b&&true)    // 右の方が高ければOK
        elif h0+1=h then (h-1, b&&true) // 右の方が低いが一つだけならよしとする
        else (h, false)) As (As.[N-1], true)
    |> fun (_,b) -> if b then "Yes" else "No"
let N = stdin.ReadLine() |> int
let As = stdin.ReadLine().Split() |> Array.map int
solve N As |> stdout.WriteLine

let stoi (s: string) = s.Split(" ") |> Array.map int
let sstois (s: string) = s.Split("\n") |> Array.map stoi

solve 5 [|1;2;1;1;3|] |> should equal "Yes"
solve 4 [|1;3;2;1|] |> should equal "No"
solve 5 [|1;2;3;4;5|] |> should equal "Yes"
solve 1 [|1000000000|] |> should equal "Yes"
