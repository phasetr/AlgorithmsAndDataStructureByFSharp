/// Array, List, Sequence のメモをまとめた
module Array =
    (*
    Array.sub を f |> g でつなげられるように引数の順番を変更し、
    引数の意味も変えたバージョン。
    Array.sub とは少し挙動が違うので注意。

    Array.sub は Array.sub array start count
    Array.sub [| 0; 2; 4; 6; 8; 10 |] 2 3 // [|4; 6; 8|]

    ここでの slice は slice start end array：end は end 番目までを含む
    slice 2 3 [| 0; 2; 4; 6; 8; 10 |] // [|4; 6|]
    *)
    let slice s e a = Array.sub a s (e - s + 1)

module List =
    (*
    delete: Haskell の delete と同じ
    https://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:delete
    delete 1 [ 1; 2; 3 ] |> printfn "%A" // [2; 3]
    delete 4 [ 1; 2; 3 ] |> printfn "%A" // [1; 2; 3]
    *)

    let rec delete x xs =
        match xs with
        | [] -> []
        | y :: ys -> if x = y then ys else y :: delete x ys

    (*
    delete と違い全ての要素を削除する
    deleteAll 1 [ 1; 2; 3; 1; 1; 2; 3 ] |> printfn "%A" // [2; 3; 2; 3]
    deleteAll 4 [ 1; 2; 3; 1; 1; 2; 3 ] |> printfn "%A" // [1; 2; 3; 1; 1; 2; 3]
    *)

    let rec deleteAll x = List.filter ((<>) x)

    (*
    takeWhile: Haskell の takeWhile と同じ
    https://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:takeWhile
    下の例では不等号の向きに注意しよう：意図通りか実際に REPL で確かめるのがベスト
    takeWhile ((>) 3) [1; 2; 3; 4; 1; 2; 3; 4] = [1; 2]
    takeWhile ((>) 9) [1; 2; 3] = [1; 2; 3]
    takeWhile ((>) 0) [1; 2; 3] = []
    *)

    let rec takeWhile (p: 'a -> bool) lst =
        match lst with
        | [] -> []
        | x :: xs -> if p x then x :: takeWhile p xs else []

    (*
    dropWhile: Haskell の dropWhile と同じ
    https://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:dropWhile
    下の例では不等号の向きに注意しよう：意図通りか実際に REPL で確かめるのがベスト
    dropWhile ((>) 3) [1; 2; 3; 4; 5; 1; 2; 3] = [3; 4; 5; 1; 2; 3]
    dropWhile ((>) 9) [1; 2; 3] |> List.isEmpty
    dropWhile ((>) 0) [1; 2; 3] = [1; 2; 3]
    *)

    let rec dropWhile (p: 'a -> bool) lst =
        match lst with
        | [] -> []
        | x :: xs -> if p x then dropWhile p xs else lst

    (*
    span: Haskell の span と同じ
    `span p xs = (takeWhile p xs, dropWhile p xs)` であることに注意。
    https://hackage.haskell.org/package/base-4.14.0.0/docs/src/GHC.List.html#span
    span ((>) 3) [1; 2; 3; 4; 1; 2; 3; 4] = ([1; 2], [3; 4; 1; 2; 3; 4])
    span ((>) 9) [1; 2; 3] = ([1; 2; 3], [])
    span ((>) 0) [1; 2; 3] = ([], [1; 2; 3])
    *)

    let rec span (p: 'a -> bool) lst =
        match lst with
        | [] -> ([], [])
        | x :: xs ->
            if p x then
                let (ys, zs) = span p xs
                (x :: ys, zs)
            else
                ([], lst)

    (*
    groupBy: Haskell の groupBy と同じ
    http://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:groupBy
    groupBy (=) ("Mississippi" |> List.ofSeq) =
      [['M']; ['i']; ['s'; 's']; ['i']; ['s'; 's']; ['i']; ['p'; 'p']; ['i']]
    *)

    let rec groupBy (p: 'a -> 'a -> bool) lst: list<list<'a>> =
        match lst with
        | [] -> []
        | x :: xs ->
            let (ys, zs) = span (p x) xs
            (x :: ys) :: groupBy p zs

    (*
    group: Haskell の group と同じ
    http://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:group
    group ("Mississippi" |> List.ofSeq)
    [['M']; ['i']; ['s'; 's']; ['i']; ['s'; 's']; ['i']; ['p'; 'p']; ['i']]
    *)

    let group xs = groupBy (=) xs
    group ("Mississippi" |> List.ofSeq)

    (*
    zipWith: FSharpPlus では ZipList?
    F# では map2 を使えばよかった模様。
    zipWith (+) [1;2;3] [2;4;6] // [3; 6; 9]
    List.map2 (+) [1;2;3] [2;4;6] // [3; 6; 9]
    *)

    let zipWith f xs ys =
        List.zip xs ys |> List.map (fun (x, y) -> f x y)

module Sequence =
    // https://atcoder.jp/contests/abc169/tasks/abc169_d
    /// Seq に対する head-tail の分解
    /// Active Pattern 利用
    let (|SeqEmpty|SeqCons|) (xs: 'a seq) =
        if Seq.isEmpty xs then SeqEmpty else SeqCons(Seq.head xs, Seq.skip 1 xs)

    /// group: Haskell の group と同じ
    /// http://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:group
    /// group "Mississippi" |> printfn "%A" // seq [seq ['M']; seq ['i']; seq ['s'; 's']; seq ['i']; ...]
    let rec group =
        function
        | SeqEmpty -> Seq.empty
        | SeqCons (x, xs) ->
            let ys: 'a seq = Seq.takeWhile ((=) x) xs
            let zs: 'a seq = Seq.skipWhile ((=) x) xs
            Seq.append (seq { Seq.append (seq { x }) ys }) (group zs)

    /// https://atcoder.jp/contests/abc169/tasks/abc169_d
    /// return! を使った再帰ではなく mutable を使っているのは return! で生成されるステートマシンのコストが（数を出して1増やすだけの処理より）普通に高いため
    let initInfinite64 f =
        seq {
            let mutable i = 0L
            while true do
                yield f i
                i <- i + 1L
        }

    let initInfiniteBigInteger f =
        seq {
            let mutable i = 0I
            while true do
                yield f i
                i <- i + 1I
        }
