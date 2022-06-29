let () =
  let hms =
    let t = read_int () in
    List.map string_of_int [t / 3600; t / 60 mod 60; t mod 60] in
  print_endline (String.concat ":" hms)
