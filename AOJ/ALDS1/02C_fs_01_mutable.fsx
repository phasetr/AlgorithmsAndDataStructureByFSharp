#r "nuget: FsUnit"
open FsUnit

let solve N Xa =
  let bsort (c:array<string>) (n:int) =
    let a = ref ""
    for i=0 to n-1 do
      for j=n-1 downto i+1 do
        if c.[j].[1] < c.[j-1].[1] then
          a.Value <- c.[j]
          c.[j] <- c.[j-1]
          c.[j-1] <- a.Value
      done
    done

  let ssort (c:array<string>) (n:int) =
    let a = ref ""
    for i=0 to n-1 do
      let minj = ref i
      for j=i to n-1 do
        if c.[j].[1] < c.[minj.Value].[1] then minj.Value <- j
      done;
      a.Value <- c.[i]
      c.[i] <- c.[minj.Value]
      c.[minj.Value] <- a.Value
    done

  let Ya = Array.copy Xa
  bsort Xa N
  ssort Ya N
  [| String.concat " " Xa; "Stable"; String.concat " " Ya; if isStable Xa Ya N then "Stable" else "Not stable" |]

let N = stdin.ReadLine() |> int
let Xa = stdin.ReadLine().Split()
solve Xa |> String.concat "\n" |> stdout.WriteLine

solve 5 [|"H4";"C9";"S4";"D2";"C3"|] |> should equal [|"D2 C3 H4 S4 C9";"Stable";"D2 C3 S4 H4 C9";"Not stable"|]
solve 2 [|"S1";"H1"|] |> should equal [|"S1 H1";"Stable";"S1 H1";"Stable"|]
