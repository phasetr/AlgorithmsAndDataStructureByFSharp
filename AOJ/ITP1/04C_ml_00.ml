let calc x op y  = match op with
  | "+" -> x+y
  | "-" -> x-y
  | "*" -> x*y
  | _   -> x/y
;;
let rec main () =
  let x,op,y = Scanf.sscanf(read_line()) "%d %s %d" (fun a b c -> a,b,c) in
  if op = "?" then () else begin
      Printf.printf "%d\n" @@ calc x op y;
      main()
    end;;
main();;
