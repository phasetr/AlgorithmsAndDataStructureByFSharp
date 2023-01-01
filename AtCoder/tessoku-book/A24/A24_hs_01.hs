-- https://atcoder.jp/contests/tessoku-book/submissions/37128252
import Control.Monad (foldM, (>=>))
import Control.Monad.ST (ST, runST)
import Data.Array.ST (STUArray, newArray, readArray, writeArray)
import qualified Data.ByteString.Char8 as BS
import Data.Char (isSpace)
import Data.List (unfoldr)

getInts :: IO [Int]
getInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

searchM :: Monad m => (Int, Int) -> (Int -> m Bool) -> m (Int, Int)
searchM (ng, ok) f
  | abs (ok - ng) == 1 = return (ng, ok)
  | otherwise = do
    x <- f mid
    if x then searchM (ng, mid) f else searchM (mid, ok) f
  where
    mid = (ok + ng) `div` 2

lis :: Int -> [Int] -> Int
lis n as = runST $ do
  l <- newArray (1, n) (maxBound :: Int)
  foldM (f l) 1 as
  where
    f :: STUArray s Int Int -> Int -> Int -> ST s Int
    f l acc a = do
      (_, ok) <- searchM (0, succ acc) (readArray l >=> (\a' -> return (a' >= a)))
      writeArray l ok a
      return (max ok acc)

main :: IO ()
main = do
  n <- readLn
  as <- getInts
  print $ lis n as
