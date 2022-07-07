let n = read_int() in
    let sa = Array.make 13 false in
    let ha = Array.make 13 false in
    let ca = Array.make 13 false in
    let da = Array.make 13 false in
    for i=1 to n do
      match (Scanf.scanf "%c %d\n" (fun s r -> (s,r-1))) with
      | ('S', r) -> sa.(r) <- true
      | ('H', r) -> ha.(r) <- true
      | ('C', r) -> ca.(r) <- true
      | ('D', r) -> da.(r) <- true
      | _        -> ()
    done;
    let f c = Array.iteri (fun i x -> if x then () else Printf.printf "%c %d\n" c (i+1)); in
    f 'S' sa;
    f 'H' ha;
    f 'C' ca;
    f 'D' da;;
