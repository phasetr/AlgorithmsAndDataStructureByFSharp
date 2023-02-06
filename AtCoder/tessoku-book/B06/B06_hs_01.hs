-- https://atcoder.jp/contests/tessoku-book/submissions/36837700
import Control.Monad ( join, replicateM_ )
import Data.Array ( Ix, Array, (!), listArray )
import qualified Data.ByteString.Char8 as C
import Data.List ( scanl', unfoldr )

main :: IO ()
main = join $ sub <$> readLn <*> get <*> readLn

sub :: Int -> [Int] -> Int -> IO ()
sub n as q = replicateM_ q (get >>= putStrLn . sol a) where
  a = listArray (0,n) $ scanl' (+) 0 as

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: (Num a, Ix a) => Array a a -> [a] -> [Char]
sol a [l,r] = case compare (r-l+1) (2*(a!r - a!(l-1))) of
  LT -> "win"
  EQ -> "draw"
  GT -> "lose"
sol _ _ = error "not come here"
