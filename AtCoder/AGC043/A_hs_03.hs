-- https://atcoder.jp/contests/agc043/submissions/11066595
import Data.Array ( listArray )
import Data.Array.IO
    ( readArray,
      thaw,
      writeArray,
      MArray(getBounds, newArray),
      IOUArray )
import Control.Monad ( replicateM, forM_, when )

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

  ((minh,minw), (maxh,maxw)) <- getBounds dp

  forM_ [1..h] $ \i -> do
    forM_ [1..w] $ \j -> do
      d <- readArray dp (i,j)
      g <- readArray grid (i,j)
      forM_ [(i+1,j),(i,j+1)] $ \p@(i',j') -> do
        when (i' <= maxh && j' <= maxw) $ do
          readArray grid p >>= \r ->
            if (r == '#') && (g == '.')
               then readArray dp p >>= \s -> writeArray dp p $ min (d+1) s
               else readArray dp p >>= \s -> writeArray dp p $ min d s

  readArray dp (h,w) >>= print
