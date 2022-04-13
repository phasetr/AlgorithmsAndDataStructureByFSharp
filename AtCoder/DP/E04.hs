-- https://atcoder.jp/contests/dp/submissions/24472285
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', unfoldr )
import qualified Data.Vector.Unboxed as U

main :: IO ()
main = get >>= \(n,k) -> replicateM n get >>= print . solve n k
get :: IO (Int, Int)
get = (\[x,y] -> (x,y))
  . unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

solve :: Foldable t => Int -> Int -> t (Int, Int) -> Int
solve n k wv =
  U.length . U.takeWhile (<=k)
  $ foldl' f (U.replicate (n*10^3) (k+1)) wv

f :: U.Vector Int -> (Int, Int) -> U.Vector Int
f u (w,v) = U.zipWith min u (U.replicate v w U.++ U.map (+w) u)
