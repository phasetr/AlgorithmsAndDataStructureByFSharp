-- https://atcoder.jp/contests/tessoku-book/submissions/37259790
import Control.Monad ()
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )
import Data.Vector.Generic ((!))
import qualified Data.Vector.Unboxed as VU

main :: IO ()
main = sol <$> get <*> get >>= print

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: [Int] -> [Int] -> Int
sol [n,k] as = f 0 0 n 0 where
  v = VU.fromListN (n+1) (as++[10^9])
  p i j = k < v!j-v!i
  f i l r s
    | i==n-1    = s
    | p i l     = f (i+1) l r (s+l-i-1)
    | otherwise = f (i+1) j r (s+j-i-1)
    where j = bsearch l r (p i)
sol _ _ = error "not come here"

bsearch :: Integral t => t -> t -> (t -> Bool) -> t
bsearch l r p
  | l+1>=r    = r
  | p m       = bsearch l m p
  | otherwise = bsearch m r p
  where m = (l+r) `div` 2
