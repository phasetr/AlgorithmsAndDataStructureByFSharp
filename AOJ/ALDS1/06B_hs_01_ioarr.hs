-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_B/review/2651560/marta1127/Haskell
import Control.Monad ( forM_, when )
import Control.Monad.State
    ( forM_,
      when,
      MonadIO(liftIO),
      StateT,
      modify,
      MonadState(get),
      evalStateT )
import Data.Array.IO
    ( newListArray,
      readArray,
      writeArray,
      MArray(getBounds),
      IOUArray )

main :: IO ()
main = do
  n <- readLn
  list <- fmap (map read.words) getLine
  arr <- newListArray (0,n-1) list
  i <- partition 0 (n-1) arr
  printPartedArray i arr

partition :: Int -> Int -> IOUArray Int Int -> IO Int
partition p r arr = evalStateT (part p r arr) (p-1)

part :: Int -> Int -> IOUArray Int Int -> StateT Int IO Int
part p r arr = do
  x <- liftIO $ readArray arr r
  forM_ [p..(r-1)] $ \j -> do
    e <- liftIO $ readArray arr j
    when (e <= x) $ modify (+1) >> get >>= \i' -> liftIO $ swap arr i' j
  i <- get
  liftIO $ swap arr (i+1) r
  return (i+1)

swap :: IOUArray Int Int -> Int -> Int -> IO ()
swap arr i j = do
  eI <- readArray arr i
  eJ <- readArray arr j
  writeArray arr j eI
  writeArray arr i eJ

printPartedArray :: Int -> IOUArray Int Int -> IO ()
printPartedArray j arr = do
  (s,g) <- getBounds arr
  forM_ [s..g] $ \i -> do
    e <- readArray arr i
    switchCase s g j i e

switchCase :: (Eq a1, Show a2) => a1 -> a1 -> a1 -> a1 -> a2 -> IO ()
switchCase s g j i e
  | i == s = putStr $ show e
  | i == g = putStrLn $ " " ++ show e
  | i == j = putStr $ " [" ++ show e ++ "]"
  | otherwise = putStr $ " " ++ show e
