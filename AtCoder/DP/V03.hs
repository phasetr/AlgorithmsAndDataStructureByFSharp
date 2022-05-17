-- https://atcoder.jp/contests/dp/submissions/23556629
import Control.Monad
import Control.Monad.State.Strict
import qualified Data.ByteString.Char8 as C
import Data.Coerce
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import qualified Data.Vector.Unboxed as U
import qualified Data.Vector.Unboxed.Mutable as UM
import Data.Vector.Generic ((!))

import Data.List

main = get2 >>= \v -> let (n,m) = (v!0, v!1) in getn (n-1) >>= mapM_ print . solve n m

get2 = U.unfoldrN 2 (C.readInt . C.dropWhile (<'+')) <$> C.getLine

geti = coerce $ C.readInt . C.dropWhile (<'+') :: StateT C.ByteString Maybe Int

getn n = U.unfoldrN n (runStateT $ (,) <$> geti <*> geti) <$> C.getContents

solve n m es = U.toList $ U.tail reroot where
  dp = U.create $ do
    v <- UM.replicate (n+1) 0
    dfs v 0 1
    return v
  dfs v p i = do
    a <- foldM (\c j -> (c .*.) . (.+. 1) <$> dfs v i j) 1 cs
    UM.unsafeWrite v i a
    return a
    where
    cs = filter (/= p) $ g!i
  reroot = U.create $ do
    v <- UM.replicate (n+1) 0
    bfs v 1 0 1
    return v
  bfs v a p i = do
    let ls = scanl' (\l c -> (dp!c .+. 1) .*. l) 1 cs
    let rs = scanr (\c r -> (dp!c .+. 1) .*. r) a cs
    UM.unsafeWrite v i $ head rs
    mapM_ (\(c,l,r) -> bfs v (l .*. r .+. 1) i c) $ zip3 cs (init ls) (tail rs)
    where
    cs = filter (/= p) $ g!i
  x .+. y = (x+y) `mod` m
  x .*. y = (x*y) `mod` m
  g = buildG n es

buildG n es = V.create $ do
  g <- VM.replicate (n+1) []
  let add a b = VM.read g a >>= VM.write g a . (b:)
  U.forM_ es $ \(a, b) -> do
    add a b
    add b a
  return g
