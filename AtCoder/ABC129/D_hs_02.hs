-- https://atcoder.jp/contests/abc129/submissions/24784283
import Data.Function ( fix )
import Data.Array.ST ( readArray, writeArray, MArray(newArray), runSTUArray )
import Data.Array.Unboxed ( (!), listArray, UArray )
import Control.Monad ( forM_ )

main :: IO ()
main = do
  [h, w] <- map read . words <$> getLine
  ss <- lines <$> getContents
  print $ solve h w ss

solve :: Int -> Int -> [String] -> Int
solve h w ss = maximum [answer ! (i, j) | i <- [1..h], j <- [1..w]]
  where
    field = listArray ((1, 1), (h, w)) $ concat ss
    answer = calc h w field

calc :: Int -> Int -> UArray (Int, Int) Char -> UArray (Int, Int) Int
calc h w field = runSTUArray $ do
  d <- newArray ((1, 1), (h, w)) 0
  forM_ [1..h] $ \i -> do
    fix (\loop j n -> do
      if w < j then return n else do
        case field ! (i, j) of
          '.' -> do
             res <- loop (j + 1) (n + 1)
             writeArray d (i, j) res
             return res
          _ -> do
             loop (j + 1) 0
             return n) 1 0
  forM_ [1..w] $ \j -> do
    fix (\loop i n -> do
      if h < i then return n else do
        case field ! (i, j) of
          '.' -> do
             res <- loop (i + 1) (n + 1)
             c <- readArray d (i, j)
             writeArray d (i, j) (c + res - 1)
             return res
          _ -> do
             loop (i + 1) 0
             return n) 1 0

  return d
