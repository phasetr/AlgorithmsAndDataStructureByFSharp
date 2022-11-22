-- https://atcoder.jp/contests/abc088/submissions/3140309
import Control.Monad ( replicateM, forM, when )
import Control.Monad.ST ( ST, runST )
import Data.Array.Unboxed ( (!), listArray, UArray )
import Data.Array.ST ( freeze, readArray, thaw, writeArray, STUArray )
import Data.Bifunctor ( Bifunctor(bimap) )
import Data.Maybe ( catMaybes )

main = do
  (h:w:_) <- map read . words <$> getLine
  m <- concat <$> replicateM h getLine
  --
  let wn = length $ filter (=='.') m
  let bd = listArray ((1,1),(h,w)) $ map (\c->if c=='.' then 0 else (-1)) m
  --
  let bd' = sol' h w bd

  print $ if bd' ! (h,w) == 0 then (-1) else wn - (bd' ! (h,w))

sol' :: Int -> Int -> UArray (Int,Int) Int -> UArray (Int,Int) Int
sol' h w bd = runST $ do
  m <- thaw bd :: ST s (STUArray s (Int,Int) Int)
  writeArray m (1,1) 1
  solve h w m 1 [(1,1)]
  freeze m

solve :: Int -> Int -> STUArray s (Int,Int) Int -> Int -> [(Int,Int)] -> ST s ()
solve _ _ _ _ [] = return ()
solve h w m s cd = do
  nn <- forM nt $ \(i,j) ->
      if i<1 || i>h || j<1 || j>w then return Nothing
      else do
        f <- readArray m (i,j)
        when (f==0) $ writeArray m (i,j) (s+1)
        return $ if f == 0 then Just (i,j) else Nothing
  solve h w m (s+1) $ catMaybes nn
  where
    nt = concatMap mv cd
    mv (i,j) = map (bimap (i +) (j +)) [(-1,0),(1,0),(0,-1),(0,1)]
