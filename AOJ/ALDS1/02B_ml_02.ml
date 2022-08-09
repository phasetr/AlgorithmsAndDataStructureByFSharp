(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_B/review/2580909/ttoott/OCaml *)
let n = Scanf.scanf "%d\n" (fun x -> x)
let a_ = Array.init n (fun _ -> Scanf.scanf "%d " (fun a -> a))

let change i minj a =
  let ai = a.(i) and aminj = a.(minj) in
  a.(i) <- aminj; a.(minj) <- ai; a

let print_array a = Array.to_list a |> List.map string_of_int |> String.concat " " |> print_endline

let rec selectionSort i j a min cnt =
  if (i = n) && (j = n) then (a, cnt)
  else if (j = n) then
    if i = min then selectionSort (i+1) (i+1) a (i+1) cnt
    else selectionSort (i+1) (i+1) (change i min a) (i+1) (cnt+1)
  else if a.(j) < a.(min) then selectionSort i (j+1) a j cnt
  else selectionSort i (j+1) a min cnt

let () =
  let a, cnt = selectionSort 0 0 a_ 0 0 in
  print_array a; Printf.printf "%d\n" cnt
