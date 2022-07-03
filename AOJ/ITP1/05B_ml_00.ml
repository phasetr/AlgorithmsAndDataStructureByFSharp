let draw_frame h w =
  for i=1 to h do
    if i=1 || i=h then print_endline @@ String.make w '#'
    else begin
        print_char '#';
        for _=2 to w-1 do print_char '.' done;
        print_endline "#"
      end;
  done;;
let rec main() = match Scanf.sscanf(read_line()) "%d %d" (fun x y -> x,y) with
  | (0,0) -> ()
  | (h,w) -> draw_frame h w; print_newline(); main();;
main();;

draw_frame 3 4;;
draw_frame 5 6;;
draw_frame 3 3;;
