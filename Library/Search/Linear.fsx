#r "nuget: FsUnit"
open FsUnit

module LinearSearch01 =
  """入力`Ia`中に`X`が見つかれば"Yes", そうでなければ"No"を返す.
  cf. ../../AtCoder/tessoku-book/A02/A02_fs_00_02.fsx"""
  let linearSearch N X Ia =
    let rec frec i =
      if i = N-1 then "No"
      elif Array.get Ia i = X then "Yes"
      else frec (i+1)
    frec 0
  linearSearch 5 40 [|10;20;30;40;50|] |> should equal "Yes"
  linearSearch 6 28 [|30;10;40;10;50;50|] |> should equal "No"
