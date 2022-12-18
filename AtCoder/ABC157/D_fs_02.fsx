// https://atcoder.jp/contests/abc157/submissions/10481595
open System
open System.Collections.Generic

[<AutoOpen>]
module Cin =
    let read f = stdin.ReadLine() |> f
    let reada f = stdin.ReadLine().Split() |> Array.map f
    let readChars() = read string |> Seq.toArray
    let readInts() = readChars() |> Array.map (fun x -> Convert.ToInt32(x.ToString()))

[<AutoOpen>]
module Cout =
    let writer = new IO.StreamWriter(new IO.BufferedStream(Console.OpenStandardOutput()))
    let print (s: string) = writer.Write s
    let println (s: string) = writer.WriteLine s
    let inline puts (s: ^a) = string s |> println

// -----------------------------------------------------------------------------------------------------

type UnionFind =
    {
      /// 添字iが属するグループID (0-indexed)
      par: int array
      /// 各集合の要素数
      size: int array }

    /// xの先祖(xが属するグループID)
    member self.Root(x: int) =
        let par = self.par

        let rec loop x =
            match x = par.[x] with
            | true -> x
            | false ->
                let px = par.[x]
                par.[x] <- loop px
                par.[x]
        loop x

    /// 連結判定
    /// ならし O(α(n))
    member self.Find(x: int, y: int) = self.Root(x) = self.Root(y)

    /// xとyを同じグループに併合
    /// ならし O(α(n))
    member self.Unite(x: int, y: int): bool =
        let par, size = self.par, self.size
        let rx, ry = self.Root(x), self.Root(y)
        match rx = ry with
        | true -> false // 既に同じグループ
        | _ ->
            // マージテク(大きい方に小さい方を併合)
            let large, small =
                if size.[rx] < size.[ry] then ry, rx else rx, ry
            par.[small] <- large
            size.[large] <- size.[large] + size.[small]
            size.[small] <- 0
            true

    /// xが属する素集合の要素数
    /// O(1)
    member self.Size(x: int): int =
        let rx = self.Root(x)
        self.size.[rx]

    /// 連結成分の個数
    /// O(n)
    member self.TreeNum: int =
        let par = self.par
        let mutable cnt = 0
        par
        |> Array.iteri (fun i x ->
            if i = x then cnt <- cnt + 1)
        cnt

[<RequireQualifiedAccess>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module UnionFind =

    /// O(n)
    let init (n: int): UnionFind =
        let par = Array.init n id
        let size = Array.init n (fun _ -> 1)
        { UnionFind.par = par
          size = size }

type UnWeightedGraph = ResizeArray<int> array

[<RequireQualifiedAccess>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module UnWeightedGraph =
    let inline init (n: int): UnWeightedGraph = Array.init n (fun _ -> ResizeArray<int>())

// -----------------------------------------------------------------------------------------------------

let main() =
    let [| N; M; K |] = reada int
    let uf = UnionFind.init N
    // 直接つながっているノード
    let directs = UnWeightedGraph.init N
    for i in 0 .. M - 1 do
        let [| a; b |] = reada int
        let a, b = a - 1, b - 1
        directs.[a].Add(b)
        directs.[b].Add(a)
        uf.Unite(a, b) |> ignore
    let blocks = UnWeightedGraph.init N
    for i in 0 .. K - 1 do
        let [| a; b |] = reada int
        let a, b = a - 1, b - 1
        blocks.[a].Add(b)
        blocks.[b].Add(a)

    let ans = Array.zeroCreate N
    for i in 0 .. N - 1 do
        let mutable a = uf.Size(i)
        // 直接の友達はアウト
        a <- a - directs.[i].Count
        // 自分自身
        a <- a - 1
        // 間接的には友達だが、たがいにブロック関係 -> 辿れない
        for b in blocks.[i] do
            if uf.Find(i, b) then a <- a - 1
        ans.[i] <- max a 0

    String.Join(" ", ans) |> puts

    ()

// -----------------------------------------------------------------------------------------------------
main()
writer.Dispose()
