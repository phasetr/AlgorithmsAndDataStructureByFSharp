#r "nuget: FsUnit"
open FsUnit
#nowarn "40"

@"
F# https://fsharp.github.io/fsharp-core-docs/reference
.NET API Browser https://docs.microsoft.com/ja-jp/dotnet/api/?view=net-6.0
.NET CLI https://docs.microsoft.com/ja-jp/dotnet/core/tools/
.NET Cloud https://cloud.google.com/dotnet/docs/reference"

@"MISC, MEMO
FsUnit: https://fsprojects.github.io/FsUnit/
FTP: Use FluentFTP, https://github.com/robinrodricks/FluentFTP"

module SimpleBenchmark =
  // https://nenono.hatenablog.com/entry/2014/06/17/223141
  let benchmark n f =
    let sw  = new System.Diagnostics.Stopwatch()
    sw.Start()
    for i in 1..n do f() |> ignore
    sw.Stop()
    sw.Elapsed
  let n = 15
  let repeat = 500000
  let bench f = benchmark repeat (fun ()->f n) |> printfn "%A"

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

module Array =
  @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html"

  @"accessor or slice"
  let a = [|0..4|]
  a.[0] |> should equal 0
  a.[0..2] |> should equal [|0;1;2|]
  a.[1..] |> should equal [|1;2;3;4|]
  a.[..3] |> should equal [|0;1;2;3|]

  @"Haskell, Array.accum, Vector.accum
  http://zvon.org/other/haskell/Outputarray/accum_f.html"
  module Accum =
    @"TODO この実装はあまり効率がよくない模様.
    本家Haskellの実装をきちんと見て実装し直したい."
    let accum f is xs =
      Array.indexed is
      |> Array.map (fun (i,v) -> Array.fold f v [|for (j,x) in xs do if i=j then yield x|])
    accum (+) [|1000;2000;3000|] [|(2,4);(1,6);(0,3);(1,10)|] |> should equal [|1003;2016;3004|]

  @"Haskell accumArray, cf. Bird, Gibbons
  http://zvon.org/other/haskell/Outputarray/accumArray_f.html
  https://hackage.haskell.org/package/base-4.16.1.0/docs/GHC-Arr.html#v:accumArray"
  module AccumArray =
    let accumArray: ('e -> 'v -> 'e) -> 'e -> ('i * 'i) -> list<'i * 'v> -> array<'i*'e> = fun f e (l,r) ivs ->
      [for j in [l..r] do (j, List.fold f e [for (i,v) in ivs do if i=j then yield v])]
      |> Array.ofList
    accumArray (+) 0 (1,3) [(1,20);(2,30);(1,40);(2,50)] |> should equal [|(1,60);(2,80);(3,0)|]

  @"Addメソッド, ResizeArray
  可変配列に対して破壊的に値を追加する."
  let xa = ResizeArray<int>() in xa.Add(1); xa.Add(2); xa |> should equal (seq {1;2})

  @"Array.allPairs
  配列 1 と配列 2 の各要素のすべての組み合わせをタプルの要素とする配列を得る.
  結果となる配列の長さが膨大になる可能性があるため引数の配列の長さに注意すること.
  引数の配列のどちらかが空のときは結果の配列も空になる."
  Array.allPairs [|'a'..'c'|] [|1..2|] |> should equal [|('a',1);('a',2);('b',1);('b',2);('c',1);('c',2)|]
  Array.allPairs<char, int> [|'a';'b'|] [||] |> should equal [||] //: (char * int) []

  @"Array.append
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#append
  配列の連結"
  Array.append [|0..5|] [|10..15|] |> should equal [|0;1;2;3;4;5;10;11;12;13;14;15|]

  @"Array.average
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#average

  To get the average of an array of integers,
  use Array.averageBy to convert to float.
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#averageBy"
  Array.average [|1.0..10.0|] |> should equal 5.5
  Array.averageBy float [|1..10|] |> should equal 5.5

  @"Array.blit, CopyTo, 一つ目の配列の一部を二つ目の配列こコピーする
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#blit"
  // Copy 4 elements from index 3 of array1 to index 5 of array2.
  let blit1 = [|1..10|]
  let blit2: int [] = Array.zeroCreate 20
  Array.blit blit1 3 blit2 5 4
  blit2 |> should equal [|0; 0; 0; 0; 0; 4; 5; 6; 7; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|]

  @"Array.choose, `if`の結果`Option`を取る関数を与えて`Some(x)`だけを取ってくる
  filterd map, Haskell mapMaybe, OCaml filtered_map
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#choose
  https://stackoverflow.com/questions/55674656/how-to-combine-filter-and-mapping-in-haskell"
  module Choose =
    Array.choose
      (fun elem ->
        if elem % 2 = 0 then Some(float (elem * elem - 1))
        else None)
      [|1..10|]
    |> should equal [|3.0; 15.0; 35.0; 63.0; 99.0|]

    [|Some 1;None;Some 2|] |> Array.choose id |> should equal [|1;2|]
    [|1;2;3|] |> Array.choose (fun n -> if n % 2 = 0 then Some n else None) |> should equal [|2|]

    [|(1,20);(2,30);(1,40);(2,50)|]
    |> Array.choose (fun (i,v) -> if i = 1 then Some v else None)
    |> should equal [|20;40|]

  @"Array.chunkBySize
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#chunkBySize
  一次元配列の要素を指定された数ごとに区切ったジャグ配列 (配列の配列) を得る。
  要素数に正の整数を指定しないと System.ArgumentException が起きる。"
  Array.chunkBySize 3 [|0..7|] |> should equal [|[|0;1;2|];[|3;4;5|];[|6;7|]|]
  (fun () -> Array.chunkBySize 0 [|0..7|] |> ignore) |> should throw typeof<System.ArgumentException>

  @"Array.collect, Haskell concatMap
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#collect
  配列の各要素に関数を当て、最後にflat化する"
  Array.collect (fun elem -> [|0..elem|]) [|1;5;10|]
  |> should equal [|0;1;0;1;2;3;4;5;0;1;2;3;4;5;6;7;8;9;10|]

  @"Array.compareWith
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#compareWith"
  module CompareWith =
    let compare elem1 elem2 =
      if elem1 > elem2 then 1
      elif elem1 < elem2 then -1
      else 0
    Array.compareWith compare [|1..3|] [|1;2;4|] |> should equal -1
    Array.compareWith compare [|1..3|] [|1;2;3|] |> should equal  0

  @"Array.concat
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#concat"
  [[|1;2|];[|3|];[|4;5|]] |> Array.concat |> should equal [|1..5|]

  @"Array.contains
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#contains"
  [|1..2|] |> Array.contains 2 |> should equal true
  [|1..2|] |> Array.contains 5 |> should equal false

  @"Array.countBy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#countBy"
  module CountBy =
    type Foo = { Bar: string }
    let inputs = [|{Bar = "a"}; {Bar = "b"}; {Bar = "a"}|]
    inputs |> Array.countBy (fun foo -> foo.Bar) |> should equal [|("a",2);("b",1)|]

  @"Array.create, OCaml Array.make
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#create"
  Array.create 4 "a" |> should equal [|"a"; "a"; "a"; "a"|]
  Array.create 4 0 |> should equal [|0;0;0;0|]

  @"Array.copy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#copy"
  let aa = [|12; 13; 14|] in Array.copy aa |> should equal aa

  @"Array.delete, あるk番目の要素だけ取り除く
  See also Array.removeAt."
  module Delete =
    let delete k xa = Array.append (Array.take k xa) (Array.skip (k+1) xa)
    let xa = [|0..4|]
    delete 0 xa |> should equal [|1;2;3;4|]
    delete 1 xa |> should equal [|0;2;3;4|]
    delete 2 xa |> should equal [|0;1;3;4|]
    delete 3 xa |> should equal [|0;1;2;4|]
    delete 4 xa |> should equal [|0;1;2;3|]

  @"Array.distinct 一意化, unique
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#distinct"
  Array.distinct [|1;1;2;3|] |> should equal [|1; 2; 3|]

  @"Array.distinctBy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#distinctBy
  配列の各要素を引数にして関数を実行した配列から重複をなくしたものを得る.
  要素のない空の配列でも例外は起きない"
  Array.distinctBy (fun n -> n % 2) [|0..3|] |> should equal [|0; 1|]
  Array.distinctBy<int, bool> (fun _ -> true) [||] |> should equal  [||]

  @"Array.dropWhile
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#skipWhile
  F#ではArray.skipWhileとして実装されているのでそちらを見ること."
  let rec dropWhile p (xs: array<'a>) =
    match xs with
    | [||] -> [||]
    | _ ->
      if p (Array.head xs) then dropWhile p (Array.tail xs)
      else xs
  dropWhile (fun x -> x < 3) [|0..5|] |> should equal [|3;4;5|]

  @"Array.empty
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#empty
  空の配列を生成する."
  Array.empty |> should equal [||]

  @"Array.exactlyOne
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#exactlyOne
  要素が1つだけの配列から要素を取り出す。
  配列の要素が複数もしくは空のときは System.ArgumentException。
  Array.singleton は逆。"
  Array.exactlyOne [|3|] |> should equal 3
  //Array.exactlyOne [|3; 2|] // 例外発生「System.ArgumentException: 入力シーケンスに複数の要素が含まれています。」
  //Array.exactlyOne<int> [||] // 例外発生「System.ArgumentException: 入力シーケンスが空でした。」
  Array.singleton 3 |> should equal [|3|] // (Array.exactlyOneとは逆)

  @"Array.except
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#except
  配列 2 の要素から配列 1 の要素を取り除いた配列を得る。
  配列 1 は list, seq, set でもいい。
  どちらの配列が空でも例外は起きない。"
  Array.except [|2;1|] [|1..5|] |> should equal [|3; 4; 5|]  // 第 1 引数はlist, seq, setでも良い
  Array.except<int> [||] [||] |> should equal ([||] : int [])

  @"Array.exists
  対義語はforall
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#exists"
  [|1..5|] |> Array.exists (fun elm -> elm % 4 = 0) |> should equal true
  [|1..5|] |> Array.exists (fun elm -> elm % 6 = 0) |> should equal false

  "@Array.find
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#find"
  [|1..3|] |> Array.find (fun elm -> elm % 2 = 0) |> should equal 2
  (fun () -> [|1..3|] |> Array.find (fun elm -> elm % 6 = 0) |> ignore) |> should throw typeof<System.Collections.Generic.KeyNotFoundException>
  [|1..3|] |> Array.tryFind (fun elm -> elm % 6 = 0) |> should equal None

  "@Array.findBack
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#findBack
  配列の要素を引数にして関数を順次実行し、その結果 (bool型) が最初に true になった要素を得る。
  要素が見つからないときは System.Collections.Generic.KeyNotFoundException。
  結果が option になる Array.tryFindBack や、配列の要素を先頭から順次判定していく Array.find もある。"
  Array.findBack (fun n -> n % 2 = 1) [|1..3|] |> should equal 3
  //Array.findBack (fun n -> n % 2 = 1) [|0|]  // 例外発生「System.Collections.Generic.KeyNotFoundException」
  Array.tryFindBack (fun n -> n % 2 = 1) [|1..3|] |> should equal (Some 3)
  Array.find (fun n -> n % 2 = 1) [|1..3|] |> should equal 1

  @"Array.findIndex, Haskell Vector.elemIndex
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#findIndex"
  [|1..5|] |> Array.findIndex ((=) 2) |> should equal 1

  @"Array.findIndexBack
  Array.findBackの結果がある要素の位置を得る.
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#findIndexBack
  要素が見つからないときは System.Collections.Generic.KeyNotFoundException.
  結果が option になる Array.tryFindIndexBack や, 配列の要素を先頭から判定していく Array.findIndex もある."
  Array.findIndexBack (fun n -> n % 2 = 1) [|1..3|] |> should equal  2
  //Array.findIndexBack (fun n -> n % 2 = 1) [|0|]  // 例外発生「 System.Collections.Generic.KeyNotFoundException 」
  Array.tryFindIndexBack (fun n -> n % 2 = 1) [|1..3|] |> should equal (Some 2)
  Array.findIndex (fun n -> n % 2 = 1) [|1..3|] |> should equal 0

  @"Array.forall
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#forall"
  [|true; true|] |> Array.forall id |> should equal true
  [|true; false|] |> Array.forall id |> should equal false

  @"Array.forall2
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#forall2"
  ([|1..3|], [|1..3|]) ||> Array.forall2 (=) |> should equal true
  ([|2017;1;1|], [|2019;19;8|]) ||> Array.forall2 (=) |> should equal false

  @"Array.fold, 初項を初期値に取りたいならArray.reduce
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#fold"
  module Fold =
    type Charge = | In of int | Out of int
    let inputs = [|In 1;Out 2;In 3|]
    let f acc charge =
      match charge with
      | In i -> acc + i
      | Out o -> acc - o
    (0, inputs) ||> Array.fold f |> should equal 2

  @"Array.fold2
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#fold2"
  module Fold2 =
    type CoinToss = Head | Tails
    let data1 = [|Tails; Head; Tails|]
    let data2 = [|Tails; Head; Head|]
    let f acc a b =
      match (a, b) with
        | Head, Head -> acc + 1
        | Tails, Tails -> acc + 1
        | _ -> acc - 1
    (0, data1, data2) |||> Array.fold2 f |> should equal 1

  @"Array.get
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#get"
  Array.get [|"a";"b";"c"|] 1 |> should equal "b"
  (fun () -> Array.get [|"a";"b";"c"|] 4 |> ignore) |> should throw typeof<System.IndexOutOfRangeException>

  @"Array.groupBy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#groupBy
  配列の要素を引数とする関数を順次実行し, その結果ごとに要素をグループ分けする.
  結果の配列の要素は (関数の結果, [|要素, ...|]).
  引数の配列が空でも例外は起きない."
  Array.groupBy (fun n -> n % 3) [|0..7|]
  |> should equal [|(0, [|0; 3; 6|]); (1, [|1; 4; 7|]); (2, [|2; 5|])|]
  Array.groupBy (fun n -> n % 3) [||] |> should equal [||]

  @"Array.head
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#groupBy
  Array.head
  配列の先頭の要素を得る.
  配列要素が空のときは System.ArgumentException.
  結果が option になる Array.tryHead もある.
  配列の先頭の要素だけをなくした配列を得る Array.tail や,
  配列の末尾の要素を得る Array.last や Array.tryLast もある."
  Array.head [|1..3|] |> should equal 1
  (fun () -> Array.head<int> [||] |> ignore) |> should throw typeof<System.ArgumentException>
  Array.tryHead [|1..3|] |> should equal (Some 1)
  Array.tryHead<int> [||] |> should equal None
  Array.tail [|1..3|] |> should equal  [|2;3|]
  Array.last [|1..3|] |> should equal 3
  Array.tryLast [|1..3|] |> should equal (Some 3)
  Array.tryLast<int> [||] |> should equal None

  @"Array.indexed
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#indexed
  配列の要素とその位置を (位置, 要素) という 1 つのタプルに収めた要素を持つ配列を得る.
  配列の要素が空でも例外は起きない."
  Array.indexed [|'a'..'c'|] |> should equal [|(0,'a');(1,'b');(2,'c')|]
  Array.indexed<char> [||] |> should equal [||]

  @"Array.init, OCaml Array.init
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#init
  https://msdn.microsoft.com/ja-jp/visualfsharpdocs/conceptual/array.init%5b't%5d-function-%5bfsharp%5d"
  Array.init 10 (fun i -> i * i)
  |> should equal [|0;1;4;9;16;25;36;49;64;81|]

  @"Array.isEmpty
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#isEmpty
  配列の空判定"
  Array.empty |> Array.isEmpty |> should be True
  [|1|] |> Array.isEmpty |> should be False

  @"Array.item
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#item
  検索用キーワード: get
  配列から指定した位置の要素を得る.
  指定した位置に要素が存在しなければ System.IndexOutOfRangeException.
  結果が option になる Array.tryItem もある."
  Array.item 2 [|'a'..'c'|] |> should equal 'c'
  (fun () -> Array.item<int> 1 [||] |> ignore) |> should throw typeof<System.IndexOutOfRangeException>
  Array.tryItem 2 [|'a'..'c'|] |> should equal (Some 'c')
  Array.tryItem<int> 0 [||] |> should equal None

  @"Array.iter: 単なるfor"
  [|for i in 1..3 -> (i, i * i)|] |> should equal [|(1,1);(2,4);(3,9)|]

  @"Array.iter2
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#iter2"
  Array.iter2 (fun x y -> x * y |> printf "%d ") [|1..3|] [|4..6|] // 4 8 10

  @"Array.iteri
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#iteri"
  [|1..3|] |> Array.iteri (fun i x -> i * x |> printf "%d ") // 0 2 6

  @"Array.iteri2
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#iteri2"
  ([|1..3|],[|4..6|]) ||> Array.iteri2 (fun i x y -> i * x * y |> printf "%d ") // 0 10 36

  "@Array.last
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#last
  配列の末尾の要素を得る: 先頭を除いた配列がほしいならArray.tailを使えばよい.
  配列の要素が空のときは System.ArgumentException.
  結果が option になる Array.tryLast もある.
  配列の先頭の要素を得られる Array.head や Array.tryHead もある."
  Array.last [|1..3|] |> should equal 3
  (fun () -> Array.last<int> [||] |> ignore) |> should throw typeof<System.ArgumentException>
  Array.tryLast [|1..3|] |> should equal (Some 3)
  Array.tryLast<int> [||] |> should equal None
  Array.head [|1..3|] |> should equal 1
  Array.tryHead [|1..3|] |> should equal (Some 1)

  @"Array.map
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#map"
  [|1..4|] |> Array.map (fun x -> x + 1) |> should equal [|2;3;4;5|]
  [|1..4|] |> Array.map string |> should equal [|"1";"2";"3";"4"|]
  [|1..4|] |> Array.map (fun x -> (x, x)) |> should equal [|(1,1);(2,2);(3,3);(4,4)|]

  @"Array.map2, Haskell zipWith
  Haskellは要素数が違うリストを食わせると少ない方に合わせてくれるが,
  F#ではエラーになる.
  ただしSeq.map2を使えばHaskellと同じ挙動になるので,
  必要に応じてSeq.map2を使おう.
  https://msdn.microsoft.com/ja-jp/visualfsharpdocs/conceptual/array.map2%5b't1,'t2,'u%5d-function-%5bfsharp%5d"
  Array.map2 (+) [|1..3|] [|4..6|] |> should equal [|5;7;9|]
  (fun () -> Array.map2 (+) [|1..3|] [|4..7|] |> ignore) |> should throw typeof<System.ArgumentException>

  @"Array.map3
  同じ数の要素を持つ 3 つの配列のそれぞれから順次取り出した要素を引数とする関数を実行し,
  その結果を要素とする配列を得る.
  それぞれの配列の要素の型が違っていてもいいが,
  3つの配列の要素の数がどれか 1 つでも違っていると System.ArgumentException."
  Array.map3 (fun x y z -> (x, y, z)) [|0..2|] [|'a'..'c'|] [|'$'..'&'|] |> should equal [|(0,'a','$');(1,'b','%');(2,'c','&')|]
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
      [|2..5|] |> should equal ([|1;2;6;24|], 120)
    (* 途中経過 *)
    //x =  1, y = 2, x * y =   2
    //x =  2, y = 3, x * y =   6
    //x =  6, y = 4, x * y =  24
    //x = 24, y = 5, x * y = 120

    // 比較用
    Array.mapFoldBack (fun x y -> (x, x * y)) [|2..5|] 1 // ([|2;3;4;5|], 120)

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
      [|2..5|]
      1 // ([|60;20;5;1|], 120)
  (* 途中経過 *)
  //x = 5, y =  1, x * y =   5
  //x = 4, y =  5, x * y =  20
  //x = 3, y = 20, x * y =  60
  //x = 2, y = 60, x * y = 120

  @"Array.mapi, imap in Haskell
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#mapi"
  [|1..3|] |> Array.mapi (fun i x -> (i,x)) |> should equal [|(0,1);(1,2);(2,3)|]

  @"Array.mapi2
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#mapi2"
  Array.mapi2 (fun i x y -> (x + y) * i) [|1..3|] [|4..6|] |> should equal [|0;7;18|]

  @"Array.max
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#max"
  [|-100..100|] |> Array.map (fun x -> 4-x*x)
  |> Array.max |> should equal 4

  @"Array.maxBy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#maxBy"
  [|-10.0..10.0|] |> Array.maxBy (fun x -> 1.0 - x * x) |> should equal 0.0

  @"Array.min
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#min"
  Array.min [|for x in -100..100 -> x*x-4|] |> should equal -4
  Array.min [|1;2;3|] |> should equal 1

  @"Array.minBy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#minBy"
  [|-10..10|] |> Array.minBy (fun x -> x*x-1) |> should equal 0

  @"Array.pairwise
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#pairwise
  隣り合う要素どうしをタプル収めた要素を持つ配列を得る.
  配列の要素が 1 つ以下のときの戻り値は空の配列."
  Array.pairwise [|'a'..'d'|] |> should equal  [|('a','b');('b','c');('c','d')|]
  Array.pairwise [|'a'|] |> should equal ([||] : (char * char) [])
  Array.pairwise<char> [||] |> should equal ([||] : (char * char) [])

  @"Array.partition, Haskell span
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#partition
  predicate の正否でわける"
  [|1..10|] |> Array.partition (fun elem -> elem > 3 && elem < 7)
  |> should equal ([|4;5;6|], [|1;2;3;7;8;9;10|])

  @"Array.reduce, 初項を設定したいならArray.fold
  第一引数がaccumulater.
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#reduce"
  [|1;3;4;2|] |> Array.reduce (fun a b -> a * 10 + b) |> should equal 1342
  // ((1 * 10 + 3) * 10 + 4) * 10 + 2

  @"Array.reduceBack, 初項を設定したいならArray.foldBack
  第二引数がaccumulater.
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#reduceBack"
  [|1;3;4;2|] |> Array.reduceBack (fun a b -> a * 10 + b) |> should equal 82
  // 1 + (3 + (4 + 2 * 10) * 10) * 10

  @"Array.replicate, Haskell replicate
  同じ値の要素を複数持つ配列を得る.
  数値が 0 以上の整数でなければ System.ArgumentException.
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html"
  Array.replicate 3 "F#" |> should equal [|"F#";"F#";"F#"|]
  (fun () -> Array.replicate -1 "F#" |> ignore) |> should throw typeof<System.ArgumentException>

  @"Array.scan
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#scan
  foldの「途中の値」をすべて集めた配列を返す関数というイメージを持つといい。
  Array.fold (+) 1 [|2..4|] = ((1 + 2) + 3) + 4
  Array.scan (+) 1 [|2..4|] = [|1;1 + 2;(1 + 2) + 3;((1 + 2) + 3) + 4|]"
  Array.scan (+) 1 [|2..4|] |> should equal [|1;3;6;10|]

  @"Array.set, もとの配列を書き換える破壊的な関数
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#set"
  module Set =
    let inputs = [|"a";"b";"c"|]
    Array.set inputs 1 "B"
    inputs |> should equal [|"a";"B";"c"|]

    @"初期化した配列からfoldで配列を更新する"
    (Array.create 10 -1, [|1..5|]) ||> Array.fold (fun a i -> Array.set a (i-1) (i*i); a) |> should equal [|1;4;9;16;25;-1;-1;-1;-1;-1|]

  @"Array.singleton
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#singleton
  要素を 1 つだけ持つ配列を得る.
  逆に要素が 1 つだけの配列から要素を取り出す Array.exactlyOne もある."
  Array.singleton 3 |> should equal [|3|]
  Array.exactlyOne [|3|] |> should equal 3

  @"Array.skip, drop in Haskell
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#skip
  先頭から指定した位置までの要素をなくした配列を得る.
  数値が負の数でも例外は発生しません.
  逆に先頭から指定した位置までの要素を持つ配列を得られる Array.take もある."
  Array.skip 2 [|'a'..'e'|] |> should equal [|'c';'d';'e'|]
  Array.skip -1 [|'a'..'e'|] |> should equal [|'a';'b';'c';'d';'e'|]
  Array.take 3 [|'a'..'e'|] |> should equal [|'a';'b';'c'|]

  @"Array.skipWhile, dropWhile in Haskell
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#skipwhile
  関数の戻り値が false となる位置までの要素をなくした配列を得る.
  逆にその位置までの要素を得られる Array.takeWhile もある."
  Array.skipWhile (fun n -> n < 4) [|3;2;5;4;1|] |> should equal [|5;4;1|]
  Array.takeWhile (fun n -> n < 4) [|3;2;5;4;1|] |> should equal [|3;2|]

  @"slice: お手製
  Array.sub を f |> g でつなげられるように引数の順番を変更し、
  引数の意味も変えたバージョン。
  Array.sub とは少し挙動が違うので注意。

  Array.sub は Array.sub array start count
  Array.sub [|0;2;4;6;8;10|] 2 3 // [|4;6;8|]

  ここでの slice は slice start end array：end は end 番目までを含む"
  let slice s e a = Array.sub a s (e - s + 1)
  slice 2 3 [|0;2;4;6;8;10|] |> should equal [|4;6|]
  @"参考: 配列が定義できているときの標準のスライス"
  [|'a'..'e'|].[2] |> should equal 'c'
  [|'a'..'e'|].[1..3] |> should equal [|'b';'c';'d'|]
  [|'a'..'e'|].[2..] |> should equal [|'c';'d';'e'|]
  [|'a'..'e'|].[..3] |> should equal [|'a';'b';'c';'d'|]

  @"Array.sortBy, stable sort, 安定ソート
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#sortBy
  関数指定でソートする"
  Array.sortBy abs [|1;4;8;-2;5|] |> should equal [|1;-2;4;5;8|]

  @"Array.sortByDescending
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#sortByDescending
  配列の要素を引数とする関数を順次実行した結果をもとに要素を降順で並べ替える.
  関数の結果は比較可能な値でなければなりません.
  他に配列の要素自体を並べ替える Array.sortDescending や,
  配列の並べ替えが昇順になる Array.sortBy もある."
  Array.sortByDescending
    (fun (x, _) -> x)
    [|(2,"dos");(3,"tres");(1,"uno")|]
  |> should equal [|(3,"tres");(2,"dos");(1,"uno")|]
  Array.sortDescending [|1..5|] |> should equal [|5..(-1)..1|]
  Array.sortBy (fun (x, _) -> x) [|(2,"dos");(3,"tres");(1,"uno")|]
  |> should equal [|(1, "uno");(2, "dos");(3, "tres")|]

  @"Array.sortDescending
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#sortDescending
  配列の要素を降順で並べ替える.
  要素は比較可能な値でなければならない.
  他に昇順で並べ替える Array.sort や要素を引数にして関数を順次実行した値で並べ替える Array.sortByDescending もある."
  Array.sortDescending [|for i in 1..5 -> -i|] |> should equal [|-1;-2;-3;-4;-5|]
  Array.sort [|for i in 1..5 -> -i|] |> should equal [|-5;-4;-3;-2;-1|]
  Array.sortByDescending (fun (x, _) -> x) [|(2,"dos");(3,"tres");(1,"uno")|]
  |> should equal [|(3,"tres");(2,"dos");(1,"uno")|]

  @"Array.splitAt
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#splitAt
  指定した要素の位置ので配列を 2 つに分けてそれぞれを同じタプルに収める.
  指定された位置の要素はタプルの右側の配列に含まれる.
  位置は 0 か正の整数に限られ, それ以外を指定すると System.ArgumentException.
  指定した位置が配列の長さ (要素の数) より大きいと System.InvalidOperationException."
  Array.splitAt 3 [|'a'..'e'|] |> should equal ([|'a';'b';'c'|], [|'d';'e'|])
  Array.splitAt 0 [|'a'..'e'|] |> should equal ([||], [|'a';'b';'c';'d';'e'|])
  Array.splitAt 5 [|'a'..'e'|] |> should equal ([|'a';'b';'c';'d';'e'|], [||])
  (fun () -> Array.splitAt -1 [|'a'..'e'|] |> ignore) |> should throw typeof<System.ArgumentException>
  (fun () -> Array.splitAt  6 [|'a'..'e'|] |> ignore) |> should throw typeof<System.InvalidOperationException>

  @"Array.splitInto
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#splitInto
  配列の要素を指定した数に等分する.
  結果は'T [] [] になる.
  分割数が 0 のときは System.ArgumentException.
  分割数が配列の要素の数より大きくても例外は起きない."
  Array.splitInto 3 [|'a'..'e'|] |> should equal ([|[|'a';'b'|];[|'c';'d'|];[|'e'|]|] : char [] [])
  (fun () -> Array.splitInto 0 [|'a'..'e'|] |> ignore) |> should throw typeof<System.ArgumentException>
  Array.splitInto 3 [|'a'..'b'|] |> should equal [|[|'a'|];[|'b'|]|]

  @"Array.sub
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#sub
  スライスの一種.
  slice参照"
  Array.sub [|0..5|] 2 3 |> should equal [|2..4|]

  @"Array.sum
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#sum"
  [|1..3|] |> Array.sum |> should equal 6

  @"Array.sumBy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#sumBy"
  [|"aa";"bbb";"cc"|] |> Array.sumBy (fun s -> s.Length) |> should equal 7

  @"Array.tail
  先頭の要素をなくした配列を得る.
  配列の要素がないときは System.ArgumentException.
  逆に配列の先頭の要素だけを得られる Array.head もある."
  Array.tail [|1..3|] |> should equal [|2;3|]
  // Array.tail<int> [||]  // 例外発生「 System.ArgumentException: 入力シーケンスには十分な数の要素がありません」.
  Array.head [|1..3|] |> should equal 1

  @"Array.take
  先頭から指定された数だけの要素を持つ配列を得る.
  要素数が負の数のときは System.ArgumentException.
  要素数が配列の長さより大きいときは System.InvalidOperationException.
  他に関数で判定した位置の要素を持つ配列を得られる Array.takeWhile や,
  逆に先頭から指定された数の要素をなくした配列を得られる Array.skip もある."
  Array.take 3 [|'a'..'e'|] |> should equal [|'a';'b';'c'|]
  Array.take 0 [|'a'..'e'|] |> should equal ([||] : char [])
  (fun () -> Array.take -1 [|'a'..'e'|] |> ignore) |> should throw typeof<System.ArgumentException>
  (fun () -> Array.take  6 [|'a'..'e'|] |> ignore) |> should throw typeof<System.InvalidOperationException>
  (fun () -> Array.take 6 [|3;2;5;4;1|] |> ignore) |> should throw typeof<System.InvalidOperationException>
  Array.takeWhile (fun n -> n < 4) [|3;2;5;4;1|] |> should equal [|3;2|]
  Array.skip 3 [|'a'..'e'|] |> should equal [|'d';'e'|]
  Array.take 3 [|3;2;5;4;1|] |> should equal [|3;2;5|]
  // 要素数が配列の長さより大きいとき
  Array.truncate 6 [|3;2;5;4;1|] |> should equal [|3;2;5;4;1|]
  // 要素数が負の数のとき
  Array.truncate -1 [|3;2;5;4;1|] |> should equal [||]

  @"Array.takeWhile
  要素を引数とする関数を先頭から順次実行し,
  結果がtrueとなる要素を持つ配列を得る.
  逆に結果がfalseとなる位置から末尾までの要素を持つ配列を得られるArray.skipWhileや,
  先頭から指定した位置までの要素を持つ配列を得られるArray.takeもある."
  Array.takeWhile (fun n -> n < 4) [|3;2;5;4;1|] |> should equal [|3;2|]
  Array.skipWhile (fun n -> n < 4) [|3;2;5;4;1|] |> should equal [|5;4;1|]
  Array.take 3 [|3;2;5;4;1|] |> should equal [|3;2;5|]

  @"配列の配列の転置: array2Dバージョンは別途参照"
  module Transpose =
    let transpose xa =
      let rnum = Array.length xa
      let cnum = Array.length xa.[0]
      let rowstr i = [|0..(rnum-1)|] |> Array.map (fun j -> xa.[j].[i])
      [|0..(cnum-1)|] |> Array.map (fun i -> rowstr i)
    [|[|1;2|];[|3;4|]|] |> transpose |> should equal [|[|1;3|];[|2;4|]|]

  @"Array.truncate
  先頭から指定した数だけの要素を持つ配列を得る.
  Array.take と違うのは要素数に関連する例外が発生しないこと."
  Array.truncate 3 [|3;2;5;4;1|] |> should equal [|3;2;5|]

  @"Array.tryFind
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#tryFind"
  Array.tryFind (fun x -> x%2=0) [|1;2;3|] |> should equal (Some 2)
  Array.tryFind (fun x -> x%2=0) [|1;5;3|] |> should equal  None

  @"Array.tryFindBack
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#tryFindBack
  末尾の要素から順次関数を実行し, 結果が true となる要素を見つける.
  見つかったら 「Some 結果」, 見つからなかったら None を返す.
  結果が option ではない Array.findBack もあるほか,
  先頭の要素から順に関数を実行する Array.tryFind や Array.find もある."
  @"結果が見つかったとき"
  Array.tryFindBack (fun n -> n % 2 = 1) [|1..3|] |> should equal (Some 3)
  Array.findBack (fun n -> n % 2 = 1) [|1..3|] |> should equal 3
  @"結果が見つからないとき"
  Array.tryFindBack (fun n -> n > 3) [|1..3|] |> should equal None
  (fun () -> Array.findBack (fun n -> n > 3) [|1;2;3|] |> ignore) |> should throw typeof<System.Collections.Generic.KeyNotFoundException>
  Array.tryFind (fun n -> n % 2 = 1) [|1..3|] |> should equal (Some 1)
  Array.find (fun n -> n % 2 = 1) [|1..3|] |> should equal 1

  @"Array.tryFindIndexBack
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#tryFindIndexBack
  Array.tryFindBack の結果となる要素の位置を見つける.
  見つかったら Some 位置, 見つからなかったら None.
  要素の位置を先頭から見つける Array.tryFindIndex や,
  結果を option ではなく実際の値で得られる Array.findIndexBack もある."
  Array.tryFindIndexBack (fun n -> n % 2 = 1) [|1..3|] |> should equal (Some 2)
  Array.tryFindIndex (fun n -> n % 2 = 1) [|1..3|] |> should equal (Some 0)
  Array.findIndexBack (fun n -> n % 2 = 1) [|1..3|] |> should equal 2

  @"Array.tryHead
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#tryHead
  配列の先頭の要素を取り出します.
  要素が存在すれば Some 要素, 要素が存在しなければ None となります.
  結果を option ではなく実際の値で得られる Array.head や,
  末尾の要素を得る Array.tryLast もある."
  @"先頭の要素が存在するとき"
  Array.tryHead [|3;1;2|] |> should equal (Some 3)
  Array.head [|3;1;2|] |> should equal 3
  @"先頭の要素が存在しないとき"
  Array.tryHead<int> [||] |> should equal None
  (fun () -> Array.head<int> [||] |> ignore) |> should throw typeof<System.ArgumentException>
  Array.tryLast [|3;1;2|] |> should equal (Some 2)

  @"Array.tryItem
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#tryItem
  指定した位置の要素を取り出します.
  要素が存在すれば Some 要素, 存在しなければ None.
  結果が option ではなく要素で得られる Array.item もある."
  @"指定した位置に要素が存在するとき"
  Array.tryItem 2 [|'c';'a';'b'|] |> should equal (Some 'b')
  Array.item 2 [|'c';'a';'b'|] |> should equal 'b'
  @"指定した位置に要素が存在しないとき"
  Array.tryItem 4 [|'c';'a';'b'|] |> should equal None
  (fun () -> Array.item 4 [|'c';'a';'b'|] |> ignore) |> should throw typeof<System.IndexOutOfRangeException>

  @"Array.tryLast
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#tryLast
  配列の末尾の要素が得られたら 「Some 要素」, 得られなければ None.
  結果が option ではなく要素自身となる Array.last もあるが,
  こちらは配列が空だと例外が起きる.
  配列の先頭の要素を得られる Array.tryHead もある."
  Array.tryLast [|3;1;2|] |> should equal (Some 2)
  Array.tryLast<int> [||] |> should equal None
  Array.last [|3;1;2|] |> should equal 2

  @"Array.unfold
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#unfold
  初期値を元に関数を累積的に実行して列をつくる.
  関数の引数は初期値および前回の結果とし,
  戻り値は次回も関数を実行するときは Some (結果となる配列の要素, 次回実行時の引数),
  関数の実行を終了するときは None とする."
  Array.unfold (fun n -> if n > 5 then None else Some(n, n + 1)) 1 |> should equal [|1;2;3;4;5|]
  module Fib =
    @"フィボナッチ数列の配列 (Array.unfold)"
    let fibs n =
      Array.unfold (fun (x, y, z) ->
        if z > 0 then
          Some(x, (y, x + y, z - 1))
        else
          None)
      <| (1, 1, n)
    fibs 10 |> should equal [|1;1;2;3;5;8;13;21;34;55|]

    @"フィボナッチ数 (Array.fold)"
    let fib n =
      fst
      <| Array.fold (fun (x, y) _ -> (x + y, x)) (0, 1) [|1..n|] // fib 10 = 55

  @"Array.where
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#where
  Array.filter と同じく配列の各要素で実行した関数の結果が true となるものをすべて取り出す.
  Array.find では最初に true となる要素だけとなるのが違う."
  Array.where (fun n -> n % 2 = 0) [|1..5|] |> should equal [|2;4|]
  Array.filter (fun n -> n % 2 = 0) [|1..5|] |> should equal [|2;4|]
  Array.find (fun n -> n % 2 = 0) [|1..5|] |> should equal 2

  @"Array.windowed
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#windowed
  指定した要素数だけ位置が連続する配列を要素とするジャグ配列を得る.
  要素数が正の整数でないときは System.ArgumentException.
  要素数が配列の要素の数を上回ると結果の配列は空.
  要素数を 2 に指定すると結果が Array.pairwise と似ているが,
  要素がタプルか配列かが違う.
  Array.chunkBySize との違いは, ただ配列の要素を区切るのではなく,
  先頭の要素から順次要素数だけ連続する要素を 1 つの配列にまとめていること."
  Array.windowed 3 [|'a'..'e'|] |> should equal [|[|'a';'b';'c'|];[|'b';'c';'d'|];[|'c';'d';'e'|]|]
  (fun () -> Array.windowed 0 [|'a'..'e'|] |> ignore) |> should throw typeof<System.ArgumentException>
  Array.windowed 6 [|'a'..'e'|] |> should equal ([||] : char [] [])
  @"windowed と pairwise との違い"
  Array.windowed 2 [|'a'..'e'|] |> should equal [|[|'a';'b'|];[|'b';'c'|];[|'c';'d'|];[|'d';'e'|]|]
  Array.pairwise [|'a'..'e'|] |> should equal [|('a', 'b');('b', 'c');('c', 'd');('d', 'e')|]
  @"windowed と chunBySize との違い"
  Array.windowed 3 [|'a'..'e'|] |> should equal [|[|'a';'b';'c'|];[|'b';'c';'d'|];[|'c';'d';'e'|]|]
  Array.chunkBySize 3 [|'a'..'e'|] |> should equal [|[|'a';'b';'c'|];[|'d';'e'|]|]

  @"
  Array.zeroCreate
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#zeroCreate"
  (Array.zeroCreate 4 : int[]) |> should equal [|0;0;0;0|]
  (Array.zeroCreate 4 : int64[]) |> should equal [|0L;0L;0L;0L|]

module Array2D =
  @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-array2dmodule.html"
  @"Array3D, Array4Dもある
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-array3dmodule.html
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-array4dmodule.html"

  @"array2D, constructor"
  array2D [[1..2];[2..3]]

  @"Array2D.create
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-array2dmodule.html#create"
  Array2D.create 2 3 1 |> should equal (array2D [[1;1;1];[1;1;1]])

  @"行または列だけ取る, slice.
  Array3D, Array4Dでも同じ.
  https://stackoverflow.com/questions/2366899/f-array2d-slices"
  module TakeColOrRow =
    let a = array2D [[1..10];[11..20]]
    a.[0..,0] |> should equal [|1;11|]
    a.[0..,1] |> should equal [|2;12|]
    a.[*,0] |> should equal [|1;11|]
    a.[*,1] |> should equal [|2;12|]

    a.[0,0..] |> should equal [|1..10|]
    a.[1,0..] |> should equal [|11..20|]
    a.[0,*] |> should equal [|1..10|]
    a.[1,*] |> should equal [|11..20|]

  @"Array2D.length: Array2D.length1, Array2D.length2
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-array2dmodule.html#length1"
  module Array2DLength =
    let a = array2D [[1..10];[11..20]]
    Array2D.length1 a |> should equal 2
    Array2D.length2 a |> should equal 10

  @"Array2D.map
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-array2dmodule.html#map"
  array2D [[3;4];[13;14]] |> Array2D.map (fun v -> 2 * v) |> should equal (array2D [[6;8;];[26;28]])

  @"Array2D.mapi
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-array2dmodule.html#mapi"
  array2D [[3;4];[13;14]] |> Array2D.mapi (fun i j v -> i + j + v) |> should equal (array2D [[3;5];[14;16]])

  @"Array2D.set
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-array2dmodule.html#set"
  module Array2DSet =
    let array:int[,] = Array2D.zeroCreate 2 2
    Array2D.set array 0 1 2
    array |> should equal (array2D [[0; 2];[0; 0]])

  @"transpose, 転置"
  module Transpose =
    let transpose xa2 =
      let rnum = Array2D.length1 xa2
      let cnum = Array2D.length2 xa2
      let newrow i = [|0..(rnum-1)|] |> Array.map (fun j -> xa2.[j,i])
      [|0..(cnum-1)|] |> Array.map (fun i -> newrow i) |> array2D
    let a = array2D [[1;2];[3;4]]
    transpose a |> should equal (array2D [[1;3];[2;4]])

module Bit =
  // https://midoliy.com/content/fsharp/text/operator/2_bit.html
  0xFF |> should equal 255
  ~~~0xFF |> should equal -256
  0x80 |> should equal 128
  0xFF ||| 0x80 |> should equal 255
  0xFF &&& 0x80 |> should equal 128
  0xFF ^^^ 0x80 |> should equal 127
  1 <<< 1 |> should equal 2
  1 <<< 2 |> should equal 4
  1 <<< 3 |> should equal 8
  10 >>> 1 |> should equal 5
  10 >>> 2 |> should equal 2
  10 >>> 3 |> should equal 1

module Bool =
  @"https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/symbol-and-operator-reference/boolean-operators"
  @"See also `module Operator`"

  @"boolean not"
  not true |> should equal false

module Char =
  @"https://docs.microsoft.com/ja-jp/dotnet/api/system.char?view=net-6.0"

  @"アルファベットかどうか判定
  https://stackoverflow.com/questions/25146714/how-to-check-if-string-only-contains-alphabets-in-f"
  let isAlpha c = (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')
  [|'a'..'z'|] |> Array.map isAlpha |> Array.forall id |> should be True
  [|'A'..'Z'|] |> Array.map isAlpha |> Array.forall id |> should be True
  [|'!';'"';'#';'$';'%';'&';'\'';'(';')';'-';'=';'^';'~';'|';'\\';'`';'@';'[';']';';';'+';':';'*';'{';'}';',';'.';'<';'>';'/';'?';'_'|] |> Array.map isAlpha |> Array.forall (fun x -> not x) |> should be True

  @"Ascii文字かどうか判定
  https://docs.microsoft.com/ja-jp/dotnet/api/system.char.isletter?view=net-6.0"
  System.Char.IsAscii 'a' |> should be True
  System.Char.IsAscii 'B' |> should be True
  System.Char.IsAscii '#' |> should be True

  @"大文字・小文字判定, System.Char.IsLower, System.Char.IsUpper
  https://docs.microsoft.com/ja-jp/dotnet/api/system.char.islower?view=net-6.0"
  System.Char.IsLower 'c' |> should equal true
  System.Char.IsUpper 'c' |> should equal false
  System.Char.IsLower 'C' |> should equal false
  System.Char.IsUpper 'C' |> should equal true

  @"文字を文字列ではなく数値にする"
  let inline charToInt c = int c - int '0'
  charToInt '3' |> should equal 3

  @"大文字・小文字変換, System.Char.ToLower, System.Char.ToUpper
  https://docs.microsoft.com/ja-jp/dotnet/api/system.char.islower?view=net-6.0"
  System.Char.ToLower 'c' |> should equal 'c'
  System.Char.ToUpper 'c' |> should equal 'C'
  System.Char.ToLower 'C' |> should equal 'c'
  System.Char.ToUpper 'C' |> should equal 'C'

module ComputationExpression =
  @"https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/computation-expressions
  expr { let! ... }
  expr { do! ... }
  expr { yield ... }
  expr { yield! ... }
  expr { return ... }
  expr { return! ... }
  expr { match! ... }"

  @"yield
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/computation-expressions#yield"
  seq { for i in 1..3 -> i * i } |> should equal [1;4;9]

module Dictionary =
  @"FSharpPlus, https://fsprojects.github.io/FSharpPlus/reference/fsharpplus-dict.html
  Dict literal, read only, FSharpPlus
  C#のDictionaryとHashtable比較: 後者はキー・値ともにObject型で変換処理があって低パフォーマンス"
  dict [(1,"a");(2,"b");(3,"c")]

module Function =
  module DefineOperator =
    @"Define an operator
    Bird, Gibbons, P.130"
    let (<<=): list<'a> -> list<'a> -> bool = fun xs ys ->
      List.forall id [for x in xs do for y in ys do x <= y]
    [1..3] <<= [4..6] |> should equal true
    [1..3] <<= [2..4] |> should equal false

    let add x y = x+y
    1 `add` 2

  @"引数をasで分解する"
  let argDecompWithAs ((a1,b1) as t1) ((a2,b2) as t2) =
    printfn "%A" (t1,t2)
    (a1+b1, a2+b2)
  argDecompWithAs (1,2) (3,4)

  @"forward-pipe operator"
  let getTotal2 items =
    (0, items)
    ||> List.fold (fun acc (q, p) -> acc + q * p)
  [(1,2);(3,4)] |> getTotal2

  @"function composition"
  let twice x = 2 * x
  let cubic x = pown x 3
  let twiceCubic = cubic >> twice
  twiceCubic 3 |> should equal 54

  @"CPS変換: See CpsTr.fsx"

  @"memoized recursion, メモ化再帰"
  module MemoRec =
    let memorec f =
      let memo = System.Collections.Generic.Dictionary<_, _>()
      let rec frec j =
        match memo.TryGetValue j with
        | exist, value when exist -> value
        | _ -> let value = f frec j in memo.Add(j, value); value
      frec
    let fact frec i =
      if i = 1L then 1L
      else i * frec (i-1L)
    (memorec fact) 20L

  @"相互再帰関数, mutual recursion"
  let rec even x = if x = 0 then true else odd (x-1)
  and odd x = if x = 0 then false else even (x-1)
  let isEven x = if (x < 0) then even (-x) else even x
  isEven 9 |> should equal false
  isEven 10 |> should equal true

  module MutualRecursion1 =
    // https://stackoverflow.com/a/3621143
    // `and`を使わなくても次のように書ける
    let rec even odd x = if x = 0 then true else odd (x-1)
    let rec odd x = if x = 0 then false else even odd (x-1)
    let isEven x = if (x < 0) then even odd (-x) else even odd x
    isEven 9 |> should equal false
    isEven 10 |> should equal true

  @"パターンマッチ・引数の場合分けによる定義,
  Haskellでいう次のような定義
  f [] = []
  f x:xs = undefined
  "
  let rec factSlow = function
  | 1 -> 1
  | n -> n * factSlow (n-1)

  let rec map: ('a -> 'b) -> 'a list -> 'b list = fun f ys ->
    match ys with
    | [] -> []
    | x::xs -> f x :: map f xs
  map (fun x -> x+1) [1;2;3] |> should equal [2;3;4]

module IO =
  @"何行あるかわからない標準入力の全取得, readAll
  https://codereview.stackexchange.com/questions/96473/reading-input-from-console-in-f-as-a-sequence-of-lines"
  let readAll () = Console.ReadLine() |> Seq.initInfinite |> Seq.takeWhile ((<>) null)

  @"https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readlines?view=net-6.0
  https://www.dotnetperls.com/file-fs?msclkid=d0f677a5af2711ec9c9679c85f806250"
  module File =
    @"https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealllines?view=net-6.0"
    let xa = seq [1..10] |> Seq.map string
    @"ファイル書き込み"
    System.IO.File.WriteAllLines ("1.tmp.txt", xa)
    System.IO.File.WriteAllText("1.tmp.txt", "test")
    System.IO.File.WriteAllText("1.tmp.txt", "あいうえお")
    @"ファイル読み込み
    https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readalltext?view=net-6.0"
    System.IO.File.ReadAllText("1.tmp.txt") |> fun s -> s.Split("\r\n")
    @"ファイル読み込み
    https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readlines?view=net-6.0"
    System.IO.File.ReadLines("1.tmp.txt") |> should equal (Array.map string [|1..10|])

  @"外部コマンド実行
  https://natsutan.hatenablog.com/entry/20111014/1318589673
  https://stackoverflow.com/questions/11960297/external-program-launch-and-output-redirect-in-fsi-and-f"
  System.Diagnostics.ProcessStartInfo(
    FileName="dotnet",
    Arguments="fsi --help",
    RedirectStandardOutput = true,
    StandardOutputEncoding = System.Text.Encoding.UTF8,
    UseShellExecute = false)
  |> System.Diagnostics.Process.Start
  |> fun p -> p.StandardOutput.ReadToEnd()
  |> fun s -> s.Split("\n")

module List =
  @"docs for List
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html
  https://github.com/dotnet/fsharp/blob/main/src/fsharp/FSharp.Core/list.fs
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/lists"

  @"参考：色々な言語でのリスト処理関数の対応
  https://qiita.com/dico_leque/items/4662a0223cb6bfb19bd3"

  @"List literal
  https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/lists"
  [1..3] |> should equal [1;2;3]
  [3..-1..0] |> should equal [3;2;1;0]

  @"リストへの型づけ, 特に空リスト"
  List.empty<int>
  List.empty<int*char>

  @"リスト内包表記: 特にifで条件をつける"
  [for n in [1..10] do if n%2=0 then yield n] |> should equal [2..2..10]
  @"多重内包表記: seqを使おう
  https://stackoverflow.com/questions/1888451/list-comprehension-in-f"
  seq { for x in 1..2 do for y in 1..2 -> x,y } |> should equal [(1,1);(1,2);(2,1);(2,2)]
  @"多重内包表記でのフィルタリング
  https://midoliy.com/content/fsharp/text/various/4-1_seq.html"
  seq {
    for row in 0..9 do
    for col in 0..9 do
    if row+col <= 2 then yield (row, col, row*col) }
    |> Array.ofSeq |> should equal [|(0,0,0);(0,1,0);(0,2,0);(1,0,0);(1,1,1);(2,0,0)|]

  @"List.allPairs
  https://fsharp.git  ihub.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#allPairs"
  List.allPairs [1;2] [3;4] |> should equal [(1,3);(1,4);(2,3);(2,4)]
  module AllPairs =
    let people = ["Kirk";"Spock";"McCoy"]
    let numbers = [1;2]
    people |> List.allPairs numbers
    |> should equal [(1,"Kirk");(1,"Spock");(1,"McCoy");(2,"Kirk");(2,"Spock");(2,"McCoy")]

  @"List.append
  リストとリストの連結: `@`を使っても書ける.
  要素とリストの連結は`::`"
  List.append [0..3] [4..7] |> should equal [0..7]
  List.append [0..3] [4..7] = [0..3]@[4..7] |> should be True

  @"List.collect, Haskell concatMap
  `let concatMap f xs = List.map f xs |> List.concat`"
  [1..4] |> List.collect (fun x -> [1..x])
  |> should equal [1;1;2;1;2;3;1;2;3;4]
  [1..4] |> List.map (fun x -> [1..x])
  |> should equal [[1];[1;2];[1;2;3];[1;2;3;4]]
  List.collect (List.take 2) [[1;2;3];[4;5;6]]
  |> should equal [1;2;4;5]

  @"List.concat, concat, join"
  let list1 = [1..5]
  let list2 = [3..7]
  list1 @ list2 |> should equal [1;2;3;4;5;3;4;5;6;7]
  List.concat [list1;list2] |> should equal [1;2;3;4;5;3;4;5;6;7]

  @"consing"
  1 :: [2;3;4] |> should equal [1;2;3;4]
  @"list comprehension, `for`"
  [for i in 1..3 do i] |> should equal [1;2;3]
  @"filtered list comprehension, `for`"
  [for i in 1..10 do if i <= 5 then yield i] |> should equal [1..5]

  @"List.contains
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#contains"
  List.contains 3 [1..9] |> should equal true
  List.contains 0 [1..9] |> should equal false

  @"delete: Haskell delete, Python remove()
  https://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:delete"
  let rec delete x xs =
    match xs with
    | [] -> []
    | y :: ys -> if x = y then ys else y :: delete x ys
  delete 1 [1..3] |> should equal [2;3]
  delete 1 [1;1;2;3] |> should equal [1..3]
  delete 4 [1..3] |> should equal [1;2;3]
  delete 'a' ("banana" |> Seq.toList) |> System.String.Concat |> should equal "bnana"

  """delete と違い全ての要素を削除する
  deleteAll 1 [ 1;2;3;1;1;2;3 ] |> printfn "%A" // [2;3;2;3]
  deleteAll 4 [ 1;2;3;1;1;2;3 ] |> printfn "%A" // [1;2;3;1;1;2;3]"""
  let deleteAll x = List.filter ((<>) x)
  deleteAll 1 [ 1;2;3;1;1;2;3 ] |> should equal [2;3;2;3]
  deleteAll 4 [ 1;2;3;1;1;2;3 ] |> should equal [1;2;3;1;1;2;3]

  @"filter"
  [1..9] |> List.filter (fun x -> x % 2 = 0) |> should equal [2;4;6;8]

  @"fold
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#fold
  初期値を入力のリストの先頭から取りたい場合はreduceを使う."
  List.fold min 0 [1..9] |> should equal 0
  List.fold min 2 [1..9] |> should equal 1
  let getTotal1 items =
    items
    |> List.fold (fun acc (q, p) -> acc + q * p) 0
  [(1,2);(3,4)] |> getTotal1 |> should equal 14

  @"List.foldBack, foldr
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#foldBack
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
  [(1,2);(3,4)] |> getTotal2

  @"List.groupBy
  注意: F#版groupByとHaskell版groupByは挙動が違う."
  module GroupBy =
    @"F#のList.groupBy: !!注意!! Haskellとは違う
    HaskellのgroupByは下記参照.
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#groupBy"
    [1;2;3;4;5;7;6;5;4;3] |> List.groupBy (fun x -> x)
    |> should equal [1,[1];2,[2];3,[3;3];4,[4;4];5,[5;5];7,[7];6,[6]]

    @"Haskell List.span -> cf. List.partition
    cf. Haskell span https://hackage.haskell.org/package/base-4.16.1.0/docs/src/GHC-List.html#span"
    let rec span: ('a -> bool) -> 'a list -> (('a list) * ('a list)) = fun p -> function
      | [] -> ([],[])
      | x::xs as lst -> if p x then let (ys, zs) = span p xs in  (x :: ys, zs) else ([], lst)

    @"Haskell List.group
    https://hackage.haskell.org/package/base-4.16.1.0/docs/src/Data-OldList.html#group"
    let rec groupBy (p: 'a -> 'a -> bool) lst: list<list<'a>> =
      match lst with
      | [] -> []
      | x :: xs ->
        let (ys, zs) = span (p x) xs
        (x :: ys) :: groupBy p zs
    groupBy (=) ("Mississippi" |> List.ofSeq)
    |> should equal [['M'];['i'];['s';'s'];['i'];['s';'s'];['i'];['p';'p'];['i']]

    @"group: Haskell の group と同じ
    http://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:group"
    let group xs = groupBy (=) xs
    group ("Mississippi" |> List.ofSeq)
    |> should equal [['M'];['i'];['s';'s'];['i'];['s';'s'];['i'];['p';'p'];['i']]

  @"List.head
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#head"
  List.head [1;2;3] |> should equal 1

  @"List.indexed
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#indexed"
  ["a";"b";"c"] |> List.indexed |> should equal [(0, "a");(1, "b");(2, "c")]

  @"List.init
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#init"
  List.init 4 (fun v -> v + 5) |> should equal [5;6;7;8]

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
    [ 0..(List.length xs) ]
    |> List.map (fun i -> List.take i xs)
  inits [1..3] |> should equal [[];[1];[1;2];[1;2;3]]

  @"Haskell isSomethingOf
  https://hackage.haskell.org/package/base-4.16.1.0/docs/Data-List.html#v:isInfixOf
  https://hackage.haskell.org/package/base-4.16.1.0/docs/Data-List.html#v:isPrefixOf
  https://hackage.haskell.org/package/base-4.16.1.0/docs/Data-List.html#v:isSubsequenceOf
  https://hackage.haskell.org/package/base-4.16.1.0/docs/Data-List.html#v:isSuffixOf"
  module IsSomethingOf =
    let rec tails = function
      | [] -> [[]]
      | x::xs -> (x::xs)::(tails xs)
    let rec isPrefixOf xs ys = match (xs,ys) with
      | ([],_) -> true
      | (_,[]) -> false
      | otherwise ->
        let (w::ws,z::zs) = (xs,ys)
        w = z && isPrefixOf ws zs
    isPrefixOf (List.ofSeq "Hello") (List.ofSeq "Hello World!") |> should equal true
    isPrefixOf (List.ofSeq "Hello") (List.ofSeq "Wello Horld!") |> should equal false

    let isInfixOf needle haystack = List.exists (isPrefixOf needle) (tails haystack)
    isInfixOf (List.ofSeq "Haskell") (List.ofSeq "I really like Haskell.") |> should equal true
    isInfixOf (List.ofSeq "Ial") (List.ofSeq "I really like Haskell.") |> should equal false

    let rec isSubsequenceOf xs ys = match (xs,ys) with
      | ([],_) -> true
      | (_,[]) -> false
      | otherwise ->
        if List.head xs = List.head ys
        then isSubsequenceOf (List.tail xs) (List.tail ys)
        else isSubsequenceOf xs (List.tail ys)
    isSubsequenceOf ('a'::['d'..'z']) ['a'..'z'] |> should equal true
    isSubsequenceOf [1..10] (10::[9..0]) |> should equal false

  @"List.Item"
  module Item =
    let l = [0..9]
    l.Item(0) |> should equal 0
    List.item 0 l |> should equal (l.Item(0))

  @"List.last
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#last"
  [ "pear";"banana" ] |> List.last |> should equal "banana"

  @"map2
  zipWith: FSharpPlus では ZipList?"
  List.map2 (+) [1;2;3] [2;4;6] |> should equal [3;6;9]
  let zipWith f xs ys =
    List.zip xs ys |> List.map (fun (x, y) -> f x y)
  zipWith (+) [1;2;3] [2;4;6] |> should equal [3;6;9]

  @"List.minBy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#minBy"
  ["aaa";"b";"cccc"] |> List.minBy (fun s -> s.Length) |> should equal "b"
  (fun () -> [] |> List.minBy (fun (s: string) -> s.Length) |> ignore) |> should throw typeof<System.ArgumentException>

  @"List.reduce, 初項を初期値にするList.fold
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#reduce"
  List.reduce min [1..9] |> should equal 1

  @"List.removeAt
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#removeAt"
  List.removeAt 1 [0..2] |> should equal [0;2]

  @"List.removeManyAt
  List.removeManyAt index count source
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#removeManyAt"
  List.removeManyAt 1 2 [0..3] |> should equal [0;3]
  List.removeManyAt 1 3 [0..4] |> should equal [0;4]

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
  List.scanBack (&&) [1>2;3>2;5=5] true |> should equal [false;true;true;true]
  List.scanBack max [3;6;12;4;55;11] 18 |> should equal [55;55;55;55;55;18;18]
  List.scanBack max [3;6;12;4;55;11] 111 |> should equal [111;111;111;111;111;111;111]
  List.scanBack (fun x y -> (x+y)/2) [12;4;10;6] 54 |> should equal [12;12;20;30;54]

  @"List.skip, Haskell drop
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#skip"
  List.skip 3 [1..5] |> should equal [4;5]
  (fun () -> List.skip 3 ([]:list<int>) |> ignore) |> should throw typeof<System.ArgumentException>
  List.skip (-1) [1;2] |> should equal [1;2]
  List.skip 0 [1;2] |> should equal [1;2]
  module Drop =
    @"https://hackage.haskell.org/package/base-4.16.0.0/docs/Data-List.html#v:drop"
    let rec drop n xs =
      if n <= 0 || List.isEmpty xs then xs
      else drop (n-1) (List.tail xs)
    drop 3 [1..5] |> should equal [4;5]
    drop 3 [] |> should equal []
    drop (-1) [1;2] |> should equal [1;2]
    drop 0 [1;2] |> should equal [1;2]

  @"List.skipWhile, Haskell dropWhile
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#skipWhile
  下の例では不等号の向きに注意しよう：意図通りか実際に REPL で確かめるのがベスト"
  List.skipWhile (fun x -> x < 3) [0..5] |> should equal [3..5]
  List.skipWhile ((>) 3) [1;2;3;4;5;1;2;3] |> should equal [3;4;5;1;2;3]
  List.skipWhile ((>) 9) [1;2;3] |> should equal List.empty<int>
  List.skipWhile ((>) 1) [1;2;3] |> should equal [1;2;3]
  List.skipWhile ((>) 2) [1;2;3] |> should equal [2;3]
  module DropWhile =
    @"https://hackage.haskell.org/package/base-4.16.0.0/docs/Data-List.html#v:dropWhile"
    let rec dropWhile: ('a -> bool) -> list<'a> -> list<'a> = fun p xs ->
      match xs with
      | [] -> []
      | y::ys -> if p y then dropWhile p ys else xs
    dropWhile (fun x -> x < 3) [0..5] |> should equal [3..5]
    dropWhile ((>) 3) [1;2;3;4;5;1;2;3] |> should equal [3;4;5;1;2;3]
    dropWhile ((>) 9) [1;2;3] |> should equal List.empty<int>
    dropWhile ((>) 1) [1;2;3] |> should equal [1;2;3]
    dropWhile ((>) 2) [1;2;3] |> should equal [2;3]

  @"span: Haskell の span と同じ, cf List.partition
  `span p xs = (takeWhile p xs, dropWhile p xs)` であることに注意。
  https://hackage.haskell.org/package/base-4.14.0.0/docs/src/GHC.List.html#span"
  let rec span: ('a -> bool) -> 'a list -> (('a list) * ('a list)) = fun p -> function
    | [] -> ([],[])
    | x::xs as lst -> if p x then let (ys, zs) = span p xs in  (x :: ys, zs) else ([], lst)
  let span' p lst = (List.takeWhile p lst, List.skipWhile p lst)
  span ((>) 3) [1;2;3;4;1;2;3;4] |> should equal ([1;2], [3;4;1;2;3;4])
  span' ((>) 3) [1;2;3;4;1;2;3;4] |> should equal ([1;2], [3;4;1;2;3;4])
  List.partition ((>) 3) [1;2;3;4;1;2;3;4] |> should equal ([1;2;1;2], [3;4;3;4])

  span  ((>) 9) [1;2;3] |> should equal ([1;2;3], List.empty<int>)
  span' ((>) 9) [1;2;3] |> should equal ([1;2;3], List.empty<int>)
  span  ((>) 0) [1;2;3] |> should equal (List.empty<int>, [1;2;3])
  span' ((>) 0) [1;2;3] |> should equal (List.empty<int>, [1;2;3])

  @"List.splitAt, Haskellと同じ.
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#splitAt
  https://hackage.haskell.org/package/base-4.16.0.0/docs/Prelude.html#v:splitAt"
  List.splitAt 3 [8;4;3;1;6;1] |> should equal ([8;4;3], [1;6;1])

  @"String to List, 文字列をリストに変換"
  Seq.toList "abc" |> should equal ['a';'b';'c']

  @"Haskell subsequences
  https://hackage.haskell.org/package/base-4.16.1.0/docs/src/Data-OldList.html#subsequences"
  module Subsequences =
    let rec nonEmptySubsequences = function
      | [] -> []
      | x::xs ->
        let f ys r = ys :: (x :: ys) :: r
        [x] :: List.foldBack f (nonEmptySubsequences xs) []
    nonEmptySubsequences [1..3] |> should equal [[1];[2];[1;2];[3];[1;3];[2;3];[1;2;3]]

    let subsequences xs =  [] :: nonEmptySubsequences xs
    subsequences [1..3] |> should equal [[];[1];[2];[1;2];[3];[1;3];[2;3];[1;2;3]]

  @"sum"
  [1..9] |> List.sum |> should equal 45

  @"tail"
  List.tail [1;2;3] |> should equal [2;3]

  @"List.take
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#take"
  ['a'..'d'] |> List.take 2 |> should equal ['a';'b']
  (fun () -> ['a'..'d'] |> List.take 6 |> ignore) |> should throw typeof<System.InvalidOperationException>
  ['a'..'d'] |> List.take 0 |> should equal List.empty<char>

  @"Haskell tails
  https://hackage.haskell.org/package/base-4.16.0.0/docs/Data-List.html#v:tails"
  let rec tails: list<'a> -> list<list<'a>> = function
  | [] -> [[]]
  | x::xs -> (x::xs)::(tails xs)
  tails [1;2;3;4] |> should equal [[1;2;3;4];[2;3;4];[3;4];[4];[]]

  @"takeWhile: Haskell の takeWhile と同じ
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#takeWhile
  List.takeWhileは標準ライブラリにある.
  下の例では不等号の向きに注意しよう：意図通りか実際に REPL で確かめるのがベスト"
  let rec takeWhile (p: 'a -> bool) lst =
    match lst with
    | [] -> []
    | x :: xs -> if p x then x :: takeWhile p xs else []
  (takeWhile ((>) 3) [1;2;3]) = (List.takeWhile ((>) 3) [1;2;3]) |> should equal true
  takeWhile ((>) 3) [1;2;3;4;1;2;3;4] |> should equal [1;2]
  takeWhile ((>) 9) [1;2;3] |> should equal [1;2;3]
  takeWhile ((>) 0) [1;2;3] |> should equal List.empty<int>

  @"List.tryItem"
  List.tryItem 1 [0..3] |> should equal (Some 1)
  List.tryItem 4 [0..3] |> should equal None

  @"Haskell until
  https://hackage.haskell.org/package/base-4.16.0.0/docs/Prelude.html#v:until"
  let until p f x =
    let rec go x =
      if p x then x else go (f x)
    go x
  until ((<) 100) ((*) 2) 1 |> should equal 128
  until (fun x -> x%2=1) (fun x -> x / 2) 400 |> should equal 25

  @"List.zip
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#zip"
  List.zip [1;2] ["one";"two"] |> should equal [(1,"one");(2,"two")]

module Literal =
  // https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/literals
  uint 100 |> should equal 100u
  int64 100 |> should equal 100L
  uint64 100 |> should equal 100UL
  bigint 100 |> should equal 100I

  @"bottom, undefined, ⊥, _|_
  https://stackoverflow.com/questions/20337249/bottom-undefined-value-in-f
  open System
  let undefined<'T> : 'T = raise (NotImplementedException())"

module Loop =
  @"module For"
  @"for in, https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/loops-for-in-expression"
  for i in [1;5;100;450;788] do printfn "%d" i done
  @"for to, for downto, https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/loops-for-to-expression"
  for i = 1 to 10 do printf "%d " i done
  for i = 10 downto 1 do printf "%d " i done

module Map =
  @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-mapmodule.html"
  @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-fsharpmap-2.html"

  @"Map.Add
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-fsharpmap-2.html#Add"
  module MethodAdd =
    let m = Map.empty.Add(1,"a").Add(2,"b")
    m.Add (3,"c") |> should equal (Map [(1,"a");(2,"b");(3,"c")])
    m.Add (2,"aa") |> should equal (Map [(1,"a");(2,"aa")])

  @"Map.Change
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-fsharpmap-2.html#Change"
  module MethodChange =
    let m = Map [(1,"a");(2,"b")]
    let f = function
      | Some s -> Some (s + "z")
      | None -> None
    m.Change (1,f) |> should equal (Map [(1,"az");(2,"b")])

  @"Map.add
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-mapmodule.html#add"
  module Add =
    let input = Map [(1,"a");(2,"b")]
    input |> Map.add 3 "c" |> should equal (Map [(1,"a");(2,"b");(3,"c")])
    input |> Map.add 2 "aa"  |> should equal (Map [(1,"a");(2,"aa")])

  @"Map.[key], get an element
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-mapmodule.html#item"

  @"Map.change
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-mapmodule.html#change"
  module Change =
    let input = Map [(1,"a");(2,"b")]
    input |> Map.change 1 (function
      | Some s -> Some (s + "z")
      | None -> None) |> should equal (Map [(1, "az");(2, "b")])
    input |> Map.change 3 (function
      | Some s -> Some (s + "z")
      | None -> None) |> should equal (Map [(1, "a");(2, "b")])

  @"Map.containsKey
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-mapmodule.html#containsKey"
  module ContainsKey =
    let m = Map [(1,"a");(2,"b")]
    m |> Map.containsKey 1 |> should equal true
    m |> Map.containsKey 3 |> should equal false

  @"Map.empty
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-mapmodule.html#empty"
  Map.empty<int, string> |> Map.isEmpty |> should equal true

  @"Map.fold
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-mapmodule.html#fold"
  ("initial", Map [(1,"a");(2,"b")])
  ||> Map.fold (fun state n s -> sprintf "%s %i %s" state n s)
  |> should equal "initial 1 a 2 b"

  Map.empty<int, string> |> Map.isEmpty |> should equal true

  @"Map.find
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-mapmodule.html#find"
  module Find =
    let m = Map [(1, "a");(2, "b")]
    m |> Map.find 1 |> should equal "a"
    m |> Map.find 2 |> should equal "b"
    (fun () -> m |> Map.find 3 |> ignore) |> should throw typeof<System.Collections.Generic.KeyNotFoundException>

  @"Map.forall
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-mapmodule.html#forall"
  module Forall =
  let m = Map [ (1, "a");(2, "b") ]
  m |> Map.forall (fun n s -> n >= s.Length) |> should equal true
  m |> Map.forall (fun n s -> n = s.Length) |> should equal false

module Math =
  """
  Literal Types: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/literals
  Math functions: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html
  """

  @"1, 0x1, 0o1, 0b1,
  1l (int),
  1u (uint32),
  1L (int64),
  1UL (uint64),
  1s (int16),
  1y (sbyte),
  1uy (byte),
  1.0 (float),
  1.0f (float32),
  1.0m (decimal),
  1I (BigInteger)
  4N (BigRational)"
  @"bigint parse"
  "1" |> bigint.Parse |> should equal 1I
  @"int64 arithmetic"
  1L+1L |> should equal 2L
  @"decimal arithmetic"
  1.0M/2.0M |> should equal 0.5M
  @"float infinity"
  infinity |> should equal infinity
  @"MinValue, 最小値
  https://midoliy.com/content/fsharp/text/type/1_primitive-type.html
  https://docs.microsoft.com/ja-jp/dotnet/api/system.int32.maxvalue?view=net-6.0"
  System.Int32.MinValue |> should equal -2_147_483_648
  System.Int64.MinValue |> should equal -9_223_372_036_854_775_808L
  @"MaxValue, 最大値, OCaml max_int
  https://midoliy.com/content/fsharp/text/type/1_primitive-type.html
  https://docs.microsoft.com/ja-jp/dotnet/api/system.int32.maxvalue?view=net-6.0"
  System.Int32.MaxValue |> should equal 2_147_483_647
  System.Int64.MaxValue |> should equal 9_223_372_036_854_775_807L

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

  @"** or power for int, 整数のべき乗・累乗
  a^b = pown a b"
  pown 2 3 |> should equal 8
  pown 3 2 |> should equal 9

  @"2のべき乗 for int64, pow2L n = 2^n, 整数のべき乗・累乗"
  let pow2L n = 1L <<< n
  pow2L 50 |> should equal 1125899906842624L

  @"** or power for floating numbers, 実数のべき乗・累乗"
  2.0 ** 3.0 |> should equal 8.0

  @"power for bigint"
  let powI (x:bigint) y =
    let rec f y acc = if y = 0 then acc else f (y-1) (x*acc)
    f y 1I
  powI 2I 20 |> should equal 1048576I
  powI 2I 50 |> should equal 1125899906842624I

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
    let xs = [|29;20;7;35;120|]
    let ys = [|30;20;10;40;120|]
    xs |> Array.map oneceil |> should equal ys

  @"compare, Generic comparison
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#compare"
  compare 1 2 |> should equal -1
  compare [1;2;3] [1;2;4] |> should equal -1
  compare 2 2 |> should equal 0
  compare [1;2;3] [1;2;3] |> should equal 0
  compare 2 1 |> should equal 1
  compare [1;2;4] [1;2;3] |> should equal 1

  @"factorial, 階乗"
  let fact n = Array.reduce (*) [|1..n|]
  [|1..6|] |> Array.map fact |> should equal [|1;2;6;24;120;720|]
  module Factorial =
    @"非正の数に対して1を返す: 状況に応じて修正しよう."
    //
    let fact n =
      let rec f acc n =
        if n <= 0L then 1L
        elif n = 1L then acc
        else f (acc*n) (n-1L)
      f 1L n
    [-1L..5L] |> List.map fact |> should equal [1L;1L;1L;2L;6L;24L;120L]

    @"comb, combination, 組み合わせ
    n <= kで1を返すようにした"
    let comb n k = if n<=k then 1L else (fact n) / ((fact k) * (fact (n-k)))
    comb 4L 2L |> should equal 6L
    comb 2 2 |> should equal 1
    comb 1 2 |> should equal 1

    @"homcomb, homogeneous combination, 重複組み合わせ"
    let homcomb n k = comb (n+k-1L) k

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
    //#nowarn "40"
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
    fibByUnfoldUntilN 1000 |> List.ofSeq |> should equal [2;3;5;8;13;21;34;55;89;144;233;377;610;987;1597]

  @"first digit, 整数の一桁目を得る"
  module FirstDigit =
    let firstDigit x = (10 - x%10) % 10
    let xs = [|29;20;7;35;120|]
    let ys = [|1;10;3;5;10|]
    let zs = [|1;0;3;5;0|]
    xs |> Array.map (fun x -> 10 - x%10) |> should equal ys
    xs |> Array.map firstDigit |> should equal zs

  @"floor, 切り捨て"
  floor -1.4 |> should equal -2.0
  floor -1.5 |> should equal -2.0
  floor 1.4  |> should equal 1.0
  floor 1.5  |> should equal 1.0

  @"gcd, lcm
  http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_B&lang=ja
  https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_1_B
  http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2116711#1"

  module GCD =
    module GCD1 =
      let gcd: int64 -> int64 -> int64 = fun x y ->
        let rec frec x y = if y=0L then x else frec y (x%y)
        if x >= y then frec x y else frec y x
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

  @"Large Numbers
  巨大な数を扱うとき
  cf: https://atcoder.jp/contests/abc169/tasks/abc169_b
  例えば積がオーバーフローするかしないかを判定するとき、
  積の値そのものを確認するのではなく、
  オーバーフローチェックすべき値を新たにかける値で割った値で判定する。"
  module LargeNumbers =
    // check
    System.Int32.MaxValue |> should equal 2147483647
    System.Int32.MaxValue * 2 |> should equal -2

    /// a*b が int を飛び越えるとき、オーバーフローしてマイナスになったりする
    let checkOverflowBad a b n = n < (a * b)
    checkOverflowBad System.Int32.MaxValue 2 System.Int32.MaxValue
    |> should equal false

    /// a: 元の値、b: 新たにかける値、n: オーバーフローチェックする値
    /// int なら int の範囲内で計算を処理できる
    let checkOverflowGood a b n = a > (n / b)
    checkOverflowGood System.Int32.MaxValue 2 System.Int32.MaxValue
    |> should equal true

  @"log, 自然対数
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#log"
  module Log =
    let logBase baseNumber value = (log value) / (log baseNumber)
    logBase 2.0 32.0 |> should equal 5.0
    logBase 10.0 1000.0 |> should equal 2.9999999999999996

  @"log10, 常用対数
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#log10"
  log10 1000.0 |> should equal 3.0
  log10 100000.0 |> should equal 5.0
  log10 0.0001 |> should equal -4.0
  log10 -20.0 |> should equal nan

  @"max
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#max"
  max 1 2 |> should equal 2
  max [1;2;3] [1;2;4] |> should equal [1;2;4]
  max "zoo" "alpha" |> should equal "zoo"

  @"min
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#min"
  min 1 2 |> should equal 1
  min [1;2;3] [1;2;4] |> should equal [1;2;3]
  min "zoo" "alpha" |> should equal "alpha"

  @"剰余, 余り, mod"
  10 % 2 |> should equal 0
  10 % 7 |> should equal 3

  @"n 進法 n-ary notation
  使える文字の都合で n < 26 を仮定するが本質的ではない
  参考：https://webbibouroku.com/Blog/Article/haskell-nstring
  AtCoderで出てきた「26進数」：AtCoder/ABC171/C1.fsx"
  module NaryLT16 =
    let numbersLT16 = [|"0";"1";"2";"3";"4";"5";"6";"7";"8";"9";"a";"b";"c";"d";"e";"f"|]
    let rec toNary n x =
      if x = 0L then []
      else
        let q = x / n
        let r = x % n |> int
        List.append (toNary n q) [ numbersLT16.[r] ]
    let to3ary = toNary 3L
    [0L..3L] |> List.map to3ary |> should equal  [[];["1"];["2"];["1";"0"]]

    let intToNary n x =
      if x = 0L then [ numbersLT16.[0] ]
      elif n = 0L then []
      elif n = 1L then List.replicate (int x) (numbersLT16.[1])
      elif n <= 16L then toNary n x
      else []
    let intTo2ary = intToNary 2L
    [0L..8L] |> List.map intTo2ary |> should equal [["0"];["1"];["1";"0"];["1";"1"];["1";"0";"0"];["1";"0";"1"];["1";"1";"0"];["1";"1";"1"];["1";"0";"0";"0"]]

  module NaryLT26 =
    let numbersLT26 = [|'a'..'z'|]
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
    [0L..11L] |> List.map intTo2ary |> should equal  [['a'];['b'];['b';'a'];['b';'b'];['b';'a';'a'];['b';'a';'b'];['b';'b';'a'];['b';'b';'b'];['b';'a';'a';'a'];['b';'a';'a';'b'];['b';'a';'b';'a'];['b';'a';'b';'b']]

  @"perfect number, 完全数"
  module IsPerfectSquare1 =
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
  module IsPerfectSquare2 =
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
    |> should equal [1;4;9;16;25;36;49;64;81;100]

  @"Method2 https://www.geeksforgeeks.org/check-if-a-number-is-perfect-square-without-finding-square-root/amp/"
  module IsPerfectSquare3 =
    let rec isPerfectSquare x left right =
      let mid = (left + right) / 2L
      let midSq = mid * mid
      if midSq = x then true
      elif right < left then false
      elif midSq < x then isPerfectSquare x (mid+1L) right
      else isPerfectSquare x left (mid-1L)

    [1L..100L] |> List.choose (fun x -> if isPerfectSquare x 1L x then Some x else None)
    |> should equal [1L;4L;9L;16L;25L;36L;49L;64L;81L;100L]

  @"Permutation, 順列, Bird-Gibbons, perms1"
  let perms xs =
    let rec inserts: 'a -> 'a list -> 'a list list = fun x -> function
      | [] -> [[x]]
      | y::ys -> (x::y::ys) :: List.map (fun z -> y::z) (inserts x ys)
    let step x xss = List.collect (inserts x) xss
    List.foldBack step xs [[]]
  perms [1..3] |> should equal [[1;2;3];[2;1;3];[2;3;1];[1;3;2];[3;1;2];[3;2;1]]

  "@Prime factorization, 素因数分解
  https://atcoder.jp/contests/ABC169/tasks/abc169_d"
  module PrimeFactorization =
    @"https://atcoder.jp/contests/ABC169/submissions/13872716"
    module PF1 =
      type Factor = { Number: int64;Count: int }
      /// m: origN を割っていった値でどんどん小さくなる
      /// a: 2L からインクリメントしていく値
      /// origN: 入力値
      let rec primes m a origN =
        // sqrt N 以下の値だけ調べればよい
        if origN < a * a then
          if m = 1L then [] else [ { Number = origN;Count = 1 } ] // 最終的に素数と分かったとき
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
          { Number = a;Count = c }
          :: (primes m1 aPlus origN)
      let primeFactors n = primes n 2L n
      @"素数判定
      https://atcoder.jp/contests/arc017/tasks/arc017_1
      https://qiita.com/drken/items/a14e9af0ca2d857dad23#問題-1-素数判定"
      let rec isPrime n =
        if n < 0L then isPrime (-n)
        elif n = 0L then false
        elif n = 1L then false
        else primeFactors n = [ { Number = n;Count = 1 } ]
      [1L..8L] |> List.filter isPrime |> should equal [2L;3L;5L;7L]

    @"https://jeremybytes.blogspot.com/2016/07/getting-prime-factors-in-f-with-good.html"
    module PF2 =
      let rec getFactors n proposed (acc:list<int64>) =
        if n<=0L then failwith "be positive"
        elif n=1L then [1L]
        elif proposed = n then proposed::acc
        elif n % proposed = 0L then getFactors (n/proposed) proposed (proposed::acc)
        else getFactors n (proposed+1L) acc
      let primeFactor n = getFactors n 2 []
      primeFactor 36 |> should equal [3;3;2;2]

    @"https://atcoder.jp/contests/caddi2018/submissions/9944877"
    module PF3 =
      let rec f c i p =
        if p%i=0L then f (c+1L) i (p/i)
        elif c<>0L then (i,c) :: f 0L (i+1L) p
        elif p < i*i then [(p,1L)]
        else (i,c) :: f 0L (i+1L) p
      let pf p = f 0L 2L p
      pf 36 |> should equal [(2L,2L);(3L,2L);(1L,1L)]

    @"http://www.fssnip.net/3X"
    module FsSnip =
      let isPrime n =
        let sqrtn = (float >> sqrt >> int) n // square root of integer
        [|2..sqrtn|] // all numbers from 2 to sqrt'
        |> Array.forall (fun x -> n % x <> 0) // no divisors

      let allPrimes =
        // sequences are lazy, so we can make them infinite
        let rec f n = seq {
            if isPrime n then
              yield n
            yield! f (n+1) // recursing
          }
        f 2 // starting from 2

      allPrimes |> Seq.take 5 |> should equal (seq  [|2;3;5;7;11|])

    @"https://stackoverflow.com/questions/1097411/learning-f-printing-prime-numbers#answer-1097596"
    module StackOverflowSieve =
      let rec sieve = function
        | (p::xs) -> p :: sieve [ for x in xs do if x % p > 0 then yield x ]
        | []    -> []
      sieve [2..50] |> List.take 5 |> should equal [2;3;5;7;11]

    module StackOverflowPrime1 =
      let twoAndOdds n =
        Array.unfold (fun x -> if x > n then None else if x = 2 then Some(x, x + 1) else Some(x, x + 2)) 2
      twoAndOdds 15 |> should equal [|2;3;5;7;9;11;13;15|]

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

      let rec isPrime x =
        if x < 0L then isPrime (-x)
        elif x = 0L then false
        elif x = 1L then false
        else infSeq x
          |> Seq.takeWhile (fun i -> i * i <= x)
          |> Seq.forall (fun i -> x % i <> 0L)
      [0L..10L] |> List.filter isPrime |> should equal [2L;3L;5L;7L]

    module AojOcaml01 =
      let isPrime = function
        | 1 -> false
        | 2 -> true
        | n when n%2=0 -> false
        | n ->
          let rec frec x =
            if n<x*x then true
            else if n%x=0 then false
            else frec (x+2)
          frec 3
      [0..10] |> List.filter isPrime |> should equal [2;3;5;7]

  @"round, 四捨五入
  どちらにも丸められる場合は偶数にする"
  round -1.4 |> should equal -1.0
  round -1.5 |> should equal -2.0
  round 0.4  |> should equal 0.0
  round 0.5  |> should equal 0.0
  round 1.4  |> should equal 1.0
  round 1.5  |> should equal 2.0

  @"sign, 符号
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#sign"
  sign -2 |> should equal -1
  sign -1 |> should equal -1
  sign 0  |> should equal 0
  sign 1  |> should equal 1
  sign 10  |> should equal 1

  @"Math sine, 正弦関数
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#sin"
  let near0 x y = (abs (x-y)) < 0.0000001
  near0 (sin System.Math.PI) 0 |> should be True

  @"順列, permutations
  標準ライブラリある?"
  let rec choose xs =
    match xs with
    | [] -> []
    | x::xs -> (x, xs) :: List.map (fun (y, ys) -> (y, x::ys)) (choose xs)
  choose [1;2;3] |> should equal [(1, [2;3]);(2, [1;3]);(3, [1;2])]
  let rec permutations xs =
    match xs with
    | [] -> [[]]
    | xs ->
      choose xs
      |> List.collect (fun (y, ys) -> List.map (fun zs -> y::zs) (permutations ys))
  permutations [1;2;3] |> should equal [[1;2;3];[1;3;2];[2;1;3];[2;3;1];[3;1;2];[3;2;1]]

module Operator =
  @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html"
  let near0 x y = (abs (x-y)) < 0.0000001

  @"self definition
  https://stackoverflow.com/questions/2210854/can-you-define-your-own-operators-in-f"
  let (+.) x s = [for y in s -> x + y]
  1 +. [2;3;4] |> should equal [3;4;5]

  @"atan
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#atan"
  near0 (atan 1.0) 0.7853981634 |> should be True

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
  // not equal
  (1 <> 0) |> should equal true
  (not (1=0)) |> should equal true

  @"flip: defition of an operator, using paretheses"
  let flip f x y = f y x
  let (><) f x y = f y x
  (/) 3 2 |> should equal 1
  flip (/) 3 2 |> should equal 0
  (><) (/) 3 2 |> should equal 0

  @"max
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#max"
  max 1 2 |> should equal 2
  max [1;2;3] [1;2;4] |> should equal [1;2;4]
  max "zoo" "alpha" |> should equal "zoo"

  @"not equal"
  1 <> 2 |> should equal true
  'b' <> 'a' |> should equal true

  @"'True' mod
  http://gettingsharper.de/2012/02/28/how-to-implement-a-mathematically-correct-modulus-operator-in-f/
  cf. https://github.com/fsharp/fslang-suggestions/issues/417
  .NETの仕様でmodの返り値に負の値を許している."
  let inline (%%) n m = let k = n%m in if sign k >= 0 then k else abs m + k
  -14 % 5 |> should equal -4
  -14 %% 5 |> should equal 1

  @"<-, substiture, 可変型の変数に代入
  TODO: fsharp.github.ioの適切なリンクを張り直す
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#(%20:=%20)
  `:=`はdeprecated."
  let count = ref 0 // Creates a reference cell object with a mutable Value property
  count.Value |> should equal 0
  count.Value <- 1  // Updates the value
  count.Value |> should equal 1

module Option =
  @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html"

  @"Option.bind, Haskell >>=
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#bind"
  let tryParse (input: string) =
    match System.Int32.TryParse input with | true, v -> Some v | false, _ -> None
  None |> Option.bind tryParse |> should equal None
  Some "42" |> Option.bind tryParse |> should equal (Some 42)
  Some "Forty-two" |> Option.bind tryParse |> should equal None

  @"Option.contains
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#contains"
  (99, None) ||> Option.contains |> should be False
  (99, Some 99) ||> Option.contains |> should be True
  (99, Some 100) ||> Option.contains |> should be False

  @"Option.count
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#count"
  None |> Option.count |> should equal 0
  Some 99 |> Option.count |> should equal 1

  @"Option defaultValue
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#defaultValue"
  (99, None) ||> Option.defaultValue |> should equal 99
  (99, Some 42) ||> Option.defaultValue |> should equal 42

  @"Option.defaultWith, Noneだったら指定した値で埋める
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#defaultWith"
  None |> Option.defaultWith (fun () -> 99) |> should equal 99
  Some 42 |> Option.defaultWith (fun () -> 99) |> should equal 42

  @"Option.exists
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#exists"
  None |> Option.exists (fun x -> x >= 5) |> should be False
  Some 42 |> Option.exists (fun x -> x >= 5) |> should be True
  Some 4 |> Option.exists (fun x -> x >= 5) |> should be False

  @"Option.filter
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#filter"
  None |> Option.filter (fun x -> x >= 5) |> should equal None
  Some 42 |> Option.filter (fun x -> x >= 5) |> should equal (Some 42)
  Some 4 |> Option.filter (fun x -> x >= 5) |> should equal None

  @"Option.flatten, `Option (Option <'a>)`を`Option<'a>'にする.
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#flatten"
  (None: int option option) |> Option.flatten |> should equal None
  (Some ((None: int option))) |> Option.flatten |> should equal None
  (Some (Some 42)) |> Option.flatten |> should equal (Some 42)

  @"Option.fold
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#fold"
  (0, None) ||> Option.fold (fun accum x -> accum + x * 2) |> should equal 0
  (0, Some 1) ||> Option.fold (fun accum x -> accum + x * 2) |> should equal 2
  (10, Some 1) ||> Option.fold (fun accum x -> accum + x * 2) |> should equal 12

  @"Option.foldBack
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#foldBack"
  (None, 0) ||> Option.foldBack (fun x accum -> accum + x * 2) |> should equal 0
  (Some 1, 0) ||> Option.foldBack (fun x accum -> accum + x * 2) |> should equal 2
  (Some 1, 10) ||> Option.foldBack (fun x accum -> accum + x * 2) |> should equal 12

  @"Option.forall
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#forall"
  None |> Option.forall (fun x -> x >= 5) |> should be True
  Some 42 |> Option.forall (fun x -> x >= 5) |> should be True
  Some 4 |> Option.forall (fun x -> x >= 5) |> should be False

  @"Option.get, Haskell fromJust
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#get"
  Some 42 |> Option.get |> should equal 42
  (fun () -> (None: int option) |> Option.get |> ignore) |> should throw typeof<System.ArgumentException>

  @"Option.isNone, Haskell isNothing
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#isNone"
  None |> Option.isNone |> should equal true
  Some 42 |> Option.isNone |> should equal  false

  @"Option.isSome, Haskell isJust
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#isSome"
  None |> Option.isSome |> should equal false
  Some 42 |> Option.isSome |> should equal true

  @"Option.iter
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#iter"

  @"Option.map
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#map"

  @"Option.map2
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#map2"

  @"Option.map3
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#map3"

  @"Option.ofNullable
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#ofNullable"
  System.Nullable<int>() |> Option.ofNullable |> should equal None
  System.Nullable(42) |> Option.ofNullable |> should equal (Some 42)

  @"Option.ofObj
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#ofObj"
  (null: string) |> Option.ofObj |> should equal None
  "not a null string" |> Option.ofObj |> should equal (Some "not a null string")

  @"Option.orElse
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#orElse"
  ((None: int Option), None) ||> Option.orElse |> should equal None
  (Some 99, None) ||> Option.orElse |> should equal (Some 99)
  (None, Some 42) ||> Option.orElse |> should equal (Some 42)
  (Some 99, Some 42) ||> Option.orElse |> should equal (Some 42)

  @"Option.orElseWith
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#orElseWith"
  (None: int Option) |> Option.orElseWith (fun () -> None) |> should equal None
  None |> Option.orElseWith (fun () -> (Some 99)) |> should equal (Some 99)
  Some 42 |> Option.orElseWith (fun () -> None) |> should equal (Some 42)
  Some 42 |> Option.orElseWith (fun () -> (Some 99)) |> should equal (Some 42)

  @"Option.toArray
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#toArray"

  @"Option.toList
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#toList"

  @"Option.toNullable
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#toNullable"
  (None: int option) |> Option.toNullable |> should equal (System.Nullable<int>())
  Some 42 |> Option.toNullable |> should equal (System.Nullable(42))

  @"Option.toObj
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#toObj"
  (None: string option) |> Option.toObj |> should equal null
  Some "not a null string" |> Option.toObj |> should equal "not a null string"

  @"tryParse"
  let tryParse (input: string) =
    match System.Int32.TryParse input with
    | true, v -> Some v
    | false, _ -> None
  None |> Option.bind tryParse |> should equal None
  Some "42" |> Option.bind tryParse |> should equal (Some 42)
  Some "Forty-two" |> Option.bind tryParse |> should equal None

module PatternMatch =
  exception DivideByZeroException
  // match a specified type of subtypes
  let tryDivide2: decimal -> decimal -> Result<decimal,DivideByZeroException> = fun x y ->
    try Ok (x/y)
    with | :? DivideByZeroException as ex -> Error ex

  @"定数パターン
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#constant-patterns"
  module ConstantPattern1 =
    [<Literal>]
    let Three = 3
    let filter123 x =
      match x with
        | 1 | 2 | Three -> printfn "Found 1, 2, or 3!"
        | var1 -> printfn "%d" var1
    for x in 1..10 do filter123 x

  @"定数パターン
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#constant-patterns"
  module ConstantPattern2 =
    type Color =
      | Red = 0
      | Green = 1
      | Blue = 2
    let printColorName (color:Color) =
      match color with
        | Color.Red -> printfn "Red"
        | Color.Green -> printfn "Green"
        | Color.Blue -> printfn "Blue"
        | _ -> ()

    printColorName Color.Red
    printColorName Color.Green
    printColorName Color.Blue

  @"識別子パターン
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#identifier-patterns"
  module IdentifierPattern1 =
    let printOption (data : int option) =
      match data with
        | Some var1  -> printfn "%d" var1
        | None -> ()
  module IdentifierPattern2 =
    type PersonName =
      | FirstOnly of string
      | LastOnly of string
      | FirstLast of string * string

    let constructQuery personName =
      match personName with
        | FirstOnly(firstName) -> printf "May I call you %s?" firstName
        | LastOnly(lastName) -> printf "Are you Mr. or Ms. %s?" lastName
        | FirstLast(firstName, lastName) -> printf "Are you %s %s?" firstName lastName
  module IdentifierPattern3 =
    type Shape =
      | Rectangle of height : float * width : float
      | Circle of radius : float
    let matchShape1 shape =
      match shape with
        | Rectangle(height = h) -> printfn $"Rectangle with length %f{h}"
        | Circle(r) -> printfn $"Circle with radius %f{r}"
    let matchShape2 shape =
      match shape with
        | Rectangle(height = h; width = w) -> printfn $"Rectangle with height %f{h} and width %f{w}"
        | _ -> ()

  @"変数パターン
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#variable-patterns"
  module VariablePattern =
    let function1 x =
      match x with
        | (var1, var2) when var1 > var2 -> printfn "%d is greater than %d" var1 var2
        | (var1, var2) when var1 < var2 -> printfn "%d is less than %d" var1 var2
        | (var1, var2) -> printfn "%d equals %d" var1 var2
    function1 (1,2)
    function1 (2, 1)
    function1 (0, 0)

  @"asパターン, Haskell @
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#as-patterns"
  module AsPattern =
    let (var1, var2) as tuple1 = (1, 2)
    printfn "%d %d %A" var1 var2 tuple1

  @"ORパターン
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#or-patterns"
  module OrPattern =
    let detectZeroOR point =
      match point with
        | (0, 0) | (0, _) | (_, 0) -> printfn "Zero found."
        | _ -> printfn "Both nonzero."
    detectZeroOR (0, 0)
    detectZeroOR (1, 0)
    detectZeroOR (0, 10)
    detectZeroOR (10, 15)

  @"ANDパターン
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#and-patterns"
  module AndPattern =
    let detectZeroAND point =
      match point with
        | (0, 0) -> printfn "Both values zero."
        | (var1, var2) & (0, _) -> printfn "First value is 0 in (%d, %d)" var1 var2
        | (var1, var2)  & (_, 0) -> printfn "Second value is 0 in (%d, %d)" var1 var2
        | _ -> printfn "Both nonzero."
    detectZeroAND (0, 0)
    detectZeroAND (1, 0)
    detectZeroAND (0, 10)
    detectZeroAND (10, 15)

  @"Consパターン
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#cons-patterns"
  module ConsPattern =
    let list1 = [1;2;3;4]
    // This example uses a cons pattern and a list pattern.
    let rec printList l =
      match l with
        | head :: tail -> printf "%d " head; printList tail
        | [] -> printfn ""
    printList list1

  @"リストパターン
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#list-patterns"
  module ListPattern =
    // This example uses a list pattern.
    let listLength list =
      match list with
        | [] -> 0
        | [ _ ] -> 1
        | [ _; _ ] -> 2
        | [ _; _; _ ] -> 3
        | _ -> List.length list

    printfn "%d" (listLength [1])
    printfn "%d" (listLength [1;1])
    printfn "%d" (listLength [1;1;1;])
    printfn "%d" (listLength [])

  @"配列パターン
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#array-patterns"
  module ArrayPattern =
    // This example uses array patterns.
    let vectorLength vec =
      match vec with
        | [| var1 |] -> var1
        | [| var1; var2 |] -> sqrt (var1*var1 + var2*var2)
        | [| var1; var2; var3 |] -> sqrt (var1*var1 + var2*var2 + var3*var3)
        | _ -> failwith (sprintf "vectorLength called with an unsupported array size of %d." (vec.Length))

    printfn "%f" (vectorLength [| 1. |])
    printfn "%f" (vectorLength [| 1.; 1. |])
    printfn "%f" (vectorLength [| 1.; 1.; 1.; |])
    printfn "%f" (vectorLength [| |] )

  @"かっこで囲まれたパターン, head-tail分解
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#parenthesized-patterns"
  module ParenthesizedPattern =
    let countValues list value =
      let rec checkList list acc =
        match list with
          | (elem1 & head) :: tail when elem1 = value -> checkList tail (acc + 1)
          | head :: tail -> checkList tail acc
          | [] -> acc
          checkList list 0

    let result = countValues [ for x in -10..10 -> x*x - 4 ] 0
    printfn "%d" result

  @"識別子パターン
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#tuple-patterns"
  module TuplePattern =
    let detectZeroTuple point =
      match point with
        | (0, 0) -> printfn "Both values zero."
        | (0, var2) -> printfn "First value is 0 in (0, %d)" var2
        | (var1, 0) -> printfn "Second value is 0 in (%d, 0)" var1
        | _ -> printfn "Both nonzero."

    detectZeroTuple (0, 0)
    detectZeroTuple (1, 0)
    detectZeroTuple (0, 10)
    detectZeroTuple (10, 15)

  @"レコードパターン
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#record-patterns"
  module RecordPattern =
    type MyRecord = { Name: string; ID: int }
    let IsMatchByName record1 (name: string) =
      match record1 with
        | { MyRecord.Name = nameFound; MyRecord.ID = _; } when nameFound = name -> true
        | _ -> false
    let recordX = { Name = "Parker"; ID = 10 }
    let isMatched1 = IsMatchByName recordX "Parker"
    let isMatched2 = IsMatchByName recordX "Hartono"

  @"型の注釈が付けられたパターン
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#patterns-that-have-type-annotations"
  module PatternsThatHaveTypeAnnotations =
    let detect1 x =
      match x with
        | 1 -> printfn "Found a 1!"
        | (var1 : int) -> printfn "%d" var1
    detect1 0
    detect1 1

  @"型テストパターン
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#type-test-pattern"
  module TypeTestPattern1 =
    open System.Windows.Forms
    let RegisterControl(control:Control) =
      match control with
        | :? Button as button -> button.Text <- "Registered."
        | :? CheckBox as checkbox -> checkbox.Text <- "Registered."
        | _ -> ()
  module TypeTestPattern2 =
    type A() = class end
    type B() = inherit A()
    type C() = inherit A()
    let m (a: A) =
      match a with
        | :? B -> printfn "It's a B"
        | :? C -> printfn "It's a C"
        | _ -> ()

  @"nullパターン
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#null-patterns"
  module NullPattern =
    let ReadFromFile (reader : System.IO.StreamReader) =
      match reader.ReadLine() with
        | null -> printfn "\n"; false
        | line -> printfn "%s" line; true

    let fs = System.IO.File.Open("..\..\Program.fs", System.IO.FileMode.Open)
    let sr = new System.IO.StreamReader(fs)
    while ReadFromFile(sr) = true do ()
    sr.Close()

  @"Nameofパターン
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/pattern-matching#nameof-patterns"
  module NameofPattern =
    let f (str: string) =
      match str with
        | nameof str -> "It's 'str'!"
        | _ -> "It is not 'str'!"
    f "str" |> should equal"It's 'str'!"
    f "asdf" |> should equal"It is not 'str'!"

module Prelude =
  @"uncurry, Haskell
  http://fssnip.net/3n/title/Curry-Uncurry
  https://hackage.haskell.org/package/base-4.16.0.0/docs/Prelude.html#v:uncurry"
  let curry f a b = f (a,b)
  let uncurry f (a,b) = f a b

module Print =
  @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-printfmodule.html"
  @"https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/plaintext-formatting"
  @"Abraham Get Programming with F#-A guide for NET developers
  %c: char
  %d: int
  %f: float, %.4fなどで桁数指定
  %b: boolean
  %s: string
  %0: .ToString()
  %A: pretty-print"
  @"sprintf: printfの書式で文字列生成, module String参照"

  module Printfn =
  @"%A: どんな型でもとにかく出力"
  [1;2;3;4] |> printfn "%A"
  2 |> printfn "%A"

  2L |> printfn "%A" // 2LのLまで出力されてしまう
  2L |> printfn "%d" // Lは出力されない

  2.0 |> printfn "%f" // floatを出力
  2.0 |> printfn "%.4f" // 出力桁数指定

  "str" |> printfn "%A" // クオートつきで出力
  "str" |> printfn "%s" // クオートなしで出力

module Random =
  let chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
  let random = System.Random()
  [|0..4|] |> Array.map (fun _ -> chars.[random.Next(chars.Length)]) |> System.String.Concat

module Record =
  """レコード: いわゆる辞書・構造体. 細かい事情は調べよう.
  cf. https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/records
  cf. https://midoliy.com/content/fsharp/text/type-detail/0_record.html"""

  """ワーニング対応
  warning FS0667: フィールド ラベルとこのレコード式またはパターンの型だけでは、対応するレコード型を一意に決定できません"""
  type Point = { X: float; Y: float; Z: float; }
  let p = { X = 1.0; Y = 2.0; Z = 3.5; } // warning(になる場合あり)
  let p = { Point.X = 1.0; Y = 2.0; Z = 3.5; } // 対応する型(レコード)を明示

  """withによる一部更新, レコード更新式.
  cf. https://midoliy.com/content/fsharp/text/type-detail/0_record.html"""
  type Point = { X: float; Y: float; Z: float; }
  let p = { Point.X = 1.0; Y = 2.0; Z = 3.5; }
  let p2 = { p with Z = 10.0; }
  p  |> should equal {X=1.0; Y=2.0; Z=3.5}
  p2 |> should equal {X=1.0; Y=2.0; Z=10.0}

module RegularExpression =
  let input = @"\\contentsline a{bcd}{efg}{hij}{lmn}"
  let pattern = @"{(.*)}{(.*)}{(.*)}{(.*)}"
  let capture = System.Text.RegularExpressions.Regex.Match(input, pattern)
  capture.Groups.Values |> Seq.iter (printfn "%A")

  module ExtranctAndReplace =
    let reg = Regex(@"\pcoloredtextbf{(.*)}")
    let m = reg.Match(@"abc\\pcoloredtextbf{text}edf")
    m.Groups |> Seq.iter (printfn "%A")
    Regex.Replace(@"abc\pcoloredtextbf{text}edf", (Seq.item 0 m.Groups).Value, (Seq.item 1 m.Groups).Value) |> should equal "abctextedf"

  module Matcher =
    let regMatch str patt = System.Text.RegularExpressions.Regex.Match(str, patt)
    let matcher str patt = regMatch str patt |> fun x -> if x.Success then x.Value else ""

    let patternBegin = @"^\\begin{(thm|prop|pos|req|axm|defn|assump|notation)}.*"
    matcher @"\begin{thm}\label{test}" patternBegin |> should equal @"\begin{thm}\label{test}"
    matcher @"\begin{thm}" patternBegin |> should equal @"\begin{thm}"
    matcher @"\begin{prop}" patternBegin |> should equal @"\begin{prop}"

    let patternTitle = @"^\*+ .*"
    matcher @"* abc"     patternTitle |> should equal "* abc"
    matcher @"** abc"    patternTitle |> should equal "** abc"
    matcher @"*** abc"   patternTitle |> should equal "*** abc"
    matcher @"**** abc"  patternTitle |> should equal "**** abc"
    matcher @"***** abc" patternTitle |> should equal "***** abc"

module Sequence =
  @"docs
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html"

  @"Sequence literal"
  {0..3} |> should equal (seq [0..3])

  @"Seq.allPairs
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#allPairs"
  ([1;2], [3;4]) ||> Seq.allPairs |> should equal (seq {(1, 3);(1, 4);(2, 3);(2, 4)})

  @"Seq.append
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#append"
  Seq.append [1;2] [3;4] |> should equal {1..4}

  @"Seq.average
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#average"
  [1.0;2.0;3.0] |> Seq.average |> should equal 2

  @"Seq.averageBy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#averageBy"
  module AverageBy =
    type Foo = { Bar: float }
    seq {{Bar = 2.0};{Bar = 4.0}}
    |> Seq.averageBy (fun foo -> foo.Bar) |> should equal 3.0

  @"Seq.cache
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#cache"
  module Cache =
    let fibSeq = (0, 1) |> Seq.unfold (fun (a,b) -> Some(a + b, (b, a + b)))
    let fibSeq3 = fibSeq |> Seq.take 3 |> Seq.cache
    fibSeq3 |> should equal {1..3}

  @"Seq.cast
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#cast"
  [box 1;box 2;box 3] |> Seq.cast<int> |> should equal {1..3}

  @"Seq.choose
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#choose"
  [Some 1;None;Some 2] |> Seq.choose id |> should equal (seq {1;2})
  [1..3] |> Seq.choose (fun n -> if n % 2 = 0 then Some n else None) |> should equal (seq [2])

  @"Seq.chunkBySize
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#chunkBySize"
  [1..3] |> Seq.chunkBySize 2 |> should equal (seq {[|1;2|];[|3|]})

  @"Seq.collect, Haskell concatMap
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#collect"
  module Collect =
    type Foo = { Bar: int seq }
    seq { {Bar = [1;2]};{Bar = [3;4]} } |> Seq.collect (fun foo -> foo.Bar)
    |> should equal {1..4}

    [[1;2];[3;4]] |> Seq.collect id |> should equal {1..4}

  @"Seq.compareWith
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#compareWith"
  module CompareWith =
    let closerToNextDozen a b = (a % 12).CompareTo(b % 12)
    ([1;10], [1;10]) ||> Seq.compareWith closerToNextDozen |> should equal 0
    ([1;5], [1;8]) ||> Seq.compareWith closerToNextDozen |> should equal -1
    ([1;11], [1;13]) ||> Seq.compareWith closerToNextDozen |> should equal 1
    ([1;2], [1]) ||> Seq.compareWith closerToNextDozen |> should equal 1
    ([1], [1;2]) ||> Seq.compareWith closerToNextDozen |> should equal -1

  @"Seq.concat
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#concat"
  [[1;2];[3];[4;5]] |> Seq.concat |> should equal {1..5}

  @"Seq.contains
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#contains"
  [1;2] |> Seq.contains 2 |> should equal true
  [1;2] |> Seq.contains 5 |> should equal false

  @"Seq.countBy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#countBy"
  module CountBy =
    type Foo = { Bar: string }
    let inputs = [{Bar = "a"};{Bar = "b"};{Bar = "a"}]
    inputs |> Seq.countBy (fun foo -> foo.Bar)
    |> should equal (seq { ("a", 2);("b", 1) })

  @"Haskell cycle"
  let cycle xs = Seq.concat <| Seq.initInfinite (fun _ -> xs)
  cycle [1..2] |> Seq.take 4 |> should equal [1;2;1;2]

  @"Seq.delay
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#delay"
  Seq.delay (fun () -> {1..3}) |> should equal {1..3}

  @"Seq.distinct
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#distinct"
  [1;1;2;3] |> Seq.distinct |> should equal {1..3}

  @"Seq.distinctBy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#distinctBy"
  module DistinctBy =
    type Foo = { Bar: int }
    [{Bar = 1 };{Bar = 1};{Bar = 2};{Bar = 3}] |> Seq.distinctBy (fun foo -> foo.Bar)
    |> should equal (seq {{ Bar = 1 };{ Bar = 2 };{ Bar = 3 }})

  @"Seq.empty
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#empty"
  Seq.empty |> should equal (seq [])

  @"Seq.exactlyOne
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#exactlyOne"
  ["banana"] |> Seq.exactlyOne |> should equal "banana"
  (fun () -> ["pear";"banana"] |> Seq.exactlyOne |> ignore) |> should throw typeof<System.ArgumentException>
  (fun () -> ([]:list<int>) |> Seq.exactlyOne |> ignore) |> should throw typeof<System.ArgumentException>

  @"Seq.except
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#except"
  [1..5] |> Seq.except [1..2..5] |> should equal (seq {2;4})

  @"Seq.exists, Haskell any
  cf. Seq.forall (= Haskell all)
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#exists"
  [1..5] |> Seq.exists (fun elm -> elm % 4 = 0) |> should equal true
  [1..5] |> Seq.exists (fun elm -> elm % 6 = 0) |> should equal false

  @"Seq.exists2 TODO
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#exists2"
  ([1;2], [1;2;0]) ||> Seq.exists2 (fun a b -> a > b) |> should equal false
  ([1;4], [1;3;4]) ||> Seq.exists2 (fun a b -> a > b) |> should equal true

  @"Seq.filter
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#exists2"
  [1..4] |> Seq.filter (fun elm -> elm % 2 = 0) |> should equal [2;4]

  @"Seq.find, 条件をみたす第一要素を取る
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#find"
  [1..4] |> Seq.find (fun elm -> elm % 2 = 0) |> should equal 2
  // [1..3] |> Seq.find (fun elm -> elm % 6 = 0) // KeyNotFoundException

  @"Seq.findBack, 後ろから探して第一要素を取る
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#findBack"
  [2..4] |> Seq.findBack (fun x -> x%2=0) |> should equal 4

  @"Seq.findIndex
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#findIndex"
  [1..5] |> Seq.findIndex (fun x -> x % 2 = 0) |> should equal 1

  @"Seq.findIndexBack
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#findIndexBack"
  [1..5] |> Seq.findIndexBack (fun x -> x % 2 = 0) |> should equal 3

  @"Seq.fold
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#fold"
  module Fold =
    type Charge = | In of int | Out of int
    let inputs = [In 1;Out 2;In 3]
    (0, inputs) ||> Seq.fold (fun acc charge ->
      match charge with
      | In i -> acc + i
      | Out o -> acc - o) |> should equal 2

  @"Seq.fold2
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#fold2"
  module Fold2 =
    type CoinToss = Head | Tails
    let data1 = [Tails;Head;Tails]
    let data2 = [Tails;Head;Head]
    (0, data1, data2) |||> Seq.fold2 (fun acc a b ->
      match (a, b) with
      | Head, Head -> acc + 1
      | Tails, Tails -> acc + 1
      | _ -> acc - 1)
      |> should equal 1

  @"Seq.foldBack
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#foldBack"
  Seq.foldBack (+) [1..5] 10 |> should equal 25
  Seq.foldBack (-) [1..5] 0 |> should equal 3
  Seq.fold (-) 0 [1..5] |> should equal -15

  @"Seq.foldBack2
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#foldBack2"
  module FoldBack2 =
    type Count = { Positive: int;Negative: int;Text: string }
    let inputs1 = [-1;-2;-3]
    let inputs2 = [3;2;1;0]
    let initialState = {Positive = 0;Negative = 0;Text = ""}

    (inputs1, inputs2, initialState) |||> Seq.foldBack2 (fun a b acc  ->
      let text = acc.Text + "(" + string a + "," + string b + ") "
      if a + b >= 0 then
        { acc with
          Positive = acc.Positive + 1
          Text = text }
      else
        { acc with
          Negative = acc.Negative + 1
          Text = text }
          )
    |> should equal {Positive=2;Negative=1;Text="(-3,1) (-2,2) (-1,3) "}

  @"Seq.forall
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#forall"
  module Forall =
    let isEven a = a % 2 = 0
    [2;42] |> Seq.forall isEven |> should equal true
    [1;2] |> Seq.forall isEven |> should equal false

  @"Seq.forall2
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#forall"

  @"group: Haskellのgroup, !!注意!! F#のSeq.groupByとは挙動が違う.
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
    group "Mississippi" |> should equal [['M'];['i'];['s';'s'];['i'];['s';'s'];['i'];['p';'p'];['i']]

  @"Seq.groupBy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#groupBy"
  [1;2;3;4;5] |> Seq.groupBy (fun n -> n % 2)
  |> should equal (seq [(1, seq [1;3;5]);(0, seq [2;4])])

  @"Seq.head
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#groupBy"
  ["banana";"pear"] |> Seq.head |> should equal "banana"
  {0..9} |> Seq.head |> should equal 0

  @"Seq.indexed
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#indexed"
  Seq.indexed "abc" |> should equal (seq [(0, 'a');(1, 'b');(2, 'c')])

  @"Seq.init
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#init"
  Seq.init 4 (fun v -> v + 5) |> should equal (seq [5..8])

  @"Seq.initInfinite, infinite seq
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#initInfinite
  https://atcoder.jp/contests/abc169/tasks/abc169_d
  Seqに対するhead-tailの分解
  Active Pattern利用"
  module InitInfinite =
    let (|SeqEmpty|SeqCons|) (xs: 'a seq) =
      if Seq.isEmpty xs then SeqEmpty else SeqCons(Seq.head xs, Seq.skip 1 xs)
    Seq.initInfinite id |> Seq.take 3 |> should equal {0..2}
    Seq.initInfinite (fun x -> x + 1) |> Seq.take 3 |> should equal {1..3}

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

  @"Seq.insertAt
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#insertAt"
  seq { 0;1;2 } |> Seq.insertAt 1 9 |> should equal (seq [0;9;1;2])

  @"Seq.insertManyAt
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#insertManyAt"
  seq {0;1;2} |> Seq.insertManyAt 1 [8;9] |> should equal (seq {0;8;9;1;2})

  @"Seq.isEmpty
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#insertManyAt"
  [] |> Seq.isEmpty |> should equal true
  ["pear";"banana"] |> Seq.isEmpty |> should equal false

  @"Seq.item
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#item"
  ["a";"b";"c"] |> Seq.item 1 |> should equal "b"

  @"Seq.iter
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#iter"
  ["a";"b";"c"] |> Seq.iter (printfn "%s")

  @"haskell iterate
  http://fssnip.net/18/title/Haskell-function-iterate
  iterate :: (a -> a) -> a -> [a]
  iterate f x = x : iterate f (f x)"
  let rec iterate f x = seq {
    yield x
    yield! iterate f (f x)
  }
  Seq.take 10 (iterate ((*) 2) 1) |> should equal (seq [1;2;4;8;16;32;64;128;256;512])

  @"Seq.iter2
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#iter2"

  @"Seq.iteri
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#iteri"
  ["a";"b";"c"] |> Seq.iteri (fun i v -> printfn "{i}: {v}")

  @"Seq.iteri2
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#iteri2"

  @"Seq.last
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#last"
  ["pear";"banana"] |> Seq.last |> should equal "banana"

  @"Seq.length
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#length"
  {1..3} |> Seq.length |> should equal 3

  @"Seq.map
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#map"

  @"Seq.map2
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#map2"
  module Map2 =
    let inputs1 = ["a";"bad";"good"]
    let inputs2 = [0;2;1]
    (inputs1, inputs2) ||> Seq.map2 (fun x y -> x.[y]) |> should equal (seq ['a';'d';'o'])
    ([1..4], [11..13]) ||> Seq.map2 (fun x y -> x+y) |> should equal (seq [12;14;16])

  @"Seq.map3
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#map3"

  @"Seq.mapFold
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#mapFold"

  @"Seq.mapFoldBack
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#mapFoldBack"

  @"Seq.mapi
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#mapi"

  @"Seq.mapi2
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#mapi2"

  @"Seq.max
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#max"

  @"Seq.maxBy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#maxBy"

  @"Seq.min
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#min"

  @"Seq.minBy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#minBy"
  module MinBy =
    let inputs =
    ["aaa";"b";"cccc"] |> Seq.minBy (fun s -> s.Length) |> should equal "b"

  @"Seq.ofArray
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#ofArray"

  @"Seq.ofList
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#ofList"
  [1;2;5] |> Seq.ofList |> should equal (seq {1;2;5})

  @"Seq.pairwise
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#pairwise"
  seq {1..4} |> Seq.pairwise |> should equal (seq [(1,2);(2,3);(3,4)])

  @"Seq.permute
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#permute"
  [1..4] |> Seq.permute (fun x -> (x + 1) % 4) |> should equal (seq [4;1;2;3])

  @"Seq.pick
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#pick"
  [1;2;3] |> Seq.pick (fun n -> if n % 2 = 0 then Some (string n) else None) |> should equal "2"

  @"Seq.readonly
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#readonly"
  [|1..3|] |> Seq.readonly |> should equal (seq [1..3])

  @"Seq.reduce
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#reduce"
  {0..9} |> Seq.reduce (-) |> should equal -45

  @"Seq.reduceBack
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#reduceBack"

  @"Seq.removeAt
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#removeAt"
  Seq.removeAt 1 {0..2} |> should equal (seq [0;2])

  @"Seq.removeManyAt
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#removeManyAt"
  Seq.removeManyAt 1 2 {0..3} |> should equal (seq [0;3])

  @"Seq.replicate
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#replicate"
  Seq.replicate 3 "a" |> should equal (seq ["a";"a";"a"])

  @"Seq.rev
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#rev"

  @"repeat, Haskell
  https://hackage.haskell.org/package/base-4.16.0.0/docs/Data-List.html"
  let rec repeat x = seq {
    yield x
    yield! repeat x
  }
  Seq.take 3 (repeat 1) |> should equal (seq [1;1;1])

  @"Seq.scan
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#scan"
  module Scan =
    type Charge = | In of int | Out of int
    let inputs = seq {In 1;Out 2;In 3}
    (0, inputs) ||> Seq.scan (fun acc charge ->
      match charge with
        | In i -> acc + i
        | Out o -> acc - o)
    |> should equal [0;1;-1;2]

  @"Seq.scanBack
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#scanBack"
  module ScanBack =
    type Charge = | In of int | Out of int
    let inputs = [In 1;Out 2;In 3]
    (inputs, 0) ||> Seq.scanBack (fun charge acc ->
      match charge with
        | In i -> acc + i
        | Out o -> acc - o)
    |> should equal [2;1;3;0]

  @"Seq.singleton
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#singleton"
  Seq.singleton 0 |> should equal (seq [0])

  @"Seq.skip, Haskell drop
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#skip"
  Seq.skip 2 [1..4] |> should equal [3;4]
  // (fun () -> Seq.skip 5 [1..4] |> ignore) |> should throw typeof<System.ArgumentException>
  Seq.skip -1 [1..4] |> should equal [1..4]

  @"Seq.skipWhile, Haskell dropWhile
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#skipWhile"
  seq {"a";"bbb";"cc";"d"} |> Seq.skipWhile (fun x -> x.Length < 3) |> should equal (seq ["bbb";"cc";"d"])
  {0..5} |> Seq.skipWhile (fun x -> x < 3) |> should equal {3..5}
  module DropWhile =
    let rec dropWhile p (xs: seq<'a>) =
      match xs with
      | s when Seq.isEmpty s -> Seq.empty
      | _ ->
        if p (Seq.head xs) then dropWhile p (Seq.tail xs)
        else xs
    {0..5} |> dropWhile (fun x -> x < 3) |> should equal {3..5}

  @"slice, subseq, お手製
  https://stackoverflow.com/questions/34093543/f-take-subsequence-of-a-sequence"
  module SliceSubseq =
    let sub i n = Seq.skip i >> Seq.take n
    let slice s e = sub s (e - s + 1)
    sub 1 3 {0..10} |> should equal {1..3}
    sub 2 4 {0..10} |> should equal {2..5}
    slice 1 3 {0..10} |> should equal {1..3}
    slice 2 4 {0..10} |> should equal {2..4}

  @"Seq.sort
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#sort"

  @"Seq.sortBy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#sortBy"
  ["a";"bbb";"cccc";"dd"] |> Seq.sortBy (fun s -> s.Length) |> should equal (seq ["a";"dd";"bbb";"cccc"])

  @"Seq.sortByDescending
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#sortByDescending"

  @"Seq.sortDescending
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#sortDescending"

  @"Seq.sortWith
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#sortWith"

  @"Seq.splitInto
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#splitInto"
  Seq.splitInto 3 [1..5] |> should equal (seq [[|1;2|];[|3;4|];[|5|]])

  @"Seq.sum s = Seq.fold (+) 0 s
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#sum"
  Seq.fold (-) 0 { 0..9 } |> should equal -45

  @"Seq.sumBy
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#sumBy"

  @"Seq.tail
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#tail"
  Seq.tail (seq {0..3}) |> should equal (seq { 1..3 })

  @"Seq.take
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#take"
  Seq.take 2 [1..4] |> should equal (seq [1;2])

  @"Seq.takeWhile
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#takeWhile"
  {0..9} |> Seq.takeWhile (fun x -> x < 3) |> should equal {0..2}

  @"Seq.toArray
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#toArray"

  @"Seq.toList
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#toList"

  @"Seq.transpose
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#transpose"
  Seq.transpose [[10;20;30];[11;21;31]] |> should equal [[10;11];[20;21];[30;31]]

  @"Seq.truncate, 高々n個の要素を取る
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#truncate"

  @"Seq.tryExactlyOne
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#tryExactlyOne"

  @"Seq.tryFind"
  @"Seq.tryFindBack"
  @"Seq.tryFindIndex"
  @"Seq.tryFindIndexBack"
  @"Seq.tryHead"
  @"Seq.tryItem"
  @"Seq.tryLast"
  @"Seq.tryPick"
  @"Seq.unfold
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#unfold"
  1 |> Seq.unfold (fun state -> if state > 100 then None else Some (state, state * 2))
  |> should equal (seq { 1;2;4;8;16;32;64 })
  @"Seq.updateAt"
  @"Seq.where
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#where"
  [1;2;3;4] |> Seq.where (fun elm -> elm % 2 = 0) |> should equal [2;4]
  @"Seq.windowed"
  @"Seq.zip"
  @"Seq.zip3"

module Set =
  @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-setmodule.html"

  @"set itself"
  set [1..5] |> should equal (set [1..5])

  @"Set.add
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-setmodule.html#add"
  Set.add 1 (set [2..4]) |> should equal (set [1..4])
  Set.add 1 (set [1..4]) |> should equal (set [1..4])

  @"count, length for sets"
  set [1;2] |> Set.count |> should equal 2

  @"difference
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-setmodule.html#difference "
  Set.difference (set "abcdef") (set "abc")
  |> should equal (set ['d';'e';'f'])

  @"intersect
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-setmodule.html#intersect "
  Set.intersect (set [1;2;3]) (set [2;3;4]) |> should equal (set [2;3])

  @"Set.ofArray"
  Set.ofArray [|1;2|] |> should equal (set [1;2])

  @"Set.ofSeq, 文字列から変換するときはこれを使う."
  Set.ofSeq "abc" |> should equal (set ['a';'b';'c'])

  @"Set.singleton
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-setmodule.html#singleton"
  Set.singleton 7 |> should equal (set [7])

  @"Set.union, 和集合
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-setmodule.html#union"
  Set.union (set [1;2;3]) (set [3;4;5]) |> should equal (set [1..5])

module String =
  @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-stringmodule.html
  @つき文字列: 逐語的文字列, verbatim string
  https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/strings#verbatim-strings"

  @"文字列結合"
  "abc" + "def" |> should equal "abcdef"

  @"文字列の反転, reverse"
  "abcde" |> Seq.toArray |> Array.rev |> System.String |> should equal"edcba"

  @"文字列を一文字ずつ切り出して数値化する"
  Seq.map (string >> int) "0123" |> should equal [0..3]

  @"埋め込み文字列"
  let text = "TEXT"
  $"text: {text}" |> should equal "text: TEXT"

  module Contains =
    @"部分文字列の検索
    https://www.dotnetperls.com/indexof-fs"
    let words = "fish frog dog"
    words.IndexOf("frog") |> should equal 5
    words.IndexOf("bird") |> should equal -1

    @"ある文字を含むかどうか: `Seq.contains`を使おう"
    "`3`を含む数かどうかを判定"
    [|20..41|] |> Array.filter (string >> Seq.contains '3') |> should equal [|23;30;31;32;33;34;35;36;37;38;39|]

  @"String.collect
  mapと違って文字を文字列に変換する関数を使ってmapする
  https://msdn.microsoft.com/visualfsharpdocs/conceptual/string.collect-function-%5bfsharp%5d"
  "Hello, World"
  |> String.collect (fun c -> sprintf "%c " c)
  |> should equal "H e l l o ,   W o r l d "

  @"単純な文字列と文字列の連結
  https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/strings#string-operators"
  "str1" + "str2" |> should equal "str1str2"

  @"String.concat
  配列やリストの要素を連結して文字列化"
  module Concat =
    [|1..5|] |> Array.map string |> String.concat " " |> should equal "1 2 3 4 5"
    [|'a'..'e'|] |> System.String |> should equal "abcde"

    [1..5]
    |> List.map string
    |> String.concat " "
    |> should equal "1 2 3 4 5"

    [1;2;1;2;3] |> List.distinct
    |> should equal [1;2;3]

    ["Stefan";"says:";"Hello";"there!"]
    |> String.concat " " |> should equal "Stefan says: Hello there!"

    [0..9] |> List.map string |> String.concat "" |> should equal "0123456789"
    [0..9] |> List.map string |> String.concat ", " |> should equal "0, 1, 2, 3, 4, 5, 6, 7, 8, 9"
    ["No comma"] |> String.concat "," |> should equal "No comma"

  @"System.String.Concat
  文字(char)のリストを文字列化.
  注意: `['1';'2';'3'] |> String.concat`はエラー."
  module StringConcat =
    ['1';'2';'3'] |> System.String.Concat |> should equal "123"

  @"exists
  文字列中に与えられた条件をみたす文字が存在するか"
  open System
  "Hello World!" |> String.exists System.Char.IsUpper |> should equal true
  "Yoda" |> String.exists Char.IsUpper |> should equal true
  "nope" |> String.exists Char.IsUpper |> should equal false

  @"filter"
  // Filtering out just alphanumeric characters
  "0 1 2 3 4 5 6 7 8 9 a A m M"
  |> String.filter Uri.IsHexDigit |> should equal "0123456789aA"

  //Filtering out just digits
  "hello" |> String.filter Char.IsDigit |> should equal ""

  @"forall"
  "all are lower" |> System.String.forall System.Char.IsLower |> should equal false
  "allarelower" |> System.String.forall System.Char.IsLower |> should equal true

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
  @"同じ文字のくり返しからなる文字列を作る"
  String.init 3 (fun _ -> "#") |> should equal "###"

  @"iter"
  "Hello" |> String.iter (fun c -> printfn "%c %d" c (int c))

  @"iteri"
  "Hello" |> String.iteri (fun i c -> printfn "%d. %c %d" (i + 1) c (int c))

  @"length
  文字列の長さ"
  "aiueo" |> String.length |> should equal 5
  String.length null  |> should equal 0
  String.length ""  |> should equal 0
  String.length "123" |> should equal 3

  @"map
  各文字に作用"
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

  @"Split
  文字列を分割する「メソッド」"
  "1 2 3" |> fun s -> s.Split(" ") |> should equal [|"1";"2";"3"|]
  "行区切り文字列を適切な配列に変換"
  "8 5
  10 8" |> fun s -> s.Split("\n") |> Array.map (fun s -> s.Split(" ") |> fun x -> int x.[0], int x.[1]) |> should equal [|(8,5);(10,8)|]

  """sprintf, 文字列埋め込み, format, printfの書式で文字列生成
  次の埋め込み文字列を使う方がF# way?
  let text = "TEXT"
  $"text: {text}" |> should equal "text: TEXT"
  """
  module Sprintf =
    sprintf "%s%02d" "TEST" 1 |> should equal "TEST01"
    // %のエスケープは%%を重ねる
    sprintf "%%%s%02d" "TEST" 1 |> should equal "%TEST01"

    let template = sprintf "%s%02d"
    template "TEST" 1 |> should equal "TEST01"

    let a = "TEST"
    $"{a}" |> should equal "TEST"

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

module SystemIoDirectory =
  @".NET
  https://docs.microsoft.com/ja-jp/dotnet/api/system.io.directory?view=net-6.0"

  @"EnumerateDirectories
  https://docs.microsoft.com/ja-jp/dotnet/api/system.io.directory.enumeratedirectories?view=net-6.0"
  System.IO.Directory.EnumerateDirectories "." |> should equal (seq ["./C++"])

  @"GetCurrentDirectory
  https://docs.microsoft.com/ja-jp/dotnet/api/system.io.directory.getcurrentdirectory?view=net-6.0"
  System.IO.Directory.GetCurrentDirectory ()

  @"SetCurrentDirectory
  https://docs.microsoft.com/ja-jp/dotnet/api/system.io.directory.setcurrentdirectory?view=net-6.0"
  System.IO.Directory.SetCurrentDirectory __SOURCE_DIRECTORY__

module SystemIoStdout =
  @".NET
  https://docs.microsoft.com/ja-jp/dotnet/api/system.io.textwriter?view=net-6.0"

  @"Write string, 改行なしの出力
  https://docs.microsoft.com/ja-jp/dotnet/api/system.io.textwriter.write?view=net-6.0#system-io-textwriter-write(system-string)"
  stdout.Write "a"
  stdout.Write "a\n"

module SystemMath =
  let near0 x y = (abs (x-y)) < 0.0000001

  "Atan, 逆正接, arctan, atan
  https://docs.microsoft.com/ja-jp/dotnet/api/system.math.atan?view=net-6.0
  See atan in the above `module Math`."
  near0 (System.Math.Atan 1) 0.7853981634 |> should be True
  near0 (atan 1) 0.7853981634 |> should be True

  @"PI, 円周率
  https://docs.microsoft.com/ja-jp/dotnet/api/system.math.atan?view=net-6.0"
  near0 System.Math.PI 3.141592654 |> should be True

module SystemNumerics =
  open System.Numerics

  @"System.Numerics.Complex, complex number, 複素数
  https://numerics.mathdotnet.com/api/MathNet.Numerics/Complex32.htm"
  System.Numerics.Complex.Zero |> should equal (System.Numerics.Complex(0,0))
  System.Numerics.Complex.One |> should equal (System.Numerics.Complex(1,0))
  System.Numerics.Complex.ImaginaryOne |> should equal (System.Numerics.Complex(0,1))
  System.Numerics.Complex(1,0).Real |> should equal 1.0
  System.Numerics.Complex(1,0).Imaginary |> should equal 0.0
  System.Numerics.Complex(1,0).Magnitude |> should equal 1.0
  System.Numerics.Complex(1,0).Phase |> should equal 0.0

  let c1 = Complex(1,2)
  let c2 = Complex(3,4)
  c1*c2 |> should equal (Complex(-5,10))
  Complex(4,0) / Complex(2,0) |> should equal (Complex(2,0))

module Struct =
  [<Struct>]
  type Coupon = { B: int;Discount: int }
  let coupon1 = {B=1;Discount=2}
  let coupon2 = {B=2;Discount=3}

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

  @"型パラメーターが複数ある場合"
  type Table<'a,'b> = Table of ('b * 'a) list
  @"型制約の例: when"
  let rec findTable: Table<'a,'b> -> 'b -> 'a when 'b: comparison = fun table i ->
    match table with
      | Table [] -> failwith "item not found in table"
      | Table ((j,v) :: r) ->
        if i=j then v else findTable (Table r) i

  @"Type Sample"
  module Sample1 =
    type elem (id, name) =
      member this.id = id
      member this.name = name
    let e = elem(1, "test")
    e.id |> should equal 1
    e.name |> should equal "test"

  module Type2 =
    // Single case discriminated union
    type ValidationError = | InputOutOfRange of string
    type Spend = private Spend of decimal with
      member this.Value = this |> fun (Spend value) -> value
      static member Create input =
        if input >= 0.0M && input <= 1000.0M then Ok (Spend input)
        else Error (InputOutOfRange "You can only spend between 0 and 1000")

  // TODO Record Type

module ValueOption =
  @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-valueoption.html"

  @"https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-valueoption.html#bind"
  module Bind =
    let tryParse input =
      match System.Int32.TryParse (input: string) with
      | true, v -> ValueSome v
      | false, _ -> ValueNone
    //ValueNone |> ValueOption.bind tryParse |> should equal ValueNone
    ValueSome "42" |> ValueOption.bind tryParse |> should equal (ValueSome 42)
    //ValueSome "Forty-two" |> ValueOption.bind tryParse |> should equal ValueNone
