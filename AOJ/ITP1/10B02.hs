-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_B/review/2213493/aimy/Haskell
main :: IO ()
main = getLine >>=
  mapM_ print . solve
  . (\[a,b,c] -> (a,b,c)) . map read . words
solve :: Floating a => (a, a, a) -> [a]
solve (a,b,c) = [s,l,h]
 where
  s = a * h / 2.0
  l = a + b + sqrt ((a - (cos (c * pi / 180.0) * b))^2 + h^2)
  h = sin (c * pi / 180.0) * b
