// https://atcoder.jp/contests/abc049/submissions/13132180
open System.Text.RegularExpressions

let ok str =
  let m = Regex("^(dream|dreamer|erase|eraser)+$").Match(str)
  m.Success

let S = stdin.ReadLine()
if ok S then "YES" else "NO" |> stdout.WriteLine
