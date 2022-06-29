let solve x =
  let h = x / (60*60) in
  let m = (x mod (60*60)) / 60 in
  let s = x mod 60 in
  Printf.sprintf "%d:%d:%d" h m s;;
let _ =
  let x = Scanf.scanf "%d" (fun x -> x) in
  print_endline @@ solve x;;

Printf.printf "%B" (solve 46979 = "13:2:59");;
