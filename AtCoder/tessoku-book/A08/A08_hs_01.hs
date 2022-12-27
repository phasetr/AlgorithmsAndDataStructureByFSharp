-- https://atcoder.jp/contests/tessoku-book/submissions/36903623
import Control.Monad ( join, replicateM, replicateM_ )
import Data.Array.Unboxed ( (!), listArray, UArray )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr, scanl' )

main :: IO ()
main = sub . (\[h,w] -> (h,w)) =<< get

sub :: (Int, Int) -> IO ()
sub (h,w) = join $ sol h w <$> replicateM h get <*> readLn

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: Int -> Int -> [[Int]] -> Int -> IO ()
sol h w ass q = replicateM_ q (get >>= print . f ar) where
  ar = listArray ((0,0),(h,w)) . concat . scanl' (zipWith (+)) (replicate (w+1) 0) $ map (scanl' (+) 0) ass

f :: UArray (Int, Int) Int -> [Int] -> Int
f ar [a,b,c,d] = ar!(a-1,b-1)-ar!(a-1,d)-ar!(c,b-1)+ar!(c,d)
f _ _ = error "not come here"
