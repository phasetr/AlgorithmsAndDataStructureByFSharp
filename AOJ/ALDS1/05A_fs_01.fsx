#r "nuget: FsUnit"
open FsUnit

let solve N Aa Ma =
  let maxM = 2000
  let makeDP Aa N =
    let mutable dp = Array2D.create (N+1) (maxM+1) false
    for i=1 to N do dp.[i, Array.get Aa (i-1)] <- true done
    for i=2 to N do
      for j=1 to maxM do
        if dp.[i-1,j] || j > (Array.get Aa (i-1)) && dp.[i-1, j - (Array.get Aa (i-1))]
        then dp.[i,j] <- true
      done
    done
    dp
  let dp = makeDP Aa N
  Ma |> Array.map (fun m -> if dp.[N,m] then "yes" else "no")

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
let Q = stdin.ReadLine() |> int
let Ma = stdin.ReadLine().Split() |> Array.map int
solve Aa Ma |> Array.map stdout.WriteLine

solve 5 [|1;5;7;10;21|] [|2;4;17;8|] |> should equal [|"no";"no";"yes";"yes"|]
