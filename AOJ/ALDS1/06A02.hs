-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_A/review/3406460/utopian/Haskell
import Control.Monad ( forM_ )
import Data.Maybe ( fromJust )
import Data.Array.Unboxed ( (!), UArray )
import Control.Monad.ST ()
import Data.Array.ST ( readArray, writeArray, MArray(newArray), runSTUArray )
import qualified Data.ByteString.Char8 as B

main :: IO ()
main = do
  n <- readLn :: IO Int
  as <- map (fst . fromJust . B.readInt) . B.words <$> B.getLine :: IO [Int]
  putStrLn . unwords . map show $ solve as

solve :: [Int] -> [Int]
solve = countingSort (0,10000)

countingSort :: (Int, Int) -> [Int] -> [Int]
countingSort (s,e) as = concatMap (\i -> replicate (carr ! i) i) [s..e] where
  carr :: UArray Int Int
  carr = runSTUArray $ do
    arr <- newArray (s,e) 0
    forM_ as (\a -> do
      val <- readArray arr a
      writeArray arr a (val + 1)
      )
    return arr
