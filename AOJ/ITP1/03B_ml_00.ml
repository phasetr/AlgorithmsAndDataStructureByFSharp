let rec frec n =
  let x = read_int () in
  if x!=0 then (
    Printf.printf "Case %d: %d\n" n x;
    frec (n+1)
  );;
frec 1;;
