-- https://atcoder.jp/contests/agc011/submissions/17434795
import Data.Char
import Data.List
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as V
import qualified Data.Vector.Algorithms.Intro as VA
main = print . solve . unfoldr (B.readInt . B.dropWhile isSpace) =<< B.getContents
solve (n:as) = (1+) . V.length . V.takeWhile f . V.zip bs . V.tail $ cs where
  bs = V.modify (VA.sortBy $ flip compare) . V.fromList $ as
  cs = V.scanr1 (+) bs
f (b,c) = b <= c*2
