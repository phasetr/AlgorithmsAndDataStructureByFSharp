@"https://atcoder.jp/contests/abc057/tasks/abc057_b
1≦N,M≦50
-10^8≦a_i,b_i,c_j,d_j≦10^8
入力は全て整数である。"
#r "nuget: FsUnit"
open FsUnit

let N = 2
let M = 2
let ss = [|(2,0);(0,0)|]
let cps = [|(-1,0);(1,0)|]
@"N,Mの値から見て全チェックできる."
let solve N M ss cps =
    let l1d (abx,aby) (cdx,cdy) = (abs (abx-cdx)) + (abs (aby-cdy))
    let minChkPt ab =
        cps |> Array.mapi (fun i cd -> (i+1, l1d ab cd))
        |> Array.minBy snd
        |> fst
    ss |> Array.map (fun ab -> minChkPt ab)

let N, M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let ss = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int |> fun x -> (x.[0],x.[1])) |]
let cps = [| for i in 1..M do (stdin.ReadLine().Split() |> Array.map int |> fun x -> (x.[0],x.[1])) |]
solve N M ss cps |> Array.map string |> String.concat "\n" |> stdout.WriteLine

solve 2 2 [|(2,0);(0,0)|] [|(-1,0);(1,0)|] |> should equal [|2;1|]
solve 3 4 [|(10,10);(-10,-10);(3,3)|] [|(1,2);(2,3);(3,5);(3,5)|] |> should equal [|3;1;2|]
solve 5 5 [|(-100000000,-100000000);(-100000000,100000000);(100000000,-100000000);(100000000,100000000);(0,0)|] [|(0,0);(100000000,100000000);(100000000,-100000000);(-100000000,100000000);(-100000000,-100000000)|] |> should equal [|5;4;3;2;1|]
