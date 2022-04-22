-- https://atcoder.jp/contests/dp/submissions/4032169
import qualified Data.ByteString.Char8 as B
import Data.List ( unfoldr )
import qualified Data.Vector as V

main :: IO ()
main = do
  [n,m] <- map read . words <$> getLine
  xys <- V.replicateM m
    $ (\[a,b] -> (a-1,b-1)) . unfoldr (B.readInt . B.dropWhile (<'!'))
    <$> B.getLine
  print $ solve n xys

solve :: (Num a, Ord a) => Int -> V.Vector (Int, Int) -> a
solve n xys = V.maximum v where
  ve = V.accumulate (flip (:)) (V.replicate n []) xys
  v = V.generate n m
  m i = (+1) $ maximum $ ((-1):) $ map (v V.!) (ve V.! i)

test :: IO ()
test = do
  print $ V.accumulate (flip (:)) (V.replicate n []) xyv == V.fromList [[],[3,2],[4],[4,2]]
  print $ V.generate n m
  where
    n = 4
    xys = [(1,2),(1,3),(3,2),(2,4),(3,4)]
    xyv = V.fromList $ map (\(x,y) -> (x-1,y-1)) xys
    ve = V.accumulate (flip (:)) (V.replicate n []) xyv
    v = V.generate n m
    m i = (+1) $ maximum $ ((-1):) $ map (v V.!) (ve V.! i)
