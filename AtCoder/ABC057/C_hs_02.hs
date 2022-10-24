-- https://atcoder.jp/contests/abc057/submissions/11965721
main :: IO ()
main = interact $ show . sol . read
sol :: Integer -> Int
sol n = length . show . div n $ last [i | i <- [1..min n (10^5)], mod n i==0, i*i<=n]
