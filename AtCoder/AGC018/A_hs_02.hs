-- https://atcoder.jp/contests/agc018/submissions/1450039
main :: IO ()
main = getContents >>= putStrLn . solve . map read . words

solve :: [Int] -> String
solve (n:k:a:as) = if any (\a -> k <= a && (a - k) `mod` d == 0) (a:as) then "POSSIBLE" else "IMPOSSIBLE"
  where d = foldl gcd a as
solve _ = error "not come here"
