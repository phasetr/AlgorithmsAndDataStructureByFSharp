-- https://atcoder.jp/contests/dp/submissions/19486243
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', unfoldr )
import qualified Data.Vector.Unboxed as U

main :: IO ()
main = get >>= \(n,k) -> replicateM n get
  >>= print . solve k

get :: IO (Int, Int)
get = (\[x,y] -> (x,y)) . unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

solve :: Int -> [(Int, Int)] -> Int
solve k wv = U.last . U.findIndices (<=k)
  $ foldl' f (U.cons 0 $ U.replicate m b) wv
  where
    b = sum (fmap fst wv) + 1
    m = sum (fmap snd wv)
    f u (w,v) = U.zipWith min u (U.replicate v b U.++ U.map (+w) u)
