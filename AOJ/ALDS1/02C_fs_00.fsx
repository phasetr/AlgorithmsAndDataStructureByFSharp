#r "nuget: FsUnit"
open FsUnit

// TODO: ソートを破壊的にしない
let solve N Xa =
  let swap i j (a:array<'a>) = let tmp = a.[i] in a.[i] <- a.[j]; a.[j] <- tmp
  let bsort (a:array<'a>) n cmp =
    let rec bubble i flag =
      if i = 0 then doit flag
      else if cmp a.[i-1] a.[i] <= 0 then bubble (i-1) flag
      else swap i (i-1) a; bubble (i-1) true
    and doit flag = if flag then bubble (n-1) false
    doit true

  let ssort (a:'a[]) n cmp =
    let rec select j minj =
      if j >= n then minj
      else select (j+1) (if cmp a.[j] a.[minj] < 0 then j else minj)
    and doit i =
      if i < n then
        let j = select i i
        if j <> i then swap i j a else ()
        doit (i+1)
    doit 0

  let cmpCard (x:string) (y:string) = compare x.[1] y.[1]

  let isStable (a:array<'a>) (b:array<'a>) n =
    let rec doit i =
      if i = n then true
      else if a.[i] <> b.[i] then false
      else doit (i + 1)
    in doit 0

  let Ya = Array.copy Xa
  bsort Xa N cmpCard
  ssort Ya N cmpCard
  [| String.concat " " Xa; "Stable"; String.concat " " Ya; if isStable Xa Ya N then "Stable" else "Not stable" |]

let N = stdin.ReadLine() |> int
let Xa = stdin.ReadLine().Split()
solve Xa |> String.concat "\n" |> stdout.WriteLine

solve 5 [|"H4";"C9";"S4";"D2";"C3"|] |> should equal [|"D2 C3 H4 S4 C9";"Stable";"D2 C3 S4 H4 C9";"Not stable"|]
solve 2 [|"S1";"H1"|] |> should equal [|"S1 H1";"Stable";"S1 H1";"Stable"|]
