-- cf. https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/2610054/nmjiri/Haskell
import qualified Data.ByteString.Char8 as B
import Control.Monad ( when, forM_ )
import Data.Char (isSpace)
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import Control.Monad.ST ( runST )
import Data.STRef ( newSTRef, readSTRef, writeSTRef )

main :: IO ()
main = do
  n <- readLn
  av <- fmap (V.unfoldr (B.readInt . B.dropWhile isSpace)) B.getLine
  let avc = bsort n av
  (putStrLn . unwords . V.toList . V.map show) (fst avc)
  print (snd avc)

bsort :: Ord a => Int -> V.Vector a -> (V.Vector a, Int)
bsort n av = runST $ do
  c <- newSTRef (0 :: Int)
  amv <- V.thaw av
  forM_ [0..(n-2)] $ \i -> do
    forM_ [0..(n-i-2)] $ \j -> do
      aj <- VM.read amv j
      aj1 <- VM.read amv (j+1)
      when (aj1 < aj) $ do
        c0 <- readSTRef c
        writeSTRef c (c0+1)
        VM.write amv j aj1
        VM.write amv (j+1) aj
  av <- V.freeze amv
  c0 <- readSTRef c
  return (av, c0)

test = do
  print $ bsort 5 (V.fromList [5,3,2,4,1]) == (V.fromList [1..5],8)
  print $ bsort 6 (V.fromList [5,2,4,6,1,3]) == (V.fromList [1..6],9)
--  print (bsort 3 (V.fromList [3,2,1]) == V.fromList [1..3])
--  print (bsort 4 (V.fromList [3,4,1,2]) == V.fromList [1..4])
--  putStrLn (unwords $ V.toList $ V.map show (bsort 4 (V.fromList [3,4,1,2])))
