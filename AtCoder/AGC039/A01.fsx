@"https://atcoder.jp/contests/agc039/tasks/agc039_a
- 1 \leq |S| \leq 100
- S は英小文字からなる
- 1 \leq K \leq 10^9
- K は整数である"
#r "nuget: FsUnit"
open FsUnit

@"解説から.

同じ文字がk個連続するときそのうちの ⌊k/2⌋ 文字を変えればよい.
S の全文字が同じなら答えは ⌊|S|K/2⌋.
以下そうではない場合を考える.
同じ文字の連続は S の内部または 2 つのSの接続部に出る.
S の先頭と末尾の文字が違うとき答えは S に対する答えの K 倍.
同じときはSの先頭・末尾に続く同じ文字の個数を a, b として,
S に対する答えの K 倍から ⌊a/2⌋+⌊b/2⌋ − ⌊(a+b)/2⌋の K − 1 倍を引く."
let S,K = "issii",2L
let S,K = "qq",81L
let solve (S:string) K =
    let Sa = S |> Array.ofSeq
    let l = Sa.Length |> int64
    if Sa |> Array.forall (fun e -> e=Sa.[0]) then l*K/2L
    else
        let inner = ((0L,Sa.[0]), Sa.[1..]) ||> Array.fold (fun (acc,c) s ->
            if c=s then (acc+1L,'0') else (acc,s)) |> fun x -> (fst x)*K
        if Sa.[0]<>(Array.last Sa) then inner
        else
            let a = Sa |> Array.takeWhile (fun c -> c=Sa.[0]) |> Array.length |> int64
            let b = Sa |> Array.rev |> Array.takeWhile (fun c -> c=Array.last Sa) |> Array.length |> int64
            inner - ((a/2L) + (b/2L) - ((a+b)/2L))*(K-1L)
let S = stdin.ReadLine()
let K = stdin.ReadLine() |> int64
solve S K |> stdout.WriteLine

solve "issii" 2L |> should equal 4L
solve "qq" 81L |> should equal 81L
solve "qa" 81L |> should equal 0L
solve "cooooooooonteeeeeeeeeest" 999993333 |> should equal 8999939997L
solve "a" 1L |> should equal 0L
solve "a" 2L |> should equal 1L
solve "a" 3L |> should equal 1L
solve "a" 4L |> should equal 2L
solve "a" 5L |> should equal 2L
