-- https://atcoder.jp/contests/abc107/submissions/3076847
main :: IO ()
main = do
  [_,k] <- map read . words <$> getLine
  xs <- map read . words <$> getLine
  print $ minimum (map solve $ pair k xs)

pair :: Int -> [b] -> [(b, b)]
pair k xs = zip xs (drop (k-1) xs)

solve :: (Int,Int) -> Int
solve (a,b)
  | a < 0 && b < 0  = abs a
  | a < 0 && 0 <= b = 2*min (abs a) b + max (abs a) b
  | otherwise       = b
