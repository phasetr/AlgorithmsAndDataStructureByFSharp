-- https://atcoder.jp/contests/tessoku-book/submissions/35367824
import Control.Monad ( replicateM_, forM_ )
import qualified Data.Vector.Unboxed.Mutable as MUV
import qualified Data.Vector.Unboxed as UV
import Control.Monad.ST ()

main :: IO ()
main = do
  q <- readLn
  replicateM_ q $ do
    x <- readLn
    putStrLn $ if primes UV.! x then "Yes" else "No"

ub :: Int
ub = 300000

primes :: UV.Vector Bool
primes = UV.create $ do
  v <- MUV.replicate (succ ub) True
  MUV.write v 0 False
  MUV.write v 1 False
  forM_ [2..ub] (\p -> do
    forM_ [p * p, p * succ p..ub] (\kp -> MUV.write v kp False)
    )
  return v
