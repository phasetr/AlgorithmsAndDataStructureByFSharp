{-# LANGUAGE BangPatterns #-}
-- https://atcoder.jp/contests/dp/submissions/19451040

import qualified Data.ByteString.Char8 as C
import Data.Vector.Unboxed (ifoldl', unfoldrN)

main :: IO ()
main = (readLn >>= get . (*3)) >>= print . solve where
  get t = unfoldrN t (C.readInt . C.dropWhile (<'+')) <$> C.getContents

solve = (\(d0,d1,d2,_,_,_) -> maximum [d0,d1,d2])
  . ifoldl' f (0,0,0,0,0,0)

f (!d0,!d1,!d2,!h0,!h1,!h2) i !h
  | r==0      = let h'=h+max d1 d2 in (d0,d1,d2,h',h1,h2)
  | r==1      = let h'=h+max d2 d0 in (d0,d1,d2,h0,h',h2)
  | otherwise = let h'=h+max d0 d1 in (h0,h1,h',h0,h1,h')
  where r = i `mod` 3
