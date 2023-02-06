-- https://atcoder.jp/contests/tessoku-book/submissions/36856572
import Control.Monad ( join, replicateM )
import Data.Array ( Ix, elems, accumArray )
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', unfoldr )

main :: IO ()
main = join $ sub <$> readLn <*> readLn

sub :: Int -> Int -> IO ()
sub t n = replicateM n (unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine)
  >>= mapM_ print . sol t

sol :: (Ix i, Num a, Num i, Foldable t) => i -> t [i] -> [a]
sol t = scanl1 (+) . init . elems . accumArray (+) 0 (0,t) . foldl' (\s [l,r] -> (l,1):(r,-1):s) []
