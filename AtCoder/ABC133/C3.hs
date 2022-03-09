{-
https://atcoder.jp/contests/abc133/submissions/29600098
-}
main :: IO ()
main = do
  [l, r] <- map read . words <$> getLine
  print $ solve l r

solve :: Int -> Int -> Int
solve l r =
  minimum [(i*j) `mod` 2019 |
            i <- [l..min (l+2018) r],
            j <- [i + 1..min (l+2018) r]]

test :: IO ()
test = do
  print $ solve 2020 2040 == 2
  print $ solve 4 5 == 20
