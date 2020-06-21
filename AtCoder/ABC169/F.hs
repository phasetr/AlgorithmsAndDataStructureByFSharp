#!/usr/bin/env stack
{- stack script
   --resolver lts-16.0
   --package vector
   --package bytestring
-}
{-
cf.
https://atcoder.jp/contests/abc169/submissions/14018589
https://atcoder.jp/contests/abc169/submissions/13992802

実行用メモ: stack 前提
chmod +x ABC169F.hs
./ABC169F.hs < F1.txt
-}
import qualified Data.ByteString.Char8 as C
import qualified Data.List as L
import qualified Data.Vector.Unboxed as U
import           Debug.Trace

p = 998244353 :: Int

main :: IO ()
main = do
  [n, s] <- map read.words <$> getLine :: IO [Int]
  as <- map read.words <$> getLine :: IO [Int]
  let ys = L.foldr f (init s) as
  print $ U.last ys
  where
    init :: Int -> U.Vector Int
    init s =
      U.iterateN (succ s) (const 0) 1
      --(U.singleton 1) U.++ (U.replicate s 0)

    -- acc の「初期値」は init s
    f :: Int -> U.Vector Int -> U.Vector Int
    f a acc =
      U.zipWith (\b c -> (b + c) `mod` p) bs cs
      where
        -- 記号は解説参照：a_i が T に選ばれている場合、または T に入るが U に入らない場合
        bs = U.map (2*) acc
        -- a_i が T にも U にも選ばれた場合
        cs = (U.replicate a 0) U.++ (U.slice 0 (U.length acc - a) acc)

mainOrig :: IO ()
mainOrig = C.interact $ C.pack . show . sol . L.unfoldr (C.readInt . C.dropWhile (<'0'))
  where
    sol :: [Int] -> Int
    sol (n:s:as) = U.last $ L.foldr f (U.singleton 1 U.++ U.replicate s 0) as
    f :: Int -> U.Vector Int -> U.Vector Int
    f a = U.zipWith (\a b -> (a+b) `mod` p) <$> U.map (2*) <*> (U.replicate a 0 U.++)
