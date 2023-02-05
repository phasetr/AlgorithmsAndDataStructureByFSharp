#r "nuget: FsUnit"
open FsUnit

@"cf.
./Math.fsx
./References.fsx, module Operator"

module Arithmetics =
  """
  Literal Types: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/literals
  Math functions or Operators: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html
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

  @":> キャストと変換
  https://learn.microsoft.com/ja-jp/dotnet/fsharp/language-reference/symbol-and-operator-reference/"

  @"`:?` 型テスト演算子
  値が指定した型と一致する場合(サブタイプを含む)は`true`"
  @"`:?>` 型を階層の下位にある型に変換"
  @"`#` 型で使用されている場合はフレキシブル型を示す.
  型またはその派生型のいずれかを指す"
  @"`'` ジェネリック型パラメーターを示す"
  @"`{}` type キーワードと一緒に使うとクラスまたはレコードを区切る"
  @"{||} 匿名レコードを表す"

  @"除算演算子: `/`, 切り捨て除算, floor div
  切上げ除算, ceil div
  https://stackoverflow.com/questions/17944/how-to-round-up-the-result-of-integer-division"
  let (./) a b = let q = a/b in if a%b=0 then q else q+1
  [| for i in 1..10 do for j in 1..3 do (i,j) |] |> Array.map (fun (i,j) -> (i, j, i/j, i./j))
  |> should equal   [| ( 1, 1,  1,  1);
                       ( 1, 2,  0,  1);
                       ( 1, 3,  0,  1);
                       ( 2, 1,  2,  2);
                       ( 2, 2,  1,  1);
                       ( 2, 3,  0,  1);
                       ( 3, 1,  3,  3);
                       ( 3, 2,  1,  2);
                       ( 3, 3,  1,  1);
                       ( 4, 1,  4,  4);
                       ( 4, 2,  2,  2);
                       ( 4, 3,  1,  2);
                       ( 5, 1,  5,  5);
                       ( 5, 2,  2,  3);
                       ( 5, 3,  1,  2);
                       ( 6, 1,  6,  6);
                       ( 6, 2,  3,  3);
                       ( 6, 3,  2,  2);
                       ( 7, 1,  7,  7);
                       ( 7, 2,  3,  4);
                       ( 7, 3,  2,  3);
                       ( 8, 1,  8,  8);
                       ( 8, 2,  4,  4);
                       ( 8, 3,  2,  3);
                       ( 9, 1,  9,  9);
                       ( 9, 2,  4,  5);
                       ( 9, 3,  3,  3);
                       (10, 1, 10, 10);
                       (10, 2,  5,  5);
                       (10, 3,  3,  4) |]

  @"ceil
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#ceil"
  ceil 12.1 |> should equal 13.0
  ceil -1.9 |> should equal -1.0
  @"floor
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#floor"
  floor 12.1 |> should equal 12.0
  floor -1.9 |> should equal -2.0

  @"abs
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#abs"
  abs 1 |> should equal 1
  abs -1 |> should equal 1
  abs 1.0 |> should equal 1.0
  abs -1.0 |> should equal 1.0
  let myabsint x = if x > 0 then x else -x
  myabsint -1 |> should equal 1
  let myabsfloat x = if x > 0.0 then x else -x
  myabsfloat -1.0 |> should equal 1.0

  @"bottom, 整数の最低桁の数.
  cf. 整数の最高桁は`top`"
  let bottom n = n%10
  bottom 1 |> should equal 1
  bottom 21 |> should equal 1
  bottom 342 |> should equal 2

  @"DivRem, Haskell divMod: ただし負の数に対してHaskellの`divMod`とは挙動が違うため注意する.
  http://www.fssnip.net/gH/title/DivRem-Operator

  TODO Haskellの実装を確認して実装する
  https://hackage.haskell.org/package/base-4.17.0.0/docs/src/GHC.Real.html#quotRem
  https://hackage.haskell.org/package/base-4.17.0.0/docs/src/GHC.Real.html#divMod"
  System.Math.DivRem(7,3) |> should equal (2,1)
  System.Math.DivRem(-9,2) |> should equal (-4,-1) // Haskellでは (-5,1)

  @"power, powmod 競プロ用高速なべき乗の計算法: 途中でmodをはさみたい場合があるため.
  くり返し二乗法, iterative square method
  https://kazu-yamamoto.hatenablog.jp/entry/20090223/1235372875"
  let MOD = 998_244_353L
  let rec powmod m x n = if n=0L then 1L else if n%2L=0L then powmod m (x*x % m) (n/2L) else (x * (powmod m x (n-1L)) % m)
  powmod MOD 2L 3L |> should equal 8L
  powmod MOD 2L 4L |> should equal 16L

  @"上記の関数と本質的に同じ処理だが別途演算子を定義
  ../AtCoder/tessoku-book/A29/A29_fs_00_01.fsx
  https://atcoder.jp/contests/abc156/submissions/11167232"
  let MOD = 1_000_000_007L
  let (.*) a b = (a*b)%MOD
  let rec powmod x n = if n=0 then 1L elif n&&&1=0 then powmod (x.*x) (n>>>1) else x .* powmod x (n-1)
  powmod 2L 3 |> should equal 8L
  powmod 2L 4 |> should equal 16L

  @"順列の場合の数, permutation, powmodを使った計算
  順列そのものについては`module Combinatrics`の`permutations`を参照すること.
  https://atcoder.jp/contests/abc156/submissions/11167232"
  let permmod m n r =
    let rec frec acc n r = if r=0L then acc else frec ((n*acc)%m) (n-1L) (r-1L)
    frec 1L n r
  @"フェルマーの小定理によるmod演算下での逆元計算, 組み合わせの計算用"
  let invmod m a = powmod m a (m-2L)
  @"組み合わせの数, combination, powmodを使った計算
  剰余演算のもとでの処理だから,
  フェルマーの小定理とmod演算下での計算を使って効率化できる."
  let combmod m n r = ((permmod m n r) * (invmod m (permmod m r r))) % m

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

  @"factorial, 階乗 -> module Combinatrics"

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

      @"配列に対するGCD"
      [|3;4;9|] |> Array.reduce gcd |> should equal 1
      [|3;6;9|] |> Array.reduce gcd |> should equal 3

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

  @"inversion, 転倒数
  ../AtCoder/tessoku-book/A74/A74_fs_00_01.fsx
  順序関係が逆転しているペアの個数を数える"
  module Inversion =
    let count xa =
      let n = Array.length xa
      let mutable c = 0
      for i in 0..n-1 do for j in (1+1)..n-1 do if xa.[j]<xa.[i] then c<-c+1
      c
    [|2;3;4;1|] |> count |> should equal 3
    [|3;1;2;4|] |> count |> should equal 2

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

  @"n進法, (nary) n-ary expansion ver1
  ver1は各桁を10進数の数値の配列で表す
  cf. https://sirocco.hatenadiary.org/entry/20130416/1366121105"
  @"10進数のNをn進展開する"
  let decimalToNary n N = if N=0 then [|0|] else N |> Array.unfold (fun k -> if k=0 then None else Some (k%n, k/n)) |> Array.rev
  let naryToDecimal n Na = (Na,(0,0)) ||> Array.foldBack (fun x (acc,i) -> (acc + x * pown n i, i+1)) |> fst
  @"下から1ずつ増えているか確認すればよい"
  let n = 2 in [|0..8|] |> Array.map (decimalToNary n) |> should equal [|[|0|];[|1|];[|1;0|];[|1;1|];[|1;0;0|];[|1;0;1|];[|1;1;0|];[|1;1;1|];[|1;0;0;0|]|]
  let n = 3 in [|0..8|] |> Array.map (decimalToNary n) |> should equal [|[|0|];[|1|];[|2|];[|1;0|];[|1;1|];[|1;2|];[|2;0|];[|2;1|];[|2;2|]|]
  let n = 4 in [|0..8|] |> Array.map (decimalToNary n) |> should equal [|[|0|];[|1|];[|2|];[|3|];[|1;0|];[|1;1|];[|1;2|];[|1;3|];[|2;0|]|]

  let n = 2 in [|0..8|] |> Array.map (decimalToNary n >> naryToDecimal n) |> should equal [|0..8|]
  let n = 3 in [|0..8|] |> Array.map (decimalToNary n >> naryToDecimal n) |> should equal [|0..8|]
  let n = 4 in [|0..8|] |> Array.map (decimalToNary n >> naryToDecimal n) |> should equal [|0..8|]

  @"展開だけ見ると変な形だが負の数でも展開できて戻せる"
  let n = 2 in [|-9..-1|] |> Array.map (decimalToNary n >> naryToDecimal n) |> should equal [|-9..-1|]
  let n = 3 in [|-9..-1|] |> Array.map (decimalToNary n >> naryToDecimal n) |> should equal [|-9..-1|]
  let n = 4 in [|-9..-1|] |> Array.map (decimalToNary n >> naryToDecimal n) |> should equal [|-9..-1|]

  @"負のnに対するn進展開, n=-2の場合
  他のnだとそもそも展開の一意性からして問題?
  cf. ../AtCoder/ABC105/C.md"
  let decimalToNary n N = if N=0 then [|0|] else N |> Array.unfold (fun k -> if k=0 then None else let m = abs(k%n) in Some (m, (k-m)/n)) |> Array.rev
  let n = -2 in [|0..8|] |> Array.map (decimalToNary n >> naryToDecimal n) |> should equal [|0..8|]
  let n = -2 in [|-9..0|] |> Array.map (decimalToNary n >> naryToDecimal n) |> should equal [|-9..0|]

  @"n進法 n-ary notation ver2
  ver2は各桁を1文字のアルファベットによる文字列で表す.
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

  @"top, 整数の最高桁, firstDigit
  cf. 整数の最低桁は`bottom`参照"
  let rec top = function | n when n<10 -> n | n -> top (n/10)
  top 1 |> should equal 1
  top 21 |> should equal 2
  top 342 |> should equal 3

  @"Math sine, 正弦関数
  https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#sin"
  let near0 x y = (abs (x-y)) < 0.0000001
  near0 (sin System.Math.PI) 0 |> should be True

module Bit =
  @"十進展開から二進展開の文字列へ変換, decimal expansion to binary expansion
  System.Convert.ToString(i,2)
  https://rosettacode.org/wiki/Binary_digits#F#
  https://learn.microsoft.com/ja-jp/dotnet/api/system.convert.tostring?view=net-7.0
  https://smdn.jp/programming/dotnet-samplecodes/bitwise_operations/14b0b0560fb111eb8931d93b9158057a/"
  [|0..5|] |> Array.map (fun i -> System.Convert.ToString(i, 2)) |> should equal [|"0";"1";"10";"11";"100";"101"|]
  [|0..5|] |> Array.map (fun i -> System.Convert.ToString(i, 2).PadLeft(3,'0')) |> should equal [|"000";"001";"010";"011";"100";"101"|]
  @"二進展開から十進展開の文字列へ変換, binary expansion to decimal expansion,
  System.Convert.ToString(n,2)
  https://stackoverflow.com/questions/9742777/binary-to-decimal-conversion-formula"
  10L |> fun n -> System.Convert.ToString(n, 2) |> fun s -> System.Convert.ToInt64(s,2) |> should equal 10L
  @"`0,1`の配列を二進展開とみなして十進数に変換, binary expansion to decimal expansion"
  let toDec Aa = ((0,0),Array.rev Aa) ||> Array.fold (fun (i,acc) a -> (i+1, acc + if a=0 then 0 else pown 2 i)) |> snd
  [|0;0;1|] |> toDec |> should equal 1
  [|0;1;0|] |> toDec |> should equal 2
  [|1;0;0|] |> toDec |> should equal 4
  [|1;1;0|] |> toDec |> should equal 6
  @"`0,1`の配列を二進展開とみなして十進数に変換, 入力の`Aa`を反転させない, binary expansion to decimal expansion"
  let toDecRev Aa = ((0,0),Aa) ||> Array.fold (fun (i,acc) a -> (i+1, acc + if a=0 then 0 else pown 2 i)) |> snd
  [|1;0;0|] |> toDecRev |> should equal 1
  [|0;1;0|] |> toDecRev |> should equal 2
  [|0;0;1|] |> toDecRev |> should equal 4
  [|0;1;1|] |> toDecRev |> should equal 6

  // https://midoliy.com/content/fsharp/text/operator/2_bit.html
  0xFF |> should equal 255
  0x80 |> should equal 128
  @"bit単位の論理否定"
  ~~~0xFF |> should equal -256
  (~~~0,~~~1) |> should equal (-1,-2)
  [|0..10|] |> Array.map (fun i -> ~~~i) |> should equal [|-1;-2;-3;-4;-5;-6;-7;-8;-9;-10;-11|]
  @"bit or, bit論理和"
  (0|||0,0|||1,1|||1) |> should equal (0,1,1)
  0xFF ||| 0x80 |> should equal 255
  [|0..10|] |> Array.map (fun i -> i ||| 1) |> should equal [|1;1;3;3;5;5;7;7;9;9;11|]
  [|0..10|] |> Array.map (fun i -> i ||| 2) |> should equal [|2;3;2;3;6;7;6;7;10;11;10|]
  [|0..10|] |> Array.map (fun i -> i ||| 3) |> should equal [|3;3;3;3;7;7;7;7;11;11;11|]
  @"bit and, bit論理積"
  (0&&&0,0&&&1,1&&&1) |> should equal (0,0,1)
  0xFF &&& 0x80 |> should equal 128
  [|0..10|] |> Array.map (fun i -> i &&& 1) |> should equal [|0;1;0;1;0;1;0;1;0;1;0|]
  [|0..10|] |> Array.map (fun i -> i &&& 2) |> should equal [|0;0;2;2;0;0;2;2;0;0;2|]
  [|0..10|] |> Array.map (fun i -> i &&& 3) |> should equal [|0;1;2;3;0;1;2;3;0;1;2|]
  @"bit排他的論理和"
  0xFF ^^^ 0x80 |> should equal 127
  (0^^^0,0^^^1,1^^^1) |> should equal (0,1,0)
  [|0..10|] |> Array.map (fun i -> i ^^^ 1) |> should equal [|1;0;3;2;5;4;7;6;9;8;11|]
  [|0..10|] |> Array.map (fun i -> i ^^^ 2) |> should equal [|2;3;0;1;6;7;4;5;10;11;8|]
  [|0..10|] |> Array.map (fun i -> i ^^^ 3) |> should equal [|3;2;1;0;7;6;5;4;11;10;9|]
  @"`<<<`: 右辺のbit数だけ左にシフト: 2倍される"
  [|0..10|] |> Array.map (fun i -> 1 <<< i) |> should equal [|1;2;4;8;16;32;64;128;256;512;1024|]
  [|0..10|] |> Array.map (fun i -> 3 <<< i) |> should equal [|3;6;12;24;48;96;192;384;768;1536;3072|]
  @"`>>>`: 右辺のbit数だけ右にシフト: 1/2される"
  [|0..10|] |> Array.map (fun i -> 10 >>> i) |> should equal [|10;5;2;1;0;0;0;0;0;0;0|]
  [|0..10|] |> Array.map (fun i -> 100 >>> i) |> should equal [|100;50;25;12;6;3;1;0;0;0;0|]
  [|0..10|] |> Array.map (fun i -> 1024 >>> i) |> should equal [|1024;512;256;128;64;32;16;8;4;2;1|]

module Combinatorics =
  module Factorial =
    @"階乗その1, factorial
    cf. 競プロ用のmodつき計算はpowmod利用の処理を使おう.
    TODO `factmod`を書く"
    let fact n = if n=0L then 1L else Array.reduce (*) [|1L..n|]
    [|0L..6L|] |> Array.map fact |> should equal [|1L;1L;2L;6L;24L;120L;720L|]

    @"階乗その2, factorial
    accをつけて高速化を意識している.
    非正の数に対して1を返す: 状況に応じて修正しよう.
    cf. 競プロ用のmodつき計算はpowmod利用の処理を使おう."
    let fact n =
      let rec f acc n =
        if n <= 0L then 1L
        elif n = 1L then acc
        else f (acc*n) (n-1L)
      f 1L n
    [-1L..5L] |> List.map fact |> should equal [1L;1L;1L;2L;6L;24L;120L]

    @"comb, combination, 組み合わせの数, nCr
    cf. 競プロ用のmodつき計算はpowmod利用の処理`combmod`を使おう.
    https://rosettacode.org/wiki/Evaluate_binomial_coefficients#F#"
    let comb n k = List.fold (fun s i -> s * (n-i+1L)/i ) 1L [1L..k]
    [0L..2L] |> List.map (comb 2L) |> should equal [1L;2L;1L]
    [0L..3L] |> List.map (comb 3L) |> should equal [1L;3L;3L;1L]
    [0L..4L] |> List.map (comb 4L) |> should equal [1L;4L;6L;4L;1L]
    [0L..5L] |> List.map (comb 5L) |> should equal [1L;5L;10L;10L;5L;1L]

    @"comb, combnation, 組み合わせの数, nCr
    cf. 競プロ用のmodつき計算はpowmod利用の処理`combmod`を使おう.
    TODO https://www.geeksforgeeks.org/program-to-calculate-the-value-of-ncr-efficiently/"

    @"comb, combination, 組み合わせの数, nCr
    n <= kで1を返すようにした
    cf. 競プロ用のmodつき計算はpowmod利用の処理`combmod`を使おう.
    cf. 定義通りの計算は余計な計算が発生する."
    let comb n k = if n<=k then 1L else (fact n) / ((fact k) * (fact (n-k)))
    [0L..2L] |> List.map (comb 2L) |> should equal [1L;2L;1L]
    [0L..3L] |> List.map (comb 3L) |> should equal [1L;3L;3L;1L]
    [0L..4L] |> List.map (comb 4L) |> should equal [1L;4L;6L;4L;1L]
    [0L..5L] |> List.map (comb 5L) |> should equal [1L;5L;10L;10L;5L;1L]

    @"homcomb, homogeneous combination, 重複組み合わせ
    cf. 競プロ用のmodつき計算はpowmod利用の処理`homcombmod`を使おう.
    TODO `homcombmod`がなければ作る"
    let homcomb n k = comb (n+k-1L) k

  @"順列, Permutation, Bird-Gibbons, perms1
  cf. 競プロ用のmodつき計算はpowmod利用の処理`permmod`を使おう."
  let perms xs =
    let rec inserts: 'a -> 'a list -> 'a list list = fun x -> function
      | [] -> [[x]]
      | y::ys -> (x::y::ys) :: List.map (fun z -> y::z) (inserts x ys)
    let step x xss = List.collect (inserts x) xss
    List.foldBack step xs [[]]
  perms [1..3] |> should equal [[1;2;3];[2;1;3];[2;3;1];[1;3;2];[3;1;2];[3;2;1]]

  @"順列, permutations, 場合の数ではなく実際に列挙する
  cf. 競プロ用のmodつき計算はpowmod利用の処理`permmod`を使おう.
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

@"Large Numbers
巨大な数を扱うとき
cf: https://atcoder.jp/contests/abc169/tasks/abc169_b
cf. ./Reference.fsx, Seq.initInfinite64

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

@"素数に関する計算処理"
module Primes =
  @"Euler's phi, EulerPhi, totient, https://ja.wikipedia.org/wiki/オイラーのφ関数
  cf. ../AOJ/NTL1/01D_fs_00.fsx"
  let phi n =
    let primeFactors n =
      let rec frec i x acc =
        if i*i > n then if x=1 then acc else x :: acc
        else if x%i = 0 then frec i (x/i) (i :: acc)
        else frec (i+1) x acc
      frec 2 n []
    primeFactors n
    |> List.countBy id
    |> List.fold (fun acc (p,e) -> acc * (pown p e - pown p (e-1))) 1
  phi 6 |> should equal 2
  phi 1000000 |> should equal 400000

  "@Prime factorization, prime decomposition, 素因数分解
  https://atcoder.jp/contests/ABC169/tasks/abc169_d"
  module PrimeFactorization =
    @"自然数の`リスト`の素因数分解: 階乗の素因数分解などで役に立つ.
    単品はPF4あたりを使おう.
    https://atcoder.jp/contests/abc052/tasks/arc067_a"
    module PFS1 =
      let rec primes (i:int64) (k:int64) =
        let (q,r) = System.Math.DivRem(k,i)
        if k=1L then []
        else if r=0L then i::primes i q
        else if i*i>k then [k]
        else primes (i+1L) k
      let insertWith f k v m = Map.tryFind k m |> function | Some(v0) -> Map.add k (f v0 v) m | None -> Map.add k v m
      let f m k = (m, primes 2L k) ||> List.fold (fun m i -> insertWith (+) i 1L m)
      (Map.empty, [2L..5L]) ||> List.fold f |> should equal (Map [(2L,3L);(3L,1L);(5L,1L)])

    @"C#のDictionary版: AtCoderでMapが使えないと思っていたがそうではなかった.
    せっかくなので過去の記録も残しておく.
    https://atcoder.jp/contests/abc052/tasks/arc067_a"
    module PFS1ByDictionary =
      open System.Collections.Generic
      let rec primes (i:int64) (k:int64) =
        let (q,r) = System.Math.DivRem(k,i)
        if k=1L then []
        else if r=0L then i::primes i q
        else if i*i>k then [k]
        else primes (i+1L) k
      let insertWith f k v (d:Dictionary<int64,int64>) =
        d.TryGetValue(k) |> function | true,n -> d.[k] <- f d.[k] v; d | false,_ -> d.Add(k, v); d
      let f d k = (d, primes 2L k) ||> List.fold (fun d i -> insertWith (+) i 1L d)
      [2L..5L] |> List.fold f (Dictionary<int64,int64>()) |> should equal (dict [(2L,3L);(3L,1L);(5L,1L)])

    @"自然数の`リスト`の素因数分解: 階乗の素因数分解などで役に立つ.
    単品はPF4あたりを使おう."
    module PFS2 =
      let rec factorize n =
        if n=1 then []
        else
          let m = Seq.initInfinite ((+) 2) |> Seq.filter (fun i -> n%i=0) |> Seq.head
          m :: factorize (n/m)
      let pf n = [1..n] |> List.collect factorize |> List.groupBy id |> List.map (fun (x,xs) -> (x,List.length xs))
      pf 5 |> should equal [(2,3);(3,1);(5,1)]

    @"https://atcoder.jp/contests/ABC169/submissions/13872716
    ルートで高速化した再帰によるアルゴリズム.
    PF3は1を素数判定してしまうため,
    コメントを除いたバージョンとしてPF4を使うといいだろう."
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
          { Number = a;Count = c }
          :: (primes m1 aPlus origN)
      let primeFactors n = primes n 2L n
      primeFactors N
      |> List.countBy id
      |> List.fold (fun acc (p,e) -> acc * (pown p e - pown p (e-1))) 1

      @"素数判定: (比較的)速い"
      let isPrime x =
        if x=0||x=1 then false
        else let sq = (float >> sqrt >> int) x in [|2..sq|] |> Array.forall (fun n -> x%n<>0)
      [|0..100|] |> Array.choose (fun x -> if isPrime x then Some x else None)
      |> should equal [|2;3;5;7;11;13;17;19;23;29;31;37;41;43;47;53;59;61;67;71;73;79;83;89;97|]

      @"素数判定: 遅い
      https://atcoder.jp/contests/arc017/tasks/arc017_1
      https://qiita.com/drken/items/a14e9af0ca2d857dad23#問題-1-素数判定"
      let rec isPrime n =
        if n < 0L then isPrime (-n)
        elif n = 0L then false
        elif n = 1L then false
        else primeFactors n = [ { Number = n;Count = 1 } ]
      [1L..8L] |> List.filter isPrime |> should equal [2L;3L;5L;7L]

    @"https://jeremybytes.blogspot.com/2016/07/getting-prime-factors-in-f-with-good.html
    遅い.
    1の素因数分解を[1]とする(してしまう)"
    module PF2 =
      let rec getFactors n proposed acc =
        if n<=0L then failwith "be positive"
        elif n=1L then [1L]
        elif proposed=n then proposed::acc
        elif n%proposed=0L then getFactors (n/proposed) proposed (proposed::acc)
        else getFactors n (proposed+1L) acc
      let primeFactor n = getFactors n 2 []
      primeFactor 36L |> should equal [3L;3L;2L;2L]
      primeFactor 1L |> should equal [1L]
      primeFactor 2L |> should equal [2L]
      primeFactor 3L |> should equal [3L]
      primeFactor 4L |> should equal [2L;2L]

    @"遅い: 1の素因数分解を[]にする"
    module PF2_1 =
      let rec getFactors n proposed acc =
        if n<=0L then failwith "be positive"
        elif n=1L then []
        elif proposed=n then proposed::acc
        elif n%proposed=0L then getFactors (n/proposed) proposed (proposed::acc)
        else getFactors n (proposed+1L) acc
      let primeFactor n = getFactors n 2 []
      primeFactor 36L |> should equal [3L;3L;2L;2L]
      primeFactor 1L |> should equal ([]:list<int64>)
      primeFactor 2L |> should equal [2L]
      primeFactor 3L |> should equal [3L]
      primeFactor 4L |> should equal [2L;2L]

    @"https://atcoder.jp/contests/caddi2018/submissions/9944877"
    module PF3 =
      let rec f c i p =
        if p%i=0L then f (c+1L) i (p/i)
        elif c<>0L then (i,c) :: f 0L (i+1L) p
        elif p < i*i then [(p,1L)]
        else (i,c) :: f 0L (i+1L) p
      let pf p = f 0L 2L p
      // 2の倍数を含むと素因数に1が含まれてしまう
      pf 36 |> should equal [(2L,2L);(3L,2L);(1L,1L)]

    @"https://atcoder.jp/contests/abc142/submissions/7794564"
    module PF4 =
      let rec pfrec acc i n =
        if n<=1L then acc
        else if n<(i*i) then n::acc
        else if n%i=0L then pfrec (i::acc) i (n/i)
        else pfrec acc (i+1L) n
      let pf n = pfrec [] 2L n
      pf 1L |> should equal ([]:list<int64>)
      pf 2L |> should equal [2L]
      pf 3L |> should equal [3L]
      pf 4L |> should equal [2L;2L]
      pf 5L |> should equal [5L]
      pf 6L |> should equal [3L;2L]

    @"https://atcoder.jp/contests/abc142/submissions/34082293"
    module PF5 =
      let rec pfrec acc i n =
        match i,n with
        | _,n when n <= 1L -> acc
        | i,n when n < i * i -> n::acc
        | i,n when n % i = 0L -> pfrec (i::acc) i (n/i)
        | _ -> pfrec acc (i+1L) n
      let pf n = pfrec [] 2L n
      pf 1L |> should equal ([]:list<int64>)
      pf 2L |> should equal [2L]
      pf 3L |> should equal [3L]
      pf 4L |> should equal [2L;2L]
      pf 5L |> should equal [5L]
      pf 6L |> should equal [3L;2L]

    @"http://www.fssnip.net/3X"
    module FsSnip =
      let isPrime n =
        if n=0||n=1 then false
        else let sqn = n |> (float >> sqrt >> int) in [|2..sqn|] |> Array.forall (fun x -> n % x <> 0)

      let allPrimes =
        let rec f n = seq {
            if isPrime n then
              yield n
            yield! f (n+1)
          }
        f 2 // starting from 2

      allPrimes |> Seq.take 5 |> should equal (seq  [|2;3;5;7;11|])

    @"https://stackoverflow.com/questions/1097411/learning-f-printing-prime-numbers#answer-1097596
    素数のリストはhttps://atcoder.jp/contests/abc084/tasks/abc084_dと解説も参考になる.
    エラトステネスの篩(Sieve of Eratosthenes)で作るとよい."
    @"エラトステネスの篩: 配列で高速化.
    0からはじめていて, 配列の添字と実際の数を対応させている."
    let sieve N =
      let primes = Array.create (N+1) true
      primes.[0] <- false; primes.[1] <- false
      let rec go i p = if i>=(N+1) then () else (primes.[i] <- false; go (i+p) p)
      [|0..N|] |> Array.iter (fun p -> if primes.[p] then go (2*p) p)
      primes
    sieve 5 |> Array.indexed
    sieve 5 |> should equal [|false;false;true;true;false;true|]

    @"エラトステネスの篩: リストによる単純な実装"
    module SoSieve =
      let rec sieve = function
        | (p::xs) -> p :: sieve [ for x in xs do if x % p > 0 then yield x ]
        | []    -> []
      sieve [2..50] |> List.take 5 |> should equal [2;3;5;7;11]

    module SoPrime1 =
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

  @"<http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html>にある一連の問題の`F#`翻訳"
  module YetAnotherFSharpProblems =
    @"素因数分解 `factorization n`
    http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html#p51"
    let factorization n =
      let rec factor n m c = if n%m=0L then factor (n/m) m (c+1L) else (c,n)
      let rec iter i n a =
        if n=1L then a
        elif n<i*i then (n,1L)::a
        else let (c, m) = factor n i 0L in if c=0L then iter (i+2L) n a else iter (i+2L) m ((i,c)::a)
      let (c,m) = factor n 2L 0L in if c>0L then iter 3L m [(2L,c)] else iter 3L n []
    factorization 12345678L |> should equal [(14593L,1L);(47L,1L);(3L,2L);(2L,1L)]
    factorization 123456789L |> should equal [(3803L,1L);(3607L,1L);(3L,2L)]
    factorization 1234567890L |> should equal [(3803L,1L);(3607L,1L);(5L,1L);(3L,2L);(2L,1L)]
    factorization 1111111111L |> should equal [(9091L,1L);(271L,1L);(41L,1L);(11L,1L)]
    factorization 11111111111L |> should equal [(513239L,1L);(21649L,1L)]

    @"自然数`n`の約数の個数を求める `divisorNum n`
    http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html#p52"
    let divisorNum n = (1L,(factorization n)) ||> List.fold (fun a (_, x) -> a*(x+1L))
    divisorNum 12345678L |> should equal 24L
    divisorNum 123456789L |> should equal 12L
    divisorNum 1234567890L |> should equal 48L
    divisorNum 1111111111L |> should equal 16L
    divisorNum 11111111111L |> should equal 4L

    @"自然数`n`の約数の合計値を求める `divisorSum n`
    http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html#p53"
    let sigma (p:int64) n = List.map (pown p) [0..n]
    let divisorSum n = (1L, factorization n) ||> List.fold (fun a (p,x) -> a * List.sum (sigma p (int x)))
    divisorSum 12345678L |> should equal 27319968L
    divisorSum 123456789L |> should equal 178422816L
    divisorSum 1234567890L |> should equal 3211610688L
    divisorSum 1111111111L |> should equal 1246404096L
    divisorSum 11111111111L |> should equal 11111646000L

    @"自然数`n`の約数のリスト `divisor n`
    O(\sqrt{N})
    テストで確認を楽にするために`Array.sort`をつけているので不要なら削除する"
    let divisor n =
      let sqrtN = n+1L |> float |> sqrt |> int64
      [|1L..sqrtN|] |> Array.filter (fun x -> n%x=0L)
      |> Array.collect (fun x -> [|x;n/x|]) |> Array.distinct |> Array.sort
    divisor 1L |> should equal [|1L|]
    divisor 2L |> should equal [|1L;2L|]
    divisor 3L |> should equal [|1L;3L|]
    divisor 4L |> should equal [|1L;2L;4L|]
    divisor 5L |> should equal [|1L;5L|]
    divisor 12L |> should equal [|1L;2L;3L;4L;6L;12L|]

    @"自然数`n`の約数のリスト `divisor n`
    必ずしも速くないが確実"
    let divisor n = [|1L..n|] |> Array.filter (fun i -> n%i=0L)
    divisor 1L |> should equal [|1L|]
    divisor 2L |> should equal [|1L;2L|]
    divisor 3L |> should equal [|1L;3L|]
    divisor 4L |> should equal [|1L;2L;4L|]
    divisor 5L |> should equal [|1L;5L|]
    divisor 12L |> should equal [|1L;2L;3L;4L;6L;12L|]

    @"自然数`n`の約数のリスト `divisor n`
    http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html#p54
    直移植はバグがあって`1L`で動作しないため修正.
    (多分)遅い."
    let divisor n =
      let product: seq<int64> -> seq<int64> -> seq<int64> =
        fun xs ys -> Seq.allPairs xs ys |> Seq.map (fun (x,y) -> x*y)
      let sigma (p:int64) n = Seq.map (pown p) [0..n]
      match factorization n with
        | [] -> [1L]
        | (p1,x1)::xs ->
          ((sigma p1 (int x1)), seq xs) ||> Seq.fold (fun a (p,x) -> product (sigma p (int x)) a) |> Seq.sort |> Seq.toList
    divisor 1L |> should equal [1L]
    divisor 2L |> should equal [1L;2L]
    divisor 3L |> should equal [1L;3L]
    divisor 4L |> should equal [1L;2L;4L]
    divisor 5L |> should equal [1L;5L]
    divisor 12L |> should equal [1L;2L;3L;4L;6L;12L]

    @"自然数`n`以下の完全数のリスト `perfectNumbers n`
    http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html#p55"
    let perfectNumbers n = [2L..n] |> List.filter (fun x -> (divisorSum x - x)=x)
    perfectNumbers 10000L |> should equal [6L;28L;496L;8128L]

    @"自然数`n`以下の友愛数のリスト `amicableNumbers n`
    http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html#p56"
    let amicableNumbers n =
      ([2L..n],[])
      ||> List.foldBack (fun a x -> let m = divisorSum a - a in if a<m && ((divisorSum m) - m = a) then (a,m)::x else x)
    amicableNumbers 220L |> should equal [(220L,284L)]
    amicableNumbers 284L |> should equal [(220L,284L)]
    amicableNumbers 1500L |> should equal [(220L, 284L);(1184L, 1210L)]
    amicableNumbers 3000L |> should equal [(220L, 284L);(1184L, 1210L);(2620L, 2924L)]
    amicableNumbers 6000L |> should equal [(220L, 284L);(1184L, 1210L);(2620L, 2924L);(5020L, 5564L)]
    amicableNumbers 7000L |> should equal [(220L, 284L);(1184L, 1210L);(2620L, 2924L);(5020L, 5564L);(6232L, 6368L)]
    amicableNumbers 11000L |> should equal [(220L, 284L);(1184L, 1210L);(2620L, 2924L);(5020L, 5564L);(6232L, 6368L);(10744L, 10856L)]

    @"自然数`n`の分割数を求める関数`partitionNumber n`
    動的計画法を使う.
    http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html#p57"
    let partitionNumber n =
      (Array.create (n+1) 1, [|2..n|])
      ||> Array.fold (fun a1 k ->
        (a1, [|k..n|]) ||> Array.fold (fun a2 m -> Array.set a2 m (a2.[m] + a2.[m-k]); a2))
      |> fun a -> a.[n]
    partitionNumber 1 |> should equal 1
    partitionNumber 2 |> should equal 2
    partitionNumber 3 |> should equal 3
    partitionNumber 4 |> should equal 5
    partitionNumber 5 |> should equal 7
    partitionNumber 10 |> should equal 42
    partitionNumber 20 |> should equal 627
    partitionNumber 50 |> should equal 204226

    @"自然数`n`の分割の仕方を全て求める関数`partitionOfInterger n`
    http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html#p58"
    let partitionOfInteger n =
      let rec partInt n k xs ys =
        if n=0 then xs::ys
        elif n=1 then (1::xs)::ys
        elif k=1 then (List.replicate n 1 @ xs)::ys
        else let zs = partInt n (k-1) xs ys in if n-k>=0 then partInt (n-k) k (k::xs) zs else zs
      partInt n n [] []
    partitionOfInteger 5 |> should equal [[5];[1;4];[2;3];[1;1;3];[1;2;2];[1;1;1;2];[1;1;1;1;1]]
    partitionOfInteger 6 |> should equal [[6];[1;5];[2;4];[1;1;4];[3;3];[1;2;3];[1;1;1;3];[2;2;2];[1;1;2;2];[1;1;1;1;2];[1;1;1;1;1;1]]

    @"リストで表した集合の分割を全て求める関数`partitionOfSet xs`
    http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html#p59"
    let partitionOfSet xs =
      let rec delete x = function | [] -> [] | y::ys -> if x=y then ys else y::delete x ys
      let rec partSet: 'a list -> 'a list list -> 'a list list list -> 'a list list list = fun xs0 ys zs ->
        match xs0 with
          | [] -> ys::zs
          | x::xs ->
            List.foldBack (fun y a -> partSet xs ((x::y)::(delete y ys)) a) ys zs |> partSet xs ([x]::ys)
      partSet (List.rev xs) [] []
    partitionOfSet [1..2] |> should equal [[[1]; [2]]; [[1; 2]]]
    partitionOfSet [1..3] |> should equal [[[1];[2];[3]];[[1;2];[3]];[[1;3];[2]];[[1];[2;3]];[[1;2;3]]]
    partitionOfSet [1..4] |> should equal [[[1];[2];[3];[4]];[[1;2];[3];[4]];[[1;3];[2];[4]];[[1;4];[2];[3]];[[1];[2;3];[4]];[[1;2;3];[4]];[[1;4];[2;3]];[[1];[2;4];[3]];[[1;2;4];[3]];[[1;3];[2;4]];[[1];[2];[3;4]];[[1;2];[3;4]];[[1;3;4];[2]];[[1];[2;3;4]];[[1;2;3;4]]]

    @"集合を分割する方法の総数であるベル数を求める`bellNumber n`
    http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html#p60"
    """TODO
    let comb n r =
      let rec frec acc n r = if n=r || r=0 then acc else (frec (acc*(n-r+1)/r) n (r-1))
      if n-r<r then frec 1 n (n-r) else frec 1 n r
    [0..2] |> List.map (comb 2)
    [0..3] |> List.map (comb 3)
    [0..4] |> List.map (comb 4)
    [0..5] |> List.map (comb 5)
    """
    let comb n k = List.fold (fun s i -> s * (n-i+1L)/i ) 1L [1L..k]
    let bellNumber n =
      let rec iter i xs =
        if n=i then List.head xs
        else List.fold (fun acc (k,x) -> (comb i (int64 k))*x+acc) 0L (List.indexed xs) :: xs |> iter (i+1L)
      iter 0L [1L]
    bellNumber 0L  |> should equal 1L
    bellNumber 1L  |> should equal 1L
    bellNumber 2L  |> should equal 2L
    bellNumber 3L  |> should equal 5L
    bellNumber 4L  |> should equal 15L
    bellNumber 5L  |> should equal 52L
    bellNumber 10L |> should equal 115975L
    bellNumber 20L |> should equal 51724158235372L

    @"`k`個の要素をもつ集合`ls`を要素数が等しい`m`個の部分集合に分割する方法,
    部分集合の要素数`n`は`k/m`で`groupPartition n m ls`
    http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html#p61"
    // group_partition :: Eq a => Int -> Int -> [a] -> [[[a]]]
    let groupPartition n m xs =
      let rec delete x = function | [] -> [] | y::ys -> if x=y then ys else y::delete x ys
      let rec groupPart xs0 ys zs =
        match xs0 with
          | [] -> ys::zs
          | x::xs ->
            let zs' = List.foldBack (fun y acc ->
              if List.length y < n then groupPart xs ((x::y)::delete y ys) acc else acc) ys zs
            if List.length ys < m then groupPart xs ([x]::ys) zs' else zs'
      groupPart (List.rev xs) [] []
    groupPartition 2 2 [1;2;3;4] |> should equal [[[1;4];[2;3]];[[1;3];[2;4]];[[1;2];[3;4]]]
    groupPartition 2 3 [1..6] |> should equal [[[1;6];[2;5];[3;4]];[[1;5];[2;6];[3;4]];[[1;6];[2;4];[3;5]];[[1;4];[2;6];[3;5]];[[1;5];[2;4];[3;6]];[[1;4];[2;5];[3;6]];[[1;6];[2;3];[4;5]];[[1;3];[2;6];[4;5]];[[1;2];[3;6];[4;5]];[[1;5];[2;3];[4;6]];[[1;3];[2;5];[4;6]];[[1;2];[3;5];[4;6]];[[1;4];[2;3];[5;6]];[[1;3];[2;4];[5;6]];[[1;2];[3;4];[5;6]]]

    @"集合を`groupPartition`で分割する総数を求める関数`groupPartitionNumber n m`
    http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html#p62"
    let groupPartitionNumber n m =
      let fact n = Array.reduce (*) [|1L..n|]
      let comb n k = List.fold (fun s i -> s * (n-i+1L)/i ) 1L [1L..k]
      let rec groupPartNum k a =
        if k=0L then a / (fact m) else groupPartNum (k-n) (a * comb k n)
      groupPartNum (n*m) 1L
    groupPartitionNumber 2L 2L |> should equal 3L
    groupPartitionNumber 2L 3L |> should equal 15L
    groupPartitionNumber 3L 3L |> should equal 280L
    groupPartitionNumber 3L 4L |> should equal 15400L
    groupPartitionNumber 3L 5L |> should equal 1401400L

    @"`1`から`m`までの整数値で完全順列を生成する関数`perfectPermutation m`
    http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html#p63"
    let perfectPermutation m =
      let rec delete x = function | [] -> [] | y::ys -> if x=y then ys else y::delete x ys
      let rec permSub n xs ys zs =
        match xs with
          | [] -> List.rev ys::zs
          | _ ->
            (xs,zs) ||> List.foldBack (fun x a -> if x=n then a else permSub (n+1L) (delete x xs) (x::ys) a)
      permSub 1L [1L..m] [] []
    perfectPermutation 3L |> should equal [[2L;3L;1L];[3L;1L;2L]]
    perfectPermutation 4L |> should equal [[2L;1L;4L;3L];[2L;3L;4L;1L];[2L;4L;1L;3L];[3L;1L;4L;2L];[3L;4L;1L;2L];[3L;4L;2L;1L];[4L;1L;2L;3L];[4L;3L;1L;2L];[4L;3L;2L;1L]]


    @"完全順列の総数をモンモール数(Montmort number)を求める関数`montmortNumber n`
    http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html#p64"
    let montmortNumber n =
      let rec iter i a b = if n=i then a else iter (i+1L) b ((i+1L)*(a+b))
      iter 1L 0L 1L
    montmortNumber 1L |> should equal 0L
    montmortNumber 2L |> should equal 1L
    montmortNumber 3L |> should equal 2L
    montmortNumber 4L |> should equal 9L
    montmortNumber 5L |> should equal 44L
    montmortNumber 10L |> should equal 1334961L
    montmortNumber 20L |> should equal 895014631192902121L

    @"ラテン方陣を全て求める関数`latina n`
    http://www.nct9.ne.jp/m_hiroi/func/yahsp03.html#p65"
    let latina size =
      let rec delete x = function | [] -> [] | y::ys -> if x=y then ys else y::delete x ys
      let checkLatina n x xss = xss |> List.map (List.item (n-1)) |> List.contains x
      let rec solver n xs a b c =
        match xs with
          | [] ->
            if size-1=List.length b then (List.rev (List.rev a :: b) :: c)
            else let m = List.length b + 2 in solver 2 (delete m [1..size]) [m] (List.rev a :: b) c
          | _ ->
            (xs,c) ||> List.foldBack (fun x z -> if checkLatina n x b then z else solver (n+1) (delete x xs) (x::a) b z)
      solver 1 [1..size] [] [[1..size]] []
    latina 3 |> should equal [[[1;2;3];[2;3;1];[3;1;2]]]
    latina 4 |> should equal [[[1;2;3;4];[2;1;4;3];[3;4;1;2];[4;3;2;1]];
                              [[1;2;3;4];[2;1;4;3];[3;4;2;1];[4;3;1;2]];
                              [[1;2;3;4];[2;3;4;1];[3;4;1;2];[4;1;2;3]];
                              [[1;2;3;4];[2;4;1;3];[3;1;4;2];[4;3;2;1]]]
