-- https://atcoder.jp/contests/abc112/submissions/3364384
main :: IO ()
main = do
  [n, m] <- map read . words <$> getLine
  print $ solve n m

solve :: Int -> Int -> Int
solve n m = maximum $ filter (<= m `div` n) $ divisors m

divisors :: Int -> [Int]
divisors m = go 1 m where
  go k m
    | k ^ 2 > m = []
    | m `mod` k == 0 = k : m `div` k : go (k + 1) m
    | otherwise = go (k + 1) m
