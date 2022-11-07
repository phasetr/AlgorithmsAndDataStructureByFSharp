-- https://atcoder.jp/contests/abc084/submissions/15246801
main :: IO ()
main = interact $ g . map read . tail . words where
  g (c:s:f:l) = shows ((s+c)#l) "\n" ++ g l
  g _ = "0"
  t # (c:s:f:l) = (div (max t s+f-1) f * f + c) # l
  t # _ = t
