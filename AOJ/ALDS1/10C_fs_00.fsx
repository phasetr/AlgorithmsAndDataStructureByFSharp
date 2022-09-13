#r "nuget: FsUnit"
open FsUnit

let solve Q (Aa:string[]) =
  let lcs x y =
    let m = String.length x
    let n = String.length y
    let s = Array.create (n+1) 0
    let t = Array.copy s
    for i = 1 to m do
      for j = 1 to n do
        t.[j] <- if x.[i-1] = y.[j-1] then s.[j-1] + 1 else max s.[j] t.[j-1]
      done
      Array.iteri (fun i e -> s.[i] <- e) t
    done
    t.[n]
  [|1..Q|] |> Array.map (fun i -> lcs Aa.[2*(i-1)] Aa.[2*i-1])

let Q = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do stdin.ReadLine() |]
solve Q Xa |> Array.iter stdout.WriteLine

let Q,Aa = 3,[|"abcbdab";"bdcaba";"abc";"abc";"#abc#";"bc"|]
solve Q Aa |> should equal [|4;3;2|]
