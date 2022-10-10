(* https://atcoder.jp/contests/abc136/submissions/6699084 *)
let () =
  let s = read_line () in
  let dp = Array.init (String.length s) (( + ) 0) in
  for i = 1 to String.length s - 1 do
    if s.[i] = 'L' then
      dp.(i) <- dp.(i - 1)
  done;
  for i = String.length s - 2 downto 0 do
    if s.[i] = 'R' then
      dp.(i) <- dp.(i + 1)
  done;
  let acc = Array.make (String.length s) 0 in
  for i = 0 to String.length s - 1 do
    let j = dp.(i) + abs (i - dp.(i)) mod 2 in
    acc.(j) <- acc.(j) + 1
  done;
  Array.iter (Printf.printf "%d ") acc;
  print_newline ()
