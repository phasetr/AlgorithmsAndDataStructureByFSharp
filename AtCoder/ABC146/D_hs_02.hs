-- https://atcoder.jp/contests/abc146/submissions/8630472
{-# LANGUAGE BangPatterns #-}
import Data.Char (isSpace)
import Data.List (unfoldr)
import Control.Monad ( forM_ )
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import qualified Data.Vector.Unboxed as U
import qualified Data.Vector.Unboxed.Mutable as UM
import qualified Data.ByteString.Char8 as BS

main :: IO ()
main = do
  n <- readLn
  edges <- U.replicateM (n-1) $ do
    [a,b] <- unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
    return (a-1,b-1)
  let graph :: V.Vector [(Int,Int)]
      graph = V.create $ do
        g <- VM.replicate n []
        flip U.imapM_ edges $ \i (a,b) -> do
          VM.modify g ((b,i) :) a
          VM.modify g ((a,i) :) b
        return g
  let result :: U.Vector Int
      result = U.create $ do
        r <- UM.new (n-1)
        let go !i0 !i !c0 = do
              forM_ (zip (filter ((/= i0) . fst) $ graph V.! i) (filter (/= c0) [1..])) $ \((j,k),c) -> do
                UM.write r k c
                go i j c
        go (-1) 0 (-1)
        return r
  print (U.maximum result)
  U.forM_ result print
