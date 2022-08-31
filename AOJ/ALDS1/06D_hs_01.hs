-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_D/review/4699794/niruneru/Haskell
import Control.Monad (forM_)
import Data.List (sort)
import Data.IntMap.Strict ( IntMap )
import Data.Vector.Unboxed (Vector)
import Data.Vector.Unboxed.Mutable (IOVector, unsafeRead, unsafeWrite)
import qualified Data.List as L
import qualified Data.IntMap.Strict as M
import qualified Data.Vector.Unboxed as V
import qualified Data.Vector.Unboxed.Mutable as MV

type Cost   = Int
type Costs  = Vector Cost
type Sorted = IntMap Int
type Flags  = IOVector Bool

main :: IO ()
main = do
  getLine
  inputs <- fmap (L.map read . words) getLine :: IO [Int]
  flags  <- MV.replicate 10000 True
  forM_ inputs (write False flags)
  cycles <- getCycles inputs flags
  print . sum . L.map (getCost (minimum inputs)) $ cycles
  where
    write v vs i = MV.unsafeWrite vs i v

getCycles :: [Int] -> Flags -> IO [[Int]]
getCycles inputs flags =  mapM (getCycle costs sorted flags []) inputs where
  costs  = V.fromList inputs
  sorted = M.fromList $ zip (sort inputs) [0..]

getCycle :: Costs -> Sorted -> Flags -> [Int] -> Int -> IO [Int]
getCycle costs sorted flags cycle c = do
  isValid <- unsafeRead flags c
  if isValid then return cycle
  else do
    unsafeWrite flags c True
    getCycle costs sorted flags (c:cycle) (costs V.! (sorted M.! c))

getCost :: Int -> [Int] -> Int
getCost _ []  = 0
getCost _ [c] = 0
getCost min costs = if min `elem` costs then sum1 else minimum [sum1, sum2] where
  sum1 = sum costs + (n - 2) * mc
  sum2 = sum costs + mc + (n + 1) * min
  n  = length costs
  mc = minimum costs
