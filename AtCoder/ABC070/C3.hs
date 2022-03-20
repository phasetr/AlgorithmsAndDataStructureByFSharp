{-
https://atcoder.jp/contests/abc070/submissions/15459532
-}
main :: IO ()
main = interact $ show . foldr1 lcm . tail . map read . words
