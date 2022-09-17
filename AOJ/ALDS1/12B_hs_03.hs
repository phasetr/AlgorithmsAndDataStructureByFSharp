-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/2918210/lvs7k/Haskell
import Control.Monad ( when, forM_, filterM, replicateM, unless )
import qualified Data.ByteString.Char8 as B
import Data.Array.IArray ( Array, (!), array )
import Data.Array.IO
    ( getAssocs, readArray, writeArray, MArray(newArray), IOUArray )
import Data.Array.MArray
    ( getAssocs, readArray, writeArray, MArray(newArray) )
import Data.Maybe ( fromJust )
import Data.Function ( on )
import Data.List ( minimumBy, unfoldr )

readi :: B.ByteString -> Int
readi = fst . fromJust . B.readInt

dijk :: Array Int [(Int, Int)] -> IOUArray Int Bool -> IOUArray Int Int -> IO ()
dijk b c d = go where
  go :: IO ()
  go = do
    as <- filterM (readArray c . fst) =<< getAssocs d
    unless (null as) $ do
      let (i, _) = minimumBy (compare `on` snd) as
      writeArray c i False -- confirmed
      bs <- filterM (readArray c . fst) (b ! i)
      forM_ bs $ \(v, w) -> do
        di <- readArray d i
        dv <- readArray d v
        when (di + w < dv) $ writeArray d v (di + w)
      go

main :: IO ()
main = do
  let f []       = Nothing
      f (i:j:ks) = Just ((i, j), ks)
      f _        = error "not come here"
  n <- readLn
  xss <- replicateM n $ do
    (i:_:xs) <- fmap (fmap readi . B.words) B.getLine
    return (i, unfoldr f xs)

  let b = array (0, n-1) xss      :: Array Int [(Int, Int)]
  c <- newArray (0, n-1) True     :: IO (IOUArray Int Bool)
  d <- newArray (0, n-1) maxBound :: IO (IOUArray Int Int)
  writeArray d 0 0

  dijk b c d

  forM_ [0 .. n-1] $ \i -> do
    v <- readArray d i
    putStr (show i ++ " ")
    print v
