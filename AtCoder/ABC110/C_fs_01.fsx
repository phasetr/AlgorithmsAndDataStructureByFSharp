// https://atcoder.jp/contests/abc110/submissions/24078386
let s = stdin.ReadLine()
let t = stdin.ReadLine()

let toInt c = int c - int 'a'

let mutable se = [|for i in 0..toInt 'z' -> -1 |]
let mutable te = [|for i in 0..toInt 'z' -> -1 |]

let rec ans index =
  if index = s.Length then "Yes"
  else
    let sn = toInt s.[index]
    let tn = toInt t.[index]
    do
      if se.[sn] = -1 then se.[sn] <- tn
      if te.[tn] = -1 then te.[tn] <- sn

    if se.[sn] = tn && te.[tn] = sn
    then
      se.[sn] <- tn
      te.[tn] <- sn
      ans (index+1)
    else  "No"

ans 0 |> printfn "%s"
