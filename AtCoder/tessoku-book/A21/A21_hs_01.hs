-- https://atcoder.jp/contests/tessoku-book/submissions/37597110
import Control.Monad ( replicateM )
import Data.Bool ( bool )
import qualified Data.ByteString.Char8 as C
import Data.Ix ( Ix(inRange) )
import Data.List ( foldl', unfoldr )
import Data.Vector.Generic ((!))
import qualified Data.Vector.Unboxed as U

main :: IO ()
main = sub =<< readLn

sub :: Int -> IO ()
sub n = replicateM n get >>= print . sol n

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: Int -> [[Int]] -> Int
sol n pas = maximum . map fst . U.toList $ foldl' upd u [1..n] where
  p = (0 `U.cons`) . (`U.snoc` 0) . U.fromListN n $ head <$> pas
  a = (0 `U.cons`) . (`U.snoc` 0) . U.fromListN n $ last <$> pas
  u = ((0,(0,n-0)) `U.cons`) . (`U.snoc` (0,(1,n+1))) $ U.empty
  upd v i = ((0,(0,n-i)) `U.cons`) . (`U.snoc` (0,(i+1,n+1))) . U.zipWith f v $ U.tail v
  f (x,(l,r)) (x',(l',r')) = (max (x+bool 0 (a!l) (inRange (l',r) (p!l))) (x'+bool 0 (a!r') (inRange (l',r) (p!r'))), (l',r))
