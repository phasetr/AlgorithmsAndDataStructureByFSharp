-- https://atcoder.jp/contests/dp/submissions/19685837
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', unfoldr )
import qualified Data.Vector.Unboxed as U

main :: IO ()
main = C.getLine >>=
  (\[h,w] -> replicateM h (getw w) >>= print . solve w)
  . unfoldr (C.readInt . C.dropWhile (<'+'))
  where
    getw w = U.fromListN w . C.unpack . C.filter (>='#') <$> C.getLine

solve :: Foldable t => Int -> t (U.Vector Char) -> Int
solve w = U.last . foldl' f (U.cons 1 $ U.replicate (w-1) 0) where
  f = (U.postscanl' (\s (t,c) -> if c=='#' then 0 else mod (s+t) (10^9+7)) (0::Int) .) . U.zip
