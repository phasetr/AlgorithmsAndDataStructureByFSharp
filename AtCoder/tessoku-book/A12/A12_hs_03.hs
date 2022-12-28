-- https://atcoder.jp/contests/tessoku-book/submissions/37246111
import Control.Monad ()
import qualified Data.ByteString.Char8 as C
import Data.List ( sort, unfoldr )
import qualified Data.Vector.Unboxed as VU

main :: IO ()
main = sol <$> get <*> get >>= print

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: [Int] -> [Int] -> Int
sol [n,k] as = bsearch 0 (10^9) ((k<=) . f) where
  v = VU.fromListN n $ sort as
  f i = VU.foldl' (\s e-> s+i `div` e) 0 v
sol _ _ = error "not come here"

bsearch :: Integral t => t -> t -> (t -> Bool) -> t
bsearch l r p
  | l+1>=r    = r
  | p m       = bsearch l m p
  | otherwise = bsearch m r p
  where m = (l+r) `div` 2
