let draw h w =
  for i=1 to h do
    for j=1 to w do print_char @@ if (i+j) mod 2 == 0 then '#' else '.' done;
    print_newline() done;;
let rec main() = match Scanf.scanf "%d %d\n" (fun a b -> a,b) with
  | (0,0) -> ()
  | (h,w) -> draw h w; print_newline(); main();;
main();;

draw 3 4;;
draw 5 6;;
draw 3 3;;
draw 2 2;;
draw 1 1;;
