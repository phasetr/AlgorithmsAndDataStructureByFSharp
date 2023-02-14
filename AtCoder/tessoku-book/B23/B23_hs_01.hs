-- https://atcoder.jp/contests/tessoku-book/submissions/37745622
{-# LANGUAGE BlockArguments #-}
import Control.Monad ( when, forM_, replicateM )
import Control.Monad.ST ( runST )
import Data.Bits ( Bits(clearBit, testBit) )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )
import Data.Vector.Generic ((!))
import qualified Data.Vector.Unboxed as U
import qualified Data.Vector.Unboxed.Mutable as UM

main :: IO ()
main = readLn >>= \n -> replicateM n get >>= print . sol n

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: (Integral b, UM.Unbox b) => Int -> [[b]] -> Float
sol n xys = runST $ do
  let
    xy = U.fromListN n $ map (\[x,y] -> (x,y)) xys
    d = U.fromListN (n^2) [dis (i,j) | i <- [0..n-1], j <- [0..n-1]]
    dis (i,j)
      | i<=j      = sqrt . fromIntegral $ (xj-xi)^2+(yj-yi)^2
      | otherwise = dis (j,i)
      where
      (xi,yi) = xy!i
      (xj,yj) = xy!j
    ix (i,j) = i*n+j
  v <- UM.replicate (n*2^n) (10^5 :: Float)
  UM.unsafeWrite v 0 0
  forM_ [0..2^n] $ \i ->
    forM_ [0..n-1] $ \j ->
      when (testBit i j) do
        forM_ [0..n-1] $ \k -> do
          d' <- UM.unsafeRead v (ix (clearBit i j,k))
          UM.modify v (min (d' + d!ix (j,k))) (ix (i,j))
  UM.unsafeRead v (ix (2^n-1,0))
