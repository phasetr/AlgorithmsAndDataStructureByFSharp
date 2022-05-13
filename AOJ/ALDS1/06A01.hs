-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_6_A
import Control.Monad ( forM_ )
import Data.Maybe ( fromJust )
import Data.Array.Unboxed ( (!), UArray )
import Control.Monad.ST ()
import Data.Array.ST ( readArray, writeArray, MArray(newArray), runSTUArray )
import qualified Data.ByteString.Char8 as B

main :: IO ()
main = getLine >> B.getLine >>=
  putStrLn . unwords . map show
  . solve . map (fst . fromJust . B.readInt) . B.words

solve :: [Int] -> [Int]
solve = csort (0,10000)

csort :: (Int, Int) -> [Int] -> [Int]
csort (s,e) as = concatMap (\i -> replicate (ca ! i) i) [s..e] where
  ca :: UArray Int Int
  ca = runSTUArray $ do
    arr <- newArray (s,e) 0
    forM_ as (\a -> do
      val <- readArray arr a
      writeArray arr a (val + 1))
    return arr

test :: IO ()
test = print $ solve [2,5,1,3,2,3,0] == [0,1,2,2,3,3,5]
