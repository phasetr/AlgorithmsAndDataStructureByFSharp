-- https://atcoder.jp/contests/agc036/submissions/14160402
main = do
  s <- readLn :: IO Int
  let x = (10^9 - (s `mod` 10^9)) `mod` 10^9
      y = (s + x) `div` 10^9
  putStrLn $ "0 0 1000000000 1 " ++ show x ++ " " ++ show y
