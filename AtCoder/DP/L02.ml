(*https://atcoder.jp/contests/dp/submissions/3947148*)
Scanf.scanf "%d" @@ fun n ->
let a = Array.init n (fun _ -> Scanf.scanf " %d" ((+) 0)) in
let dp = Array.init (n+1) (fun _ -> Array.make (n+1) 0) in
for w = 1 to n do
  for i = 0 to n-w do
    dp.(i).(i+w) <-
      max (a.(i) - dp.(i+1).(i+w)) (a.(i+w-1) - dp.(i).(i+w-1))
  done;
done;
Printf.printf "%d\n" dp.(0).(n)
