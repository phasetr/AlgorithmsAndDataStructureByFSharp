#r "nuget: FsUnit"
open FsUnit

let Xa = [|5;2;4;6;1;3|]
let solve Xa =
  let toString: int[] -> string = Array.map string >> String.concat " "

  let isort Xa =
    let mutable Aa = Xa
    for i=1 to (Array.length Aa - 1) do
      toString Aa |> stdout.WriteLine
      let key = Aa.[i]
      let j = ref (i - 1)
      while j.Value >= 0 && Aa.[j.Value] > key do
        Aa.[j.Value+1] <- Aa.[j.Value]
        j.Value <- j.Value - 1
        Aa.[j.Value+1] <- key
      done
    done
    Aa

  let res = isort Xa
  toString res |> stdout.WriteLine

let N = stdin.ReadLine() |> int
let Xa = stdin.ReadLine().Split() |> Array.map int

solve [|5;2;4;6;1;3|]
solve [|1;2;3|]
