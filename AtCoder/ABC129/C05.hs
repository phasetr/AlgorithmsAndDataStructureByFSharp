-- https://atcoder.jp/contests/abc129/submissions/20180512
import Data.Char (isSpace)
import Data.List (unfoldr)
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as V
main :: IO ()
main = print . solve .
  unfoldr (B.readInt . B.dropWhile isSpace)
  =<< B.getContents

solve :: [Int] -> Int
solve (n:m:as) = snd
  $ V.foldl' f (0,1)
  $ V.accum (||) (V.replicate n False)
  $ map (\a -> (a-1,True)) as
solve _ = undefined
f :: (Int, Int) -> Bool -> (Int, Int)
f (b,c) a = (c, if a then 0 else mod (b+c) m)
  where m = 10^9+7
