-- https://atcoder.jp/contests/dp/submissions/30392701
import Data.Char ( isSpace )
import Control.Monad ( forM_ )
import Control.Monad.ST ( runST )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as MV

main :: IO ()
main = do
  n <- readLn
  hs <- V.unfoldr (B.readInt . B.dropWhile isSpace) <$> B.getLine
  print $ solve hs n

solve :: V.Vector Int -> Int -> Int
solve hs n = runST $ do
  vec <- MV.replicate n 0
  MV.write vec 0 0
  MV.write vec 1 (cost 0 1)
  forM_ [2..n-1] $ \i -> do
    dp1 <- MV.read vec (i-1)
    dp2 <- MV.read vec (i-2)
    let dp = min (dp1 + cost i (i-1)) (dp2 + cost i (i-2))
    MV.write vec i dp
  MV.read vec (n-1)
  where cost i j = abs $ (hs V.! i) - (hs V.! j)
