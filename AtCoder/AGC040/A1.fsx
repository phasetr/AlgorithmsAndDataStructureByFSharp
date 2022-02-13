@"https://atcoder.jp/contests/agc040/tasks/agc040_a
2≤N≤5×10^5"
#r "nuget: FsUnit"
open FsUnit

let S = "<>>><<><<<<<>>><"
let s = Seq.toArray S
let N = Array.length s + 1
let i = 3
s.[0..(i-1)] |> Array.rev |> Array.takeWhile (fun c -> c='>')
s.[(i+1)..] |> Array.takeWhile (fun c -> c='<')
[|1..N|] |> Array.map (fun i ->
    let b = s.[0..i-1] |> Array.rev |> Array.takeWhile (fun c -> c='>') |> Array.length
    let f = s.[i..] |> Array.takeWhile (fun c -> c='<') |> Array.length
    max b f)
|> Array.sum

"'>'が続くところは後ろから小さい値を取りたい.
最初に'<'が来たところは0を置けばいい.
'<'と'>'の間の勘定が重要か.

結局, 各a_iは左に連続する'<'の数と,
右に連続する'>'の数のうちの大きい方が来る."
let solve S =
    let left = Seq.scan(fun count s -> if s='<' then count+1L else 0L) 0L S
    let right = Seq.scanBack(fun s count -> if s='>' then count+1L else 0L) S 0L
    (0L, left, right) |||> Seq.fold2 (fun acc l r -> acc + (max l r))

let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "<>>" |> should equal 3L
solve "<>>><<><<<<<>>><" |> should equal 28L
