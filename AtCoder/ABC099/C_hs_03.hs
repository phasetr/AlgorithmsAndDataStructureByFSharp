-- https://atcoder.jp/contests/abc099/submissions/2698906
adicI :: Int -> Int -> Int
adicI i n = if n < i then n else mod n i + adicI  i (div n i)

solver :: Int -> Int
solver n = minimum [adicI 6 (n-i) + adicI 9 i | i <- [0..n]]

main :: IO()
main = readLn >>= print . solver
