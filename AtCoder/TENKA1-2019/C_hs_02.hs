-- https://atcoder.jp/contests/tenka1-2019/submissions/5047235
{-# LANGUAGE BangPatterns #-}
{-# LANGUAGE ScopedTypeVariables #-}
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed as U

main :: IO ()
main = do
  n :: Int <- readLn
  s <- BS.getLine
  let count s | BS.null s = []
              | otherwise = let (s1,s2) = BS.span (== '.') s
                                (s3,s4) = BS.span (== '#') s2
                                !n1 = BS.length s1
                                !n2 = BS.length s3
                            in (n1,n2) : count s4
      vec = U.fromList $ count s
      blackAcc = U.init $ U.scanl' (\n (_,m) -> n + m) 0 vec
      whiteAcc = U.tail $ U.scanr' (\(m,_) n -> n + m) 0 vec
      acc = U.zipWith (+) blackAcc whiteAcc
  print $ if U.null acc then 0 else U.minimum acc
