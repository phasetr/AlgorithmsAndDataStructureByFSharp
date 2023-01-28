-- https://atcoder.jp/contests/tessoku-book/submissions/35596259
import Control.Monad ( foldM_, replicateM, liftM2, when )
import Control.Monad.Primitive ( PrimMonad(PrimState) )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed.Mutable as VUM

newUF :: PrimMonad m => Int -> m (VUM.MVector (PrimState m) Int)
newUF n = VUM.replicate n (-1 :: Int)

root :: PrimMonad m => VUM.MVector (PrimState m) Int -> Int -> m Int
root uf x = do
  p <- VUM.read uf x
  if p < 0
    then return x
    else do
      r <- root uf p
      VUM.write uf x r
      return r

same :: PrimMonad m => VUM.MVector (PrimState m) Int -> Int -> Int -> m Bool
same uf x y = liftM2 (==) (root uf x) (root uf y)

unite :: PrimMonad m => VUM.MVector (PrimState m) Int -> Int -> Int -> m ()
unite uf x y = do
  px <- root uf x
  py <- root uf y
  when (px /= py) $ do
    sx <- VUM.read uf px
    sy <- VUM.read uf py
    let (par, chld) = if sx < sy then (px, py)　else (py, px)
    VUM.write uf chld par
    VUM.write uf par (sx + sy)

size :: PrimMonad m => VUM.MVector (PrimState m) Int -> Int -> m Int
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
  [n, q] <- getIntList
  qs <- replicateM q $ do
    [x, u, v] <- getIntList
    return (x, u-1, v-1)
  query n qs

query :: (Foldable t, Eq a, Num a) => Int -> t (a, Int, Int) -> IO ()
query n qs = do
  uf <- newUF n
  let proc uftree (1, u, v) = do
        unite uftree u v
        return uftree
      proc uftree (2, u, v) = do
        p <- same uftree u v
        if p
            then putStrLn "Yes"
            else putStrLn "No"
        return uftree
      proc _ _ = error "not come here"
  foldM_ proc uf qs
