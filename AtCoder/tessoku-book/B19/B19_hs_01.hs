-- https://atcoder.jp/contests/tessoku-book/submissions/37450065
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', unfoldr )
import qualified Data.Vector.Unboxed as U

main :: IO ()
main = get >>= \(n,k) -> replicateM n get >>= print . sol n k

get :: IO (Int, Int)
get = (\[x,y] -> (x,y)) . unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: (U.Unbox a, Foldable t, Num a, Ord a) => Int -> a -> t (a, Int) -> Int
sol n k = U.length . U.takeWhile (<=k) . foldl' f (U.replicate (n*10^3) (10^9+1))

f :: (U.Unbox b, Ord b, Num b) => U.Vector b -> (b, Int) -> U.Vector b
f u (w,v) = U.zipWith min u (U.replicate v w U.++ U.map (+w) u)
