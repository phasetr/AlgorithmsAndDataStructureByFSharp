-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_2_A/review/3831096/th90tk297/Haskell
main :: IO ()
main = do
 [a,b] <- fmap (map read . words) getLine
 putStrLn $ unwords [show (a + b)]
