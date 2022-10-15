-- https://atcoder.jp/contests/abc148/submissions/18899811
main :: IO ()
main = print . solve =<< readLn
solve :: Integral p => p -> p
solve n = if odd n then 0 else sum.map(div m).takeWhile(m>=)$iterate(*5)5 where m=div n 2
