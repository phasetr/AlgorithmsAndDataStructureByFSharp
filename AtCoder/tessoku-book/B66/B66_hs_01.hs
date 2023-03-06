-- https://atcoder.jp/contests/tessoku-book/submissions/35596654
import Control.Monad ( liftM2, when, forM_, forM, replicateM )
import Control.Monad.Primitive ( PrimMonad(PrimState) )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM
import Data.Vector.Unboxed.Base ( MVector )

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
    ab <- replicateM m $ do
        [a, b] <- getIntList
        return (a-1, b-1)
    q <- getInt
    qs <- replicateM q getIntList

    let abvec = VU.fromList ab

    let fin = VU.create $ do
            let stops = [x-1 | (a:x:_) <- qs, a == 1]
            vec <- VUM.replicate m True
            forM_ stops $ \x -> do
                VUM.write vec x False
            return vec

    let query = do
            uf <- newUF n
            forM_ (zip [0..] ab) $ \(i, (a, b)) -> do
                when (fin VU.! i) $ unite uf a b
            let proc [1, x] = do
                    let (a, b) = abvec VU.! (x-1)
                    unite uf a b
                    return []
                proc [2, u, v] = do
                    p <- same uf (u-1) (v-1)
                    let a = if p then "Yes" else "No"
                    return a
                proc _ = error "not come here"
            ans <- forM (reverse qs) $ \i -> proc i
            mapM_ putStrLn . reverse $ filter (/= []) ans
    query
