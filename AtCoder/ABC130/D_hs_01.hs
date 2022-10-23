-- https://atcoder.jp/contests/abc130/submissions/9857330
main :: IO ()
main = do
  [n,k] <- map read . words <$> getLine
  a <- map read . words <$> getLine
  print $ n*(n+1) `div` 2 - f 0 k a a
f ::  Int -> Int -> [Int] -> [Int] -> Int
f c k a []
  | k <= 0 = f(c-1)(k+head a)(tail a)[]
  | otherwise = c
f c k a (b:bs)
  | k <= 0 = f (c-1) (k+head a) (tail a) (b:bs)
  | otherwise = c + f (c+1) (k-b) a bs
