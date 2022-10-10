-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/DSL_1_A/review/1616124/cojna/Haskell
{-# OPTIONS_GHC -O2 -funbox-strict-fields #-}
{-# LANGUAGE BangPatterns    #-}
{-# LANGUAGE RecordWildCards #-}

import Control.Monad ( ap, liftM, when )
import Control.Monad.Primitive ( PrimMonad(PrimState) )
import Control.Monad.ST ( runST )
import qualified Data.ByteString.Char8       as B
import qualified Data.ByteString.Unsafe      as B
import Data.Char ( isSpace )
import qualified Data.Vector.Unboxed         as U
import qualified Data.Vector.Unboxed.Mutable as UM

main :: IO ()
main = do
  [n, q] <- fmap (map read.words) getLine :: IO [Int]
  queries <- fmap (U.unfoldrN q (readInt3.B.dropWhile isSpace)) B.getContents
  putStr.unlines.map show $ solve n queries

solve :: Int -> U.Vector (Int, Int, Int) -> [Int]
solve n queries = ($ []) $ runST $ do
  uf <- newUnionFind n
  U.foldM' `flip` id `flip` queries $ \ !acc (com,x,y) ->
      if com == 0
      then uniteM x y uf >> return acc
      else fmap ((acc.).(:).fromEnum) (equivM x y uf)

-------------------------------------------------------------------------------

readInt3 :: B.ByteString -> Maybe ((Int,Int,Int), B.ByteString)
readInt3 bs = Just ((x,y,z),bsz) where
  Just (x, bsx) = B.readInt bs
  Just (y, bsy) = B.readInt $ B.unsafeTail bsx
  Just (z, bsz) = B.readInt $ B.unsafeTail bsy

data UnionFind m = UF
  { parent :: UM.MVector m Int
  , rank   :: UM.MVector m Int
  }

nothing :: Int
nothing = -1
{-# INLINE nothing #-}

newUnionFind :: PrimMonad m => Int -> m (UnionFind (PrimState m))
newUnionFind n = UF `fmap` UM.replicate n nothing `ap` UM.replicate n 0
{-# INLINE newUnionFind #-}

findM :: PrimMonad m => Int -> UnionFind (PrimState m) -> m Int
findM x uf@UF{..} = do
    px <- UM.unsafeRead parent x
    if px == nothing
    then return x
    else do
        ppx <- findM px uf
        UM.unsafeWrite parent x ppx
        return ppx
{-# INLINE findM #-}

uniteM :: PrimMonad m => Int -> Int -> UnionFind (PrimState m) -> m ()
uniteM x y uf@UF{..} = do
    px <- findM x uf
    py <- findM y uf
    when (px /= py) $ do
        rx <- UM.unsafeRead rank px
        ry <- UM.unsafeRead rank py
        case compare rx ry of
            LT -> UM.unsafeWrite parent px py
            GT -> UM.unsafeWrite parent py px
            EQ -> do
                UM.unsafeWrite parent px py
                UM.unsafeWrite rank py (ry + 1)
{-# INLINE uniteM #-}

equivM :: PrimMonad m => Int -> Int -> UnionFind (PrimState m) -> m Bool
equivM x y uf = (==) `fmap` findM x uf `ap` findM y uf
{-# INLINE equivM #-}
