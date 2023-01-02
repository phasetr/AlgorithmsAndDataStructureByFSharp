-- https://atcoder.jp/contests/tessoku-book/submissions/37195268
{-# LANGUAGE TypeApplications #-}
import Control.Monad (replicateM)
import Data.Array.IArray (Array, listArray, (!))
import Data.Array.Unboxed (UArray)

solve :: Int -> Int -> UArray (Int, Int) Char -> Array (Int, Int) Int
solve h w cs = dp where
  dp :: Array (Int, Int) Int
  dp = listArray ((1, 1), (h, w)) [f (i, j) | i <- [1 .. h], j <- [1 .. w]]

  f :: (Int, Int) -> Int
  f (1, 1) = 1
  f (1, j) = g (1, j) (dp ! (1, j -1))
  f (i, 1) = g (i, 1) (dp ! (i - 1, 1))
  f (i, j) = g (i, j) (dp ! (i - 1, j) + dp ! (i, j - 1))

  g :: (Int, Int) -> Int -> Int
  g x v = if cs ! x == '#' then 0 else v

main :: IO ()
main = do
  [h, w] <- map read . words <$> getLine
  cs <- listArray @UArray @Char ((1, 1), (h, w)) . concat <$> replicateM h getLine
  print $ solve h w cs ! (h, w)
