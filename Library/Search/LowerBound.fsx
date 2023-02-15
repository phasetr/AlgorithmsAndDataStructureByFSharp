#r "nuget: FsUnit"
open FsUnit

@"Python bisect_left, C++/Rust lower_bound, lowerBound
ソートされた順序を保ったまま`x`を`Xa`に挿入できる点を探す.
全ての`Xa.[0..i-1]`が`x`より厳密に小さい`i`を探す.
https://amateur-engineer-blog.com/python-bisect/
https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/solutions/702162/python-lets-implement-pythons-bisect-algorithm/"
let bisectLeft x (Xa:'a[]) =
  let rec bsearch l r =
    if r<=l then l
    else let m = l+(r-l)/2 in if Xa.[m] < x then bsearch (m+1) r else bsearch l m
  Xa |> Array.length |> bsearch 0
[|2;5;8;13;13;18;25;30|] |> bisectLeft 10 |> should equal 3
[|2;5;8;13;13;18;25;30|] |> bisectLeft 13 |> should equal 3
[|0..10|] |> Array.map (fun i -> [|0..10|] |> bisectLeft i) |> should equal [|0..10|]
[|0..10|] |> bisectLeft 3 |> should equal 3
[|0..10|] |> bisectLeft 4 |> should equal 4

@"cf. ../../AtCoder/tessoku-book/B11/B11_cs_01.cs"
let bisectLeft x (Xa:'a[]) =
  let rec bsearch l r =
    if r-l<=1 then r
    else let m = (r+l)/2 in if Xa.[m] < x then bsearch m r else bsearch l m
  if x<=Xa.[0] then 0 else Xa |> Array.length |> bsearch 0
[|2;5;8;13;13;18;25;30|] |> bisectLeft 10 |> should equal 3
[|2;5;8;13;13;18;25;30|] |> bisectLeft 13 |> should equal 3
[|0..10|] |> Array.map (fun i -> [|0..10|] |> bisectLeft i) |> should equal [|0..10|]
[|0..10|] |> bisectLeft 3 |> should equal 3
[|0..10|] |> bisectLeft 4 |> should equal 4

@"Python bisect right"
let bisectRight x (Xa:'a[]) =
  let rec bsearch l r =
    if r<=l then l
    else let m = l+(r-l)/2 in if x < Xa.[m] then bsearch l m else bsearch (m+1) r
  Xa |> Array.length |> bsearch 0
[|2;5;8;13;13;18;25;30|] |> bisectRight 10 |> should equal 3
[|2;5;8;13;13;18;25;30|] |> bisectRight 13 |> should equal 5
[|0..9|] |> Array.map (fun i -> [|0..10|] |> bisectRight i) |> should equal [|1..10|]
[|0..10|] |> bisectRight 3 |> should equal 4
[|0..10|] |> bisectRight 4 |> should equal 5
