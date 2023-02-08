-- https://atcoder.jp/contests/tessoku-book/submissions/36908081
{-# LANGUAGE TupleSections #-}
import Control.Monad ( join, replicateM, replicateM_, liftM2 )
import Data.Array.Unboxed
    ( Ix, (!), accumArray, listArray, IArray, UArray )
import qualified Data.ByteString.Char8 as C
import Data.List ( scanl', unfoldr )

main :: IO ()
main = sub =<< readLn

sub :: Int -> IO ()
sub n = join $ sol n <$> replicateM n get <*> readLn

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: p -> [[Int]] -> Int -> IO ()
sol n ps q = replicateM_ q (get >>= print . f v) where
  (h0,h1) = liftM2 (,) minimum maximum $ map head ps
  (w0,w1) = liftM2 (,) minimum maximum $ map last ps
  a = accumArray (+) 0 ((h0,w0),(h1,w1)) $ map (\[x,y] -> ((x,y), 1)) ps :: UArray (Int, Int) Int
  v = listArray ((h0-1,w0-1),(h1,w1)) . concat
    . scanl' (zipWith (+)) (replicate (w1-w0+2) 0)
    $ map (\i -> (scanl' (+) 0 . map ((a!) . (i,))) [w0..w1]) [h0..h1] :: UArray (Int, Int) Int

f :: (IArray a1 e, Ix a2, Num e, Num a2) => a1 (a2, a2) e -> [a2] -> e
f v [a,b,c,d] = v!(a-1,b-1)-v!(a-1,d)-v!(c,b-1)+v!(c,d)
f _ _ = error "not come here"
