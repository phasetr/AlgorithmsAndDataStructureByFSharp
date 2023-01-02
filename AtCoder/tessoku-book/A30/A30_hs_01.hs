-- https://atcoder.jp/contests/tessoku-book/submissions/35373539
import qualified Data.Vector.Unboxed.Mutable as MUV
import qualified Data.Vector.Unboxed as UV
import Control.Monad ( forM_ )

tba30 :: Int -> Int -> Int
tba30 n r = c n r where c = mkComb n

p = 1000000007  -- 10^9+7
reg x = mod x p
mul x y = reg (x * y)

-- @gotoki_no_joe
mkComb :: Int -> (Int -> Int -> Int)
mkComb nmax = c where
  c n k = (fact UV.! n) `mul` (factinv UV.! k) `mul` (factinv UV.! (n - k))
  fact = UV.fromListN (succ nmax) $ scanl mul 1 [1 .. nmax]
  factinv = UV.scanl1 mul invs
  invs = UV.create $ do
    v <- MUV.new (succ nmax)
    MUV.write v 0 1
    MUV.write v 1 1
    forM_ [2..nmax] $ \a -> do
      let (q, r) = divMod p a
      rinv <- MUV.read v r
      let ainv = mul (negate q) rinv
      MUV.write v a ainv
    return v

main :: IO ()
main = do
  [n,r] <- getLnInts
  let ans = tba30 n r
  print ans

getLnInts :: IO [Int]
getLnInts = map read . words <$> getLine
