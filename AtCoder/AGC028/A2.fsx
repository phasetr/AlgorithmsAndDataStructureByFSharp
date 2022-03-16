@"https://atcoder.jp/contests/agc028/submissions/18063940"
#r "nuget: FsUnit"
open FsUnit

let N,M,S,T = 3L,2L,"acp","ae"
let N,M,S,T = 15L,9L,"dnsusrayukuaiia","dujrunuma"
let solve N M (S:string) (T:string) =
    let gcd: int64 -> int64 -> int64 = fun x y ->
        let rec locgcd x y =
            match y with
            | 0L -> x
            | _ -> locgcd y (x % y)
        if x >= y then locgcd x y else locgcd y x
    let g = gcd N M
    let f i = S.[int ((N/g)*i)] = T.[int ((M/g)*i)]
    if Array.forall f [|0L..g-1L|] then (N*M)/g else -1L
let N, M = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
let S = stdin.ReadLine()
let T = stdin.ReadLine()
solve N M S T |> stdout.WriteLine

solve 3L 2L "acp" "ae" |> should equal 6L
solve 6L 3L  "abcdef" "abc" |> should equal -1L
solve 15L 9L "dnsusrayukuaiia" "dujrunuma" |> should equal 45L
