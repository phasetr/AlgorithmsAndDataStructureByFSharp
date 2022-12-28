-- https://atcoder.jp/contests/tessoku-book/submissions/37130579
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )
import Data.Vector.Generic ((!))
import Data.Vector.Unboxed (Vector, fromListN)

main :: IO ()
main = sol <$> get <*> get >>= print

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: [Int] -> [Int] -> Int
sol [n,x] as = f 1 n where
  v = fromListN (n+1) (0:as)
  f l r
    | v!l==x    = l
    | v!r==x    = r
    | v!m>x     = f l m
    | otherwise = f m r
    where m = (l+r) `div` 2
sol _ _ = error "not come here"
