-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/GRL_1_A/review/1618074/cojna/Haskell
{-# OPTIONS_GHC -O2 #-}
{-# LANGUAGE BangPatterns #-}

import Control.Applicative ((<$>))
import Control.Monad ( ap, liftM, liftM2, when )
import Control.Monad.Primitive ( PrimMonad(PrimState) )
import Data.Bits ( Bits((.|.), unsafeShiftR, unsafeShiftL) )
import qualified Data.ByteString.Char8       as B
import qualified Data.ByteString.Unsafe      as B
import Data.Char ( isSpace )
import Data.Function ( fix )
import Data.Primitive.MutVar
    ( modifyMutVar,
      modifyMutVar',
      newMutVar,
      readMutVar,
      writeMutVar,
      MutVar )
import qualified Data.Vector                 as V
import qualified Data.Vector.Unboxed         as U
import qualified Data.Vector.Unboxed.Mutable as UM

main :: IO ()
main = do
    [v, e, r] <- map read.words <$> getLine
    edges <- U.unfoldrN e (readInt3.B.dropWhile isSpace) <$> B.getContents
    putStr.unlines.map showCost.U.toList.solve e r $ fromEdges v edges

solve :: Int -> Vertex -> Graph -> U.Vector Cost
solve = dijkstra

showCost :: Cost -> String
showCost cost
    | cost < inf = show cost
    | otherwise = "INF"

-------------------------------------------------------------------------------

readInt3 :: B.ByteString -> Maybe ((Int,Int,Int), B.ByteString)
readInt3 bs = Just ((x,y,z),bsz)
  where
    Just (x, bsx) = B.readInt bs
    Just (y, bsy) = B.readInt $ B.unsafeTail bsx
    Just (z, bsz) = B.readInt $ B.unsafeTail bsy

type Vertex = Int
type Cost = Int
type Edge = (Vertex, Vertex, Cost)
type Graph = V.Vector (U.Vector (Vertex, Cost))

fromEdges :: Int -> U.Vector Edge -> Graph
fromEdges numV = V.map U.fromList
    . V.unsafeAccumulate (flip (:)) (V.replicate numV [])
    . U.convert
    . U.map (\(src, dst, cost) -> (src, (dst, cost)))

inf :: Cost
inf = 0x3f3f3f3f

dijkstra :: Int -> Vertex -> Graph -> U.Vector Cost
dijkstra numE root gr = U.create $ do
    dist <- UM.replicate (V.length gr) inf
    heap <- newHeap numE
    UM.unsafeWrite dist root 0
    insertM (0, root) heap
    fix $ \loop -> do
        hd <- deleteFindMinM heap
        case hd of
            Just (!d,!v) -> do
                dv <- UM.unsafeRead dist v
                if d > dv
                then loop
                else do
                    U.forM_ (V.unsafeIndex gr v) $ \(nv, v2nv) -> do
                        let !dnv = dv + v2nv
                        old <- UM.unsafeRead dist nv
                        when (dnv < old) $ do
                            UM.unsafeWrite dist nv dnv
                            insertM (dnv, nv) heap
                    loop
            Nothing -> return dist

data HeapM m a = HeapM (MutVar m Int) (UM.MVector m a)

newHeap :: (PrimMonad m, U.Unbox a) => Int -> m (HeapM (PrimState m) a)
newHeap limitSize = HeapM `liftM` newMutVar 0 `ap` UM.new limitSize

getHeapSize :: (PrimMonad m) => HeapM (PrimState m) a -> m Int
getHeapSize (HeapM ref _) = readMutVar ref
{-# INLINE getHeapSize #-}

insertM :: (PrimMonad m, U.Unbox a, Ord a)
        => a -> HeapM (PrimState m) a -> m ()
insertM x heap@(HeapM ref vec) = do
    size <- getHeapSize heap
    modifyMutVar ref (+1)
    flip fix size $ \loop !i ->
        if i == 0
        then UM.unsafeWrite vec 0 x
        else do
            let !parent = (i - 1) `unsafeShiftR` 1
            p <- UM.unsafeRead vec parent
            if p <= x
            then UM.unsafeWrite vec i x
            else do
                UM.unsafeWrite vec i p
                loop parent
{-# INLINE insertM #-}

unsafeDeleteMinM :: (PrimMonad m, U.Unbox a, Ord a)
                 => HeapM (PrimState m) a -> m ()
unsafeDeleteMinM (HeapM ref vec) = do
    modifyMutVar' ref (subtract 1)
    size <- readMutVar ref
    x <- UM.unsafeRead vec size
    flip fix 0 $ \loop !i -> do
        let !l = unsafeShiftL i 1 .|. 1
        if size <= l
        then UM.unsafeWrite vec i x
        else do
            let !r = l + 1
            childL <- UM.unsafeRead vec l
            childR <- UM.unsafeRead vec r
            if r < size && childR < childL
            then if x <= childR
                 then UM.unsafeWrite vec i x
                 else do
                     UM.unsafeWrite vec i childR
                     loop r
            else if x <= childL
                 then UM.unsafeWrite vec i x
                 else do
                     UM.unsafeWrite vec i childL
                     loop l
{-# INLINE unsafeDeleteMinM #-}

unsafeMinViewM :: (PrimMonad m, U.Unbox a) => HeapM (PrimState m) a -> m a
unsafeMinViewM (HeapM _ vec) = UM.unsafeRead vec 0
{-# INLINE unsafeMinViewM #-}

minViewM :: (PrimMonad m, U.Unbox a) => HeapM (PrimState m) a -> m (Maybe a)
minViewM heap = do
    size <- getHeapSize heap
    if size > 0
    then Just `fmap` unsafeMinViewM heap
    else return Nothing
{-# INLINE minViewM #-}

deleteFindMinM :: (PrimMonad m, U.Unbox a, Ord a)
               => HeapM (PrimState m) a -> m (Maybe a)
deleteFindMinM heap = do
    size <- getHeapSize heap
    if size > 0
    then liftM2 ((Just.).const) (unsafeMinViewM heap) (unsafeDeleteMinM heap)
    else return Nothing
{-# INLINE deleteFindMinM #-}

clearHeapM :: (PrimMonad m) => HeapM (PrimState m) a -> m ()
clearHeapM (HeapM ref _) = writeMutVar ref 0
{-# INLINE clearHeapM #-}
