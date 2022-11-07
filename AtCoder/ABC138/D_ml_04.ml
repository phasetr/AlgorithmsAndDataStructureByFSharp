(* https://atcoder.jp/contests/abc138/submissions/14696048 *)
let n, q = Scanf.sscanf (read_line ()) "%d %d" (fun a b -> a, b)

let g = Array.init n (fun _ -> [])
let () =
  Array.init (n - 1) (fun _ -> Scanf.sscanf (read_line ()) "%d %d" (fun a b -> a-1, b-1))
  |> Array.iter (fun (a, b) ->
      g.(a) <- b :: g.(a);
      g.(b) <- a :: g.(b)
  )

let sum = Array.init n (fun _ -> 0)
let () =
  Array.init q (fun _ -> Scanf.sscanf (read_line ()) "%d %d" (fun q x -> q - 1, x))
  |> Array.iter (fun (q, x) -> sum.(q) <- sum.(q) + x)

let ans = Array.init n (fun _ -> 0)

let rec cumsum now par acc =
  let acc = acc + sum.(now) in (
    ans.(now) <- acc;
    List.iter (fun child -> if child = par then () else cumsum child now acc) g.(now)
  )

let () = (
  cumsum 0 0 0;
  for i = 0 to n - 1 do
    Printf.printf "%d " ans.(i)
  done
)
