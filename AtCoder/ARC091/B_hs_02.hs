-- https://atcoder.jp/contests/abc090/submissions/26427336
main :: IO ()
main = do
  (n,k) <- (\[n,k] -> (n,k)) . map read . words <$> getLine
  print $ solve n k
solve :: Integral a => a -> a -> a

solve n k
  | k == 0     = n*n
  | otherwise  = sum $ map (\b -> ( n `div` b ) * max 0 (b-k) + max ( n `mod` b - k+1) 0 ) [1..n]
