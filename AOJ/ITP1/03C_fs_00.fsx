let rec main() = match sprintf "%d %d\n" (fun x y -> if x<y then (x,y) else (y,x)) with
  | (0,0) -> ()
  | (x,y) -> stdout.WriteLine "%d %d" x y; main()
main()
