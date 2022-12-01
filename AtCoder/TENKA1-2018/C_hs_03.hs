-- https://atcoder.jp/contests/tenka1-2018/submissions/3564874
{-# OPTIONS_GHC -O2 #-}
{-# LANGUAGE BangPatterns          #-}
{-# LANGUAGE CPP                   #-}
{-# LANGUAGE MultiParamTypeClasses #-}
{-# LANGUAGE OverloadedStrings     #-}
{-# LANGUAGE TypeFamilies          #-}

import qualified Data.ByteString.Char8       as B
import qualified Data.ByteString.Unsafe      as B
import Data.Char ( isSpace )
import Data.List ( sort, unfoldr )

main :: IO ()
main = do
  n <- readLn :: IO Int
  xs <- unfoldr (B.readInt.B.dropWhile isSpace) <$> B.getContents
  print $ solve n xs

solve :: Int -> [Int] -> Int
solve n xs = go (r - f) f r fs rs where
  !(f:fs, r:rs) = fmap reverse . splitAt (div n 2) $ sort xs
  go !acc !low !high (f:fs) (r:rs) = go acc' f r fs rs
    where !acc' = acc + (r - low) + (high - f)
  go !acc !low !high [] [r] = acc + max (r - low) (high - r)
  go !acc _ _ _ _ = acc

test = do
  let n = 5
  let xs = [6,8,1,2,3]
  print $ sort xs
  print $ splitAt (div n 2) $ sort xs
  print $ fmap reverse . splitAt (div n 2) $ sort xs
