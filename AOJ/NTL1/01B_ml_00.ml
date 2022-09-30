let solve (m,n) =
  let rec modpow m n modnum =
    if n = 0 then 1
    else if n mod 2 = 0 then modpow (m*m mod modnum) (n/2) modnum
    else (m * modpow m (n-1) modnum) mod modnum
  in modpow m n 1_000_000_007

let () =
  Scanf.scanf "%d %d" (fun m n -> (m,n))
  |> fun (m,n) -> solve (m,n) |> Printf.printf "%d\n"

let () =
  Printf.printf "%B\n" (solve (2,3) == 8);
  Printf.printf "%B\n" (solve (5,8) == 390625);;
