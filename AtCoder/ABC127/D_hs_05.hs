-- https://atcoder.jp/contests/abc127/submissions/19224186
import Data.Ord
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as V
import qualified Data.Vector.Algorithms.Intro as VA
main = do
  [n,m] < -map read.words <$> getLine
  as <- f n
  bcs <- V.replicateM m $ (\v -> (v V.! 0, v V.!1 )) <$> f 2
  print $ solve as bcs
solve as bcs = h . V.foldl' g (0, V.modify VA.sort as) $ V.modify (VA.sortBy $ comparing $ Down . snd) bcs
f n = V.unfoldrN n (B.readInt . B.dropWhile (== ' ')) <$> B.getLine
g (s,as) (b,c) = (s+c*k, V.drop k as) where
  n = V.length as
  k = if n>b && c>as V.!b then b else V.length$V.takeWhile(c>)as
h (s,as) = s + V.sum as
