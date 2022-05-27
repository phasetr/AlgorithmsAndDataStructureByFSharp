-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_C/review/2254854/matonix/Haskell
{-# LANGUAGE FlexibleContexts #-}
import Control.Monad ( when, forM_, replicateM )
import Data.Array.MArray
    ( getElems, newListArray, readArray, writeArray, MArray )
import Data.Array.Base
    ( getElems,
      newListArray,
      readArray,
      writeArray,
      MArray(unsafeWrite, unsafeRead) )
import Data.Array.IO
    ( getElems, newListArray, readArray, writeArray, MArray, IOArray )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS

type Card = (Char, Int, Int)

main :: IO ()
main = do
  n <- fmap readInt1 BS.getLine
  ns <- fmap (map (applyTuple BS.head readInt1 . toTuple . BS.words)) (replicateM n BS.getLine)
  let (a,b) = unzip ((' ',0):ns)
  let ns' = zip3 a b [0..]
  arr <- newListArray (0, n) ns' :: IO (IOArray Int Card)
  quicksort arr 1 n
  es <- fmap tail (getElems arr)
  putStrLn $ if stable es then "Stable" else "Not stable"
  mapM_ (putStrLn . (\(a, b, _) -> a:' ':show b)) es

quicksort :: (MArray a Card m) => a Int Card -> Int -> Int -> m ()
quicksort arr p r =
  when (p < r) $ do
    partition' arr p r
    (_, q, _) <- readArray arr 0
    quicksort arr p (q-1)
    quicksort arr (q+1) r

partition' :: (MArray a Card m) => a Int Card -> Int -> Int -> m ()
partition' arr p r = do
  (_, x, _) <- readArray arr r
  writeArray arr 0 (' ', p-1, 0)
  forM_ [p..r-1] $ \j -> do
    (_, y, _) <- readArray arr j
    when (y <= x) $ do
      increment arr
      (_, i, _) <- readArray arr 0
      swapArray arr i j
  (_, i, _) <- readArray arr 0
  swapArray arr (i+1) r
  writeArray arr 0 (' ', i+1, 0)

swapArray :: (MArray a e m) => a Int e -> Int -> Int -> m ()
swapArray arr i j = do
  x <- unsafeRead arr i
  y <- unsafeRead arr j
  unsafeWrite arr i y
  unsafeWrite arr j x

increment :: (MArray a Card m) => a Int Card -> m ()
increment arr = do
  (s, x, i) <- unsafeRead arr 0
  unsafeWrite arr 0 (s, x+1, i)

stable :: [Card] -> Bool
stable [_] = True
stable ((_, x, i):(s, y, j):xs) = not (x == y && i > j) && stable ((s, y, j):xs)
stable _ = error "undefined"

readInt1 :: BS.ByteString -> Int
readInt1 = fst . fromJust . BS.readInt

toTuple :: [a] -> (a, a)
toTuple [x, y] = (x, y)
toTuple _ = error "undefined"

applyTuple :: (a -> a') -> (b -> b') -> (a, b) -> (a', b')
applyTuple f g (x, y) = (f x, g y)
