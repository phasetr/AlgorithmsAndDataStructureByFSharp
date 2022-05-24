-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_6_A
-- 今回は負の数がないためVectorでもいけるが, 負の数を含むならArrayの方が便利だろう.
-- もしくはdictやIntMapを使う.
-- MLE
import Data.Array.Unboxed ( (!), UArray )
import Data.Array.ST ( readArray, writeArray, MArray(newArray), runSTUArray )
import Control.Monad ( forM_ )
import Control.Monad.ST ( runST )
import Data.Char (isSpace)
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
main :: IO ()
main = do
  n <- readLn
  av <- fmap (V.unfoldr (B.readInt . B.dropWhile isSpace)) B.getLine
  putStrLn . unwords . V.toList . V.map show $ csort n av

csort :: Int -> V.Vector Int -> V.Vector Int
csort n av = V.concatMap (\i -> V.replicate (cv V.! i) i) (V.fromList [0..n0])
  where
    n0 = 10000
    cv = generateCV (n0+1) av

generateCV :: Int -> V.Vector Int -> V.Vector Int
generateCV n av = runST $ do
  cmv <- VM.replicate n 0
  V.forM_ av $ \a -> do
    val <- VM.read cmv a
    VM.write cmv a (val+1)
  V.freeze cmv

csort0 :: (Int, Int) -> [Int] -> [Int]
csort0 (s,e) as = concatMap (\i -> replicate (ca ! i) i) [s..e] where
  ca :: UArray Int Int
  ca = runSTUArray $ do
    arr <- newArray (s,e) 0
    forM_ as (\a -> do
      val <- readArray arr a
      writeArray arr a (val + 1))
    return arr

test :: IO ()
test = do
  let as = [2,5,1,3,2,3,0]
  let av = V.fromList as
  let n  = V.maximum av + 1
  print $ V.replicate 3 0 == V.fromList [0,0,0]
  print $ generateCV n av == V.fromList [1,1,2,2,0,1]
  print $ csort n av == V.fromList [0,1,2,2,3,3,5]
  print $ csort0 (0,5) as
