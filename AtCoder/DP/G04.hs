-- https://atcoder.jp/contests/dp/submissions/19669646
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
  a = array (1,n) $ fmap ((,) <*> f) (vertices g)
  f = \i -> bool (1+maximum (fmap (a!) (g!i))) 0 (null (g!i))
