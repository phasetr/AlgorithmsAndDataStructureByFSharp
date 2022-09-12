#r "nuget: FsUnit"
open FsUnit

let solve N (Aa:(int*int)[]) =
  let mcm n (p: int[]) =
    let mutable m = Array2D.create (n+1) (n+1) System.Int32.MaxValue
    for i = 1 to n do m.[i,i] <- 0 done
    for l = 1 to n-1 do
      for i = 1 to n-l do
        let j = i+l in
        for k = i to j-1 do
          m.[i,j] <- min m.[i,j] (m.[i,k] + m.[k+1,j] + p.[i-1]*p.[k]*p.[j])
        done
      done
    done;
    m.[1,n]
  Array.append [|fst Aa.[0]|] (Array.map snd Aa) |> mcm N

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> int x.[0],x.[1]) |]
solve N Aa |> stdout.WriteLine

let N,Aa = 6,[|(30,35);(35,15);(15,5);(5,10);(10,20);(20,25)|]
solve N Aa |> should equal 15125
