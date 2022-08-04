#r "nuget: FsUnit"
open FsUnit

// A problem in functional programming in quick sort https://togetter.com/li/445854?page=2
// A benchmark by Haskell https://kazu-yamamoto.hatenablog.jp/entry/20120706/1341546985
// Famous, problematic quick sort https://fsharpforfunandprofit.com/posts/fvsc-quicksort/
module Quick1 =
  let rec qsort =
    function
    | [] -> []
    | first :: rest ->
      let smaller, larger = List.partition ((>=) first) rest
      List.concat
        [qsort smaller; [ first ]; qsort larger]
  qsort [1;5;23;18;9;1;3 ] |> should equal [1; 1; 3; 5; 9; 18; 23]

module Quick2 =
  // http://www.fssnip.net/bn/title/Inplace-parallel-QuickSort
  open System
  open System.Threading

  /// Rewrite the input array
  let qsort (a: 'a []) =
    let rand = Random() // for random pivot choice
    // swaps elements of array a with indices i and j
    let swap (a: 'a []) i j =
      let temp = a.[i]
      a.[i] <- a.[j]
      a.[j] <- temp

    // sorts subarray [l; r) of array a in-place
    let rec qsort2range (a: 'a []) l r =
      match r - l with
      | 0
      | 1 -> ()
      | n ->
        // preprocess: swap pivot to 1st position
        swap a l <| rand.Next(l, r)
        let p = a.[l]
        // scan and partitioning
        let mutable i = l + 1 // left from i <=> less than pivot part
        for j in (l + 1) .. (r - 1) do
          //preserve invariant: [p|  <p |i >p  |j  unpartitioned  ]
          if a.[j] < p then
            swap a j i
            i <- i + 1
        swap a (i - 1) l // place pivot in appropriate pos.
        let iImmutable = i // instead of using ref cells
        ThreadPool.QueueUserWorkItem(fun _ -> qsort2range a l (iImmutable - 1))
        |> ignore
        ThreadPool.QueueUserWorkItem(fun _ -> qsort2range a iImmutable r)
        |> ignore
    qsort2range a 0 a.Length

  qsort [|1;5;23;18;9;1;3|] |> should equal [|1;1;3;5;9;18;23|]
