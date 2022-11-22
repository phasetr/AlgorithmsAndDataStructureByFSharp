-- https://atcoder.jp/contests/abc145/submissions/13486681
import GHC.Integer.GMP.Internals ( recipModInteger )

main :: IO ()
main = interact $ show . f . map read . words
f [x,y]
  | (s,0) <- divMod(2*y-x)3, (t,0) <- divMod (2*x-y)3, s>=0, t>=0 = g (s+t) % recipModInteger (g s%g t) m
  | 0<1 = 0
    where
      g x = foldl (%) 1 [1..x]
      x%y = rem (x*y) m
      m = 10^9+7
f _ = error "not come here"
