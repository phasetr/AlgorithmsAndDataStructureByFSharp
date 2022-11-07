#r "nuget: FsUnit"
open FsUnit

let N,Aa = 4,[|(12,24,6);(52,16,4);(99,2,2)|]
let solve N Aa =
  [|0..N-1|] |> Array.map (fun i ->
    Aa |> Array.skip i |> Array.fold (fun acc (c,s,f) -> c + ((max acc s + f - 1)/f)*f) 0)

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..(N-1) do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2]) |]
solve N Aa |> Array.map string |> String.concat "\n" |> stdout.WriteLine

solve 3 [|(6,5,1);(1,10,1)|] |> should equal [|12;11;0|]
solve 4 [|(12,24,6);(52,16,4);(99,2,2)|] |> should equal [|187;167;101;0|]
solve 4 [|(12,13,1);(44,17,17);(66,4096,64)|] |> should equal [|4162;4162;4162;0|]
