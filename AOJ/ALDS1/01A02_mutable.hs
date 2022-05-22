-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_A/review/2729808/rabbisland/Haskell
import qualified Data.ByteString.Char8 as B
import Control.Monad ( forM_ )
import Data.Char (isSpace)
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import Control.Monad.ST ( RealWorld )
main :: IO ()
main = do
  n <- readLn
  av <- fmap (V.unfoldr (B.readInt . B.dropWhile isSpace)) B.getLine
  -- 初期状態の出力として必須
  putStrLn . unwords . V.toList . V.map show $ av
  _ <- isort n av
  return ()
isort :: Int -> V.Vector Int -> IO (VM.MVector RealWorld  Int)
isort n av = do
  amv <- V.thaw av
  forM_ [1..n-1] (\i -> do
                     let j = i-1
                     v <- VM.read amv i
                     j <- while amv j v
                     VM.write amv (j+1) v
                     printmv amv)
  return amv
  where
    --printmv :: Show a => VM.MVector RealWorld a -> IO ()
    printmv v = putStrLn . unwords . V.toList . V.map show =<< V.freeze v
    --while :: VM.MVector (PrimState m) Int -> Int -> Int -> m Int
    while av j v = do
      if j < 0 then return j
      else do
        u <- VM.read av j
        if u <= v then return j
        else do
          VM.write av (j+1) u
          while av (j - 1) v
{-
-- test
isort 6 (V.fromList [5,2,4,6,1,3])
->
2 5 4 6 1 3
2 4 5 6 1 3
2 4 5 6 1 3
1 2 4 5 6 3
1 2 3 4 5 6

isort 3 (V.fromList [1..3])
->
1 2 3
1 2 3
-}
