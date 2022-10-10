-- https://atcoder.jp/contests/agc043/submissions/11066643
import Data.Array ( listArray )
import Data.Array.IO
    ( readArray, thaw, writeArray, MArray(newArray), IOUArray )
import Control.Monad ( replicateM, unless, forM_ )

type Grid = IOUArray (Int,Int) Char
type DP = IOUArray (Int,Int) Int
main :: IO ()

main = do
  [h,w] <- map read . words <$> getLine :: IO [Int]
  xss <- replicateM h getLine
  grid <- thaw $ listArray ((1,1),(h,w)) $ concat xss :: IO Grid
  dp <- newArray ((1,1),(h,w)) (10^9) :: IO DP

  readArray grid (1,1) >>= \r -> do
    if r == '#' then writeArray dp (1,1) 1 else writeArray dp (1,1) 0

  forM_ [1..h] $ \i -> do
    forM_ [1..w] $ \j -> do
      d <- readArray dp (i,j)
      g <- readArray grid (i,j)
      forM_ [(i+1,j),(i,j+1)] $ \p@(i',j') -> do
        unless (i' > h || j' > w) $ do
          readArray grid p >>= \g' ->
            if (g' == '#') && (g == '.')
               then readArray dp p >>= \d' -> writeArray dp p $ min (d+1) d'
               else readArray dp p >>= \d' -> writeArray dp p $ min d d'

  readArray dp (h,w) >>= print
