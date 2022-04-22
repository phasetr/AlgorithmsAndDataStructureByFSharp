-- https://atcoder.jp/contests/dp/submissions/19661314
import Control.Monad ( replicateM )
import Data.Array ( elems, array, (!) )
import Data.Bool ( bool )
import qualified Data.ByteString.Char8 as C
import Data.Graph ( buildG, vertices, Vertex )
import Data.List ( unfoldr )

main :: IO ()
main = get >>= \[n,m] -> replicateM m get >>= print . solve n where
  get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

solve :: (Num a, Ord a) => Int -> [[Vertex]] -> a
solve n es = maximum $ elems a where
  g = buildG (1,n) $ fmap (\[u,v] -> (u,v)) es
  a = array (1,n) [(i, f as) | i <- vertices g, let as = fmap (a!) (g!i)]
  f = \as -> bool (1+maximum as) 0 (null as)
