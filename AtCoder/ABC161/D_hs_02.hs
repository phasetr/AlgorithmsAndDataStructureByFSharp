-- https://atcoder.jp/contests/abc161/submissions/11572825
main :: IO ()
main = readLn >>= print . (lnum!!) . pred
lnum :: [Integer]
lnum = [1..9] ++ [10*x+a | x <- lnum, let r = mod x 10, a <- [r-1 .. r+1], 0 <= a, a <= 9]
