-- https://atcoder.jp/contests/agc023/submissions/3009442
import Data.List ( scanl', unfoldr )
import qualified Data.IntMap.Strict as M
import qualified Data.ByteString.Char8 as B
main = getLine *> B.getLine >>=
  print . sum . map (\a -> (a*a-a) `div` 2) . M.elems . foldl (\m a -> M.insertWith(+) a 1 m) M.empty. scanl' (+) 0 . unfoldr (B.readInt . B.dropWhile (==' '))
