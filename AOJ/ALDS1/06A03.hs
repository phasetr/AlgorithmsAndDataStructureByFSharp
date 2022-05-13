-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_A/review/2897635/lvs7k/Haskell
{-# LANGUAGE BangPatterns #-}
import Control.Applicative ()
import Control.Monad ( forM_ )
import Data.Array.IO ( getAssocs, readArray, writeArray, MArray(newArray), IOUArray )
import qualified Data.ByteString.Char8 as B
import Data.List ( genericReplicate )
import Data.Word ( Word16 )

read' :: B.ByteString -> Word16
read' bs | Just (n, _) <- B.readInt bs = fromIntegral n

_VMAX = 10000

countingSort :: [Word16] -> IO ()
countingSort as = do
  c <- newArray (0, _VMAX) 0 :: IO (IOUArray Word16 Int)
  forM_ as $ \a -> do
    t <- readArray c a
    writeArray c a (t + 1)
  bs <- getAssocs c
  putStrLn . unwords . fmap show . concatMap (\(i, e) -> genericReplicate e i) $ bs

main :: IO ()
main = do
  B.getLine
  !xs <- fmap read' . B.words <$> B.getLine
  countingSort xs
