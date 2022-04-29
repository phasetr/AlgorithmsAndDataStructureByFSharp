(*https://atcoder.jp/contests/dp/submissions/3948019*)
let modulo = 1000000007
let (+@) a b = (a + b) mod modulo
let (-@) a b = (a - b + modulo) mod modulo
let () =
  Scanf.scanf "%d %d" @@ fun n k ->
  let a = Array.init n (fun _ -> Scanf.scanf " %d" ((+) 0)) in
  let dp = Array.init (n+1) (fun _ -> Array.make (k+1) 0) in
  for i = 0 to k do dp.(0).(i) <- 1 done;
  for i = 1 to n do
    dp.(i).(0) <- 1;
    for j = 1 to k do
      dp.(i).(j) <- dp.(i).(j-1) +@
        if j - a.(i-1) > 0 then dp.(i-1).(j) -@ dp.(i-1).(j - a.(i-1) - 1)
        else dp.(i-1).(j);
    done;
  done;
  Printf.printf "%d\n" (if k = 0 then dp.(n).(0) else dp.(n).(k) -@ dp.(n).(k-1))
