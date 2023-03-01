// https://gist.github.com/taiseiKMC/c422618cca920bd1a8a5bcde54a7a802
// cf. ../AtCoder/tessoku-book/B59/B59_js_01.js
// Imperative, Destructive
module SegmentTree =
  let length k =
    if k=0 then 0
    else let rec frec acc = if k<=acc then acc else frec (2*acc) in frec 1

  let create k v = Array.create (2*length k) v

  /// Destructive for st
  let update f k x (st:'a[]) =
    let mutable i = st.Length/2 + k - 1
    st.[i] <- x
    while i>1 do i<-i/2; st.[i] <- f st.[2*i] st.[2*i+1]
    st

  /// query: Destructive for st
  let fold f l r v (st:int[]) =
    let left k = 2*k
    let right k = 2*k+1
    let rec frec l r a b i =
      if l<=a && b<=r then st.[i]
      elif b<=l || r<=a then v
      else let m = (a+b)/2 in f (frec l r a m (left i)) (frec l r m b (right i))
    frec l r 1 (st.Length/2+1) 1
