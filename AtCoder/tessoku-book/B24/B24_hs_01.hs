-- https://atcoder.jp/contests/tessoku-book/submissions/37777820
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', sortBy, unfoldr )
import qualified Data.IntSet as S

main :: IO ()
main = (readLn >>= flip replicateM get) >>= print . sol

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: [[S.Key]] -> Int
sol = S.size . foldl' f S.empty . map snd . sortBy g . map (\(x:y:_) -> (x,y))

f :: S.IntSet -> S.Key -> S.IntSet
f s a = S.insert a $ maybe s (`S.delete` s) (S.lookupGE a s)

g :: (Ord a1, Ord a2) => (a2, a1) -> (a2, a1) -> Ordering
g (x,y) (x',y')
  | x==x' = compare y' y
  | x<x'  = LT
  | otherwise  = GT
