-- https://atcoder.jp/contests/abc061/submissions/30606577
import Control.Monad (replicateM)
import qualified Data.ByteString.Char8 as BS
import Data.Char (isSpace)
import Data.List (sort,unfoldr)
import Data.Functor ((<&>))

bsGetLnInts :: IO [Int]
bsGetLnInts = BS.getLine
  <&> unfoldr (BS.readInt . BS.dropWhile isSpace)

main :: IO ()
main = do
  [n,k] <- bsGetLnInts
  abs <- replicateM n bsGetLnInts
  print $ solve n k abs

solve :: Int -> Int -> [[Int]] -> Int
solve n k abs = loop k $ sort abs

loop k ((a:b:_):abs)
  | k > b = loop (k - b) abs
  | otherwise  = a
loop k _ = error "undefined"
