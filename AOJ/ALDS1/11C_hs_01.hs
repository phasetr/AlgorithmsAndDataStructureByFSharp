-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_C/review/3857933/niruneru/Haskell
import Control.Monad (forM_)
import Data.Maybe (fromJust)
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector as V
import qualified Data.Vector.Unboxed as VU

type Distance  = Int
type Adjacency = [Int]
type Queue     = [Int]

main :: IO ()
main = do
  n <- readLn :: IO Int
  adjs <- V.replicateM n $ fmap (map (subtract 1 . fst . fromJust . B.readInt) . drop 2 . B.words) B.getLine
  let distance0 = VU.replicate n (-1) VU.// [(0,0)]
      distanceN = bfs [0] adjs distance0
  forM_ [0..n-1] $ \i -> putStrLn $ show (i + 1) ++ " " ++ show (distanceN VU.! i)

bfs :: Queue -> V.Vector Adjacency -> VU.Vector Distance -> VU.Vector Distance
bfs [] _ dists = dists
bfs queue adjs dists =
  let q   = last queue
      adj = adjs V.! q
  in case next adj dists of
       Nothing ->
         bfs (init queue) adjs dists
       Just n ->
         let newDists = update q n dists
         in bfs (n:queue) adjs (update q n dists)

next :: Adjacency -> VU.Vector Distance -> Maybe Int
next [] _ = Nothing
next (n:ns) dists =
  if dists VU.! n == -1 then Just n
  else next ns dists

update :: Int -> Int -> VU.Vector Distance -> VU.Vector Distance
update q n dists =
  let v = dists VU.! q + 1
  in dists VU.// [(n, v)]
