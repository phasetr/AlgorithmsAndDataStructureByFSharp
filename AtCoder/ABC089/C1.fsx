@"https://atcoder.jp/contests/abc089/tasks/abc089_c
- 1 \leq N \leq 10^5
- S_i は英大文字からなる
- 1 \leq |S_i| \leq 10
- S_i \neq S_j (i \neq j)"
#r "nuget: FsUnit"
open FsUnit

@".NET Core 3.1.201では Map.change がない模様."
let solve N (Sa: array<string>) =
    let m = Map [('M',0L);('A',0L);('R',0L);('C',0L);('H',0L)]
    (m, Sa) ||> Array.fold (fun accm S ->
        accm.Change (S.[0], (function
            | Some s -> Some (s+1L)
            | None -> None)))
    |> fun m ->
        let M,A,R,C,H = m.['M'],m.['A'],m.['R'],m.['C'],m.['H']
        M*A*R + M*A*C + M*A*H + M*R*C + M*R*H + M*C*H + A*R*C + A*R*H + A*C*H + R*C*H
let N = stdin.ReadLine() |> int
let Sa = [| for i in 1..N do stdin.ReadLine() |]
solve N Sa |> stdout.WriteLine

solve 5 [|"MASHIKE";"RUMOI";"OBIRA";"HABORO";"HOROKANAI"|] |> should equal 2L
solve 4 [|"ZZ";"ZZZ";"Z";"ZZZZZZZZZZ"|] |> should equal 0L
solve 5 [|"CHOKUDAI";"RNG";"MAKOTO";"AOKI";"RINGO"|] |> should equal 7L
