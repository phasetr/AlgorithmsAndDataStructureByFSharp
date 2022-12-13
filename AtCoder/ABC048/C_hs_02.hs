-- https://atcoder.jp/contests/abc048/submissions/9850619
import qualified Data.ByteString.Char8 as C
import Data.Maybe ( mapMaybe )

main :: IO ()
main = sol <$> get <*> get >>= print

get :: IO [Int]
get = fmap fst . mapMaybe C.readInt . C.words <$> C.getLine

sol :: (Ord a, Num a) => [a] -> [a] -> a
sol [_,x] = pm (0,0) where
  pm (s,p) []   = s
  pm (s,p) (a:as)
    | p+a <= x  = pm (s,a) as
    | p <= x    = pm (s+p+a-x,x-p) as
    | otherwise = pm (s+p+a-x,0) as
sol _ = error "not come here"
