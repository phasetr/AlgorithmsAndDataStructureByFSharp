(* https://atcoder.jp/contests/abc043/submissions/2787180 *)
let () =
  let s = read_line () in
  Array.init (String.length s) (fun i -> s.[i])
  |> Array.fold_left (fun s c ->
         match s, c with
         | _, '0' -> '0' :: s
         | _, '1' -> '1' :: s
         | [], 'B' -> []
         | _ :: s, 'B' -> s
         | _, _ -> failwith "Invalid_input") []
  |> (fun s -> List.rev_append s ['\n'])
  |> List.iter print_char;;
