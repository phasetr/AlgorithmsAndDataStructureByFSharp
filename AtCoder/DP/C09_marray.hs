-- https://atcoder.jp/contests/dp/submissions/30398817
import Control.Monad ( forM_, replicateM )
import Data.Char ( isSpace )
import Data.List ( unfoldr )
import qualified Data.ByteString.Char8 as B
import qualified Data.Array.Unboxed as A
import qualified Data.Array.MArray as MA
import Data.Array.ST ( STUArray )
import Control.Monad.ST ( ST, runST )

main :: IO ()
main = do
  [n,wLimit] <- map read . words <$> getLine :: IO [Int]
  xs <- replicateM n $ do
    [w,v] <- unfoldr (B.readInt . B.dropWhile isSpace) <$> B.getLine -- :: IO [Int]
    return (w,v)
  print $ solve (n,wLimit) xs

solve :: (Int,Int) -> [(Int,Int)] -> Int
solve (n,wLimit) xs = runST $ do
  let xs' = zip [1..n] xs
  arr <- MA.newArray ((0,0),(n,wLimit)) 0 :: ST s (STUArray s (Int,Int) Int)
  forM_ xs' $ \(i,(w,v)) -> do
    forM_ [1..wLimit] $ \j -> do
      prevval <- MA.readArray arr (i-1,j)
      candidate <- if j >= w then MA.readArray arr (i-1,j-w) else return 0
      let vcand = if j >= w then v else 0
      MA.writeArray arr (i,j) (max prevval (candidate+vcand))
  MA.readArray arr (n,wLimit)
