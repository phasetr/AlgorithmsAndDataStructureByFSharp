#r "nuget: FsUnit"
open FsUnit

// 13B_py_00.pyのソース内コメント参照
type puzzle = string*int*int // state: パズルの状態, p: 0の位置, cnt: 交換回数
let solve S =
  let swap (s:string) i j =
    let sa = s |> Seq.toArray
    let t = sa.[i] in sa.[i] <- sa.[j]; sa.[j] <- t
    sa |> Array.map string |> String.concat ""

  // 処理をゴールの状態からはじめて入力の状態に持っていく形にする
  let goal = "123456780"
  let ng = [|(2,3);(3,2);(5,6);(6,5)|]

  // 交換した状態はキューの後ろに追加: 後ろに交換回数の多い状態がどんどん積まれる
  // 交換回数が少ないキューの前から適切な状態かチェックする
  let rec frec used = function
    | [] -> failwith "Cannot get the answer"
    | (state,zp,cnt)::t ->
      if state = S then cnt
      else
        let newPuzzles: puzzle list =
          // i: 0の場所を見て交換できる盤面上の位置
          [ for i in [zp-1;zp+1;zp-3;zp+3] do if 0<=i && i<=8 && (not (Array.contains (zp,i) ng)) then yield i ]
          |> List.map (fun p -> (swap state zp p,p,cnt+1)) // 適切にカウントアップしながらパズルの状態・0の位置・交換回数を記録して試行キューに追加
          |> List.filter (fun (state,_,_) -> List.contains state used |> not)
        frec (used @ (newPuzzles |> List.map (fun (s,_,_) -> s))) (t @ newPuzzles)
  frec [goal] [(goal,8,0)]

let S = [| for i in 1..3 do (stdin.ReadLine().Split() |> String.concat "") |] |> String.concat ""
solve S |> stdout.WriteLine

let S = "130425786"
solve S |> should equal 4
