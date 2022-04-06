@"https://atcoder.jp/contests/abc129/submissions/20180512"
#r "nuget: FsUnit"
open FsUnit

@"TLE"
let solve N M Aa =
    let K = 1_000_000_007
    let (++) a b = (a+b)%K
    let f (x,y) b = (y, if b then 0 else x++y)
    let accum f is xs = Array.indexed is |> Array.map (fun (i,v) -> Array.fold f v [|for (j,x) in xs do if i=j then yield x|])
    Array.map (fun a -> (a-1,true)) Aa
    |> accum (||) (Array.replicate N false)
    |> Array.fold f (0,1)
    |> snd
let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = [| for i in 1..M do (stdin.ReadLine() |> int) |]
solve N M Aa |> Array.map stdout.WriteLine

solve 6 1 [|3|] |> should equal 4
solve 10 2 [|4;5|] |> should equal 0
solve 100 5 [|1;23;45;67;89|] |> should equal 608200469
