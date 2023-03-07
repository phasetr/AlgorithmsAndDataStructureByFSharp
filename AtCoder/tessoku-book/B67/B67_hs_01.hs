-- https://atcoder.jp/contests/tessoku-book/submissions/35596938
import Control.Monad ( replicateM, forM, liftM2, when )
import Control.Monad.ST ( runST )
import Control.Monad.Primitive ( PrimMonad(PrimState) )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import Data.List ( sortOn )
import Data.Char ()
import Data.Ord ( Down(Down) )
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM
import Data.Vector.Unboxed.Base ( MVector )
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM

newUF :: PrimMonad m => Int -> m (MVector (PrimState m) Int)
newUF n = VUM.replicate n (-1 :: Int)

root :: PrimMonad m => MVector (PrimState m) Int -> Int -> m Int
root uf x = do
    p <- VUM.read uf x
    if p < 0
        then return x
        else do
            r <- root uf p
            VUM.write uf x r
            return r

same :: PrimMonad m => MVector (PrimState m) Int -> Int -> Int -> m Bool
same uf x y = liftM2 (==) (root uf x) (root uf y)

unite :: PrimMonad m => MVector (PrimState m) Int -> Int -> Int -> m ()
unite uf x y = do
    px <- root uf x
    py <- root uf y
    when (px /= py) $ do
        sx <- VUM.read uf px
        sy <- VUM.read uf py
        let (par, chld) = if sx < sy then (px, py)　else (py, px)
        VUM.write uf chld par
        VUM.write uf par (sx + sy)

size :: PrimMonad m => MVector (PrimState m) Int -> Int -> m Int
size uf x = do
    px <- root uf x
    s <- VUM.read uf px
    return $ abs s

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
    [n, m] <- getIntList
    cab <- fmap (sortOn Down) . replicateM m $ do
        [a, b, c] <- getIntList
        return (c, a-1, b-1)
    print $ mst n cab

mst :: (Traversable t, Num a) => Int -> t (a, Int, Int) -> a
mst n cab = runST $ do
    uf <- newUF n
    let proc (c, a, b) = do
            p <- same uf a b
            if p
                then return 0
                else do
                    unite uf a b
                    return c
    cost <- forM cab proc
    return $ sum cost
