# Even Fibonacci numbers

## はじめに

これは記録としてブログの方にも挙げておく.

- [問題の URL](https://projecteuler.net/problem=2)
- [GitHub の URL](https://github.com/phasetr/AlgorithmsAndDataStructureByFSharp/tree/master/ProjectEuler/00002_Even_Fibonacci_numbers)
- [対応するブログ記事の URL](https://phasetr.com/blog/2020/08/30/project-euler-problem-2-even-fibonacci-numbers-fsharp-and-julia/)

F# に合わせて Julia 版も書き直したいが後回しにする.

## F# に関する注意

この readme では次のツイートと Gist の調査結果をまとめている.

- [ツイート](https://twitter.com/phasetrbot/status/1299374694408151042)
- [Gist](https://gist.github.com/phasetr/4f4770b991e6926a8a6e9e86e2785ee1)

ポイントは次の 2 点.

- フィボナッチ数列の `seq` を作るときの注意.
- フィボナッチ数列を作らない場合の処理.

成果はそれぞれ 01.fsx, 02.fsx にまとめてある.
以下では備忘録としてはまった点と調査経緯をまとめおく.

## はまりどころまとめ

### 初手

まず次のようなコードを書いた.

```
let rec fibMemo =
    let dict =
        System.Collections.Generic.Dictionary<_, _>()

    fun n ->
        match dict.TryGetValue(n) with
        | true, v -> v
        | false, _ ->
            let temp =
                if n = 0L then 0L
                else if n = 1L then 1L
                else fibMemo (n - 1L) + fibMemo (n - 2L)

            dict.Add(n, temp)
            temp

let initInfinite64 f =
    seq {
        let mutable i = 0L
        while true do
            yield f i
            i <- i + 1L
    }

let fourMillion = 4000000L

initInfinite64 fibMemo
|> Seq.filter (fun x -> x < fourMillion)
|> Seq.filter (fun x -> x % 2L = 0L)
|> Seq.sum
```

これでエラーが出た.

> System.OverflowException: Arithmetic operation resulted in an overflow.
> at <StartupCode$FSI_0014>.$FSI_0014.main@()
> エラーのため停止しました

`Seq.sum` の前まではきちんと動くものの `Seq.sum` で怒られる.

ここで有識者に質問したところ次のコメントを頂く.

> 1. フィボナッチ数列を seq として実際に作る必要はない．fib(n-2), fib(n-1), 和の3つだけ持っていればいいはず．
> 2. fib(34) > 4000000 なので printf デバッグが通用するはず．
>
> ヒント: int64 がオーバーフローしたとき，その値はどうなる？それを 4000000 と < で比べると？

オーバーフローについてメモ.

- int64 MAX: 9223372036854775807L
- int64 MIN: -9223372036854775808L
- int MAX: 2147483647
- int MIN: -2147483648

### 調査第 2 弾

まず printf デバッグ的な方向で調査しようとして次のようにはまる.

`let initInfinite64 (f: int64 -> int64)` として `f` に型をつけてみたが駄目だた.
`sum` は `int` 用の関数なのかと思い, `sum` を `Seq.fold (+) 0L` に変えてみると型があってハッピーかもしれないと思ったが,
処理が止まり待つとエラー.

`filter` の挙動がよくわからなかった.
その調査ログは次の通り.

```
initInfinite64 fibMemo
|> Seq.take 34
|> Seq.toArray

val it : int64 [] =
  [|0L; 1L; 1L; 2L; 3L; 5L; 8L; 13L; 21L; 34L; 55L; 89L; 144L; 233L; 377L;
    610L; 987L; 1597L; 2584L; 4181L; 6765L; 10946L; 17711L; 28657L; 46368L;
    75025L; 121393L; 196418L; 317811L; 514229L; 832040L; 1346269L; 2178309L;
    3524578L|]
```

上のコードは問題ないが, 下の `filter` つきのコードはエラー.

```
> initInfinite64 fibMemo
- |> Seq.filter (fun x -> x < 30L)
- |> Seq.take 34
- |> Seq.toArray;;
System.OverflowException: Arithmetic operation resulted in an overflow.
   at FSI_0017.clo@117-2.Invoke(Int64 n)
   at FSI_0017.initInfinite64@131-3.GenerateNext(IEnumerable`1& next)
   at Microsoft.FSharp.Core.CompilerServices.GeneratedSequenceBase`1.MoveNextImpl() in F:\workspace\_work\1\s\src\fsharp\FSharp.Core\seqcore.fs:line 371
   at Microsoft.FSharp.Core.CompilerServices.GeneratedSequenceBase`1.System-Collections-IEnumerator-MoveNext() in F:\workspace\_work\1\s\src\fsharp\FSharp.Core\seqcore.fs:line 403
   at Microsoft.FSharp.Collections.Internal.IEnumerator.next@193[T](FSharpFunc`2 f, IEnumerator`1 e, FSharpRef`1 started, Unit unitVar0) in F:\workspace\_work\1\s\src\fsharp\FSharp.Core\seq.fs:line 194
   at Microsoft.FSharp.Collections.Internal.IEnumerator.filter@188.System-Collections-IEnumerator-MoveNext() in F:\workspace\_work\1\s\src\fsharp\FSharp.Core\seq.fs:line 196
   at Microsoft.FSharp.Collections.SeqModule.Take@686.GenerateNext(IEnumerable`1& next) in F:\workspace\_work\1\s\src\fsharp\FSharp.Core\seq.fs:line 688
   at Microsoft.FSharp.Core.CompilerServices.GeneratedSequenceBase`1.MoveNextImpl() in F:\workspace\_work\1\s\src\fsharp\FSharp.Core\seqcore.fs:line 371
   at Microsoft.FSharp.Core.CompilerServices.GeneratedSequenceBase`1.System-Collections-IEnumerator-MoveNext() in F:\workspace\_work\1\s\src\fsharp\FSharp.Core\seqcore.fs:line 403
   at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
   at Microsoft.FSharp.Collections.SeqModule.ToArray[T](IEnumerable`1 source) in F:\workspace\_work\1\s\src\fsharp\FSharp.Core\seq.fs:line 825
   at <StartupCode$FSI_0044>.$FSI_0044.main@()
エラーのため停止しました
```

ここで追加質問して次の回答を頂く.

> ilter を施す前に Seq.iter (printfn "%A") などを使って実際にどういう数列が出てきているのか確かめてみましょう，それを見ればどうしておかしくなっているのかわかりそう

### 調査第 3 段

次のようなコードを実行して 100 くらい見てみると, オーバーフローしてマイナスが出てきた.
それも繰り返し出てくる.
これに対して `filter` すれば, それは確かに無限に `filter` が走ってひどいことになる.
上のテストで `filter` をかませるとひどいことになるのは先にこれが走るからだ.

```
> initInfinite64 fibMemo |> Seq.take 100 |> Seq.iter (printfn "%A");;
0L
1L
1L
2L
3L
5L
8L
13L
21L
34L
55L
89L
144L
233L
377L
610L
987L
1597L
2584L
4181L
6765L
10946L
17711L
28657L
46368L
75025L
121393L
196418L
317811L
514229L
832040L
1346269L
2178309L
3524578L
5702887L
9227465L
14930352L
24157817L
39088169L
63245986L
102334155L
165580141L
267914296L
433494437L
701408733L
1134903170L
1836311903L
2971215073L
4807526976L
7778742049L
12586269025L
20365011074L
32951280099L
53316291173L
86267571272L
139583862445L
225851433717L
365435296162L
591286729879L
956722026041L
1548008755920L
2504730781961L
4052739537881L
6557470319842L
10610209857723L
17167680177565L
27777890035288L
44945570212853L
72723460248141L
117669030460994L
190392490709135L
308061521170129L
498454011879264L
806515533049393L
1304969544928657L
2111485077978050L
3416454622906707L
5527939700884757L
8944394323791464L
14472334024676221L
23416728348467685L
37889062373143906L
61305790721611591L
99194853094755497L
160500643816367088L
259695496911122585L
420196140727489673L
679891637638612258L
1100087778366101931L
1779979416004714189L
2880067194370816120L
4660046610375530309L
7540113804746346429L
-6246583658587674878L
1293530146158671551L
-4953053512429003327L
-3659523366270331776L
-8612576878699335103L
6174643828739884737L
-2437933049959450366L
```

### フィボナッチ数列の seq を作る手法での修正

`initInfinite64` 自体に `limit` を追加して対応.

```
let initInfinite64 (f: int64 -> int64) (limit: int64) =
    seq {
        let mutable i = 0L
        let mutable l = 0L
        while l < limit do
            yield f i
            l <- f i
            i <- i + 1L
    }
```

オーバーフローを未然に防ぐ形で処理できた.

### フィボナッチ数列の seq を作らない手法

指摘を受けてこちらにも対応してみた.
成果は 02.fsx にまとめている.
特に問題なく一発で動いた.
