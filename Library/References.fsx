/// 関数の名前をよく忘れてリファレンスを見に行くのが面倒なので、使った関数はまとめよう
/// TODO compareWith まで対応 https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html
#r "nuget: FsUnit"
open FsUnit

module Array =
    // accessor or slice
    let a = [| 0 .. 4 |]
    a.[0] |> should equal 0
    a.[0..2] |> should equal [| 0; 1; 2 |]
    a.[1..] |> should equal [| 1; 2; 3; 4 |]
    a.[..3] |> should equal [| 0; 1; 2; 3 |]

    module AllPairs =
        // Array.allPairs
        // 配列 1 と配列 2 の各要素のすべての組み合わせをタプルの要素とする配列を得る.
        // 結果となる配列の長さが膨大になる可能性があるため引数の配列の長さに注意すること.
        // 引数の配列のどちらかが空のときは結果の配列も空になる.
        Array.allPairs [| 'a'; 'b'; 'c' |] [|
            1
            2
        |]

        Array.allPairs<char, int> [| 'a'; 'b' |] [||] // [||] : (char * int) []

    module Append =
        // Array.append
        // 配列の連結
        // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#append
        let a1 = [| 0 .. 5 |]
        let a2 = [| 10 .. 15 |]
        Array.append a1 a2 //  [|0; 1; 2; 3; 4; 5; 10; 11; 12; 13; 14; 15|]

    module Average =
        // Array.average
        // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#average
        Array.average [| 1.0 .. 10.0 |]
        |> printfn "Average: %f" // 5.500000
        // To get the average of an array of integers,
        // use Array.averageBy to convert to float.
        // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#averageBy
        Array.averageBy float [| 1 .. 10 |]
        |> printfn "Average: %f" // 5.500000

    module Blit =
        // Array.blit
        // CopyTo
        // 1 つ目の配列の一部を 2 つ目の配列こコピーする
        // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#blit
        let blit1 = [| 1 .. 10 |]
        let blit2: int [] = Array.zeroCreate 20
        // Copy 4 elements from index 3 of array1 to index 5 of array2.
        Array.blit blit1 3 blit2 5 4
        printfn "%A" blit2 // [|0; 0; 0; 0; 0; 4; 5; 6; 7; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|]

    module Choose =
        // Array.choose
        // if の結果 Option を取る関数を与えて Some(x) だけを取ってくる
        // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#choose
        Array.choose
            (fun elem ->
                if elem % 2 = 0 then
                    Some(float (elem * elem - 1))
                else
                    None)
            [| 1 .. 10 |]
        |> printfn "%A" // [|3.0; 15.0; 35.0; 63.0; 99.0|]

    module ChunkBySize =
        // Array.chunkBySize
        // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#chunkBySize
        // 一次元配列の要素を指定された数ごとに区切ったジャグ配列 (配列の配列) を得る。
        // 要素数に正の整数を指定しないと System.ArgumentException が起きる。
        Array.chunkBySize 3 [| 0 .. 7 |] // [|[|0; 1; 2|]; [|3; 4; 5|]; [|6; 7|]|] : int [] []
        //Array.chunkBySize 0 [| 0 .. 7 |] // 例外発生「System.ArgumentException: 入力は正である必要があります。」
        Array.chunkBySize<int> 3 [| 0 .. 7 |] // [||] : int [] []

    module Collect =
        // Array.collect
        // 配列の各要素に関数を当て、最後に flat 化する
        // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#collect
        Array.collect (fun elem -> [| 0 .. elem |]) [| 1; 5; 10 |]
        |> printfn "%A" // [|0; 1; 0; 1; 2; 3; 4; 5; 0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10|]

    module CompareWith =
        // Array.compareWith
        // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#compareWith
        let compare elem1 elem2 =
            if elem1 > elem2 then 1
            elif elem1 < elem2 then -1
            else 0

        Array.compareWith compare [| 1 .. 3 |] [| 1; 2; 4 |] // -1
        Array.compareWith compare [| 1 .. 3 |] [| 1; 2; 3 |] // 0

    module DistinctBy =
        // Array.distinctBy
        // 配列の各要素を引数にして関数を実行し、その結果の配列から重複をなくしたものを得る。
        // 要素のない空の配列でも例外は起きない。
        Array.distinctBy (fun n -> n % 2) [| 0 .. 3 |] // [|0; 1|]
        Array.distinctBy<int, bool> (fun _ -> true) [||] // [||] : int []

    let rec dropWhile p (xs: 'T array) =
        match xs with
        | [||] -> [||]
        | _ ->
            if p (Array.head xs) then
                dropWhile p (Array.tail xs)
            else
                (Array.tail xs)

    dropWhile (fun x -> x < 3) [| 0 .. 5 |]
    |> should equal [| 4; 5 |]

    module Empty =
        // Array.empty
        // 空の配列を生成する
        Array.empty |> printfn "%A" // 'a []

    module ExactlyOne =
        // Array.exactlyOne
        // 要素が1つだけの配列から要素を取り出す。
        // 配列の要素が複数もしくは空のときは System.ArgumentException。
        // Array.singleton は逆。
        Array.exactlyOne [| 3 |]
        //Array.exactlyOne [| 3; 2 |] // 例外発生「System.ArgumentException: 入力シーケンスに複数の要素が含まれています。」
        //Array.exactlyOne<int> [||] // 例外発生「System.ArgumentException: 入力シーケンスが空でした。」
        Array.singleton 3 // [|3|] (Array.exactlyOneとは逆)

    module Except =
        // Array.except
        // 配列 2 の要素から配列 1 の要素を取り除いた配列を得る。
        // 配列 1 は list, seq, set でもいい。
        // どちらの配列が空でも例外は起きない。
        Array.except [| 2; 1 |] [| 1 .. 5 |] // [|3; 4; 5|]  第 1 引数はlist, seq, setでも良い
        Array.except<int> [||] [||] // [||] : int []

    module FindBack =
        // Array.findBack
        // 配列の要素を引数にして関数を順次実行し、その結果 (bool型) が最初に true になった要素を得る。
        // 要素が見つからないときは System.Collections.Generic.KeyNotFoundException。
        // 結果が option になる Array.tryFindBack や、配列の要素を先頭から順次判定していく Array.find もある。
        Array.findBack (fun n -> n % 2 = 1) [| 1 .. 3 |] // 3
        //Array.findBack (fun n -> n % 2 = 1) [|0|]  // 例外発生「System.Collections.Generic.KeyNotFoundException」
        Array.tryFindBack (fun n -> n % 2 = 1) [| 1 .. 3 |] // Some 3
        Array.find (fun n -> n % 2 = 1) [| 1 .. 3 |] // 1

    module Sub =
        // Array.sub
        // スライスの一種
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
        /// 配列が定義できているときのスライス
        [| 'a' .. 'e' |].[2] // 'c'
        [| 'a' .. 'e' |].[1..3] // [|'b'; 'c'; 'd'|]
        [| 'a' .. 'e' |].[2..] // [|'c'; 'd'; 'e'|]
        [| 'a' .. 'e' |].[..3] // [|'a'; 'b'; 'c'; 'd'|]

    module SortBy =
        // Array.sortBy
        // 関数指定でソートする
        Array.sortBy abs [| 1; 4; 8; -2; 5 |]
        |> printfn "%A" // [|1; -2; 4; 5; 8|]

    module FindIndexBack =
        // Array.findBack の結果がある要素の位置を得る.
        // 要素が見つからないときは System.Collections.Generic.KeyNotFoundException.
        // 結果が option になる Array.tryFindIndexBack や, 配列の要素を先頭から判定していく Array.findIndex もある.
        Array.findIndexBack (fun n -> n % 2 = 1) [| 1 .. 3 |] // 2
        //Array.findIndexBack (fun n -> n % 2 = 1) [|0|]  // 例外発生「 System.Collections.Generic.KeyNotFoundException 」
        Array.tryFindIndexBack (fun n -> n % 2 = 1) [| 1 .. 3 |] // Some 2
        Array.findIndex (fun n -> n % 2 = 1) [| 1 .. 3 |] // 0

    module GroupBy =
        // Array.groupBy
        // 配列の要素を引数とする関数を順次実行し, その結果ごとに要素をグループ分けする.
        // 結果となる配列の要素は (関数の結果, [|要素, ...|]).
        // 引数の配列が空でも例外は起きない.
        Array.groupBy (fun n -> n % 3) [| 0 .. 7 |] // [|(0, [|0; 3; 6|]); (1, [|1; 4; 7|]); (2, [|2; 5|])|]
        Array.groupBy (fun n -> n % 3) [||] // [||] : (int * int []) []

    module Head =
        // Array.head
        // 配列の先頭の要素を得る.
        // 配列要素が空のときは System.ArgumentException.
        // 結果が option になる Array.tryHead もある.
        // 配列の先頭の要素だけをなくした配列を得る Array.tail や,
        // 配列の末尾の要素を得る Array.last や Array.tryLast もある.
        Array.head [| 1 .. 3 |] // 1
        //Array.head<int> [||]    // 例外発生「 System.ArgumentException: 入力配列が空でした」.
        Array.tryHead [| 1 .. 3 |] // Some 1
        Array.tryHead<int> [||] // None
        Array.tail [| 1 .. 3 |] // [| 2; 3 |]
        Array.last [| 1 .. 3 |] // 3
        Array.tryLast [| 1 .. 3 |] // Some 3
        Array.tryLast<int> [||] // None

    module Indexed =
        // Array.indexed
        // 配列の要素とその位置を (位置, 要素) という 1 つのタプルに収めた要素を持つ配列を得る.
        // 配列の要素が空でも例外は起きない.
        Array.indexed [| 'a' .. 'c' |] // [|(0, 'a'); (1, 'b'); (2, 'c')|]
        Array.indexed<char> [||] // [||] : (int * char) []

    module Init =
        // https://msdn.microsoft.com/ja-jp/visualfsharpdocs/conceptual/array.init%5b't%5d-function-%5bfsharp%5d
        Array.init 10 (fun i -> i * i)
        |> should equal [| 0; 1; 4; 9; 16; 25; 36; 49; 64; 81 |]

    module IsEmpty =
        // https://msdn.microsoft.com/ja-jp/visualfsharpdocs/conceptual/array.isempty%5b't%5d-function-%5bfsharp%5d
        // Array.isEmpty
        // 配列の空判定
        Array.empty |> Array.isEmpty // true
        [| 1 |] |> Array.isEmpty // false

    module Item =
        // Array.item
        // 配列から指定した位置の要素を得る.
        // 指定した位置に要素が存在しなければ System.IndexOutOfRangeException.
        // 結果が option になる Array.tryItem もある.
        Array.item 2 [| 'a' .. 'c' |] // 'c'
        //Array.item<int> 1 [||]  // 例外発生「 System.IndexOutOfRangeException: インデックスが配列の境界外です」.
        Array.tryItem 2 [| 'a' .. 'c' |] // Some 'c'
        Array.tryItem<int> 0 [||] // None

    module Iter =
        // https://msdn.microsoft.com/ja-jp/visualfsharpdocs/conceptual/array.iter%5b't%5d-function-%5bfsharp%5d
        [| for i in 1 .. 5 -> (i, i * i) |]
        |> Array.iter (fun (a, b) -> printf "(%d, %d) " a b) // (1, 1) (2, 4) (3, 9) (4, 16) (5, 25)

    module Iter2 =
        // https://msdn.microsoft.com/ja-jp/visualfsharpdocs/conceptual/array.iter2%5b't1,'t2%5d-function-%5bfsharp%5d
        let array1 = [| 1; 2; 3 |]
        let array2 = [| 4; 5; 6 |]
        Array.iter2 (fun x y -> x * y |> printf "%d ") array1 array2 // 4 10 18

    module Iteri =
        // https://msdn.microsoft.com/ja-jp/visualfsharpdocs/conceptual/array.iteri%5b't%5d-function-%5bfsharp%5d
        let array1 = [| 1; 2; 3 |]
        Array.iteri (fun i x -> i * x |> printf "%d ") array1 // 0 2 6

    module Iteri2 =
        // https://msdn.microsoft.com/ja-jp/visualfsharpdocs/conceptual/array.iteri2%5b't1,'t2%5d-function-%5bfsharp%5d
        let array1 = [| 1; 2; 3 |]
        let array2 = [| 4; 5; 6 |]
        Array.iteri2 (fun i x y -> i * x * y |> printf "%d ") array1 array2 // 0 10 36

    module Last =
        // Array.last
        // 配列の末尾の要素を得る.
        // 配列の要素が空のときは System.ArgumentException.
        // 結果が option になる Array.tryLast もある.
        // 配列の先頭の要素を得られる Array.head や Array.tryHead もある.
        Array.last [| 1 .. 3 |] // 3
        //Array.last<int> [||]  // 例外発生「 System.ArgumentException: 入力配列が空でした」.
        Array.tryLast [| 1 .. 3 |] // Some 3
        Array.tryLast<int> [||] // None
        Array.head [| 1 .. 3 |] // 1
        Array.tryHead [| 1 .. 3 |] // Some 1

    module Map =
        // https://msdn.microsoft.com/ja-jp/visualfsharpdocs/conceptual/array.map%5b't,'u%5d-function-%5bfsharp%5d
        let data = [| 1; 2; 3; 4 |]
        data |> Array.map (fun x -> x + 1) |> printfn "%A" // [|2; 3; 4; 5|]
        data |> Array.map string |> printfn "%A" // [|"1"; "2"; "3"; "4"|]

        data
        |> Array.map (fun x -> (x, x))
        |> printfn "%A" // [|(1, 1); (2, 2); (3, 3); (4, 4)|]

    module Map2 =
        // https://msdn.microsoft.com/ja-jp/visualfsharpdocs/conceptual/array.map2%5b't1,'t2,'u%5d-function-%5bfsharp%5d
        let array1 = [| 1; 2; 3 |]
        let array2 = [| 4; 5; 6 |]
        Array.map2 (+) array1 array2 |> printfn "%A" // [|5; 7; 9|]

    module Map3 =
        // Array.map3
        // 同じ数の要素を持つ 3 つの配列のそれぞれから順次取り出した要素を引数とする関数を実行し,
        // その結果を要素とする配列を得る.
        // それぞれの配列の要素の型が違っていてもいいが,
        // 3 つの配列の要素の数がどれか 1 つでも違っていると System.ArgumentException.
        Array.map3 (fun x y z -> (x, y, z)) [| 0 .. 2 |] [| 'a' .. 'c' |] [| '$' .. '&' |] // [|(0, 'a', '$'); (1, 'b', '%'); (2, 'c', '&')|]
    //Array.map3 (fun x y z -> (x, y, z)) [|0..2|] [|'a'..'d'|] [|'$'..'&'|] // 例外発生「 System.ArgumentException: 配列の長さが異なります」.

    module MapFold =
        // Array.mapFold
        // 初期値に対して配列の要素を関数で累積的に処理していった途中経過と最終的な結果をタプルで得る.
        // 関数の引数を初期値もしくは前回の処理結果と配列の先頭から順次取り出される要素の 2 つとし,
        // 戻り値は (最終結果のタプルの左側の要素, 次回関数実行時の第 1 引数) とする.
        // 配列の要素を末尾から取り出す Array.mapFoldBack もあるが,
        // 引数の位置などに違いがある.
        Array.mapFold
            (fun x y ->
                printfn "x = %2d, y = %1d, x * y = %3d" x y (x * y)
                (x, x * y))
            1
            [| 2 .. 5 |] //([|1; 2; 6; 24|], 120)
        (* 途中経過 *)
        //x =  1, y = 2, x * y =   2
        //x =  2, y = 3, x * y =   6
        //x =  6, y = 4, x * y =  24
        //x = 24, y = 5, x * y = 120

        // 比較用
        Array.mapFoldBack (fun x y -> (x, x * y)) [| 2 .. 5 |] 1 // ([|2; 3; 4; 5|], 120)

    module MapFoldBack =
        // Array.mapFoldBack
        // 初期値に対して配列の要素を関数で累積的に処理していった途中経過と最終結果をタプルで得る.
        // 関数の引数は配列の末尾から順次取り出される要素と,
        // 初期値もしくは前回の処理結果の 2 つとし,
        // 戻り値は (最終結果左側の配列の要素, 次回関数実行時の第 2 引数) とする.
        // 最終結果の配列の要素は先に関数から得られたものほど後に配置される.
        // 配列の要素を先頭から順次取り出す Array.mapFold もある:
        // 引数の位置などに違いがあるので注意してください.
        Array.mapFoldBack
            (fun x y ->
                printfn "x = %1d, y = %2d, x * y = %3d" x y (x * y)
                (y, x * y))
            [| 2 .. 5 |]
            1 // ([| 60; 20; 5; 1 |], 120)
    (* 途中経過 *)
    //x = 5, y =  1, x * y =   5
    //x = 4, y =  5, x * y =  20
    //x = 3, y = 20, x * y =  60
    //x = 2, y = 60, x * y = 120

    module Mapi =
        // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#mapi
        // Haskell imap
        let array1 = [| 1; 2; 3 |]

        array1
        |> Array.mapi (fun i x -> (i, x))
        |> printfn "%A" // [|(0, 1); (1, 2); (2, 3)|]

    module Mapi2 =
        // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#mapi2
        let array1 = [| 1; 2; 3 |]
        let array2 = [| 4; 5; 6 |]

        Array.mapi2 (fun i x y -> (x + y) * i) array1 array2
        |> printfn "%A" // [|0; 7; 18|]

    module Max =
        // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#max
        [| for x in -100 .. 100 -> 4 - x * x |]
        |> Array.max
        |> printfn "%A" // 4

    module MaxBy =
        // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#maxBy
        [| -10.0 .. 10.0 |]
        |> Array.maxBy (fun x -> 1.0 - x * x)
        |> printfn "%A" // 0.0

    // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#min
    [| for x in -100 .. 100 -> x * x - 4 |]
    |> Array.min
    |> should equal -4

    Array.min [| 1; 2; 3 |] |> should equal 1

    module MinBy =
        // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#minBy
        [| -10.0 .. 10.0 |]
        |> Array.minBy (fun x -> x * x - 1.0)
        |> printfn "%A" // 0.0

    module Pairwise =
        // Array.pairwise
        // 隣り合う要素どうしをタプル収めた要素を持つ配列を得る.
        // 配列の要素が 1 つ以下のときの戻り値は空の配列.
        Array.pairwise [| 'a' .. 'd' |] // [|('a', 'b'); ('b', 'c'); ('c', 'd')|]
        Array.pairwise [| 'a' |]
        Array.pairwise<char> [||] // [||] : (char * char) []

    module Partition =
        // Array.partition
        // predicate の正否でわける
        [| 1 .. 10 |]
        |> Array.partition (fun elem -> elem > 3 && elem < 7)
        |> printfn "%A"
    // ([|4; 5; 6|], [|1; 2; 3; 7; 8; 9; 10|])

    module Replicate =
        // Array.replicate
        // 同じ値の要素を複数持つ配列を得る.
        // 数値が 0 以上の整数でなければ System.ArgumentException.
        Array.replicate 3 "F#" // [|"F#"; "F#"; "F#"|]
    //Array.replicate -1 "F#"  // 例外発生「 System.ArgumentException: 入力は負以外である必要がある」.

    module Scan =
        // Array.scan
        // fold の「途中の値」をすべて集めた配列を返す関数というイメージを持つといい。
        // Array.fold (+) 1 [2; 3; 4] == ((1 + 2) + 3) + 4
        // Array.scan (+) 1 [2; 3; 4] == [1; 1 + 2; (1 + 2) + 3; ((1 + 2) + 3) + 4]
        Array.scan (+) 1 [| 2 .. 4 |] // [|1; 3; 6; 10|]

    module Singleton =
        // Array.singleton
        // 要素を 1 つだけ持つ配列を得る.
        // 逆に要素が 1 つだけの配列から要素を取り出す Array.exactlyOne もある.
        Array.singleton 3 // [|3|]
        Array.exactlyOne [| 3 |]

    module Skip =
        // Array.skip
        // 先頭から指定した位置までの要素をなくした配列を得る.
        // 数値が負の数でも例外は発生しません.
        // 逆に先頭から指定した位置までの要素を持つ配列を得られる Array.take もある.
        Array.skip 2 [| 'a' .. 'e' |] // [|'c'; 'd'; 'e'|]
        Array.skip -1 [| 'a' .. 'e' |] // [|'a'; 'b'; 'c'; 'd'; 'e'|]
        Array.take 3 [| 'a' .. 'e' |] // [|'a'; 'b'; 'c'|]

    module SkipWhile =
        // Array.skipWhile
        // 関数の戻り値が false となる位置までの要素をなくした配列を得る.
        // 逆にその位置までの要素を得られる Array.takeWhile もある.
        Array.skipWhile (fun n -> n < 4) [| 3; 2; 5; 4; 1 |] // [| 5; 4; 1 |]

        Array.takeWhile (fun n -> n < 4) [| 3; 2; 5; 4; 1 |] // [|3; 2|]

    module SortByDescending =
        // Array.sortByDescending
        // 配列の要素を引数とする関数を順次実行した結果をもとに要素を降順で並べ替える.
        // 関数の結果は比較可能な値でなければなりません.
        // 他に配列の要素自体を並べ替える Array.sortDescending や,
        // 配列の並べ替えが昇順になる Array.sortBy もある.
        Array.sortByDescending
            (fun (x, _) -> x)
            [| (2, "dos")
               (3, "tres")
               (1, "uno") |]
        |> should
            equal
            [| (3, "tres")
               (2, "dos")
               (1, "uno") |]

        Array.sortDescending [| 1 .. 5 |]
        |> should equal [| 5; 4; 3; 2; 1 |]

        Array.sortBy
            (fun (x, _) -> x)
            [| (2, "dos")
               (3, "tres")
               (1, "uno") |]
        |> should
            equal
            [| (1, "uno")
               (2, "dos")
               (3, "tres") |]

    module SortDescending =
        // Array.sortDescending
        // 配列の要素を降順で並べ替える.
        // 要素は比較可能な値でなければならない.
        // 他に昇順で並べ替える Array.sort や要素を引数にして関数を順次実行した値で並べ替える Array.sortByDescending もある.
        Array.sortDescending [| for i in 1 .. 5 -> -i |]
        |> should equal [| -1; -2; -3; -4; -5 |]

        Array.sort [| for i in 1 .. 5 -> -i |]
        |> should equal [| -5; -4; -3; -2; -1 |]

        Array.sortByDescending
            (fun (x, _) -> x)
            [| (2, "dos")
               (3, "tres")
               (1, "uno") |]
        |> should
            equal
            [| (3, "tres")
               (2, "dos")
               (1, "uno") |]

    module SplitAt =
        // Array.splitAt
        // 指定した要素の位置ので配列を 2 つに分けてそれぞれを同じタプルに収める.
        // 指定された位置の要素はタプルの右側の配列に含まれる.
        // 位置は 0 か正の整数に限られ, それ以外を指定すると System.ArgumentException.
        // 指定した位置が配列の長さ (要素の数) より大きいと System.InvalidOperationException.
        Array.splitAt 3 [| 'a' .. 'e' |] // ([|'a'; 'b'; 'c'|], [|'d'; 'e'|])
        Array.splitAt 0 [| 'a' .. 'e' |] // ([||], ([||], [|'a'; 'b'; 'c'; 'd'; 'e'|]))
        Array.splitAt 5 [| 'a' .. 'e' |] // ([|'a'; 'b'; 'c'; 'd'; 'e'|], [||])
    //Array.splitAt -1 [|'a'..'e'|]  // 例外発生「 System.ArgumentException: 入力は負以外である必要がある」.
    //Array.splitAt  6 [|'a'..'e'|]  // 例外発生「 System.InvalidOperationException: 入力シーケンスには十分な数の要素がありません」.

    module SplitInto =
        // Array.splitInto
        // 配列の要素を指定した数に等分する.
        // 結果は'T [] [] になる.
        // 分割数が 0 のときは System.ArgumentException.
        // 分割数が配列の要素の数より大きくても例外は起きない.
        Array.splitInto 3 [| 'a' .. 'e' |] // [|[|'a'; 'b'|]; [|'c'; 'd'|]; [|'e'|]|] : char [] []
        //Array.splitInto 0 [|'a'..'e'|]  // 例外発生「 System.ArgumentException: 入力は正である必要がある」.
        Array.splitInto 3 [| 'a' .. 'b' |] // [|[|'a'|]; [|'b'|]|]

    module Tail =
        // Array.tail
        // 先頭の要素をなくした配列を得る.
        // 配列の要素がないときは System.ArgumentException.
        // 逆に配列の先頭の要素だけを得られる Array.head もある.
        Array.tail [| 1 .. 3 |] // [|2; 3|]
        // Array.tail<int> [||]    // 例外発生「 System.ArgumentException: 入力シーケンスには十分な数の要素がありません」.
        Array.head [| 1 .. 3 |] // 1

    module Take =
        // Array.take
        // 先頭から指定された数だけの要素を持つ配列を得る.
        // 要素数が負の数のときは System.ArgumentException.
        // 要素数が配列の長さより大きいときは System.InvalidOperationException.
        // 他に関数で判定した位置の要素を持つ配列を得られる Array.takeWhile や,
        // 逆に先頭から指定された数の要素をなくした配列を得られる Array.skip もある.
        Array.take 3 [| 'a' .. 'e' |] // [|'a'; 'b'; 'c'|]
        Array.take 0 [| 'a' .. 'e' |] // [||] : char []
        // Array.take -1 [|'a'..'e'|]  // 例外発生「 System.ArgumentException: 入力は負以外である必要がある」.
        // Array.take  6 [|'a'..'e'|]  // 例外発生「 System.InvalidOperationException: 入力シーケンスには十分な数の要素がありません」.
        // Array.take 6 [|3; 2; 5; 4; 1|]  // 例外発生「 System.InvalidOperationException: 入力シーケンスには十分な数の要素がありません」.
        Array.takeWhile (fun n -> n < 4) [| 3; 2; 5; 4; 1 |] // [|3; 2|]

        Array.skip 3 [| 'a' .. 'e' |] // [|'d'; 'e'|]
        Array.take 3 [| 3; 2; 5; 4; 1 |] // [|3; 2; 5|]
        // 要素数が配列の長さより大きいとき
        Array.truncate 6 [| 3; 2; 5; 4; 1 |] // [|3; 2; 5; 4; 1|]
        // 要素数が負の数のとき
        Array.truncate -1 [| 3; 2; 5; 4; 1 |] // [||]

    module TakeWhile =
        // Array.takeWhile
        // 要素を引数とする関数を先頭から順次実行し,
        // 結果が true となる要素を持つ配列を得る.
        // 逆に結果が false となる位置から末尾までの要素を持つ配列を得られる Array.skipWhile や,
        // 先頭から指定した位置までの要素を持つ配列を得られる Array.take もある.
        Array.takeWhile (fun n -> n < 4) [| 3; 2; 5; 4; 1 |] // [|3; 2|]
        Array.skipWhile (fun n -> n < 4) [| 3; 2; 5; 4; 1 |] // [|5; 4; 1|]

        Array.take 3 [| 3; 2; 5; 4; 1 |] // [|3; 2; 5|]

    module Truncate =
        // Array.truncate
        // 先頭から指定した数だけの要素を持つ配列を得る.
        // Array.take と違うのは要素数に関連する例外が発生しないこと.
        Array.truncate 3 [| 3; 2; 5; 4; 1 |] // [|3; 2; 5|]

    module TryFindBack =
        // Array.tryFindBack
        // 末尾の要素から順次関数を実行し, 結果が true となる要素を見つける.
        // 見つかったら 「Some 結果」, 見つからなかったら None を返す.
        // 結果が option ではない Array.findBack もあるほか,
        // 先頭の要素から順に関数を実行する Array.tryFind や Array.find もある.
        (* 結果が見つかったとき *)
        Array.tryFindBack (fun n -> n % 2 = 1) [| 1 .. 3 |] // Some 3
        Array.findBack (fun n -> n % 2 = 1) [| 1 .. 3 |] // 3
        (* 結果が見つからないとき *)
        Array.tryFindBack (fun n -> n > 3) [| 1 .. 3 |] // None
        // Array.findBack (fun n -> n > 3) [|1; 2; 3|]  // 例外発生「 System.Collections.Generic.KeyNotFoundException 」
        Array.tryFind (fun n -> n % 2 = 1) [| 1 .. 3 |] // Some 1
        Array.find (fun n -> n % 2 = 1) [| 1 .. 3 |] // 1

    module TryFindIndexBack =
        // Array.tryFindIndexBack
        // Array.tryFindBack の結果となる要素の位置を見つける.
        // 見つかったら Some 位置, 見つからなかったら None.
        // 要素の位置を先頭から見つける Array.tryFindIndex や,
        // 結果を option ではなく実際の値で得られる Array.findIndexBack もある.
        Array.tryFindIndexBack (fun n -> n % 2 = 1) [| 1 .. 3 |] // Some 2
        Array.tryFindIndex (fun n -> n % 2 = 1) [| 1 .. 3 |] // Some 0
        Array.findIndexBack (fun n -> n % 2 = 1) [| 1 .. 3 |] // 2

    module TryHead =
        // Array.tryHead
        // 配列の先頭の要素を取り出します.
        // 要素が存在すれば Some 要素, 要素が存在しなければ None となります.
        // 結果を option ではなく実際の値で得られる Array.head や,
        // 末尾の要素を得る Array.tryLast もある.
        (* 先頭の要素が存在するとき *)
        Array.tryHead [| 3; 1; 2 |]
        Array.head [| 3; 1; 2 |]
        (* 先頭の要素が存在しないとき *)
        Array.tryHead<int> [||] // None
        //Array.head<int>    [||]  // 例外発生「 System.ArgumentException: 入力配列が空でした」.
        Array.tryLast [| 3; 1; 2 |]

    module TryItem =
        // Array.tryItem
        // 指定した位置の要素を取り出します.
        // 要素が存在すれば Some 要素, 存在しなければ None.
        // 結果が option ではなく要素で得られる Array.item もある.
        (* 指定した位置に要素が存在するとき *)
        Array.tryItem 2 [| 'c'; 'a'; 'b' |] // Some 'b'
        Array.item 2 [| 'c'; 'a'; 'b' |] // 'b'
        (* 指定した位置に要素が存在しないとき *)
        Array.tryItem 4 [| 'c'; 'a'; 'b' |] // None
    // Array.item 4 [| 'c'; 'a'; 'b' |] // 例外発生「 System.IndexOutOfRangeException 」

    module TryLast =
        // Array.tryLast
        // 配列の末尾の要素が得られたら 「Some 要素」, 得られなければ None.
        // 結果が option ではなく要素自身となる Array.last もあるが,
        // こちらは配列が空だと例外が起きる.
        // 配列の先頭の要素を得られる Array.tryHead もある.
        Array.tryLast [| 3; 1; 2 |]
        Array.tryLast<int> [||] // None
        Array.last [| 3; 1; 2 |]

    module Unfold =
        // Array.unfold
        // 初期値を元に関数を累積的に実行して列をつくる.
        // 関数の引数は初期値および前回の結果とし,
        // 戻り値は次回も関数を実行するときは Some (結果となる配列の要素, 次回実行時の引数),
        // 関数の実行を終了するときは None とする.
        Array.unfold (fun n -> if n > 5 then None else Some(n, n + 1)) 1 // [|1; 2; 3; 4; 5|]
    (* フィボナッチ数列の配列 (Array.unfold) *)

    module Fib =
        let fibs n =
            Array.unfold (fun (x, y, z) ->
                if z > 0 then
                    Some(x, (y, x + y, z - 1))
                else
                    None)
            <| (1, 1, n)
        // fibs 10 = [|1; 1; 2; 3; 5; 8; 13; 21; 34; 55|]

        (* フィボナッチ数 (Array.fold) *)
        let fib n =
            fst
            <| Array.fold (fun (x, y) _ -> (x + y, x)) (0, 1) [| 1 .. n |] // fib 10 = 55

        // Array.where
        // Array.filter と同じく配列の各要素で実行した関数の結果が true となるものをすべて取り出す.
        // Array.find では最初に true となる要素だけとなるのが違う.
        Array.where (fun n -> n % 2 = 0) [| 1 .. 5 |] // [|2; 4|]
        Array.filter (fun n -> n % 2 = 0) [| 1 .. 5 |] // [|2; 4|]
        Array.find (fun n -> n % 2 = 0) [| 1 .. 5 |] // 2

    module Windowed =
        // Array.windowed
        // 指定した要素数だけ位置が連続する配列を要素とするジャグ配列を得る.
        // 要素数が正の整数でないときは System.ArgumentException.
        // 要素数が配列の要素の数を上回ると結果の配列は空.
        // 要素数を 2 に指定すると結果が Array.pairwise と似ているが,
        // 要素がタプルか配列かが違う.
        // Array.chunkBySize との違いは, ただ配列の要素を区切るのではなく,
        // 先頭の要素から順次要素数だけ連続する要素を 1 つの配列にまとめていること.
        Array.windowed 3 [| 'a' .. 'e' |] // [|[|'a'; 'b'; 'c'|]; [|'b'; 'c'; 'd'|]; [|'c'; 'd'; 'e'|]|]
        //Array.windowed 0 [|'a'..'e'|]  // 例外発生「 System.ArgumentException: 入力は正である必要がある」.
        Array.windowed 6 [| 'a' .. 'e' |] // [||] : char [] []

        (* windowed と pairwise との違い *)
        Array.windowed 2 [| 'a' .. 'e' |] // [|[|'a'; 'b'|]; [|'b'; 'c'|]; [|'c'; 'd'|]; [|'d'; 'e'|]|]
        Array.pairwise [| 'a' .. 'e' |] // [|('a', 'b'); ('b', 'c'); ('c', 'd'); ('d', 'e')|]

        (* windowed と chunBySize との違い *)
        Array.windowed 3 [| 'a' .. 'e' |] // [|[|'a'; 'b'; 'c'|]; [|'b'; 'c'; 'd'|]; [|'c'; 'd'; 'e'|]|]
        Array.chunkBySize 3 [| 'a' .. 'e' |] // [|[|'a'; 'b'; 'c'|]; [|'d'; 'e'|]|]

module List =
    // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html
    // https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/lists
    // https://github.com/dotnet/fsharp/blob/main/src/fsharp/FSharp.Core/list.fs
    List.append [ 0 .. 5 ] [ 10 .. 15 ]
    |> should
        equal
        [ 0; 1; 2; 3; 4; 5; 10; 11; 12; 13; 14; 15 ]

    // collect, Haskell concatMap
    [1..4] |> List.collect (fun x -> [1..x])
    |> should equal [1; 1; 2; 1; 2; 3; 1; 2; 3; 4]
    [1..4] |> List.map (fun x -> [1..x])
    |> should equal [[1]; [1; 2]; [1; 2; 3]; [1; 2; 3; 4]]
    List.collect (List.take 2) [[1;2;3]; [4;5;6]]
    |> should equal [1;2;4;5]
    // Haskell concatMap
    //let concatMap f xs = List.map f xs |> List.concat

    // concat, join
    let list1 = [1..5]
    let list2 = [3..7]
    list1 @ list2
    |> should equal [1;2;3;4;5;3;4;5;6;7]
    List.concat [list1;list2]
    |> should equal [1;2;3;4;5;3;4;5;6;7]

    // consing
    1 :: [2;3;4] |> should equal [1;2;3;4]

    // list comprehension, for
    [for i in 1..3 do i] |> should equal [1;2;3]

    // Haskell dropWhile
    // https://hackage.haskell.org/package/base-4.16.0.0/docs/Data-List.html#v:dropWhile
    let rec dropWhile p (list: 'T list) =
        match list with
        | [] -> []
        | x :: xs -> if p x then dropWhile p xs else xs

    dropWhile (fun x -> x < 3) [ 0 .. 5 ]
    |> should equal [ 4; 5 ]

    // filter
    [1..9]
    |> List.filter (fun x -> x % 2 = 0)
    |> should equal [2;4;6;8]

    // fold
    let getTotal1 items =
        items
        |> List.fold (fun acc (q, p) -> acc + q * p) 0
    [(1,2); (3,4)] |> getTotal1 |> should equal 14

    // forward-pipe operator
    let getTotal2 items =
        (0, items)
        ||> List.fold (fun acc (q, p) -> acc + q * p)
    [(1,2); (3,4)] |> getTotal2

    // head
    List.head [1;2;3] |> should equal 1

    // Haskell inits
    // https://hackage.haskell.org/package/base-4.16.0.0/docs/Data-List.html#v:inits
    let inits xs =
        [ 0 .. (Seq.length xs) ]
        |> Seq.map (fun i -> Seq.take i xs)
    //let inits xs =
    //    Seq.mapi (fun i _ -> Seq.take i xs) xs
    inits "abc" |> should equal [ ""; "a"; "ab"; "abc" ]
    inits "123" |> should equal [ ""; "1"; "12"; "123" ]

    // sum
    [1..9] |> List.sum |> should equal 45

    @"tail"
    List.tail [1;2;3] |> should equal [2;3]

module Sequence =
    // countBy
    type Foo = { Bar: string }
    let inputs = [{Bar = "a"}; {Bar = "b"}; {Bar = "a"}]
    inputs |> Seq.countBy (fun foo -> foo.Bar)
    |> should equal (seq { ("a", 2); ("b", 1) })

    let rec dropWhile p (xs: 'T seq) =
        match xs with
        | s when Seq.isEmpty s -> Seq.empty
        | _ ->
            if p (Seq.head xs) then
                dropWhile p (Seq.tail xs)
            else
                (Seq.tail xs)

    dropWhile (fun x -> x < 3) (seq { 0 .. 5 })
    |> should equal (seq { 4; 5 })

    // Seq.sum s = Seq.fold (+) 0 s
    Seq.fold (-) 0 { 0 .. 9 } |> should equal -45

    Seq.head (seq { 0 .. 9 }) |> should equal 0

    // infinite list
    Seq.initInfinite id |> Seq.take 3 |> should equal [0; 1; 2]
    Seq.initInfinite (fun x -> x + 1)
    |> Seq.take 3 |> should equal [1; 2; 3]

    // Seq.length
    seq [1; 2; 3] |> Seq.length |> should equal 3

    module Map =
        // https://msdn.microsoft.com/ja-jp/visualfsharpdocs/conceptual/collections.seq-module-%5bfsharp%5d
        let s = seq { 0 .. 9 }
        Seq.reduce (-) s // -45

    Seq.reduce (-) (seq { 0 .. 9 })
    |> should equal -45

    let s = seq { 0 .. 3 }

    Seq.tail s |> should equal (seq { 1 .. 3 })

    Seq.takeWhile (fun x -> x < 3) (seq { 0 .. 9 })
    |> should equal (seq { 0..2 })

module String =
    // 埋め込み文字列
    let text = "TEXT"
    $"text: {text}" |> should equal "text: TEXT"

    // collect
    // map と違って文字を文字列に変換する関数を使って map する
    // https://msdn.microsoft.com/visualfsharpdocs/conceptual/string.collect-function-%5bfsharp%5d
    "Hello, World"
    |> String.collect (fun c -> sprintf "%c " c)
    |> should equal "H e l l o ,   W o r l d "

    // concat
    // 配列やリストの要素を連結して文字列にする
    [| 1; 2; 3; 4; 5 |]
    |> Array.map string
    |> String.concat " "
    |> should equal "1 2 3 4 5"

    [ 1; 2; 3; 4; 5 ]
    |> List.map string
    |> String.concat " "
    |> should equal "1 2 3 4 5"

    [1;2;1;2;3] |> List.distinct
    |> should equal [1;2;3]

    // exists
    // 文字列中に与えられた条件をみたす文字が存在するか
    "Hello World!"
    |> String.exists System.Char.IsUpper
    |> should equal true

    // groupBy
    [1;2;3;4;5;7;6;5;4;3]
    |> List.groupBy (fun x -> x)
    |> should equal [1,[1];2,[2];3,[3;3];4,[4;4];5,[5;5];7,[7];6,[6]]

    // forall
    // 文字列中のすべての文字が条件を満たすか
    "helloworld"
    |> String.forall System.Char.IsLower
    |> should equal true
    // space がある
    "hello world"
    |> String.forall System.Char.IsLower
    |> should equal false

    // init
    // インデックスに対して関数を作用させた結果の文字列を連結する
    String.init 10 (fun i -> i.ToString())
    |> should equal "0123456789"
    String.init 26 (fun i -> sprintf "%c" (char (i + int 'A')))
    |> should equal "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    // length
    // 文字列の長さ
    "aiueo" |> String.length |> should equal 5

    // map
    // 各文字に作用
    "hello, world"
    |> String.map System.Char.ToUpper
    |> should equal "HELLO, WORLD"

    // reverse
    "abcde"
    |> Seq.toArray
    |> Array.rev
    |> System.String
    |> should equal"edcba"

    // Split
    // 文字列を分割する「メソッド」
    "1 2 3" |> fun s -> s.Split(" ")
    |> should equal [| "1"; "2"; "3"|]

    // Substring
    // 部分文字列をとる「メソッド」
    let s = "0123456789"
    s.Substring(s.Length - 5) |> should equal "56789"
    s.Substring(1, 5) |> should equal "12345"

module Function =
    @"forward-pipe operator"
    let getTotal2 items =
        (0, items)
        ||> List.fold (fun acc (q, p) -> acc + q * p)
    [(1,2); (3,4)] |> getTotal2

    @"function composition"
    let twice x = 2 * x
    let cubic x = pown x 3
    let twiceCubic = cubic >> twice
    twiceCubic 3 |> should equal 54

    @"パターンマッチ・引数の場合分けによる定義,
    Haskellでいう次のような定義
    f [] = []
    f x:xs = undefined
    "
    let rec fact1 = function
    | 1 -> 1
    | n -> n * fact1 (n-1)

module PatternMatch =
    // match a specified type of subtypes
    let tryDivide2: decimal -> decimal -> Result<decimal,DivideByZeroException> = fun x y ->
        try Ok (x/y)
        with | :? DivideByZeroException as ex -> Error ex

module Tuple =
    // 値の取得
    match (1, "abc") with
    | (a,b) -> printfn "%A, %A" a b

    let (a, b) = (100, 200)
    should equal 100 a
    should equal 200 b

    fst (10, 20) |> should equal 10
    snd (10, 20) |> should equal 20

module Type =
    type Tax = decimal
    type Spend = decimal
    type Total = decimal
    type CalcTotal = Spend -> Tax -> Total
    let calcTotal: CalcTotal = fun spend tax ->
        spend * tax
    calcTotal 3.0M 1.08M |> should equal 3.24M

    // Single case discriminated union
    type ValidationError = | InputOutOfRange of string
    type Spend = private Spend of decimal with
        member this.Value = this |> fun (Spend value) -> value
        static member Create input =
            if input >= 0.0M && input <= 1000.0M then Ok (Spend input)
            else Error (InputOutOfRange "You can only spend between 0 and 1000")

    // TODO Record Type

module Struct =
    [<Struct>]
    type Coupon = { B: int; Discount: int }
    coupon1 = {B=1; Discount=2}
    coupon2 = {B=2; Discount=3}

module Map =
    // https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-mapmodule.html
    let sample = Map [ (1, "a"); (2, "b") ]
    sample |> Map.find 1 |> should equal "a"
    sample |> Map.find 2 |> should equal "b"
    //sample |> Map.find 3 // Error

    Map.empty<int, string> |> Map.isEmpty |> should equal true

module Math =
    @"int64 arithmetic"
    1L+1L |> should equal 2L
    @"float arithmetic"
    1.0M/2.0M |> should equal 0.5M

    @"** or power for integers
    a^b = pown a b"
    pown 2 3 |> should equal 8
    pown 3 2 |> should equal 9

    @"** or power for floating numbers"
    2.0 ** 3.0 |> should equal 8.0

    @"absolute value"
    abs 10 |> should equal 10
    abs (-10) |> should equal 10

    @"ceiling, 切り上げ"
    ceil -1.4 |> should equal -1.0
    ceil -1.5 |> should equal -1.0
    ceil 1.4  |> should equal 2.0
    ceil 1.5  |> should equal 2.0

    @"floor, 切り捨て"
    floor -1.4 |> should equal -2.0
    floor -1.5 |> should equal -2.0
    floor 1.4  |> should equal 1.0
    floor 1.5  |> should equal 1.0

    @"剰余, 余り, mod"
    10 % 2 |> should equal 0
    10 % 7 |> should equal 3

    @"round, 四捨五入
    どちらにも丸められる場合は偶数にする"
    round -1.4 |> should equal -1.0
    round -1.5 |> should equal -2.0
    round 0.4  |> should equal 0.0
    round 0.5  |> should equal 0.0
    round 1.4  |> should equal 1.0
    round 1.5  |> should equal 2.0

    @"sign, 符号"
    sign -2 |> should equal -1
    sign -1 |> should equal -1
    sign 0  |> should equal 0
    sign 1  |> should equal 1
    sign 10  |> should equal 1

    @"順列, permutations
    標準ライブラリある?"
    let rec choose xs =
        match xs with
        | [] -> []
        | x::xs -> (x, xs) :: List.map (fun (y, ys) -> (y, x::ys)) (choose xs)
    let rec permutations xs =
        match xs with
        | [] -> [[]]
        | xs ->
            choose xs
            |> concatMap (fun (y, ys) -> List.map (fun zs -> y::zs) (permutations ys))

module ActivePattern =
    // 引数で受け取った値を「奇数/偶数」の識別子に分類
    let (|Even|Odd|) input =
        if input % 2 = 0 then Even else Odd

    // アクティブパターンのパターンマッチ
    let testNumber input =
        match input with
        | Even -> "even"
        | Odd -> "odd"

    testNumber 7  |> should equal "odd"
    testNumber 11 |> should equal "odd"
    testNumber 32 |> should equal "even"

module Literal =
    // https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/literals
    uint64 100

module Operator =
    @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html"
