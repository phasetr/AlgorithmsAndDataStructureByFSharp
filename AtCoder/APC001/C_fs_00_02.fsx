let rec frec l r s0 =
  let m = (l+r)/2
  stdout.WriteLine m
  let s = stdin.ReadLine()
  if s="Vacant" then ()
  else if (m%2=0 && s0=s) || (m%2=1 && s0<>s) then frec (m+1) r s0 else frec l m s0

let N = stdin.ReadLine() |> int
stdout.WriteLine 0
let s0 = stdin.ReadLine()
if s0="Vacant" then ()
else frec 0 (N-1) s0
