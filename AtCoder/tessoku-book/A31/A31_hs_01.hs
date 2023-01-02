-- https://atcoder.jp/contests/tessoku-book/submissions/35373720
tba31 :: Int -> Int
tba31 n = div n 3 + div n 5 - div n 15

main :: IO ()
main = do
  n <- readLn
  let ans = tba31 n
  print ans

getLnInts :: IO [Int]
getLnInts = map read . words <$> getLine
