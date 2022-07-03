let rec main () = match Scanf.sscanf(read_line()) "%d %d" (fun x y -> x,y) with
  | (0,0) -> ()
  | (h,w) -> begin
      for _ = 1 to h do Printf.printf "%s\n" @@ String.make w '#'; done;
      print_newline();
      main()
    end;;
main();;

let draw h w = List.init h (fun _ -> String.make w '#');;
draw 3 4 = ["####";"####";"####"];;
draw 5 6 = ["######";"######";"######";"######";"######"];;
draw 2 2 = ["##";"##"];;

let print_rect h w = for _ = 1 to h do Printf.printf "%s\n" @@ String.make w '#'; done;;
print_rect 3 4;;
print_rect 5 6;;
