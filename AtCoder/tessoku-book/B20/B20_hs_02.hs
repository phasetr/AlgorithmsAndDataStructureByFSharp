-- https://atcoder.jp/contests/tessoku-book/submissions/37571052
{-# LANGUAGE FlexibleContexts #-}
import Data.Bool ( bool )
import qualified Data.ByteString.Char8 as C
import Data.Vector.Generic ((!))
import qualified Data.Vector as V
import qualified Data.Vector.Unboxed as U

main :: IO ()
main = sol <$> get <*> get >>= print

get :: IO [Char]
get = C.unpack . C.filter (>'+') <$> C.getLine

sol :: [Char] -> [Char] -> Int
sol s t = U.last dp where
  n = 1+length s
  m = 1+length t
  v = V.fromListN n (' ':s)
  w = U.fromListN m (' ':t)
  dp = V.foldl' f (U.enumFromN (0 :: Int) m) (V.enumFromN (0 :: Int) n)
  f u i = U.unfoldrN m (g u i) (0 :: Int,i)
  g u i (j,x) = Just (x',(j+1,x')) where
    x' = if j==0 then i else minimum [x+1, u!j+1, u!(j-1)+bool 1 0 (w!j==v!i)]
