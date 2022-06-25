-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_A/review/2917753/lvs7k/Haskell
{-# LANGUAGE BangPatterns #-}
import Control.Monad ( forM_, replicateM )
import qualified Data.ByteString.Char8 as B
import Data.Array.IArray ( (!) )
import Data.Array.IO ( writeArray, MArray(newArray), IOUArray )
import Data.Array.Unboxed ( UArray )
import Data.Array.Unsafe ( unsafeFreeze )
import Data.Maybe ( fromJust )

prim :: Int -> UArray (Int, Int) Int -> [Int]
prim n g = go [1] [] where
  go :: [Int] -> [Int] -> [Int]
  go !as !bs
    | null xs   = bs
    | otherwise = let (v, i) = minimum xs in go (i:as) (v:bs)
    where
      xs = [ (g ! (a, i), i)
           | i <- filter (`notElem` as) [1 .. n]
           , a <- as
           , (g ! (a, i)) /= -1
           ]

main :: IO ()
main = do
  n <- readLn
  xss <- fmap (fmap (fmap (fst . fromJust . B.readInt) . B.words)) (replicateM n B.getLine)
  a <- newArray ((1, 1), (n, n)) (-1) :: IO (IOUArray (Int, Int) Int)
  forM_ (zip [1 ..] xss) $ \(i, xs) -> do
    forM_ (zip [1 ..] xs) $ \(j, x) -> do
      writeArray a (i, j) x
  a <- unsafeFreeze a :: IO (UArray (Int, Int) Int)
  print . sum $ prim n a
