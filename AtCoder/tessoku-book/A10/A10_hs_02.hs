-- https://atcoder.jp/contests/tessoku-book/submissions/37049624
import Control.Monad ( join, replicateM_ )
import Data.Array.Unboxed ( (!), listArray, UArray )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr, scanl' )

main :: IO ()
main = join $ sub <$> readLn <*> get <*> readLn

sub :: Int -> [Int] -> Int -> IO ()
sub n as d = replicateM_ d (get >>= print. sol a b) where
  a = listArray (0,n) $ scanl' max 0 as :: UArray Int Int
  b = listArray (0,n) $ scanr max 0 as :: UArray Int Int

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol a b [l,r] = max (a!(l-1)) (b!r)
sol _ _ _ = error "not come here"
