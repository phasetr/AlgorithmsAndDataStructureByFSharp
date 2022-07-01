let solve w h x y r = match (0<x,0<y) with
  | (true,true) -> if (0<=x-r && r+x<=w && 0<=y-r && r+y<=h) then "Yes" else "No"
  | _ -> "No"
;;
let w,h,x,y,r = Scanf.sscanf(read_line()) "%d %d %d %d %d" (fun a b c d e -> a,b,c,d,e);;
let () = Printf.printf "%s\n" (solve w h x y r);;

solve 5 4 2 2 1 = "Yes";;
solve 5 4 2 4 1 = "No";;
