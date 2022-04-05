@"https://atcoder.jp/contests/abc129/tasks/abc129_c
* 1 \leqq N \leqq 10^5
* 0 \leqq M \leqq N-1
* 1 \leqq a_1 < a_2 < ... < a_M \leqq N-1"
#r "nuget: FsUnit"
open FsUnit

let solve N M Aa =
    let K = 1_000_000_007
    let (++) a b = (a+b)%K
    let rec frec (a,b,k) l =
        if k=l then (b,0,k+1)
        else frec (b, a++b, k+1) l
    Array.append Aa [|N+1|]
    |> Array.fold frec (0,1,1)
    |> fun (x,_,_) -> x
let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = [| for i in 1..M do (stdin.ReadLine() |> int) |]
solve N M Aa |> stdout.WriteLine

solve 6 1 [|3|] |> should equal 4
solve 10 2 [|4;5|] |> should equal 0
solve 100 5 [|1;23;45;67;89|] |> should equal 608200469
