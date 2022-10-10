-- https://atcoder.jp/contests/jsc2019-qual/submissions/7150282
main :: IO ()
main = do
  [_,k] <- map read . words <$> getLine
  a <- map read . words <$> getLine
  print (solve a k)

solve :: [Int] -> Int -> Int
solve [x] p = 0
solve (x:xs) p = mod (mod (mod (div (p*(p+1)) 2) 1000000007 *length [c | c <- xs, c < x] + mod (div (p*(p-1)) 2) 1000000007 * length [c | c <- xs, c > x])1000000007 + solve xs p) 1000000007
solve _ _ = error "not come here"
