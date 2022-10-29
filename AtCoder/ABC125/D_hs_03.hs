-- https://atcoder.jp/contests/abc125/submissions/5172231
import Data.Char(isSpace)
import qualified Data.Vector.Unboxed as U
import qualified Data.ByteString.Char8 as C

main :: IO ()
main = do
  n <- readLn
  as <- U.unfoldrN n (C.readInt . C.dropWhile isSpace) <$> C.getLine
  let negCnt = U.length $ U.filter (<0) as
  let absLst = U.map abs as
  let absSum = U.sum absLst
  let absMin = U.minimum absLst
  print $ if even negCnt then absSum else absSum - 2*absMin
