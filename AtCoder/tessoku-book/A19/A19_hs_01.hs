-- https://atcoder.jp/contests/tessoku-book/submissions/37437678
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', unfoldr )
import qualified Data.Vector.Unboxed as U

main :: IO ()
main = get >>= \(n,k) -> replicateM n get >>= print . sol (k+1)

get :: IO (Int, Int)
get = (\[x,y] -> (x,y)) . unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: (U.Unbox a, Foldable t, Ord a, Num a) => Int -> t (Int, a) -> a
sol k wv = U.last $ foldl' f (U.replicate k 0) wv where
  f u (w,v) = U.zipWith max u (U.replicate w 0 U.++ U.map (+v) u)
