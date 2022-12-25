#r "nuget: FsUnit"
open FsUnit

(*
let H,W,Ia = 3,4,[|"aabb";"aabb";"aacc"|]
let H,W,Ia = 2,2,[|"aa";"bb"|]
let H,W,Ia = 5,1,[|"t";"w";"e";"e";"t"|]
let H,W,Ia = 2,5,[|"abxba";"abyba"|]
let H,W,Ia = 1,1,[|"z"|]

let H,W,Ia = 3,3,[|"aaa";"bbb";"ccc"|]
let H,W,Ia = 1,4,[|"aaab"|]
let H,W,Ia = 1,6,[|"aaabbb"|]
*)
@"このコードはACで通ってしまうが, 下に追加したテストケースを満たさない不適なコード"
let solve H W Ia =
  let Aq = Ia |> String.concat "" |> Seq.groupBy id |> Seq.map (snd >> Seq.length)
  let m4 = Aq |> Seq.map (fun x -> x%4)
  let x = m4 |> Seq.sumBy (fun x -> if x=1 then 1 else 0)
  let y = m4 |> Seq.sumBy (fun x -> if x=2 then 1 else 0)
  let s4 = Aq |> Seq.sumBy (fun x -> x/4)
  let s1 = Aq |> Seq.sumBy (fun x -> x%2)
  match H%2=0,W%2=0 with
    | (true, true)  -> x=0 && y=0
    | (true, false) -> x=0 && y <= H/2
    | (false, true) -> x=0 && y <= W/2
    | (false,false) -> x=1 && y <= (H+W)/2 - 1
  |> fun b -> if b then "Yes" else "No"

let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init H (fun _ -> stdin.ReadLine())
solve H W Ia |> stdout.WriteLine

solve 3 4 [|"aabb";"aabb";"aacc"|] |> should equal "Yes"
solve 2 2 [|"aa";"bb"|] |> should equal "No"
solve 5 1 [|"t";"w";"e";"e";"t"|] |> should equal "Yes"
solve 2 5 [|"abxba";"abyba"|] |> should equal "No"
solve 1 1 [|"z"|] |> should equal "Yes"

solve 3 3 [|"aba";"cdc";"aba"|] |> should equal "Yes"
solve 3 3 [|"aba";"cde";"aba"|] |> should equal "No"
solve 3 3 [|"aaa";"bbb";"ccc"|] |> should equal "No"
solve 1 4 [|"aaab"|] |> should equal "No"
solve 1 6 [|"aaabbb"|] |> should equal "No"
solve 1 3 [|"aaa"|] |> should equal "Yes"
