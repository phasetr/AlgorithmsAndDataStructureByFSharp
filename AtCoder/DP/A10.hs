-- https://atcoder.jp/contests/dp/submissions/19409630
import qualified Data.ByteString.Char8 as C
import Data.List (unfoldr)

main :: IO ()
main = C.getLine >> C.getLine >>=
  print . solve . unfoldr (C.readInt . C.dropWhile (<'+'))

solve :: [Int] -> Int
solve hs@(h1:h2:hr) = (\(_,_,_,c) -> c) dp where
  dp = foldl f (h1, 0, h2, d h1 h2) hr
  f (h1, c1, h2, c2) h = (h2, c2, h, min (c2+d h h2) (c1+d h h1))
  d = (abs .) . (-)
solve _ = undefined
