(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_C/review/5589401/tt99kuze/OCaml *)
let bubbleSort (c: string array) (n: int) =
  let a = ref "" in
  for i = 0 to n - 1 do
    for j = n - 1 downto i + 1 do
      if c.(j).[1] < c.(j-1).[1] then
        begin
          a := c.(j) ;
          c.(j) <- c.(j-1) ;
          c.(j-1) <- !a
        end else ()
    done
  done ;;

let selectionSort (c: string array) (n: int) =
  let a = ref "" in
  for i = 0 to n - 1 do
    let minj = ref i in
    for j = i to n - 1 do
      if c.(j).[1] < c.(!minj).[1] then
        minj := j
      else ()
    done;
    a := c.(i) ;
    c.(i) <- c.(!minj) ;
    c.(!minj) <- !a
  done ;;

let xs = ["H4"; "C9" ; "S4" ; "D2" ; "C3" ] ;;
let ys = Array.of_list xs ;;
let zs = Array.of_list xs ;;

let () =
  let n = Scanf.scanf "%d\n" (fun n -> n) in
  let ar1 = Array.init n (fun _ -> Scanf.scanf "%s " (fun s -> s)) in
  let ar2 = Array.init n (fun i -> ar1.(i)) in
  bubbleSort ar1 n ;
  selectionSort ar2 n ;
  Array.iteri (fun i -> if i = 0 then Printf.printf "%s" else Printf.printf " %s") ar1 ;
  Printf.printf "\nStable\n" ;
  Array.iteri (fun i -> if i = 0 then Printf.printf "%s" else Printf.printf " %s") ar2 ;
  if ar1 = ar2 then Printf.printf "\nStable\n"
  else Printf.printf "\nNot stable\n" ;;
