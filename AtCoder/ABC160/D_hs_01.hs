-- https://atcoder.jp/contests/abc160/submissions/16040635
{-# LANGUAGE Strict #-}
import qualified Data.Vector.Unboxed as V

main :: IO ()
main = do
  [n, x, y] <- map read . words <$> getLine
  V.forM_ (solve n x y) print

solve :: Int -> Int -> Int -> V.Vector Int
solve n x y = V.accum (+) (V.replicate (n - 1) 0)
  [(f i j - 1, 1) | i <- [1 .. n - 1], j <- [i + 1 .. n]]
  where f i j = minimum [ j - i, abs (x - i) + 1 + abs (y - j), abs (y - i) + 1 + abs (x - j)]
