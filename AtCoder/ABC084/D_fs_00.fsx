#r "nuget: FsUnit"
open FsUnit

let Q,Na = 6,[|(1,53);(13,91);(37,55);(19,51);(73,91);(13,49)|]
let solve Q Na =
  let N = 100_000
  let sieve =
    let primes = Array.create (N+1) true
    primes.[0] <- false; primes.[1] <- false
    let rec go i p = if i>=(N+1) then () else (primes.[i] <- false; go (i+p) p)
    [|0..N|] |> Array.iter (fun p -> if primes.[p] then go (2*p) p)
    primes
  let Ca =
    let Sa = Array.init (N+1) (fun n -> if n%2=1 && sieve.[n] && sieve.[(n+1)/2] then 1 else 0)
    [|1..N|] |> Array.iter (fun n -> Array.set Sa n (Sa.[n]+Sa.[n-1]))
    Sa
  Na |> Array.map (fun (l,r) -> Ca.[r]-Ca.[l-1])

let Q = stdin.ReadLine() |> int
let Na = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve Q Na |> Array.iter stdout.WriteLine

solve 1 [|(3,7)|] |> should equal [|2|]
solve 4 [|(13,13);(7,11);(7,11);(2017,2017)|] |> should equal [|1;0;0;1|]
solve 6 [|(1,53);(13,91);(37,55);(19,51);(73,91);(13,49)|] |> should equal [|4;4;1;1;1;2|]

