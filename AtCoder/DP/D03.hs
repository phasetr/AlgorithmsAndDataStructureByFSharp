-- https://atcoder.jp/contests/dp/submissions/25093892
import Control.Monad ( replicateM )
import Data.Char ( isSpace )
import Data.List ( foldl', unfoldr )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as VU

main :: IO ()
main = do
  [n,wLimit] <- map read . words <$> getLine :: IO [Int]
  xs <- replicateM n $ do
    [w,v] <- unfoldr (B.readInt . B.dropWhile isSpace) <$> B.getLine
    return (w,v)
  print $ solve wLimit xs

solve :: Int -> [(Int,Int)] -> Int
solve wLimit xs = VU.last $ foldl' step s0 xs where
  step :: VU.Vector Int -> (Int, Int) -> VU.Vector Int
  step tbl (wi,vi) = tbl' where
    tbl' = VU.generate (wLimit+1) $ \i -> max (tbl VU.! i) (if i >= wi then tbl VU.! (i - wi) + vi else 0)
  s0 = VU.replicate (wLimit+1) 0
