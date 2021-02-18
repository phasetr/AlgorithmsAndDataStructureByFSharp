// https://atcoder.jp/contests/sumitrust2019/submissions/8729137
// 要整理・ドキュメンテーション
module AtCoder

open Microsoft.FSharp.Collections
open System
open System.Collections
open System.Collections.Generic

#nowarn "0025" // パターンマッチが不完全である警告の無効

module Seq =
    let interval startInclusive endExclusive =
        seq { startInclusive .. (endExclusive - 1) }

    let inline mapAdjacent (op: 'a -> 'a -> 'b) (source: seq<'a>): seq<'b> =
        match source with
        | source when Seq.isEmpty source -> Seq.empty
        | _ -> Seq.map2 op source (Seq.tail source)

module Array2D =
    let inline transpose (array: 'a [,]): 'a [,] =
        let transposed =
            Array2D.zeroCreate (Array2D.length2 array) (Array2D.length1 array)

        transposed
        |> Array2D.mapi (fun i k _ -> array.[k, i])

module InputOutputs =
    let read (): string = Console.ReadLine()
    let reads (): string [] = read().Split()

    let readMatrix (rowNum: int32): string [,] =
        let mutable lines = Array.zeroCreate rowNum
        for i in Seq.interval 0 rowNum do
            lines.[i] <- reads ()

        lines |> array2D

    let readInt32 (): int32 = read () |> int32
    let readInt64 (): int64 = read () |> int64
    let readInt32s (): int32 [] = reads () |> Array.map int32
    let readInt64s (): int64 [] = reads () |> Array.map int64

    let readMatrixInt32 (rowNum: int32): int32 [,] = readMatrix rowNum |> Array2D.map int32

    let readMatrixInt64 (rowNum: int32): int64 [,] = readMatrix rowNum |> Array2D.map int64

    let inline print (item: 'a): unit = printfn "%s" (string item)

    let inline printRow (line: seq<'a>): unit =
        let strs = line |> Seq.map string
        if not (Seq.isEmpty strs) then
            printf "%s" (Seq.head strs)
            for s in Seq.skip 1 strs do
                printf " %s" s
        printf "\n"

    let inline printColumn (line: seq<'a>): unit =
        for item in line do
            print item

    let inline printGridGraph (lines: 'a [,]): unit =
        for i in (Seq.interval 0 lines.Length) do
            lines.[i, *]
            |> Seq.map string
            |> String.concat " "
            |> print

module NumericFunctions =
    type Mods =
        { Divisor: int32 }

        member this.Mod(a: int64) =
            let b = a % int64 this.Divisor |> int32
            if b < 0 then b + this.Divisor else b

        member this.Mod(a: int32) = this.Mod(int64 a)

        member this.Add (a: int32) (b: int32): int32 = (this.Mod a + this.Mod b) % this.Divisor

        member this.Sub (a: int32) (b: int32): int32 =
            let sub = (this.Mod a - this.Mod b) % this.Divisor
            if sub < 0 then sub + this.Divisor else sub

        member this.Mul (a: int32) (b: int32): int32 =
            (int64 (this.Mod a) * int64 (this.Mod b)) % int64 this.Divisor
            |> int32

        member this.Div (a: int32) (b: int32): int32 = this.Mul a (this.Inv b)

        /// 二分累積 O(Log N)
        member this.Pow (b: int32) (n: int32): int32 =
            let digit = int32 (Math.Log(float n, 2.0))

            let seqs =
                seq { 0 .. digit }
                |> Seq.scan (fun acm _ -> this.Mul acm acm) b
                |> Seq.toArray

            seq { 0 .. digit }
            |> Seq.fold (fun acm i -> if ((n >>> i) &&& 1) = 1 then this.Mul acm seqs.[i] else acm) 1

        /// フェルマーの小定理より
        member this.Inv(a: int32): int32 = this.Pow a (this.Divisor - 2)

        member this.Perm (n: int32) (k: int32): int32 =
            match (n, k) with
            | (n, _) when n < 0 -> invalidArg "n" "n >= 0"
            | (_, k) when k < 0 -> invalidArg "k" "k >= 0"
            | (n, k) when k > n -> 0
            | _ -> seq { n - k + 1 .. n } |> Seq.fold this.Mul 1

        member this.FactTable(nMax: int32): int32 [] =
            seq { 1 .. nMax }
            |> Seq.scan this.Mul 1
            |> Seq.toArray

        /// パスカルの三角形 O(N^2)
        member this.CombTable(nMax: int32): int32 [,] =
            let table = Array2D.zeroCreate (nMax + 1) (nMax + 1)
            for n in 0 .. nMax do
                for k in 0 .. nMax do
                    match (n, k) with
                    | (n, k) when n < k -> table.[n, k] <- 0
                    | (_, k) when k = 0 -> table.[n, k] <- 1
                    | _ ->
                        table.[n, k] <- int64 table.[n - 1, k - 1]
                                        + int64 table.[n - 1, k] % int64 this.Divisor
                                        |> int32
            table

    let isEven (a: int64): bool = a % 2L = 0L
    let isOdd (a: int64): bool = not (isEven a)

    /// ユークリッドの互除法 O(Log N)
    let rec gcd (m: int64) (n: int64): int64 =
        match (m, n) with
        | (m, _) when m <= 0L -> invalidArg "m" "m <= 0"
        | (_, n) when n <= 0L -> invalidArg "n" "n <= 0"
        | (m, n) when m < n -> gcd n m
        | (m, n) when m % n = 0L -> n
        | _ -> gcd n (m % n)

    /// gcdを使っているため O(Log N)
    let lcm (m: int64) (n: int64): int64 =
        (bigint m)
        * (bigint n)
        / bigint (gcd m n)
        |> Checked.int64

    /// O(√N)
    let divisors (m: int64): seq<int64> =
        match m with
        | m when m <= 0L -> invalidArg "m" "m <= 0"
        | _ ->
            let sqrtM = int (sqrt (float m))

            let overRootM =
                Seq.interval 1 (sqrtM + 1)
                |> Seq.map int64
                |> Seq.filter (fun d -> m % d = 0L)
                |> Seq.rev

            overRootM
            |> if int64 sqrtM * int64 sqrtM = m then Seq.tail else id
            |> Seq.map (fun x -> m / x)
            |> Seq.append overRootM

    /// O(√N)
    let rec commonDivisor (m: int64) (n: int64): seq<int64> =
        match (m, n) with
        | (_, n) when n <= 0L -> invalidArg "n" "n <= 0"
        | (m, n) when m < n -> commonDivisor n m
        | _ -> divisors n |> Seq.filter (fun nd -> m % nd = 0L)

    /// エラトステネスの篩 O(N loglog N)
    let primes (n: int32): seq<int32> =
        match n with
        | n when n <= 1 -> invalidArg "n" "n <= 1"
        | _ ->
            let sqrtN = int32 (sqrt (float n))
            let mutable sieve = Seq.interval 2 (n + 1) |> Seq.toList
            let mutable ps = []
            while not (List.isEmpty sieve)
                  && List.head sieve
                  <= sqrtN do
                let m = List.head sieve
                ps <- m :: ps
                sieve <- List.filter (fun p -> p % m <> 0) sieve
            List.append ps sieve |> Seq.ofList

    /// 試し割り法 O(√N)
    let primeFactrization (n: int64): seq<int64 * int64> =
        match n with
        | n when n <= 1L -> invalidArg "n" "n <= 1"
        | _ ->
            let mutable i = 2L
            let mutable m = n
            let mutable ps = []
            while i * i <= n do
                if m % i = 0L then
                    let mutable count = 0L
                    while m % i = 0L do
                        count <- count + 1L
                        m <- m / i
                    ps <- (int64 i, count) :: ps
                i <- i + 1L
            if m <> 1L then ps <- (m, 1L) :: ps
            List.toSeq ps

module Algorithm =
    let rec binarySearch (predicate: int64 -> bool) (exclusiveNg: int64) (exclusiveOk: int64): int64 =
        match (exclusiveOk, exclusiveNg) with
        | (ok, ng) when abs (ok - ng) = 1L -> ok
        | _ ->
            let mid = (exclusiveOk + exclusiveNg) / 2L
            if predicate mid then binarySearch predicate exclusiveNg mid else binarySearch predicate mid exclusiveOk

    let runLengthEncoding (source: string): seq<string * int32> =
        match source.Length with
        | n when n = 0 -> Seq.empty
        | n ->
            let cutIxs =
                Seq.interval 1 n
                |> Seq.filter (fun i -> source.[i] <> source.[i - 1])

            Seq.append (Seq.append (seq { yield 0 }) cutIxs) (seq { yield n })
            |> Seq.mapAdjacent (fun i0 i1 -> (string source.[i0], i1 - i0))

    let rec ternarySearchDownward (left: float) (right: float) (convexFunction: float -> float) (allowableError: float) =
        match left, right, convexFunction, allowableError with
        | l, r, f, e when r - l < e -> l
        | l, r, f, e ->
            let ml = l + (r - l) / 3.0
            let mr = l + (r - l) / 3.0 * 2.0
            if f ml < f mr then ternarySearchDownward l mr f e
            else if f ml > f mr then ternarySearchDownward ml r f e
            else ternarySearchDownward ml mr f e

    let rec ternarySearchUpward (left: float) (right: float) (convexFunction: float -> float) (allowableError: float) =
        match left, right, convexFunction, allowableError with
        | l, r, f, e when r - l < e -> l
        | l, r, f, e ->
            let ml = l + (r - l) / 3.0
            let mr = l + (r - l) / 3.0 * 2.0
            if f ml < f mr then ternarySearchUpward ml r f e
            else if f ml > f mr then ternarySearchUpward l mr f e
            else ternarySearchUpward ml mr f e

    let checkFlag (flag: int) (flagNumber: int): bool =
        if (flag < 0) then invalidArg "flag" "flag < 0"
        if (flagNumber < 0) then invalidArg "flagNumber" "flagNumber < 0"
        flag >>> flagNumber &&& 1 = 1

    let rec permutaions (xs: list<'a>): list<list<'a>> =
        match xs with
        | [] -> [ [] ]
        | [ x ] -> [ [ x ] ]
        | _ ->
            xs
            |> List.mapi (fun i x -> x, (List.append (List.take i xs) (List.skip (i + 1) xs)))
            |> List.collect (fun (y, other) -> List.map (fun ys -> y :: ys) (permutaions other))

    let rec fastPermutations (xs: list<'a>) =
        let rec insertions (x: 'a) (ys: list<'a>): list<list<'a>> =
            match ys with
            | [] -> [ [ x ] ]
            | (z :: zs) as l ->
                (x :: l)
                :: (List.map (fun w -> z :: w) (insertions x zs))

        match xs with
        | [] -> [ [] ]
        | y :: ys -> List.collect (insertions y) (fastPermutations ys)
