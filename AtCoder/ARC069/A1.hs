{-
https://atcoder.jp/contests/arc069/submissions/19069862
-}
main :: IO ()
main = do
  [n,m] <- map read . words <$> getLine
  print $ solve n m

solve :: Integral a => a -> a -> a
solve n m = min (m `div` 2) ((n*2+m) `div` 4)

test :: IO ()
test = print $ (solve 1 6 == 2 && solve 12345 678901 == 175897)
