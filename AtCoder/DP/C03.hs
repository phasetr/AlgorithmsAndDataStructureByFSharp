-- https://atcoder.jp/contests/dp/submissions/25090836
import Control.Monad (replicateM)
import Data.Char (isSpace)
import Data.List (unfoldr)
import qualified Data.ByteString.Char8 as B

main :: IO ()
main = do
  n <- readLn
  xs <- replicateM n
    $ (\[a,b,c] -> (a,b,c))
    . unfoldr (B.readInt . B.dropWhile isSpace) <$> B.getLine
  print $ solve xs

solve :: [(Int,Int,Int)] -> Int
solve xs = (\(x,y,z)->max (max x y) z) $ foldl step (0,0,0) xs where
  step (a0,b0,c0) (a,b,c) = (a + max b0 c0, b + max c0 a0, c + max a0 b0)
