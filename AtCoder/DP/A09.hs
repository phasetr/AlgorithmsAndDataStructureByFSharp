-- https://atcoder.jp/contests/dp/submissions/19415641
import qualified Data.ByteString.Char8 as B
import Data.Char (isSpace)
import Data.List (unfoldr)

main = do
  (_:h1:h2:hs) <- unfoldr(B.readInt.B.dropWhile isSpace) <$> B.getContents
  print $ f 0 (abs (h1-h2)) (h1:h2:hs)

f :: (Ord a, Num a) => a -> a -> [a] -> a
f _ c [_,_] = c
f c1 c2 (h1:h2:h3:hs) = f (min (c1 + abs (h1-h2)) c2) (min (c1 + abs (h1-h3)) (c2 + abs (h2-h3))) (h2:h3:hs)
f _ _ _ = undefined
