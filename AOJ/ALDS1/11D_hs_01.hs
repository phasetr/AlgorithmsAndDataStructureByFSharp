-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_D/review/2917691/lvs7k/Haskell
import Control.Monad ( filterM, forM_, replicateM, when )
import qualified Data.ByteString.Char8 as B
import Data.Maybe ( fromJust )
import Data.Array.IArray ( (!), IArray(bounds), Array, accumArray )
import Data.Array.IO
    ( writeArray, readArray, MArray(newArray), IOArray )
import Data.Array.MArray
    ( writeArray, readArray, MArray(newArray) )

readi :: B.ByteString -> Int
readi = fst . fromJust . B.readInt

paint :: Array Int [Int] -> IOArray Int Int -> IO ()
paint g d = do
  let (s, t) = bounds g
  forM_ [s .. t] $ \i -> do
    c <- readArray d i
    when (c == -1) $ go i i
  where
    go :: Int -> Int -> IO ()
    go c k = do
      writeArray d k c
      cs <- filterM (fmap (== -1) . readArray d) (g ! k)
      mapM_ (go c) cs

main :: IO ()
main = do
  [n,m] <- fmap (fmap readi . B.words) B.getLine
  mss <-
      fmap (accumArray (flip (:)) [] (0, n - 1)
            . concatMap ((\[a, b] -> [(a, b), (b, a)]) . fmap readi . B.words))
      (replicateM m B.getLine) :: IO (Array Int [Int])
  q <- fmap readi B.getLine
  qss <- fmap (fmap ((\[a, b] -> (a, b)) . fmap readi . B.words)) (replicateM q B.getLine)
  d <- newArray (0, n - 1) (-1) :: IO (IOArray Int Int)
  paint mss d
  forM_ qss $ \(i, j) -> do
    vi <- readArray d i
    vj <- readArray d j
    if vi == vj then putStrLn "yes" else putStrLn "no"

