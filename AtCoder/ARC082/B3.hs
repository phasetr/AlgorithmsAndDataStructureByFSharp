{-
https://atcoder.jp/contests/abc072/submissions/22314679
-}
import qualified Data.ByteString.Char8 as C
import qualified Data.Vector.Unboxed as VU
import Data.Char (isSpace)

main :: IO ()
main = do
  n <- readLn
  ps <- VU.unfoldrN n (C.readInt . C.dropWhile isSpace) <$> C.getLine
  print $ solve ps

solve :: VU.Vector Int -> Int
solve ps = go (VU.head ps) (VU.tail ps) 1 0
  where
    go p ps i acc
      | VU.null ps && p /= i = acc
      | VU.null ps = acc + 1
      | p == i = go p (VU.tail ps) (i+1) (acc+1)
      | otherwise = go (VU.head ps) (VU.tail ps) (i+1) acc
