-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_D/review/4039954/niruneru/Haskell
main :: IO ()
main = do
  [n, k] <- fmap (map read . words) getLine     :: IO [Int]
  ws     <- fmap (map read . lines) getContents :: IO [Int]
  let sumW = sum ws
      minP = sumW `div` k - 1
      maxP = sumW
  print $ solve n k ws minP maxP

solve :: Int -> Int -> [Int] -> Int -> Int -> Int
solve n k ws = mlc where
  mlc row high
    | (high - row) == 1 = high
    | c < n             = mlc mid high
    | otherwise         = mlc row mid
    where
      c   = lc ws mid 1 0 0
      mid = (high + row) `div` 2

  lc []     p track loaded total = total
  lc (x:xs) p track loaded total
    | total == n = total
    | track > k  = total
    | otherwise  =
        if (loaded + x) > p then lc (x:xs) p (track + 1) 0 total
        else lc xs p track (loaded + x) (total + 1)
