-- https://atcoder.jp/contests/abc045/submissions/3083533
{-# LANGUAGE BangPatterns #-}
import Data.Char ( digitToInt )

main :: IO ()
main = getLine >>= print . solve

solve :: String -> Int
solve xs = let (y:ys) = digitToInt <$> xs in go 0 y ys where
  go !a !y []     = a + y
  go !a !y (z:zs) = go (a + y) z zs + go a (y * 10 + z) zs
