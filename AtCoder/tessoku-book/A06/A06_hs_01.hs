-- https://atcoder.jp/contests/tessoku-book/submissions/36779727
import Control.Monad ( join, replicateM_ )
import Data.Array ( (!), listArray )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr, scanl' )

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

main :: IO ()
main = join $ sub <$> get <*> get

sub :: (Show a, Num a) => [Int] -> [a] -> IO ()
sub [n,q] as = replicateM_ q (get >>= print . sol a)
  where a = listArray (0,n) $ scanl' (+) 0 as
sub _ _ = error "not come here"

sol a [l,r] = a!r - a!(l-1)
sol _ _ = error "not come here"
