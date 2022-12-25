let judge s = if s = "Male" then 0 else 1
let rec frec l r e =
  let m = (l+r)/2
  stdout.WriteLine m
  let s = stdin.ReadLine()
  if s="Vacant" then ()
  else
    let v = judge s
    if (m-l-v+e+2)%2=0 then frec (m+1) r ((m+1-l-e)%2) else frec l m e

let N = stdin.ReadLine() |> int
stdout.WriteLine 0
let s0 = stdin.ReadLine()
if s0="Vacant" then ()
else frec 0 (N-1) (judge s0)
