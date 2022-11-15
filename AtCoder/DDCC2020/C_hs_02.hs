-- https://atcoder.jp/contests/ddcc2020-qual/submissions/8580071
-- https://github.com/minoki/my-atcoder-solutions
{-# LANGUAGE BangPatterns #-}
import Data.Char (isSpace)
import Data.List (unfoldr, intersperse)
import Control.Monad ( forM_ )
import qualified Data.Vector as V
import qualified Data.Vector.Unboxed as U
import qualified Data.ByteString.Char8 as BS
import Data.Array.Unboxed ( (!), UArray )
import Data.Array.ST ( readArray, writeArray, MArray(newArray), runSTUArray )

main = do
  [h,w,k] <- unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
  matrix <- V.replicateM h BS.getLine
  let result :: UArray (Int,Int) Int
      result = runSTUArray $ do
        a <- newArray ((0,0),(h-1,w-1)) 0
        let go !i0 !i !n
              | i == h = do
                  forM_ [i0+1..h-1] $ \i' -> do
                    forM_ [0..w-1] $ \j -> do
                      v <- readArray a (i0,j)
                      writeArray a (i',j) v
              | BS.all (== '.') (matrix V.! i) = go i0 (i+1) n
              | otherwise = do
                  let row = matrix V.! i
                  let go2 !j0 !j !n
                        | j == w = do
                            forM_ [j0+1..w-1] $ \j' -> do
                              writeArray a (i,j') (n-1)
                            return n
                        | row `BS.index` j == '.' = go2 j0 (j+1) n
                        | otherwise = do
                            forM_ [j0+1..j] $ \j' -> do
                              writeArray a (i,j') n
                            go2 j (j+1) (n+1)
                  n' <- go2 (-1) 0 n
                  forM_ [i0+1..i-1] $ \i' -> do
                    forM_ [0..w-1] $ \j -> do
                      v <- readArray a (i,j)
                      writeArray a (i',j) v
                  go i (i+1) n'
        go (-1) 0 1
        return a
  forM_ [0..h-1] $ \i -> do
    putStrLn $ unwords $ [show (result ! (i,j)) | j <- [0..w-1]]

