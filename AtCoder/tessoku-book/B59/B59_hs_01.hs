-- https://atcoder.jp/contests/tessoku-book/submissions/35216060
import Control.Monad
import Control.Monad.Primitive
import Data.Maybe
import qualified Data.ByteString.Char8 as BS
import Data.List
import Data.Char
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM
import Data.Vector.Unboxed.Base
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import qualified Data.Array as A
import qualified Data.Array.ST as AM
import qualified Data.Map as Map
import qualified Data.IntSet as IS
import qualified Data.Bits as B

data SegTree m a = SegTree {segTreeN :: Int,
                            segTreeSize :: Int,
                            segTreeLog :: Int,
                            segTreeD :: VUM.MVector (PrimState m) a,
                            segTreeOp :: a -> a -> a,
                            segTreeE :: a}

newSegTree :: (PrimMonad m, Unbox a, Show a) => (a -> a -> a) -> a -> Int -> m (SegTree m a)
newSegTree op e n = fromVecSegTree op e $ VU.replicate n e

fromVecSegTree :: (PrimMonad m, Unbox a, Show a) => (a -> a -> a) -> a -> VU.Vector a -> m (SegTree m a)
fromVecSegTree op e v = do
    let nST = VU.length v
        logST = ceiling $ logBase 2 (fromIntegral nST) :: Int
        sizeST = 1 `B.shiftL` logST
    dST <- VUM.replicate (2 * sizeST) e
    forM_ [0..(nST - 1)] $ \i -> do
        VUM.write dST (sizeST + i) (v VU.! i)
    let segtree = SegTree nST sizeST logST dST op e
    forM_ [(sizeST - 1), (sizeST - 2)..1] $ \i -> do
        updateSegTree segtree i
    return segtree

updateSegTree :: (PrimMonad m, Unbox a, Show a) => SegTree m a -> Int -> m ()
updateSegTree segtree k = do
        x <- VUM.read dST (2 * k)
        y <- VUM.read dST (2 * k + 1)
        VUM.write dST k (opST x y)
    where dST = segTreeD segtree
          opST = segTreeOp segtree

setSegTree :: (PrimMonad m, Unbox a, Show a) => SegTree m a -> Int -> a -> m ()
setSegTree segtree p x = do
        let p' = p + sizeST
        VUM.write dST p' x
        forM_ [1..logST] $ \i -> do
            updateSegTree segtree (p' `B.shiftR` i)
    where nST = segTreeN segtree
          logST = segTreeLog segtree
          sizeST = segTreeSize segtree
          dST = segTreeD segtree

getSegTree :: (PrimMonad m, Unbox a, Show a) => SegTree m a -> Int -> m a
getSegTree segtree p = VUM.read dST (p + sizeST)
    where nST = segTreeN segtree
          dST = segTreeD segtree
          sizeST = segTreeSize segtree

rangeSegTree :: (PrimMonad m, Unbox a, Show a) => SegTree m a -> Int -> Int -> m a
rangeSegTree segtree l r = do
        let loop l r xl xr
                | l < r = do
                    dl <- VUM.read dST l
                    dr <- VUM.read dST (r - 1)
                    let xl' | (l B..&. 1) == 1 = opST xl dl
                            | otherwise = xl
                        xr' | (r B..&. 1) == 1 = opST dr xr
                            | otherwise = xr
                        l' = (l + (l B..&. 1)) `B.shiftR` 1
                        r' = (r - (r B..&. 1)) `B.shiftR` 1
                    loop l' r' xl' xr'
                | otherwise = return $ opST xl xr
        loop (l + sizeST) (r + sizeST) eST eST
    where dST = segTreeD segtree
          opST = segTreeOp segtree
          sizeST = segTreeSize segtree
          eST = segTreeE segtree

allRangeSegTree :: (PrimMonad m, Unbox a, Show a) => SegTree m a -> m a
allRangeSegTree segtree = VUM.read dST 1
    where dST = segTreeD segtree

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main = do
    n <- getInt
    as <- VU.fromList <$> getIntList
    segtree <- newSegTree (+) (0 :: Int) n
    number <- VU.forM as $ \a -> do
                 s <- rangeSegTree segtree (a-1) n
                 k <- getSegTree segtree (a-1)
                 setSegTree segtree (a-1) (k + 1)
                 return s
    print $ VU.sum number
