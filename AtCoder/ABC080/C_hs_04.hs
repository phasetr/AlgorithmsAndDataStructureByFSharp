-- https://atcoder.jp/contests/abc080/submissions/2667696
{-# OPTIONS_GHC -O #-}
{-# LANGUAGE OverloadedStrings #-}

import Control.Monad ( replicateM )
import Data.List ( unfoldr )
import Data.Bits ((.&.), popCount)
import qualified Data.ByteString.Char8 as B

main :: IO ()
main = do
  n <- readLn :: IO Int
  ss <- replicateM n $ sum.zipWith (flip (*)) (iterate (*2) 1).unfoldr (B.readInt.B.dropWhile(==' ')) <$> B.getLine
  vs <- replicateM n $ unfoldr (B.readInt.B.dropWhile(==' ')) <$> B.getLine
  print $ maximum $ map (f 0 ss vs) [1..1023]
  where
    f a [] _ _ = a
    f a (s:ss) (v:vs) i = f (a + (v !! popCount (s .&. i))) ss vs i
    f _ _ _ _ = error "not come here"
