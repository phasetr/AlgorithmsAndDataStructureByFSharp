-- https://atcoder.jp/contests/abc146/submissions/17647196
main :: IO ()
main = do
  [a,b,x] <- map read . words <$> getLine
  print $ solve a b x

solve :: Int -> Int -> Int -> Int
solve a b x = bsearch 0 (10^9 + 1) where
  bsearch :: Int -> Int -> Int
  bsearch l r
    | r - l <= 1 = l
    | otherwise = uncurry bsearch newRange
      where
        cost =  a * mid + b * length (show mid)
        mid = (l + r) `div` 2
        newRange = if cost > x then (l, mid) else (mid, r)
