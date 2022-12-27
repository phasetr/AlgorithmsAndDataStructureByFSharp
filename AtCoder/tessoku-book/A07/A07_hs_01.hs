-- https://atcoder.jp/contests/tessoku-book/submissions/36855557
import Control.Monad ( join, replicateM )
import Data.Array ( Ix, accumArray, elems )
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', unfoldr )

main :: IO ()
main = join $ sub <$> readLn <*> readLn

sub :: Int -> Int -> IO ()
sub d n = replicateM n get >>= put . sol d
 where
   get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine
   put = mapM_ print

sol :: (Ix i, Num a, Num i, Foldable t, Enum i) => i -> t [i] -> [a]
sol d = scanl1 (+) . init . elems . accumArray (+) 0 (0,d) . foldl' (\s [l,r] -> (pred l,1):(r,-1):s) []

test = do
  let d = 8
  let n = 5
  let as = [[2,3],[3,6],[5,7],[3,7],[1,5]]
  let bs = foldl' (\s [l,r] -> (pred l,1):(r,-1):s) [] as
  print bs
  let aa = accumArray (+) 0 (0,d) bs
  print aa
  print $ elems aa
  print $ init $ elems aa
  print $ scanl1 (+) $ init $ elems aa
