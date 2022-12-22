// https://atcoder.jp/contests/abc070/submissions/9907017
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

type PriorityQueue<'T>(compare: 'T -> 'T -> int) =
    let _heap = ResizeArray<'T>() // 二分ヒープ
    let _compare = compare // 比較関数
    let parent n = (n - 1) / 2
    let leftChild n = (n <<< 1) + 1
    let rightChild n = (n <<< 1) + 2

    let swap x y =
        let tmp = _heap.[x]
        _heap.[x] <- _heap.[y]
        _heap.[y] <- tmp

    /// ここでの比較は昇順ソートを基準に考えている
    member self.Compare(x: int, y: int) = (_compare _heap.[x] _heap.[y]) < 0

    /// O(log n)
    member self.Enque(x: 'T) =
        let size = _heap.Count
        _heap.Add(x)
        // 親と値を入れ替えていく
        let rec loop k =
            match k > 0 with
            | true ->
                let p = parent k
                match self.Compare(k, p) with
                | true ->
                    swap k p
                    loop p
                | _ -> ()
            | _ -> ()
        loop size

    /// O(log n)
    member self.Deque() =
        let res = _heap.[0]
        // 末尾ノードを根に持ってくる
        let size = _heap.Count - 1
        _heap.[0] <- _heap.[size]
        _heap.RemoveAt(size)
        // 葉ノードに達するまで子と値を入れ替えていく
        let rec loop k =
            let left = leftChild k
            match left < size with
            | true ->
                let right = rightChild k

                let c =
                    if right < size && self.Compare(right, left)
                    then right
                    else left
                match self.Compare(c, k) with
                | true ->
                    swap c k
                    loop c
                | _ -> ()
            | _ -> ()
        loop 0
        res

    member self.Any(): bool = _heap.Count > 0

    member self.Peek(): 'T = _heap.[0]

    member self.Dump() = String.Join(" ", _heap)

type Edge<'T when 'T: comparison> =
    { from: int
      toward: int
      cost: 'T }

[<RequireQualifiedAccess>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Edge =
    open System

    let init (from: int) (toward: int) (cost: 'a): Edge<'a> =
        { Edge.from = from
          toward = toward
          cost = cost }

    let initWithoutFrom (toward: int) (cost: 'a): Edge<'a> = init -1 toward cost

    /// 昇順
    let less (x: Edge<'a>) (y: Edge<'a>) = (x.cost :> IComparable<_>).CompareTo(y.cost)

    /// 降順
    let greater (x: Edge<'a>) (y: Edge<'a>) = (y.cost :> IComparable<_>).CompareTo(x.cost)

/// 重み付き辺集合
type Edges<'a when 'a: comparison> = ResizeArray<Edge<'a>>

/// 重み付きグラフ
type WeightedGraph<'a when 'a: comparison> = Edges<'a> array

[<RequireQualifiedAccess>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module WeightedGraph =
    let inline init (n: int): WeightedGraph<'a> = Array.init n (fun _ -> ResizeArray<Edge<'a>>())

/// 重みなしグラフ
type UnWeightedGraph = ResizeArray<int> array

[<RequireQualifiedAccess>]
module Dijkstra =

    /// ダイクストラ基本形
    /// 頂点startからの全点間最短路配列を返す
    /// 到達できないノードにはinfが格納される
    /// O(E log V)
    let inline main (graph: WeightedGraph< ^a >) (startNode: int) (inf: ^a): ^a array =
        let nedge = graph |> Array.length // ノード数
        let dist = Array.init nedge (fun _ -> inf) // 始点からの距離
        let zero = LanguagePrimitives.GenericZero
        dist.[startNode] <- zero
        let heap = PriorityQueue<Edge<'a>>(Edge.less) // コストの低い順に探索する
        let start = Edge.initWithoutFrom startNode dist.[startNode]
        heap.Enque(start)
        while heap.Any() do
            let from = heap.Deque()
            match dist.[from.toward] < from.cost with
            | true -> ()
            | _ ->
                for edge in graph.[from.toward] do
                    let nextCost = edge.cost + from.cost
                    if dist.[edge.toward] <= nextCost then
                        ()
                    else
                        dist.[edge.toward] <- nextCost
                        let nextEdge = Edge.initWithoutFrom edge.toward dist.[edge.toward]
                        heap.Enque(nextEdge)
        dist

let main() =
    let n = read int
    let graph = WeightedGraph.init n
    for i in 0 .. n - 2 do
        let [| a; b; c |] = reada int
        let a, b = a - 1, b - 1
        let c = int64 c
        graph.[a].Add(Edge.initWithoutFrom b c)
        graph.[b].Add(Edge.initWithoutFrom a c)

    let [| q; k |] = reada int
    let k = k - 1
    let inf = Int64.MaxValue
    let dist = Dijkstra.main graph k inf
    for i in 0 .. q - 1 do
        let [| x; y |] = reada int
        let x, y = x - 1, y - 1
        let ans = dist.[x] + dist.[y]
        puts ans
    ()

main()
writer.Close()
