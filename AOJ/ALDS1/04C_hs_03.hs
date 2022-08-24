-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_C/review/3118715/little_Haskeller/Haskell
{-# LANGUAGE OverloadedStrings #-}
import qualified Data.ByteString as BS
import qualified Data.Map.Strict as Map

main :: IO ()
main = do
  n <- readLn
  loop n Map.empty

splitSpace :: BS.ByteString -> [BS.ByteString]
splitSpace = BS.split 32

loop :: (Eq a, Num a) => a -> Map.Map BS.ByteString a -> IO ()
loop 0 _   = return ()
loop n dic = do
  [c,s] <- fmap splitSpace BS.getLine
  case c of
    "insert" -> loop (n - 1) (Map.insert s n dic)
    _ -> do
      putStrLn (if Map.member s dic then "yes" else "no")
      loop (n - 1) dic

