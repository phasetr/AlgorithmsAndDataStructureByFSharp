(* https://atcoder.jp/contests/abc042/submissions/7672533 *)
let n,l = Scanf.scanf " %d %d" @@ fun a b -> a, b;;
let sa = Array.init n @@ fun _ -> Scanf.scanf " %s" @@ fun s -> s;;
Array.sort compare sa;
Array.iter print_string sa;
print_newline();;
