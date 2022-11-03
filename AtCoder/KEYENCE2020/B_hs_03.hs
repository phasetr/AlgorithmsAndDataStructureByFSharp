-- https://atcoder.jp/contests/keyence2020/submissions/10973185
{-# LANGUAGE BangPatterns #-}
import Data.Char ( isSpace )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed   as U
import qualified Data.IntMap           as M

readPair :: IO (Int, Int)
readPair = ((,) <$> U.head <*> U.last) . U.unfoldrN 2 (B.readInt . B.dropWhile isSpace) <$> B.getLine

main :: IO ()
main = do
  n <- readLn
  xls <- U.replicateM n readPair
  print $ solve xls

solve :: U.Vector (Int, Int) -> Int
solve = go 0 minBound . U.foldr (\(x, l) mp -> M.insertWith max (x + l) (x - l) mp) M.empty where
  go !k !t0 !mp = case M.minViewWithKey mp of
    Nothing       -> k
    Just ((t,s),mp1)
      | t0 <= s   -> go (k + 1) t mp1
      | otherwise -> go k t0 mp1
