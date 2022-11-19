-- https://atcoder.jp/contests/abc079/submissions/16203448
import Control.Monad ( liftM2, forM_ )
import Data.Char ( isSpace )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VM
main :: IO ()
solve :: VU.Vector Int -> Int
main = print . solve . VU.unfoldr (B.readInt . B.dropWhile isSpace) =<< B.getContents
solve hwcas = VU.sum . VU.map f $ as where
  (cs,as) = VU.splitAt 100 $ VU.drop 2 hwcas
  g = wf 10 cs
  f a = if a<0 then 0 else g VU.! a
wf :: (VM.Unbox a, Num a, Ord a) => Int -> VU.Vector a -> VU.Vector a
wf n es = VU.generate n (\i -> d VU.! idx i 1) where
  idx i j = i*n+j
  d = VU.create $ do
    d <- VU.thaw es
    forM_ [0..n-1] $ \k ->
      forM_ [0..n-1] $ \i ->
        forM_ [0..n-1] $ \j -> do
          a <- VM.read d (idx i j)
          b <- liftM2 (+) (VM.read d (idx i k)) (VM.read d (idx k j))
          VM.write d (idx i j) $ min a b
    return d
