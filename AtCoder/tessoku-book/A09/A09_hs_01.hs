-- https://atcoder.jp/contests/tessoku-book/submissions/37012319
{-# LANGUAGE TupleSections #-}
import Control.Monad ( replicateM )
import Data.Array.Unboxed ( (!), accumArray, listArray, UArray )
import qualified Data.ByteString.Char8 as C
import Data.List ( transpose, unfoldr )

main :: IO ()
main = sub . (\[h,w,n] -> (h,w,n)) =<< get

sub :: (Int, Int, Int) -> IO ()
sub (h,w,n) = replicateM n get >>= put . sol h w n

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

put :: [[Int]] -> IO ()
put = mapM_ (putStrLn . unwords . map show)

sol :: Int -> Int -> p -> [[Int]] -> [[Int]]
sol h w n ps = transpose $ map k [0..w-1] where
  a = accumArray (+) 0 ((0,0),(h,w)) $ f ps :: UArray (Int, Int) Int
  b = listArray ((0,0),(h-1,w-1)) $ concatMap g [0..h-1] :: UArray (Int, Int) Int
  g = \i -> (scanl1 (+) . map ((a!) . (i,))) [0..w-1]
  k = \j -> (scanl1 (+) . map ((b!) . (,j))) [0..h-1]

f :: (Num b1, Num b2) => [[b1]] -> [((b1, b1), b2)]
f [] = []
f ([a,b,c,d]:ps) = ((a-1,b-1),1):((a-1,d),-1):((c,b-1),-1):((c,d),1):f ps
f _ = error "not come here"
