-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_A/review/3899772/niruneru/Haskell
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector as V
import Data.List (minimumBy)

type Node   = Int
type Weight = Int
type AdjM   = V.Vector (VU.Vector Weight)
type MST    = [(Node, Weight)]

main :: IO ()
main = do
  n    <- readLn
  adjM <- V.replicateM n $
          fmap (VU.fromList . map ((\w -> if w == -1 then 2001 else w) . read) . words) getLine
  print $ total n adjM

total :: Int -> AdjM -> Weight
total n adjM = sum . map snd $ prim [(0, 0)] where
  prim :: MST -> MST
  prim mst
    | n == length mst = mst
    | otherwise       = prim (next:mst)
    where
      next :: (Node, Weight)
      next = minimumBy (\a b -> compare (snd a) (snd b)) unvisits

      unvisits :: [(Node, Weight)]
      unvisits = [ (node, (adjM V.! vnodes) VU.! node)
                 | node <- [0..(n-1)]
                 , node `notElem` map fst mst
                 , vnodes <- map fst mst
                 ]
