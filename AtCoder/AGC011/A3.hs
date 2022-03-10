{-
https://atcoder.jp/contests/agc011/submissions/10371123
-}
import Control.Monad
import Data.List
import qualified Data.ByteString.Char8 as BS

main :: IO ()
main = do
  [n,c,k] <- map read . words <$> getLine
  ts <- replicateM n $ read . BS.unpack <$> BS.getLine
  print $ solve 0 c k (sort ts)

solve :: Int -> Int -> Int -> [Int] -> Int
solve bus _ _ [] = bus
solve bus c k (t:ts) =
  solve (bus+1) c k (f c (k+t) (t:ts)) where
    f _ _ [] = []
    f 0 _ ts = ts
    f c k (t:ts) = if t<=k then f (c-1) k ts else t:ts
