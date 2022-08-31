-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_D/review/4699794/niruneru/Haskell
import Control.Monad.ST ( runST )
import Control.Monad.Primitive ( PrimMonad(PrimState) )
import Data.Char (isSpace)
import qualified Data.List as L
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import qualified Data.IntMap.Strict as IMS
import qualified Data.ByteString.Char8 as B

main :: IO ()
main = do
  _ <- getLine
  wv <- fmap (V.unfoldr (B.readInt . B.dropWhile isSpace)) B.getLine
  print $ solve wv

solve :: V.Vector Int -> Int
solve wv = V.sum $ V.map (getCost (V.minimum wv)) cyclv where
  fv = getFlags wv
  cyclv = getCycles wv fv

getFlags :: V.Vector Int -> V.Vector Bool
getFlags wv = runST $ do
  fv <- VM.replicate 10001 True
  V.forM_ wv $ \i  -> do
    VM.write fv i False
  V.freeze fv

getCycles :: V.Vector Int -> V.Vector Bool -> V.Vector (V.Vector Int)
getCycles costv fv = V.map V.fromList $ runST $ do
  fmv <- V.thaw fv
  V.mapM (getCycle costv im fmv []) costv
  where im = IMS.fromList $ zip (L.sort $ V.toList costv) [0..]

getCycle :: PrimMonad m => V.Vector Int -> IMS.IntMap Int -> VM.MVector (PrimState m) Bool -> [Int] -> Int -> m [Int]
getCycle costv im fv cycle c = do
  isValid <- VM.read fv c
  if isValid then return cycle
  else do
    VM.write fv c True
    getCycle costv im fv (c:cycle) (costv V.! (im IMS.! c))

getCost :: Int -> V.Vector Int -> Int
getCost minV costv = case n of
  0 -> 0
  1 -> 0
  _ -> if minV `V.elem` costv then sum1 else min sum1 sum2
  where
    sum1 = V.sum costv + (n - 2) * mc
    sum2 = V.sum costv + mc + (n + 1) * minV
    n = V.length costv
    mc = V.minimum costv

test = do
  print $ solve (V.fromList [1,5,3,4,2]) == 7
  print $ solve (V.fromList [4,3,2,1]) == 10
  print $ solve (V.fromList [10000,9999,9998,9997,1,2,3,4]) == 40010
