-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/3948648/niruneru/Haskell
import Control.Monad ( when, forM_ )
import Control.Monad.Primitive ( PrimMonad(PrimState) )
import Control.Monad.ST ( runST )
import qualified Data.ByteString.Char8 as B
import Data.Char ( isSpace )
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM

main :: IO ()
main = do
  n  <- readLn :: IO Int
  av <- fmap (V.unfoldr (B.readInt . B.dropWhile isSpace)) B.getLine
  putStrLn . (' ' :) . unwords . V.toList . V.map show $ solve n av

solve :: Int -> V.Vector Int -> V.Vector Int
solve n av = runST $ do
  amv <- V.thaw av
  let m = n `div` 2
  forM_ [m, (m-1)..0] $ \i -> maxHeapify i n amv
  V.freeze amv

maxHeapify :: (PrimMonad m, Ord a) => Int -> Int -> VM.MVector (PrimState m) a -> m ()
maxHeapify i n amv = do
  let (l,r) = (2*i+1,l+1)
  ami <- VM.read amv i
  case (l < n, r < n) of
    (True, False) -> VM.read amv l >>= \aml -> when (ami < aml) (VM.swap amv i l >> maxHeapify l n amv)
    (False, True) -> VM.read amv r >>= \amr -> when (ami < amr) (VM.swap amv i r >> maxHeapify r n amv)
    (True, True)  -> VM.read amv l >>= \aml -> VM.read amv r >>= \amr ->
      if aml > amr then when (ami < aml) (VM.swap amv i l >> maxHeapify l n amv)
      else when (ami < amr) (VM.swap amv i r >> maxHeapify r n amv)
    (False, False) -> return ()

test :: IO ()
test = do
  print $ solve 10 (V.fromList [4,1,3,2,16,9,10,14,8,7]) == V.fromList [16,14,10,8,7,9,3,2,4,1]
  putStrLn . unwords . V.toList . V.map show $ solve 10 (V.fromList [4,1,3,2,16,9,10,14,8,7])
