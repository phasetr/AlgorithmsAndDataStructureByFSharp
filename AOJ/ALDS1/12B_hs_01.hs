-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/3912858/niruneru/Haskell
import Data.Vector.Unboxed ((//), generate, minIndex, (!))
import qualified Data.Vector as V
import qualified Data.Vector.Unboxed as VU
import qualified Data.List as L
import Debug.Trace (trace)

type AdjM = V.Vector (VU.Vector Int)
type Costs = VU.Vector Int
type Verified = VU.Vector Bool

main :: IO ()
main = do
  n    <- readLn :: IO Int
  adjm <- V.replicateM n $ fmap (adj n . toCs [] . map read . drop 2 . words) getLine
  let vs = VU.replicate n False                :: Verified
      ws = VU.cons 0 (VU.replicate (n - 1) (n * 100001)) :: Costs
      cs = snd $ dijkstra n adjm (vs, ws)
  VU.forM_ (generate n id) $ \i -> do
      putStrLn $ show i ++ " " ++ show (cs ! i)
  where
    adj n cs = VU.replicate n (n * 100001) // cs
    toCs accum []         = accum
    toCs accum (a:b:rest) = toCs ((a, b) : accum) rest
    toCs _ _ = error "not come here"

dijkstra :: Int -> AdjM -> (Verified, Costs) -> (Verified, Costs)
dijkstra n adjm (vs, cs)
  | VU.all id vs = (vs, cs)
  | otherwise    = dijkstra n adjm (vs', cs')
  where
    vs' = vs // [(mi, True)]
    mi  = (\(i,_,_) -> i) . VU.foldl' f (-1, False, n * 100001) $ VU.zip3 (generate n id) vs cs
      where
        f (ai, av, ac) (i, v, c)
          | not v && c < ac = (i, v, c)
          | otherwise       = (ai, av, ac)

    cs' = cs // updatelist
    updatelist = VU.foldl' g [] $ VU.zip3 (generate n id) cs (adjm V.! mi)
    mc  = cs ! mi
    g accum (i, a, b)
      | a > mc + b = (i, mc + b) : accum
      | otherwise  = accum
