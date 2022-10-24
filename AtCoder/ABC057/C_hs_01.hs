-- https://atcoder.jp/contests/abc057/submissions/9848330
main :: IO ()
main = do
  n <- readLn
  print $ minimum [f i $ div n i | i <- [1..10^5], mod n i == 0]
f :: Integer -> Integer -> Int
f a b = max (g a) (g b)
g :: Integer -> Int
g = length . show
