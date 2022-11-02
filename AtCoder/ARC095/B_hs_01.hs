-- https://atcoder.jp/contests/abc094/submissions/16173287
import Data.Char ( isSpace )
import Data.List ( maximumBy, unfoldr )
import qualified Data.ByteString.Char8 as B
main :: IO ()
main = putStrLn.unwords.map show.solve.tail.unfoldr(B.readInt.B.dropWhile isSpace)=<<B.getContents
solve :: (Num a, Ord a) => [a] -> [a]
solve as = [n,r] where
  n = maximum as
  r = maximumBy (\a b->compare(f a)(f b))$filter(n>)as
  f = min =<< (n-)
