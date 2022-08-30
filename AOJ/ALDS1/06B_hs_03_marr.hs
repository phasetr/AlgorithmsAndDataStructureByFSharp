-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_B/review/2897462/lvs7k/Haskell
import Control.Monad ( forM_, when )
import qualified Data.ByteString.Char8 as B
import Data.Array.IO
    ( newListArray,
      readArray,
      writeArray,
      MArray(getBounds),
      IOUArray )
import Data.Array.MArray
    ( newListArray, readArray, writeArray, MArray(getBounds) )
import Data.IORef ( newIORef, readIORef, writeIORef )

read' :: B.ByteString -> Int
read' bs | Just (n, _) <- B.readInt bs = n
read' _ = error "undefined"

swap :: Int -> Int -> IOUArray Int Int -> IO ()
swap i j a = do
  x <- readArray a i
  y <- readArray a j
  writeArray a i y
  writeArray a j x

partition :: Int -> Int -> IOUArray Int Int -> IO Int
partition p r a = do
  x <- readArray a r
  i <- newIORef (p - 1)
  forM_ [p .. r - 1] $ \j -> do
    t <- readArray a j
    when (t <= x) $ do
      i' <- readIORef i
      swap (i' + 1) j a
      writeIORef i (i' + 1)
  i' <- readIORef i
  swap (i' + 1) r a
  return (i' + 1)

print' :: Int -> IOUArray Int Int -> IO ()
print' n a = do
  (s, e) <- getBounds a
  forM_ [s .. e] $ \i -> do
    m <- readArray a i
    case i of
        0 | i == n    -> putStr ("[" ++ show m ++ "]")
          | otherwise -> putStr (show m)
        _ | i == n    -> putStr (" [" ++ show m ++ "]")
          | otherwise -> putStr (" " ++ show m)
  putStrLn ""

main :: IO ()
main = do
  n <- readLn
  xs <- fmap (fmap read' . B.words) B.getLine
  ary <- newListArray (0, n-1) xs
  m <- partition 0 (n-1) ary
  print' m ary
