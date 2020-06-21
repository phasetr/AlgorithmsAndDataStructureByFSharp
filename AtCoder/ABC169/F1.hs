#!/usr/bin/env stack
{- stack script
   --resolver lts-16.0
   --package vector
   --package bytestring
-}
{-
cf. https://atcoder.jp/contests/abc169/submissions/13992790

実行用メモ: stack 前提
chmod +x ABC169F.hs
./ABC169F.hs < F1.txt
-}
import qualified Data.Bool as B
import qualified Data.Vector.Unboxed as U
import           Debug.Trace

p = 998244353 :: Int

main :: IO ()
main = do
  [_, s] <- map read.words <$> getLine :: IO [Int]
  as <- map read.words <$> getLine :: IO [Int]
  print $ f s as
  where
    f :: Int -> [Int] -> Int
    f s = U.last . snd . foldl step dp0
      where
        dp0 = (1, U.replicate (s+1) 0)

        step :: (Int, U.Vector Int) -> Int -> (Int, U.Vector Int)
        step (d, dp) x = (2 * d `mod` p, U.generate (s+1) g)
          where
            g :: Int -> Int
            g i =
              if i == x then 2 * (dp U.! i) + d
              else if x < i then 2 * (dp U.! i) + (dp U.! (i-x))
              else 2 * (dp U.! i)

mainOrig = do
  [_, s] <- map read.words <$> getLine :: IO [Int]
  as <- map read.words <$> getLine :: IO [Int]
  print $ f s as
  where
    f :: Int -> [Int] -> Int
    f s = U.last . snd . foldl step (1, U.replicate (s+1) 0)
      where
        step :: (Int, U.Vector Int) -> Int -> (Int, U.Vector Int)
        step (d, v) x = (2 * d `mod` p, U.generate (s+1) g)
          where
            g :: Int -> Int
            g i = (2 * (v U.! i) + B.bool 0 d (i == x) + B.bool 0 (v U.! (i - x)) (x < i)) `mod` p
            -- bool x y p = if p then y else x
