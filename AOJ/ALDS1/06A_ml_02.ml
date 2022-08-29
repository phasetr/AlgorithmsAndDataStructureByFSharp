(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_A/review/2009777/superluminalsloth/OCaml *)
let () =
  let counting_sort a b k =
    let len = (Array.length a) -1 and
        c = Array.make (k+1) 0 in
    Array.iter (fun x -> c.(x) <- c.(x)+1) a;
    for i = 1 to k do
      c.(i) <- c.(i) + c.(i-1)
    done;
    for i = 0 to len do
      let j = len - i in
      b.(c.(a.(j))-1) <- a.(j);c.(a.(j)) <- c.(a.(j))-1
    done;b
  in
  let read x = Scanf.scanf " %d" (fun y -> y) in
  let n = read_int () in
  let a = Array.init n read in
  let res = counting_sort a (Array.make n 0) 10000 in
  print_int res.(0);
  for i = 1 to n-1 do
    print_string  " ";print_int res.(i)
  done;
  print_newline ()
