// https://atcoder.jp/contests/abc145/submissions/25398953
1_000_000_007L
|> fun p -> ((([| fun _ _ -> 0L |]) |> fun fnc -> (fun m n -> match n with | _ when n = 0L -> 1L | _ when n % 2L = 0L -> fnc.[0] m (n / 2L) |> (fun x -> x * x % p) | _ -> m * fnc.[0] m (n - 1L) % p) |> fun fn -> (fnc.[0] <- fn) |> fun () -> fn), (fun n r -> seq {0L..(r - 1L)} |> Seq.fold (fun acc i -> acc * (n - i) % p) 1L)) |> fun (power, permutation) -> (fun n r -> (permutation n r, permutation r r) |> fun (a, b) -> a * (power b (p - 2L)) % p)
|> fun combination -> 
  (stdin.ReadLine().Split() |> Array.map int64 |> Array.sort |> fun x -> x.[0], x.[1])
  |> fun (x, y) -> if (x + y) % 3L <> 0L || x * 2L < y then 0L else combination ((x + y) / 3L) ((x * 2L - y) / 3L)
|> printfn "%d"

