#r "nuget: FsUnit"
open FsUnit

module Array =
    @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html"

    @"accessor or slice"
    let a = [| 0 .. 4 |]
    a.[0] |> should equal 0
    a.[0..2] |> should equal [| 0; 1; 2 |]
    a.[1..] |> should equal [| 1; 2; 3; 4 |]
    a.[..3] |> should equal [| 0; 1; 2; 3 |]

    @"Array.allPairs
    配列 1 と配列 2 の各要素のすべての組み合わせをタプルの要素とする配列を得る.
    結果となる配列の長さが膨大になる可能性があるため引数の配列の長さに注意すること.
    引数の配列のどちらかが空のときは結果の配列も空になる."
    Array.allPairs [| 'a'; 'b'; 'c' |] [| 1; 2 |]
    |> should equal [|('a', 1); ('a', 2); ('b', 1); ('b', 2); ('c', 1); ('c', 2)|]
    Array.allPairs<char, int> [| 'a'; 'b' |] [||]
    |> should equal [||] //: (char * int) []

    @"Array.append
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#append
    配列の連結"
    Array.append [| 0 .. 5 |] [| 10 .. 15 |]
    |> should equal [|0; 1; 2; 3; 4; 5; 10; 11; 12; 13; 14; 15|]

    @"Array.average
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#average

    To get the average of an array of integers,
    use Array.averageBy to convert to float.
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#averageBy"
    Array.average [| 1.0 .. 10.0 |] |> should equal 5.5
    Array.averageBy float [| 1 .. 10 |] |> should equal 5.5

    @"Array.blit, CopyTo, 1 つ目の配列の一部を 2 つ目の配列こコピーする
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#blit"
    // Copy 4 elements from index 3 of array1 to index 5 of array2.
    let blit1 = [| 1 .. 10 |]
    let blit2: int [] = Array.zeroCreate 20
    Array.blit blit1 3 blit2 5 4
    blit2 |> should equal [|0; 0; 0; 0; 0; 4; 5; 6; 7; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|]

    @"Array.choose, `if`の結果`Option`を取る関数を与えて`Some(x)`だけを取ってくる
    filterd map, Haskell mapMaybe
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#choose
    https://stackoverflow.com/questions/55674656/how-to-combine-filter-and-mapping-in-haskell"
    Array.choose
        (fun elem ->
            if elem % 2 = 0 then Some(float (elem * elem - 1))
            else None)
        [| 1 .. 10 |]
    |> should equal [|3.0; 15.0; 35.0; 63.0; 99.0|]

    [|Some 1;None;Some 2|] |> Array.choose id |> should equal [|1;2|]
    [|1;2;3|] |> Array.choose (fun n -> if n % 2 = 0 then Some n else None) |> should equal [|2|]

    [|(1,20);(2,30);(1,40);(2,50)|]
    |> Array.choose (fun (i,v) -> if i = 1 then Some v else None)
    |> should equal [|20;40|]

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

    @"Array.create
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#create"
    Array.create 4 "a" |> should equal [|"a"; "a"; "a"; "a"|]
    Array.create 4 0 |> should equal [|0;0;0;0|]

    module DistinctBy =
        // Array.distinctBy
        // 配列の各要素を引数にして関数を実行し、その結果の配列から重複をなくしたものを得る。
        // 要素のない空の配列でも例外は起きない。
        Array.distinctBy (fun n -> n % 2) [| 0 .. 3 |] // [|0; 1|]
        Array.distinctBy<int, bool> (fun _ -> true) [||] // [||] : int []

    @"Array.dropWhile"
    let rec dropWhile p (xs: array<'a>) =
        match xs with
        | [||] -> [||]
        | _ ->
            if p (Array.head xs) then dropWhile p (Array.tail xs)
            else xs
    dropWhile (fun x -> x < 3) [|0..5|] |> should equal [|3;4;5|]

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

    @"forall"
    [|true; true|] |> Array.forall id |> should equal true
    [|true; false|] |> Array.forall id |> should equal false

    @"Array.indexed
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#indexed"
    [|"a";"b";"c"|] |> Array.indexed |> should equal [|(0,"a");(1,"b");(2,"c")|]

    module FindIndexBack =
        // Array.findBack の結果がある要素の位置を得る.
        // 要素が見つからないときは System.Collections.Generic.KeyNotFoundException.
        // 結果が option になる Array.tryFindIndexBack や, 配列の要素を先頭から判定していく Array.findIndex もある.
        Array.findIndexBack (fun n -> n % 2 = 1) [| 1 .. 3 |] // 2
        //Array.findIndexBack (fun n -> n % 2 = 1) [|0|]  // 例外発生「 System.Collections.Generic.KeyNotFoundException 」
        Array.tryFindIndexBack (fun n -> n % 2 = 1) [| 1 .. 3 |] // Some 2
        Array.findIndex (fun n -> n % 2 = 1) [| 1 .. 3 |] // 0

    @"Array.fold
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#fold"
    module Fold =
        type Charge = | In of int | Out of int
        let inputs = [| In 1; Out 2; In 3 |]
        let f acc charge =
            match charge with
            | In i -> acc + i
            | Out o -> acc - o
        (0, inputs) ||> Array.fold f |> should equal 2

    @"Array.fold2
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#fold2"
    module Fold2 =
        type CoinToss = Head | Tails
        let data1 = [| Tails; Head; Tails |]
        let data2 = [| Tails; Head; Head |]
        let f acc a b =
            match (a, b) with
                | Head, Head -> acc + 1
                | Tails, Tails -> acc + 1
                | _ -> acc - 1
        (0, data1, data2) |||> Array.fold2 f |> should equal 1

    @"Array.groupBy
    配列の要素を引数とする関数を順次実行し, その結果ごとに要素をグループ分けする.
    結果の配列の要素は (関数の結果, [|要素, ...|]).
    引数の配列が空でも例外は起きない."
    Array.groupBy (fun n -> n % 3) [| 0 .. 7 |]
    |> should equal [|(0, [|0; 3; 6|]); (1, [|1; 4; 7|]); (2, [|2; 5|])|]
    Array.groupBy (fun n -> n % 3) [||] |> should equal [||]

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

    @"Array.replicate, 同じ値の要素を複数持つ配列を得る.
    数値が 0 以上の整数でなければ System.ArgumentException.
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html"
    Array.replicate 3 "F#" |> should equal [|"F#"; "F#"; "F#"|]
    // Array.replicate -1 "F#" |> should throw typeof<System.ArgumentException>
    // 例外発生「 System.ArgumentException: 入力は負以外である必要がある」.

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

    module SortBy =
        // Array.sortBy
        // 関数指定でソートする
        Array.sortBy abs [| 1; 4; 8; -2; 5 |]
        |> printfn "%A" // [|1; -2; 4; 5; 8|]

    module SortByDescending =
        // Array.sortByDescending
        // 配列の要素を引数とする関数を順次実行した結果をもとに要素を降順で並べ替える.
        // 関数の結果は比較可能な値でなければなりません.
        // 他に配列の要素自体を並べ替える Array.sortDescending や,
        // 配列の並べ替えが昇順になる Array.sortBy もある.
        Array.sortByDescending
            (fun (x, _) -> x)
            [| (2, "dos"); (3, "tres"); (1, "uno") |]
        |> should equal [| (3, "tres"); (2, "dos"); (1, "uno") |]

        Array.sortDescending [| 1 .. 5 |]
        |> should equal [| 5; 4; 3; 2; 1 |]

        Array.sortBy
            (fun (x, _) -> x)
            [| (2, "dos"); (3, "tres"); (1, "uno") |]
        |> should equal [| (1, "uno"); (2, "dos"); (3, "tres") |]

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
            [| (2, "dos"); (3, "tres"); (1, "uno") |]
        |> should equal [| (3, "tres"); (2, "dos"); (1, "uno") |]

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
        slice 2 3 [| 0; 2; 4; 6; 8; 10 |] |> should equal [|4; 6|]
        /// 配列が定義できているときの標準のスライス
        [| 'a' .. 'e' |].[2] |> should equal 'c'
        [| 'a' .. 'e' |].[1..3] |> should equal [|'b'; 'c'; 'd'|]
        [| 'a' .. 'e' |].[2..] |> should equal [|'c'; 'd'; 'e'|]
        [| 'a' .. 'e' |].[..3] |> should equal [|'a'; 'b'; 'c'; 'd'|]

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
    @"docs for List
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html
    https://github.com/dotnet/fsharp/blob/main/src/fsharp/FSharp.Core/list.fs
    https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/lists"

    @"append"
    List.append [ 0 .. 3 ] [ 5 .. 7]
    |> should equal [ 0; 1; 2; 3; 5; 6; 7 ]

    @"collect, Haskell concatMap
    `let concatMap f xs = List.map f xs |> List.concat`"
    [1..4] |> List.collect (fun x -> [1..x])
    |> should equal [1; 1; 2; 1; 2; 3; 1; 2; 3; 4]
    [1..4] |> List.map (fun x -> [1..x])
    |> should equal [[1]; [1; 2]; [1; 2; 3]; [1; 2; 3; 4]]
    List.collect (List.take 2) [[1;2;3]; [4;5;6]]
    |> should equal [1;2;4;5]

    @"concat, join
    Do not coincide with Haskell concat"
    let list1 = [1..5]
    let list2 = [3..7]
    list1 @ list2 |> should equal [1;2;3;4;5;3;4;5;6;7]
    List.concat [list1;list2] |> should equal [1;2;3;4;5;3;4;5;6;7]

    @"consing"
    1 :: [2;3;4] |> should equal [1;2;3;4]
    @"list comprehension, `for`"
    [for i in 1..3 do i] |> should equal [1;2;3]

    @"contains, https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#contains"
    List.contains 3 [1..9] |> should equal true
    List.contains 0 [1..9] |> should equal false

    @"delete: Haskell の delete と同じ.
    https://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:delete"
    let rec delete x xs =
        match xs with
        | [] -> []
        | y :: ys -> if x = y then ys else y :: delete x ys
    delete 1 [1..3] |> should equal [2; 3]
    delete 4 [1..3] |> should equal [1; 2; 3]

    """delete と違い全ての要素を削除する
    deleteAll 1 [ 1; 2; 3; 1; 1; 2; 3 ] |> printfn "%A" // [2; 3; 2; 3]
    deleteAll 4 [ 1; 2; 3; 1; 1; 2; 3 ] |> printfn "%A" // [1; 2; 3; 1; 1; 2; 3]"""
    let deleteAll x = List.filter ((<>) x)
    deleteAll 1 [ 1; 2; 3; 1; 1; 2; 3 ] |> should equal [2; 3; 2; 3]
    deleteAll 4 [ 1; 2; 3; 1; 1; 2; 3 ] |> should equal [1; 2; 3; 1; 1; 2; 3]

    @"Haskell List.dropWhile
    https://hackage.haskell.org/package/base-4.16.0.0/docs/Data-List.html#v:dropWhile
    下の例では不等号の向きに注意しよう：意図通りか実際に REPL で確かめるのがベスト"
    let rec dropWhile: ('a -> bool) -> list<'a> -> list<'a> = fun p xs ->
        match xs with
        | [] -> []
        | y::ys -> if p y then dropWhile p ys else xs
    dropWhile (fun x -> x < 3) [0..5] |> should equal [3..5]
    dropWhile ((>) 3) [1; 2; 3; 4; 5; 1; 2; 3] |> should equal [3; 4; 5; 1; 2; 3]
    dropWhile ((>) 9) [1; 2; 3] |> should equal List.empty<int>
    dropWhile ((>) 1) [1; 2; 3] |> should equal [1; 2; 3]
    dropWhile ((>) 2) [1; 2; 3] |> should equal [2; 3]

    @"filter"
    [1..9]
    |> List.filter (fun x -> x % 2 = 0)
    |> should equal [2;4;6;8]

    @"fold
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#fold
    初期値を入力のリストの先頭から取りたい場合はreduceを使う."
    List.fold min 0 [1..9] |> should equal 0
    List.fold min 2 [1..9] |> should equal 1
    let getTotal1 items =
        items
        |> List.fold (fun acc (q, p) -> acc + q * p) 0
    [(1,2); (3,4)] |> getTotal1 |> should equal 14


    @"List.foldBack, foldr
    注意: 引数の順番がHaskellと違う
    In haskell, foldr :: (a -> b -> b) -> b -> [a] -> [b].
    But in F#,  foldBack: ('a -> 'b -> 'b) -> [a] -> b -> 'b list"
    [1;2;3] |> fun xs -> List.foldBack (+) xs 0 |> should equal 6
    [1;2;3] |> fun xs -> List.foldBack (-) xs 0 |> should equal 2
    // 1 - (2 - (3 - 0)) = 1 - (2 - 3) = 1 - (-1) = 2

    @"forward-pipe operator"
    let getTotal2 items =
        (0, items)
        ||> List.fold (fun acc (q, p) -> acc + q * p)
    [(1,2); (3,4)] |> getTotal2

    @"groupBy: Haskell の groupBy と同じ
    http://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:groupBy"
    module Group =
        @"groupBy"
        [1;2;3;4;5;7;6;5;4;3]
        |> List.groupBy (fun x -> x)
        |> should equal [1,[1];2,[2];3,[3;3];4,[4;4];5,[5;5];7,[7];6,[6]]

        let rec span (p: 'a -> bool) lst =
            match lst with
            | [] -> ([], [])
            | x :: xs ->
                if p x then
                    let (ys, zs) = span p xs
                    (x :: ys, zs)
                else
                    ([], lst)

        let rec groupBy (p: 'a -> 'a -> bool) lst: list<list<'a>> =
            match lst with
            | [] -> []
            | x :: xs ->
                let (ys, zs) = span (p x) xs
                (x :: ys) :: groupBy p zs
        groupBy (=) ("Mississippi" |> List.ofSeq)
        |> should equal [['M']; ['i']; ['s'; 's']; ['i']; ['s'; 's']; ['i']; ['p'; 'p']; ['i']]

        @"group: Haskell の group と同じ
        http://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:group"
        let group xs = groupBy (=) xs
        group ("Mississippi" |> List.ofSeq)
        |> should equal [['M']; ['i']; ['s'; 's']; ['i']; ['s'; 's']; ['i']; ['p'; 'p']; ['i']]

    @"List.head
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#head"
    List.head [1;2;3] |> should equal 1

    @"List.indexed
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#indexed"
    ["a"; "b"; "c"] |> List.indexed |> should equal [(0, "a"); (1, "b"); (2, "c")]

    @"List.init
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#init"
    List.init 4 (fun v -> v + 5) |> should equal [5; 6; 7; 8]

    @"Haskell init, not List.init
    https://hackage.haskell.org/package/base-4.16.0.0/docs/Prelude.html#v:init"
    module InitHaskellPrelude =
        let rec init: list<'a> -> list<'a> = function
        | [] -> failwith "Undefined"
        | [x] -> []
        | x::xs -> x :: init xs
        init [1] |> should equal List.empty<int>
        init [1;2;3;4] |> should equal [1;2;3]

    @"Haskell inits
    https://hackage.haskell.org/package/base-4.16.0.0/docs/Data-List.html#v:inits"
    let inits xs =
        [ 0 .. (List.length xs) ]
        |> List.map (fun i -> List.take i xs)
    inits [1..3] |> should equal [[]; [1]; [1; 2]; [1; 2; 3]]

    @"List.last
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#last"
    [ "pear"; "banana" ] |> List.last |> should equal "banana"

    @"map2
    zipWith: FSharpPlus では ZipList?"
    List.map2 (+) [1;2;3] [2;4;6] |> should equal [3; 6; 9]
    let zipWith f xs ys =
        List.zip xs ys |> List.map (fun (x, y) -> f x y)
    zipWith (+) [1;2;3] [2;4;6] |> should equal [3; 6; 9]

    @"reduce
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#reduce"
    List.reduce min [1..9] |> should equal 1

    @"List.replicate
    `repeat`にも転用可能
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#replicate"
    List.replicate 3 "a" |> should equal ["a";"a";"a"]

    @"List.scan, Haskell scanl
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#scan
    http://zvon.org/other/haskell/Outputprelude/scanl_f.html"
    List.scan (/) 64 [4;2;4] |> should equal [64;16;8;2]
    List.scan (/) 3 [] |> should equal [3]
    List.scan max 5 [1;2;3;4] |> should equal [5;5;5;5;5]
    List.scan max 5 [1;2;3;4;5;6;7] |> should equal [5;5;5;5;5;5;6;7]
    List.scan (fun x y -> 2*x + y)4 [1;2;3] |> should equal [4;9;20;43]

    @"List.scanBack, Haskell scanr
    http://zvon.org/other/haskell/Outputprelude/scanr_f.html"
    List.scanBack (+) [1;2;3;4] 5 |> should equal [15;14;12;9;5]
    List.scanBack (/) [8;12;24;4] 2 |> should equal [8;1;12;2;2]
    List.scanBack (/) [] 3 |> should equal [3]
    List.scanBack (&&) [1>2; 3>2; 5=5] true |> should equal [false;true;true;true]
    List.scanBack max [3;6;12;4;55;11] 18 |> should equal [55;55;55;55;55;18;18]
    List.scanBack max [3;6;12;4;55;11] 111 |> should equal [111;111;111;111;111;111;111]
    List.scanBack (fun x y -> (x+y)/2) [12;4;10;6] 54 |> should equal [12;12;20;30;54]

    @"spanHaskell の span と同じ
    `span p xs = (takeWhile p xs, dropWhile p xs)` であることに注意。
    https://hackage.haskell.org/package/base-4.14.0.0/docs/src/GHC.List.html#span"
    let rec span (p: 'a -> bool) lst =
        match lst with
        | [] -> ([], [])
        | x :: xs ->
            if p x then
                let (ys, zs) = span p xs
                (x :: ys, zs)
            else
                ([], lst)
    span ((>) 3) [1; 2; 3; 4; 1; 2; 3; 4] |> should equal ([1; 2], [3; 4; 1; 2; 3; 4])
    span ((>) 9) [1; 2; 3] |> should equal ([1; 2; 3], List.empty<int>)
    span ((>) 0) [1; 2; 3] |> should equal (List.empty<int>, [1; 2; 3])

    @"String to List, 文字列をリストに変換"
    Seq.toList "abc" |> should equal ['a';'b';'c']

    @"sum"
    [1..9] |> List.sum |> should equal 45

    @"tail"
    List.tail [1;2;3] |> should equal [2;3]

    @"Haskell tails
    https://hackage.haskell.org/package/base-4.16.0.0/docs/Data-List.html#v:tails"
    let rec tails: list<'a> -> list<list<'a>> = function
    | [] -> [[]]
    | x::xs -> (x::xs)::(tails xs)
    tails [1;2;3;4] |> should equal [[1;2;3;4]; [2;3;4]; [3;4]; [4]; []]

    @"takeWhile: Haskell の takeWhile と同じ
    List.takeWhileは標準ライブラリにある.
    下の例では不等号の向きに注意しよう：意図通りか実際に REPL で確かめるのがベスト"
    let rec takeWhile (p: 'a -> bool) lst =
        match lst with
        | [] -> []
        | x :: xs -> if p x then x :: takeWhile p xs else []
    (takeWhile ((>) 3) [1;2;3]) = (List.takeWhile ((>) 3) [1;2;3]) |> should equal true
    takeWhile ((>) 3) [1; 2; 3; 4; 1; 2; 3; 4] |> should equal [1; 2]
    takeWhile ((>) 9) [1; 2; 3] |> should equal [1; 2; 3]
    takeWhile ((>) 0) [1; 2; 3] |> should equal List.empty<int>

module Sequence =
    @"docs
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html"

    @"Seq.allPairs
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#allPairs"
    ([1; 2], [3; 4]) ||> Seq.allPairs |> should equal (seq {(1, 3); (1, 4); (2, 3); (2, 4)})

    @"Seq.append
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html"
    Seq.append [1;2] [3;4]|> should equal (seq [1..4])

    @"Seq.average
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#average"
    [1.0; 2.0; 3.0] |> Seq.average |> should equal 2

    @"Seq.averageBy
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#averageBy"
    module AverageBy =
        type Foo = { Bar: float }
        seq {{Bar = 2.0}; {Bar = 4.0}}
        |> Seq.averageBy (fun foo -> foo.Bar) |> should equal 3.0

    @"Seq.cache
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#cache"
    module Cache =
        let fibSeq = (0, 1) |> Seq.unfold (fun (a,b) -> Some(a + b, (b, a + b)))
        let fibSeq3 = fibSeq |> Seq.take 3 |> Seq.cache
        fibSeq3 |> should equal (seq [1;2;3])

    @"Seq.cast
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#cast"
    [box 1; box 2; box 3] |> Seq.cast<int> |> should equal (seq {1; 2; 3})

    @"Seq.choose"
    [Some 1; None; Some 2] |> Seq.choose id |> should equal (seq {1; 2})
    [1; 2; 3] |> Seq.choose (fun n -> if n % 2 = 0 then Some n else None) |> should equal (seq [2])

    @"Seq.chunkBySize"
    [1; 2; 3] |> Seq.chunkBySize 2 |> should equal (seq {[|1; 2|]; [|3|]})

    @"Seq.collect"
    module Collect =
        type Foo = { Bar: int seq }
        seq { {Bar = [1; 2]}; {Bar = [3; 4]} } |> Seq.collect (fun foo -> foo.Bar)
        |> should equal (seq { 1; 2; 3; 4 })

        [[1; 2]; [3; 4]] |> Seq.collect id |> should equal (seq { 1; 2; 3; 4 })

    @"Seq.compareWith"
    module CompareWith =
        let closerToNextDozen a b = (a % 12).CompareTo(b % 12)
        ([1; 10], [1; 10]) ||> Seq.compareWith closerToNextDozen |> should equal 0
        ([1;5], [1;8]) ||> Seq.compareWith closerToNextDozen |> should equal -1
        ([1;11], [1;13]) ||> Seq.compareWith closerToNextDozen |> should equal 1
        ([1;2], [1]) ||> Seq.compareWith closerToNextDozen |> should equal 1
        ([1], [1;2]) ||> Seq.compareWith closerToNextDozen |> should equal -1

    @"Seq.concat"
    [[1; 2]; [3]; [4; 5]] |> Seq.concat |> should equal (seq { 1; 2; 3; 4; 5 })

    @"Seq.contains"
    [1; 2] |> Seq.contains 2 |> should equal true
    [1; 2] |> Seq.contains 5 |> should equal false

    @"Seq.countBy"
    module CountBy =
        type Foo = { Bar: string }
        let inputs = [{Bar = "a"}; {Bar = "b"}; {Bar = "a"}]
        inputs |> Seq.countBy (fun foo -> foo.Bar)
        |> should equal (seq { ("a", 2); ("b", 1) })

    @"Seq.delay"
    Seq.delay (fun () -> Seq.ofList [1; 2; 3]) |> should equal (seq { 1; 2; 3 })

    @"Seq.distinct"
    [1; 1; 2; 3] |> Seq.distinct |> should equal (seq { 1; 2; 3 })

    @"Seq.distinctBy"
    module DistinctBy =
        type Foo = { Bar: int }
        [{Bar = 1 };{Bar = 1}; {Bar = 2}; {Bar = 3}] |> Seq.distinctBy (fun foo -> foo.Bar)
        |> should equal (seq {{ Bar = 1 }; { Bar = 2 }; { Bar = 3 }})

    @"dropWhile"
    let rec dropWhile p (xs: seq<'a>) =
        match xs with
        | s when Seq.isEmpty s -> Seq.empty
        | _ ->
            if p (Seq.head xs) then dropWhile p (Seq.tail xs)
            else xs
    dropWhile (fun x -> x < 3) (seq {0..5})
    |> should equal (seq {3;4;5})

    @"Seq.empty"
    Seq.empty |> should equal (seq [])

    @"Seq.exactlyOne"
    ["banana"] |> Seq.exactlyOne |> should equal "banana"

    @"Seq.except"
    let original = [1; 2; 3; 4; 5]
    let itemsToExclude = [1; 3; 5]
    original |> Seq.except itemsToExclude |> should equal (seq { 2; 4 })

    @"Seq.exists"
    [1; 2; 3; 4; 5] |> Seq.exists (fun elm -> elm % 4 = 0) |> should equal true
    [1; 2; 3; 4; 5] |> Seq.exists (fun elm -> elm % 6 = 0) |> should equal false

    @"Seq.exists2 TODO"

    @"Seq.fold2
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#fold2"
    type CoinToss = Head | Tails
    let data1 = [Tails; Head; Tails]
    let data2 = [Tails; Head; Head]
    (0, data1, data2) |||> Seq.fold2 (fun acc a b ->
        match (a, b) with
        | Head, Head -> acc + 1
        | Tails, Tails -> acc + 1
        | _ -> acc - 1)
        |> should equal 1

    @"Seq.item"
    ["a"; "b"; "c"] |> Seq.item 1 |> should equal "b"

    @"Seq.sum s = Seq.fold (+) 0 s"
    Seq.fold (-) 0 { 0 .. 9 } |> should equal -45

    @"group: Haskell の group と同じ
    http://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:group"
    module Group =
        let (|SeqEmpty|SeqCons|) (xs: 'a seq) =
            if Seq.isEmpty xs then SeqEmpty else SeqCons(Seq.head xs, Seq.skip 1 xs)

        let rec group = function
            | SeqEmpty -> Seq.empty
            | SeqCons (x, xs) ->
                let ys: 'a seq = Seq.takeWhile ((=) x) xs
                let zs: 'a seq = Seq.skipWhile ((=) x) xs
                Seq.append (seq { Seq.append (seq { x }) ys }) (group zs)
        group "Mississippi" |> printfn "%A"
        // seq [seq ['M']; seq ['i']; seq ['s'; 's']; seq ['i']; ...]

    @"head"
    Seq.head (seq { 0 .. 9 }) |> should equal 0

    @"Seq.initInfinite, infinite seq
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#initInfinite
    https://atcoder.jp/contests/abc169/tasks/abc169_d
    Seqに対するhead-tailの分解
    Active Pattern利用"
    let (|SeqEmpty|SeqCons|) (xs: 'a seq) =
        if Seq.isEmpty xs then SeqEmpty else SeqCons(Seq.head xs, Seq.skip 1 xs)
    Seq.initInfinite id |> Seq.take 3 |> should equal [0; 1; 2]
    Seq.initInfinite (fun x -> x + 1) |> Seq.take 3 |> should equal [1; 2; 3]

    @"initInfinite64
    https://atcoder.jp/contests/abc169/tasks/abc169_d
    `return!`を使った再帰ではなく`mutable`を使っているのは`return!`で生成されるステートマシンのコストが（数を出して1増やすだけの処理より）高いため"
    let initInfinite64 f =
        seq {
            let mutable i = 0L
            while true do
                yield f i
                i <- i + 1L
        }
    @"initInfiniteBigInteger"
    let initInfiniteBigInteger f =
        seq {
            let mutable i = 0I
            while true do
                yield f i
                i <- i + 1I
        }

    @"haskell iterate
    http://fssnip.net/18/title/Haskell-function-iterate
    iterate :: (a -> a) -> a -> [a]
    iterate f x = x : iterate f (f x)"
    let rec iterate f x = seq {
        yield x
        yield! iterate f (f x)
    }
    Seq.take 10 (iterate ((*) 2) 1) |> should equal (seq [1;2;4;8;16;32;64;128;256;512])

    @"Seq.length"
    seq [1; 2; 3] |> Seq.length |> should equal 3

    @"Seq.ofList"
    [ 1; 2; 5 ] |> Seq.ofList |> should equal (seq {1;2;5})

    @"Seq.reduce"
    seq {0..9} |> Seq.reduce (-) |> should equal -45

    @"Seq.replicate"
    Seq.replicate 3 'a' |> should equal (seq ['a'; 'a'; 'a'])

    @"repeat, Haskell
    https://hackage.haskell.org/package/base-4.16.0.0/docs/Data-List.html"
    let rec repeat x = seq {
        yield x
        yield! repeat x
    }
    Seq.take 3 (repeat 1) |> should equal (seq [1;1;1])

    @"Seq.tail"
    Seq.tail (seq {0..3}) |> should equal (seq { 1 .. 3 })

    @"Seq.takeWhile"
    Seq.takeWhile (fun x -> x < 3) (seq { 0 .. 9 })
    |> should equal (seq { 0..2 })

module String =
    @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-stringmodule.html"

    @"埋め込み文字列"
    let text = "TEXT"
    $"text: {text}" |> should equal "text: TEXT"

    @"String.collect
    mapと違って文字を文字列に変換する関数を使ってmapする
    https://msdn.microsoft.com/visualfsharpdocs/conceptual/string.collect-function-%5bfsharp%5d"
    "Hello, World"
    |> String.collect (fun c -> sprintf "%c " c)
    |> should equal "H e l l o ,   W o r l d "

    @"String.concat
    配列やリストの要素を連結して文字列化"
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

    ["Stefan"; "says:"; "Hello"; "there!"]
    |> String.concat " " |> should equal "Stefan says: Hello there!"

    [0..9] |> List.map string |> String.concat "" |> should equal "0123456789"
    [0..9] |> List.map string |> String.concat ", " |> should equal "0, 1, 2, 3, 4, 5, 6, 7, 8, 9"
    ["No comma"] |> String.concat "," |> should equal "No comma"

    @"System.String.Concat
    文字(char)のリストを文字列化.
    注意: `['1'; '2'; '3'] |> String.concat`はエラー."
    ['1'; '2'; '3'] |> System.String.Concat |> should equal "123"

    @"exists
    文字列中に与えられた条件をみたす文字が存在するか"
    open System
    "Hello World!" |> String.exists System.Char.IsUpper |> should equal true
    "Yoda" |> String.exists Char.IsUpper |> should equal true
    "nope" |> String.exists Char.IsUpper |> should equal false

    @"filter"
    open System
    // Filtering out just alphanumeric characters
    "0 1 2 3 4 5 6 7 8 9 a A m M"
    |> String.filter Uri.IsHexDigit |> should equal "0123456789aA"

    //Filtering out just digits
    "hello" |> String.filter Char.IsDigit |> should equal ""

    @"forall"
    open System
    "all are lower" |> String.forall Char.IsLower |> should equal false
    "allarelower" |> String.forall Char.IsLower |> should equal true

    @"forall
    文字列中のすべての文字が条件を満たすか"
    "helloworld"
    |> String.forall System.Char.IsLower
    |> should equal true
    // space がある
    "hello world"
    |> String.forall System.Char.IsLower
    |> should equal false

    @"init
    インデックスに対して関数を作用させた結果の文字列を連結する"
    String.init 10 (fun i -> i.ToString())
    |> should equal "0123456789"
    String.init 26 (fun i -> sprintf "%c" (char (i + int 'A')))
    |> should equal "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    String.init 10 (fun i -> int '0' + i |> sprintf "%d ")
    |> should equal "48 49 50 51 52 53 54 55 56 57 "

    @"iter"
    "Hello" |> String.iter (fun c -> printfn "%c %d" c (int c))

    @"iteri"
    "Hello" |> String.iteri (fun i c -> printfn "%d. %c %d" (i + 1) c (int c))

    @"length
    文字列の長さ"
    "aiueo" |> String.length |> should equal 5
    String.length null  |> should equal 0
    String.length ""    |> should equal 0
    String.length "123" |> should equal 3

    @"map
    各文字に作用"
    open System
    "hello, world" |> String.map System.Char.ToUpper
    |> should equal "HELLO, WORLD"

    "Hello there!" |> String.map Char.ToUpper
    |> should equal "HELLO THERE!"

    @"mapi"
    "OK!" |> String.mapi (fun i c -> char c)
    |> should equal "OK!"

    @"String.replicate
    文字列のくり返し."
    "Do it!" |> String.replicate 3
    |> should equal "Do it!Do it!Do it!"

    @"reverse"
    "abcde"
    |> Seq.toArray
    |> Array.rev
    |> System.String
    |> should equal"edcba"

    @"Split
    文字列を分割する「メソッド」"
    "1 2 3" |> fun s -> s.Split(" ")
    |> should equal [| "1"; "2"; "3"|]

    @"Substring
    部分文字列をとる「メソッド」"
    let s = "0123456789"
    s.Substring(s.Length - 5) |> should equal "56789"
    s.Substring(1, 5) |> should equal "12345"

    @"Seq.take"
    seq {0..4} |> Seq.take 2 |> should equal (seq {0;1})

    @"Seq.truncate
    Seq.takeとの違いは指定の要素数以上取れないときにエラーにならず,
    取れるだけ取ってくれる点."
    seq {0..4} |> Seq.truncate 2 |> should equal (seq {0;1})
    seq {0..4} |> Seq.truncate 7 |> should equal (seq {0..4})

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

    @"相互再帰関数, mutual recursion"
    let rec even x = if x = 0 then true else odd (x-1)
    and odd x = if x = 0 then false else even(x-1)
    let isEven x = if (x < 0) then even (-x) else even x
    isEven 9 |> should equal false
    isEven 10 |> should equal true

    @"パターンマッチ・引数の場合分けによる定義,
    Haskellでいう次のような定義
    f [] = []
    f x:xs = undefined
    "
    let rec fact1 = function
    | 1 -> 1
    | n -> n * fact1 (n-1)

    let rec map: ('a -> 'b) -> 'a list -> 'b list = fun f ys ->
        match ys with
        | [] -> []
        | x::xs -> f x :: map f xs
    map (fun x -> x+1) [1;2;3] |> should equal [2;3;4]

module PatternMatch =
    exception DivideByZeroException
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

    module Type2 =
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
    let coupon1 = {B=1; Discount=2}
    let coupon2 = {B=2; Discount=3}

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

    @"abs
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#abs"
    abs 1 |> should equal 1
    abs -1 |> should equal 1
    abs 1.0 |> should equal 1.0
    abs -1.0 |> should equal 1.0
    module Abs =
        let myabsint x = if x > 0 then x else -x
        myabsint -1 |> should equal 1
        let myabsfloat x = if x > 0.0 then x else -x
        myabsfloat -1.0 |> should equal 1.0

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
    @"整数の一桁目の切り上げ
    cf. ABC123 B, https://atcoder.jp/contests/abc123/submissions/20135376"
    module Oneceil =
        let oneceil x = (x+9) / 10 * 10
        let xs = [|29; 20; 7; 35; 120|]
        let ys = [|30; 20; 10; 40; 120|]
        xs |> Array.map oneceil |> should equal ys

    @"factorial, 階乗"
    module Factorial =
        let rec fact acc n =
            if n = 0L then 0L
            elif n = 1L then acc
            else fact (acc*n) (n-1L)
        let fact1 = fact 1L
        [1L..5L] |> List.map fact1 |> should equal [1L;2L;6L;24L;120L]

    @"Fibonacci sequence, フィボナッチ数列"
    module Fib =
        @"メモ化していない重いフィボナッチ"
        let rec fibNoMemo n =
            if n = 0I then 0I
            else if n = 1I then 1I
            else fibNoMemo (n - 1I) + fibNoMemo (n - 2I)
        fibNoMemo 5I |> should equal 5I
        fibNoMemo 6I |> should equal 8I

        @"メモ化したフィボナッチ"
        #nowarn "40"
        let rec fibMemo =
            let dict =
                System.Collections.Generic.Dictionary<_, _>()
            fun n ->
                match dict.TryGetValue(n) with
                | true, v -> v
                | false, _ ->
                    let temp =
                        if n = 0I then 0I
                        else if n = 1I then 1I
                        else fibMemo (n - 1I) + fibMemo (n - 2I)

                    dict.Add(n, temp)
                    temp
        fibMemo 5I |> should equal 5I
        fibMemo 6I |> should equal 8I
        fibMemo 50I |> should equal 12586269025I

        @"unfold によるフィボナッチ数列
        https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/sequences
        UntilN とあるが、実際には最終項が N を超えたところでようやく止まる.
        実際に実行してみるとわかる."
        let fibByUnfoldUntilN n =
            (1, 1) // Initial state
            |> Seq.unfold (fun state ->
                if (snd state > n)
                then None
                else Some(fst state + snd state, (snd state, fst state + snd state)))
        fibByUnfoldUntilN 1000 |> List.ofSeq |> should equal [2; 3; 5; 8; 13; 21; 34; 55; 89; 144; 233; 377; 610; 987; 1597]

    @"first digit, 整数の一桁目を得る"
    module FirstDigit =
        let firstDigit x = (10 - x%10) % 10
        let xs = [|29; 20; 7; 35; 120|]
        let ys = [|1; 10; 3; 5; 10|]
        let zs = [|1; 0; 3; 5; 0|]
        xs |> Array.map (fun x -> 10 - x%10) |> should equal ys
        xs |> Array.map firstDigit |> should equal zs

    @"floor, 切り捨て"
    floor -1.4 |> should equal -2.0
    floor -1.5 |> should equal -2.0
    floor 1.4  |> should equal 1.0
    floor 1.5  |> should equal 1.0

    @"gcd, lcm
    http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_B&lang=ja
    http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2116711#1"
    module GCD =
        module GCD1 =
            let gcd: int64 -> int64 -> int64 = fun x y ->
                let rec locgcd x y =
                    match y with
                    | 0L -> x
                    | _ -> locgcd y (x % y)
                if x >= y then locgcd x y else locgcd y x
            let lcm a b = a * b / (gcd a b)

            gcd 2L 4L |> should equal 2L
            lcm 2L 4L |> should equal 4L
            gcd 147L 105L |> should equal 21L
            lcm 147L 105L |> should equal 735L

        @"参考
        https://docs.microsoft.com/ja-jp/dotnet/fsharp/tour
        https://alexatnet.com/hr-f-computing-the-gcd/"
        module MyGcd2 =
            let rec gcd: int64 -> int64 -> int64 = fun a b ->
                if a = 0L then b
                elif a < b then gcd a (b - a)
                else gcd (a - b) b
            let lcm a b = a * b / (gcd a b)

            gcd 2L 4L |> should equal 2L
            lcm 2L 4L |> should equal 4L
            gcd 147L 105L |> should equal 21L
            lcm 147L 105L |> should equal 735L

        @"../ProjectEuler/00005_Smallest_multiple/01.fsx"
        module MyGcd3 =
            let rec gcd a b =
                let (s, l) = if a < b then (a, b) else (b, a)
                let r = l % s
                if r = 0L then s else gcd r s
            let lcm a b = a * b / (gcd a b)

            gcd 2L 4L |> should equal 2L
            lcm 2L 4L |> should equal 4L
            gcd 147L 105L |> should equal 21L
            lcm 147L 105L |> should equal 735L

    @"剰余, 余り, mod"
    10 % 2 |> should equal 0
    10 % 7 |> should equal 3

    @"n 進法 n-ary notation
    使える文字の都合で n < 26 を仮定するが本質的ではない
    参考：https://webbibouroku.com/Blog/Article/haskell-nstring
    AtCoderで出てきた「26進数」：AtCoder/ABC171/C1.fsx"
    module NaryLT16 =
        let numbersLT16 = [| "0";"1";"2";"3";"4";"5";"6";"7";"8";"9";"a";"b";"c";"d";"e";"f"|]
        let rec toNary n x =
            if x = 0L then []
            else
                let q = x / n
                let r = x % n |> int
                List.append (toNary n q) [ numbersLT16.[r] ]
        let to3ary = toNary 3L
        [0L..3L] |> List.map to3ary |> should equal  [[]; ["1"]; ["2"]; ["1"; "0"]]

        let intToNary n x =
            if x = 0L then [ numbersLT16.[0] ]
            elif n = 0L then []
            elif n = 1L then List.replicate (int x) (numbersLT16.[1])
            elif n <= 16L then toNary n x
            else []
        let intTo2ary = intToNary 2L
        [0L..8L] |> List.map intTo2ary |> should equal [["0"]; ["1"]; ["1"; "0"]; ["1"; "1"]; ["1"; "0"; "0"]; ["1"; "0"; "1"]; ["1"; "1"; "0"]; ["1"; "1"; "1"]; ["1"; "0"; "0"; "0"]]

    module NaryLT26 =
        let numbersLT26 = [| 'a' .. 'z' |]
        let rec toNary n x =
            if x = 0L then []
            else
                let q = x / n
                let r = x % n |> int
                List.append (toNary n q) [ numbersLT26.[r |> int] ]

        let intToNary n x =
            if x = 0L then [ numbersLT26.[0] ]
            elif n = 0L then []
            elif n = 1L then List.replicate (int x) (numbersLT26.[1])
            elif n <= 26L then toNary n x
            else []
        let intTo2ary = intToNary 2L
        [0L..11L] |> List.map intTo2ary |> should equal  [['a']; ['b']; ['b'; 'a']; ['b'; 'b']; ['b'; 'a'; 'a']; ['b'; 'a'; 'b']; ['b'; 'b'; 'a']; ['b'; 'b'; 'b']; ['b'; 'a'; 'a'; 'a']; ['b'; 'a'; 'a'; 'b']; ['b'; 'a'; 'b'; 'a']; ['b'; 'a'; 'b'; 'b']]

    @"perfect number, 完全数"
    let isPerfect n =
        if n <= 0L then false
        else
            seq {1L..(n-1L)}
            |> Seq.filter (fun x -> n%x = 0L)
            |> Seq.sum
            |> (fun x -> x=n)
    [1L..28L] |> List.filter isPerfect |> should equal [6L;28L]

    @"perfect square, 完全平方数
    http://www.fssnip.net/dn/title/Checking-for-perfect-squares
    An implementation of John D. Cook's algorithm for fast-finding perfect squares: http://www.johndcook.com/blog/2008/11/17/fast-way-to-test-whether-a-number-is-a-square/"
    module IsPerfectSquare =
        let isPerfectSquare n =
            let h = n &&& 0xF
            if (h > 9) then false
            else
                if ( h <> 2 && h <> 3 && h <> 5 && h <> 6 && h <> 7 && h <> 8 ) then
                    let t = ((n |> double |> sqrt) + 0.5) |> floor|> int
                    t*t = n
                else false
        [1..100]
        |> List.choose (fun x -> if isPerfectSquare x then Some x else None)
        |> should equal [1; 4; 9; 16; 25; 36; 49; 64; 81; 100]

    "@Prime factorization, 素因数分解
    https://atcoder.jp/contests/ABC169/tasks/abc169_d"
    module PrimeFactorization =
        @"https://atcoder.jp/contests/ABC169/submissions/13872716"
        module PF1 =
            type Factor = { Number: int64; Count: int }
            /// m: origN を割っていった値でどんどん小さくなる
            /// a: 2L からインクリメントしていく値
            /// origN: 入力値
            let rec primes m a origN =
                // sqrt N 以下の値だけ調べればよい
                if origN < a * a then
                    if m = 1L then [] else [ { Number = origN; Count = 1 } ] // 最終的に素数と分かったとき
                elif m % a <> 0L then
                    let aPlus = if a = 2L then 3L else a + 2L
                    primes m aPlus origN
                else
                    /// n: primes オリジナルの引数 m を a でどんどん割っていく
                    /// acc: 割り切った回数のカウンター
                    let rec inner n acc =
                        if n % a <> 0L then (n, acc) else inner (n / a) (acc + 1)

                    let (m1, c) = inner m 0
                    // 1 番最初に 2L で呼んでいるため a >= 3 以上では
                    // m がすでに因数として 2 はもっていない。
                    // 2 より大きい偶数を考えても仕方ないので奇数だけ考える
                    let aPlus = if a = 2L then 3L else a + 2L
                    { Number = a; Count = c }
                    :: (primes m1 aPlus origN)
            let primeFactors n = primes n 2L n
            @"素数判定
            https://atcoder.jp/contests/arc017/tasks/arc017_1
            https://qiita.com/drken/items/a14e9af0ca2d857dad23#問題-1-素数判定"
            let rec isprime n =
                if n < 0L then isprime (-n)
                elif n = 0L then false
                elif n = 1L then false
                else primeFactors n = [ { Number = n; Count = 1 } ]
            [1L..8L] |> List.filter isprime |> should equal [2L;3L;5L;7L]

        @"http://www.fssnip.net/3X"
        module FsSnip =
            let isprime n =
                let sqrtn = (float >> sqrt >> int) n // square root of integer
                [| 2 .. sqrtn |] // all numbers from 2 to sqrt'
                |> Array.forall (fun x -> n % x <> 0) // no divisors

            let allPrimes =
                // sequences are lazy, so we can make them infinite
                let rec f n = seq {
                        if isprime n then
                            yield n
                        yield! f (n+1) // recursing
                    }
                f 2 // starting from 2

            allPrimes |> Seq.take 5 |> should equal (seq  [|2; 3; 5; 7; 11|])

        @"https://stackoverflow.com/questions/1097411/learning-f-printing-prime-numbers#answer-1097596"
        module StackOverflowSieve =
            let rec sieve = function
                | (p::xs) -> p :: sieve [ for x in xs do if x % p > 0 then yield x ]
                | []      -> []
            sieve [2..50] |> List.take 5 |> should equal [2;3;5;7;11]

        module StackOverflowPrime1 =
            let twoAndOdds n =
                Array.unfold (fun x -> if x > n then None else if x = 2 then Some(x, x + 1) else Some(x, x + 2)) 2
            twoAndOdds 15 |> should equal [|2; 3; 5; 7; 9; 11; 13; 15|]

            // https://stackoverflow.com/questions/1097411/learning-f-printing-prime-numbers#answer-35966305
            let infSeq (limit: int64) =
                seq {
                    yield 2L
                    let mutable i = 3L
                    let mutable l = 3L
                    while l < limit do // この制約を入れないと f i がオーバーフローしてひどいことになったことがある。
                        let a = i
                        yield a
                        i <- i + 2L
                        l <- i
                }

            let rec isprime x =
                if x < 0L then isprime (-x)
                elif x = 0L then false
                elif x = 1L then false
                else infSeq x
                    |> Seq.takeWhile (fun i -> i * i <= x)
                    |> Seq.forall (fun i -> x % i <> 0L)
            [0L..10L] |> List.filter isprime |> should equal [2L;3L;5L;7L]

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
    choose [1;2;3] |> should equal [(1, [2; 3]); (2, [1; 3]); (3, [1; 2])]
    let rec permutations xs =
        match xs with
        | [] -> [[]]
        | xs ->
            choose xs
            |> List.collect (fun (y, ys) -> List.map (fun zs -> y::zs) (permutations ys))
    permutations [1;2;3] |> should equal [[1; 2; 3]; [1; 3; 2]; [2; 1; 3]; [2; 3; 1]; [3; 1; 2]; [3; 2; 1]]

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
    uint 100 |> should equal 100u
    int64 100 |> should equal 100L
    uint64 100 |> should equal 100UL

    @"bottom, undefined, ⊥, _|_
    https://stackoverflow.com/questions/20337249/bottom-undefined-value-in-f
    open System
    let undefined<'T> : 'T = raise (NotImplementedException())"

module Operator =
    @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html"

    @"self definition
    https://stackoverflow.com/questions/2210854/can-you-define-your-own-operators-in-f"
    let (+.) x s = [for y in s -> x + y]
    1 +. [2;3;4] |> should equal [3;4;5]

    @"Boolean Operators
    https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/symbol-and-operator-reference/boolean-operators"
    not true |> should equal false
    not false |> should equal true
    (true || true) |> should equal true
    (true || false) |> should equal true
    (false || false) |> should equal false
    (true && true) |> should equal true
    (true && false) |> should equal false
    (false && false) |> should equal false

    @"flip: defition of an operator, using paretheses"
    let flip f x y = f y x
    let (><) f x y = f y x
    (/) 3 2 |> should equal 1
    flip (/) 3 2 |> should equal 0
    (><) (/) 3 2 |> should equal 0

    @"not equal"
    1 <> 2 |> should equal true
    'b' <> 'a' |> should equal true

    @"<-, substiture, 可変型の変数に代入
    TODO: fsharp.github.ioの適切なリンクを張り直す
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#(%20:=%20)
    `:=`はdeprecated."
    let count = ref 0 // Creates a reference cell object with a mutable Value property
    count.Value |> should equal 0
    count.Value <- 1  // Updates the value
    count.Value |> should equal 1

module Prelude =
    @"uncurry,
    http://fssnip.net/3n/title/Curry-Uncurry
    https://hackage.haskell.org/package/base-4.16.0.0/docs/Prelude.html#v:uncurry"
    let curry f a b = f (a,b)
    let uncurry f (a,b) = f a b

module Option =
    @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html"
    let tryParse (input: string) =
        match System.Int32.TryParse input with
        | true, v -> Some v
        | false, _ -> None
    None |> Option.bind tryParse |> should equal None
    Some "42" |> Option.bind tryParse |> should equal (Some 42)
    Some "Forty-two" |> Option.bind tryParse |> should equal None

module Print =
    @"%A: どんな型でもとにかく出力"
    [1;2;3;4] |> printfn "%A"
    2 |> printfn "%A"

    2L |> printfn "%A" // 2LのLまで出力されてしまう
    2L |> printfn "%d" // Lは出力されない

    "str" |> printfn "%A" // クオートつきで出力
    "str" |> printfn "%s" // クオートなしで出力

module Set =
    @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-setmodule.html"

    @"count, length for sets"
    set [1;2] |> Set.count |> should equal 2

    @"difference
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-setmodule.html#difference "
    let origset = Set "abc"
    let chk = Set "abcdef"
    Set.difference chk origset |> should equal (set ['d';'e';'f'])

    @"intersect
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-setmodule.html#intersect "
    Set.intersect (set [1;2;3]) (set [2;3;4]) |> should equal (set [2;3])

    @"Set.ofArray"
    Set.ofArray [|1;2|] |> should equal (set [1;2])

    @"Set.ofSeq, 文字列から変換するときはこれを使う."
    Set.ofSeq "abc" |> should equal (set ['a';'b';'c'])
