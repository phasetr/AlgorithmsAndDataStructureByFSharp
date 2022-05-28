-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_D/review/4699794/niruneru/Haskell
import Control.Monad.ST ( runST )
import Control.Monad.Primitive ( PrimMonad(PrimState) )
import Data.Char (isSpace)
import qualified Data.List as L
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import qualified Data.IntMap.Strict as M
import qualified Data.ByteString.Char8 as B

main :: IO ()
main = do
  _ <- getLine
  wv <- fmap (V.unfoldr (B.readInt . B.dropWhile isSpace)) B.getLine
  print $ solve wv

solve :: V.Vector Int -> Int
solve wv = V.sum $ V.map (getCost (V.minimum wv)) cv where
  fv = getFlags wv
  cv = getCycles wv fv

getFlags :: V.Vector Int -> V.Vector Bool
getFlags wv = runST $ do
  fv <- VM.replicate 10001 True
  V.forM_ wv $ \i  -> do
    VM.write fv i False
  V.freeze fv

getCycles :: V.Vector Int -> V.Vector Bool -> V.Vector (V.Vector Int)
getCycles costs fv = V.map V.fromList $ runST $ do
  fmv <- V.thaw fv
  V.mapM (getCycle costs sorted fmv []) costs
  where sorted = M.fromList $ zip (L.sort $ V.toList costs) [0..]

getCycle :: PrimMonad m => V.Vector Int -> M.IntMap Int -> VM.MVector (PrimState m) Bool -> [Int] -> Int -> m [Int]
getCycle costs sorted fv cycle c = do
  isValid <- VM.read fv c
  if isValid then return cycle
  else do
    VM.write fv c True
    getCycle costs sorted fv (c:cycle) (costs V.! (sorted M.! c))

getCost :: Int -> V.Vector Int -> Int
getCost minV costs = case n of
  0 -> 0
  1 -> 0
  _ -> if minV `V.elem` costs then sum1 else min sum1 sum2
  where
    sum1 = V.sum costs + (n - 2) * mc
    sum2 = V.sum costs + mc + (n + 1) * minV
    n = V.length costs
    mc = V.minimum costs

test = do
  print $ solve (V.fromList [1,5,3,4,2]) == 7
  print $ solve (V.fromList [4,3,2,1]) == 10
  print $ solve (V.fromList [10000,9999,9998,9997,1,2,3,4]) == 40010
