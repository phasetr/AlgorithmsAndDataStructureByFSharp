// https://atcoder.jp/contests/abc105/submissions/6219787
let scanInts () = stdin.ReadLine().Split() |> Array.map int

let [|n|] = scanInts ()

let rec rfn arr n =
  let s = if n % 2 = 0  then 0 else -1
  let t = if n % 2 = 0  then "0" else "1"
  match n with
  | 0 -> arr
  | _ -> rfn (t::arr) (-(n+s)/2)

if n = 0 then printfn "0"
else rfn [] n |> String.concat "" |> printfn "%s"
