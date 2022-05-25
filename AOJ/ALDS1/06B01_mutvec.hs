import Control.Monad ( forM_, when )
import Control.Monad.ST ( runST )
import qualified Data.ByteString.Char8 as B
import Data.Char ( isSpace )
import Data.STRef ( newSTRef, readSTRef, writeSTRef )
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM

main :: IO ()
main = do
  n <- readLn
  av <- fmap (V.unfoldr (B.readInt . B.dropWhile isSpace)) B.getLine
  putStrLn $ solve n av

solve :: (Show a, Ord a) => Int -> V.Vector a -> String
solve n av = toString $ partition 0 (n-1) av

partition :: Ord a => Int -> Int -> V.Vector a -> (V.Vector a, Int)
partition p r av = runST $ do
  let x = av V.! r
  i <- newSTRef (p-1)
  amv <- V.thaw av
  forM_ [p..r-1] $ \j -> do
    t <- VM.read amv j
    when (t<=x) $ do
      i' <- readSTRef i
      swap (i'+1) j amv
      writeSTRef i (i'+1)
  i' <- readSTRef i
  swap (i'+1) r amv
  av <- V.freeze amv
  return (av, i'+1)
  where
    swap i j mv = do
      x <- VM.read mv i
      y <- VM.read mv j
      VM.write mv i y
      VM.write mv j x

toString :: Show a => (V.Vector a, Int) -> String
toString (xs, i) = before ++ mid ++ after where
  before = unwords . map show . V.toList $ V.take i xs
  after  = unwords . map show . V.toList $ V.drop (i + 1) xs
  mid    = " [" ++ show (xs V.! i) ++ "] "

test = do
  let n = 12
  let as = [13,19,9,5,12,8,7,4,21,2,6,11]
  let asp = V.fromList [9,5,8,7,4,2,6,11,21,13,19,12]
  let ans = "9 5 8 7 4 2 6 [11] 21 13 19 12"
  let av = V.fromList as
  print $ partition 0 (n-1) av == (asp, 7)
  print $ toString (partition 0 (n-1) av) == ans
