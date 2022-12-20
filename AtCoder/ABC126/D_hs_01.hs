-- https://atcoder.jp/contests/abc126/submissions/19106615
import Data.Bool ( bool )
import Data.List ( foldl', unfoldr )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector as V
import qualified Data.IntMap as IM
main :: IO ()
main = do
  n <- readLn
  uvw <- V.replicateM (n-1) $ (\[u,v,w] -> (u-1,v-1,odd w)) . unfoldr (B.readInt . B.dropWhile (==' ')) <$> B.getLine
  mapM_ print $ solve n uvw

solve :: Num a => Int -> V.Vector (Int, Int, Bool) -> [a]
solve n uvw = IM.elems $ f 0 0 False IM.empty where
  g = V.accumulate (flip (:)) (V.replicate n [])
      $ V.concatMap (\(u,v,w) -> V.fromList [(u,(v,w)),(v,(u,w))]) uvw
  f p i o m = foldl' (\m (j,w) -> f i j (o/=w) m) (IM.insert i (bool 0 1 o) m)
              $ filter ((/=p) . fst) $ g V.! i

test = do
  let uvw = V.map (\(u,v,w) -> (u-1,v-1,odd w)) $ V.fromList [(1,2,2),(2,3,1)]
  mapM_ print $ solve 3 uvw
  let uvw = V.map (\(u,v,w) -> (u-1,v-1,odd w)) $ V.fromList [(2,5,2),(2,3,10),(1,3,8),(3,4,2)]
  mapM_ print $ solve 5 uvw
