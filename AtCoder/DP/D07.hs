-- https://atcoder.jp/contests/dp/submissions/12179183
import Control.Monad
import Data.List ( foldl' )
import qualified Data.Vector.Unboxed as U

solve n goods w = U.last $ foldl' f initial goods where
  f acc (w, v) = U.zipWith max acc pick where
    pick = U.map (v+) $ U.replicate w (-v) U.++ acc
  initial = U.replicate (w+1) (0::Int)

main = do
  [n,w] <- map read.words <$> getLine
  goods <- replicateM n $ (\[a,b]->(a,b)).map read.words <$> getLine
  print $ solve n goods w
