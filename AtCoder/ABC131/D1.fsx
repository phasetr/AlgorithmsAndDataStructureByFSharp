@"https://atcoder.jp/contests/abc131/tasks/abc131_d
入力はすべて整数
1 \leq N \leq 2 \times 10^5
1 \leq A_i, B_i \leq 10^9 (1 \leq i \leq N)"
#r "nuget: FsUnit"
open FsUnit

@"締切が早い順に処理する.
締切が同じならどちらを処理しても結果は同じ."
let solve N Ta =
    Ta |> Array.sortBy snd
    |> Array.fold (fun (t,res) (a,b) -> (t+a, res && t+a<=b)) (0, true)
    |> fun (_,b) -> if b then "Yes" else "No"
let N = stdin.ReadLine() |> int
let Ta = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> (int x.[0], int x.[1])) |]
solve N Ta |> stdout.WriteLine

solve 5 [|(2,4);(1,9);(1,8);(4,9);(3,12)|] |> should equal "Yes"
solve 3 [|(334,1000);(334,1000);(334,1000)|] |> should equal "No"
solve 30 [|(384,8895);(1725,9791);(170,1024);(4,11105);(2,6);
          (578,1815);(702,3352);(143,5141);(1420,6980);(24,1602);
          (849,999);(76,7586);(85,5570);(444,4991);(719,11090);
          (470,10708);(1137,4547);(455,9003);(110,9901);(15,8578);
          (368,3692);(104,1286);(3,4);(366,12143);(7,6649);
          (610,2374);(152,7324);(4,7042);(292,11386);(334,5720)|]
          |> should equal "Yes"
