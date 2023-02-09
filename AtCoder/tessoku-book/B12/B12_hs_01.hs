-- https://atcoder.jp/contests/tessoku-book/submissions/37258064
main :: IO ()
main = readLn >>= print . sol

sol :: Floating a => Integer -> a
sol n = u-v where
  q = fromInteger n/2.0
  d = q^2+1.0/27.0
  u = (sqrt d+q)**(1/3)
  v = (sqrt d-q)**(1/3)
