-- https://atcoder.jp/contests/tessoku-book/submissions/37032709
import Control.Monad ( Monad((>>=)), mapM_, (=<<), when, replicateM )
import qualified Data.ByteString.Char8 as C
import Data.List ( map, unwords, unfoldr )
import Data.Vector.Generic ((!))
import Data.Vector.Unboxed (Vector, accum, modify, replicate)
import Data.Vector.Unboxed.Mutable (unsafeRead, unsafeWrite)
import Prelude hiding (replicate)

main :: IO ()
main = sub . (\[h,w,n] -> (h,w,n)) =<< get

sub :: (Int, Int, Int) -> IO ()
sub (h,w,n) = replicateM n get >>= put . sol h w

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

put :: [[Int]] -> IO ()
put = mapM_ (putStrLn . unwords . map show)

sol :: Int -> Int -> [[Int]] -> [[Int]]
sol h w ps = [[v ! ix (i,j) | j <- [0..w-1]] | i <- [0..h-1]] where
  v = modify k . modify g . accum (+) (replicate (h*w) 0) $ f ps
  ix (i,j) = i*w+j
  f [] = []
  f ([a,b,c,d]:ps)
    | c==h && d==w  = (ix (a-1,b-1),1):f ps
    | c==h          = (ix (a-1,b-1),1):(ix (a-1,d),-1):f ps
    | d==w          = (ix (a-1,b-1),1):(ix (c,b-1),-1):f ps
    | otherwise     = (ix (a-1,b-1),1):(ix (a-1,d),-1):(ix (c,b-1),-1):(ix (c,d),1):f ps
  f _ = error "not come here"
  g v = loop 0 1 where
    loop i j = when (i < h && j < w) $ do
      x <- unsafeRead v $ ix (i,j-1)
      y <- unsafeRead v $ ix (i,j)
      unsafeWrite v (ix (i,j)) (x+y)
      if j==w-1 then loop (i+1) 1 else loop i (j+1)
  k v = loop 1 0 where
    loop i j = when (i < h && j < w) $ do
      x <- unsafeRead v $ ix (i-1,j)
      y <- unsafeRead v $ ix (i,j)
      unsafeWrite v (ix (i,j)) (x+y)
      if i==h-1 then loop 1 (j+1) else loop (i+1) j
