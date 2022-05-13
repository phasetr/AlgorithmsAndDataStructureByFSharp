-- https://atcoder.jp/contests/dp/submissions/22290824
import qualified Data.ByteString.Char8 as C
import Data.Vector.Unboxed ( foldl', scanl', scanr', singleton )

main :: IO ()
main = (C.getLine *> C.getLine) >>= print . solve

solve :: C.ByteString -> Int
solve = foldl' (.+.) 0 . C.foldr' f (singleton 1) where
  p = 10^9+7
  x .+. y = (x+y) `mod` p
  f '<' = scanl' (.+.) 0
  f _   = scanr' (.+.) 0
