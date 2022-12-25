#r "nuget: FsUnit"
open FsUnit

(*
let H,W,Ia = 3,4,[|"aabb";"aabb";"aacc"|]
let H,W,Ia = 2,2,[|"aa";"bb"|]
let H,W,Ia = 5,1,[|"t";"w";"e";"e";"t"|]
let H,W,Ia = 2,5,[|"abxba";"abyba"|]
let H,W,Ia = 1,1,[|"z"|]
*)
let solve H W Ia =
  let Aq = Ia |> String.concat "" |> Seq.groupBy id |> Seq.map (snd >> Seq.length)
  let s4 = Aq |> Seq.sumBy (fun x -> x/4)
  let s1 = Aq |> Seq.sumBy (fun x -> x%2)
  match H%2=0,W%2=0 with
    | (false,false) -> (H-1)*(W-1)/4 <= s4 && s1=1
    | (true, true)  -> Aq |> Seq.forall (fun x -> x%4=0)
    | (false, true) -> (H-1)*W/4 <= s4 && s1=0
    | (true, false) -> H*(W-1)/4 <= s4 && s1=0
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

@"テスト用"
let solve H W Ia =
  let Aq = Ia |> String.concat "" |> Seq.groupBy id |> Seq.map (snd >> Seq.length)
  let s4 = Aq |> Seq.sumBy (fun x -> x/4)
  let s1 = Aq |> Seq.sumBy (fun x -> x%2)
  printfn "%A" (Aq,s4,s1)
  match H%2=0,W%2=0 with
    | (false,false) ->
      printfn "((H-1)*(W-1)/4, s4) = %A" ((H-1)*(W-1)/4, s4)
      (H-1)*(W-1)/4 <= s4 && s1=1
    | (true, true)  -> Aq |> Seq.forall (fun x -> x%4=0)
    | (false, true) ->
      printfn "((H-1)*W/4, s4) = %A" ((H-1)*W/4, s4)
      (H-1)*W/4 <= s4 && s1=0
    | (true, false) ->
      printfn "(H*(W-1)/4, s4) = %A" (H*(W-1)/4, s4)
      H*(W-1)/4 <= s4 && s1=0
  |> fun b -> if b then "Yes" else "No"
