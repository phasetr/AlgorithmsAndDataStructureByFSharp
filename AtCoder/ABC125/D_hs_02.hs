-- https://atcoder.jp/contests/abc125/submissions/15796808
import Data.Char ( isSpace )
import Data.List ( unfoldr )
import qualified Data.ByteString.Char8 as B
main :: IO ()
main = print . solve . unfoldr (B.readInt . B.dropWhile isSpace) =<< (B.getLine >> B.getLine)
solve :: [Int] -> Int
solve = g =<< foldr f(0,0,0)
f :: (Ord a1, Num a1, Num a2, Num a3, Num a4) => a1 -> (a2, a4, a3) -> (a2, a4, a3)
f a (i,j,k)
  | a<0 = (i+1,j,k)
  | a>0 = (i,j,k+1)
  | otherwise = (i,j+1,k)
g :: (Integral a1, Num a2, Ord a2, Ord a3, Num a3) => (a1, a2, c) -> [a3] -> a3
g (i,j,k) as
  | even i || j>0 = sum bs
  | otherwise = sum bs - minimum bs*2
  where bs = map abs as
