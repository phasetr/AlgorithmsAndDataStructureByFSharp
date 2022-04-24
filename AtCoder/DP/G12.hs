import qualified Data.ByteString.Char8 as B
import Data.List ( unfoldr )
import qualified Data.Vector as V

main :: IO ()
main = do
  [n,m] <- map read . words <$> getLine
  xyv <- V.replicateM m
    $ (\[a,b] -> (a-1,b-1)) . unfoldr (B.readInt . B.dropWhile (<'!'))
    <$> B.getLine
  print $ solve n xyv
solve :: (Num a, Ord a) => Int -> V.Vector (Int, Int) -> a
solve n xyv = V.maximum dp where
  g = V.accumulate (flip (:)) (V.replicate n []) xyv
  dp = V.generate n f
  f v = if null (g V.! v) then 0
    else foldl (\acc i -> max acc (1 + dp V.! i)) 0 (g V.! v)

test :: IO ()
test = do
  print $ solve 4 (convert [(1,2),(1,3),(3,2),(2,4),(3,4)]) == 3
  print $ solve 6 (convert [(2,3),(4,5),(5,6)]) == 2
  print $ solve 5 (convert [(5,3),(2,3),(2,4),(5,2),(5,1),(1,4),(4,3),(1,3)]) == 3
  where
    convert = V.fromList . map (\(s,t) -> (s-1,t-1))
