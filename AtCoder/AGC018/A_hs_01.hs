-- https://atcoder.jp/contests/agc018/submissions/9931828
main :: IO ()
main = do
 [n,k] <- map read . words <$> getLine
 a <- map read . words <$> getLine
 putStr $ if k>maximum a || k `mod` foldl1 gcd a > 0 then "IM" else ""
 putStrLn "POSSIBLE"
