let input = [|25;36;4;55;71;18;0;71;89;65|]
input |> Array.sort |> Array.rev |> Array.take 3 |> printfn "%A"
