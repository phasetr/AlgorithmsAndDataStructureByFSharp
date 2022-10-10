-- https://atcoder.jp/contests/jsc2019-qual/submissions/12904799
main :: IO ()
main = do
  [n, k] <- map read . words <$> getLine
  as <- map read . words <$> getLine
  print $ solve k as

solve :: Int -> [Int] -> Int
solve k as = (f as * k + g as * k * (k-1) `div` 2) `mod` (10^9+7)
f [] = 0
f (a:as) = fromIntegral (length (filter (a >) as)) + f as
g as = sum $ map (\a -> fromIntegral (length (filter (a >) as))) as

test :: IO()
test = do
  print $ f xs
  print $ g xs
  print $ f xs * k
  print $ g xs * k * (k-1) `div` 2
  print $ (f xs * k + g xs * k * (k-1) `div` 2) `mod` m
  print $ k * (k-1) `div` 2
  print $ g xs * k * (k-1) `div` 2 `mod` m
  where
    xs = [10,9,8,7,5,6,3,4,2,1]
    k = 998244353
    m = 10^9+7
