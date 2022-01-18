@"https://atcoder.jp/contests/abc124/submissions/8079073"
#r "nuget: FsUnit"
open FsUnit

let paturn1 (S: string) =
    seq{0..S.Length-1}
    |> Seq.map (fun i -> if i%2=0 then '0' else '1')
    |> Seq.toArray
let paturn2 (S: string) =
    seq{0..S.Length-1}
    |> Seq.map (fun i -> if i%2=0 then '1' else '0')
    |> Seq.toArray

let compare (S: string) (paturn: char[]) =
    S.ToCharArray()
    |> Seq.zip (paturn)
    |> Seq.fold (fun count (x,y) ->if x<>y then count+1 else count ) 0
let solve S =
    min (compare S (paturn1 S)) (compare S (paturn2 S))
let S = stdin.ReadLine()
solve S |> stdout.WriteLine

paturn1 "000" |> should equal [|'0';'1';'0'|]
solve "000" |> should equal 1
solve "10010010" |> should equal 3
solve "0" |> should equal 0
