{-# LANGUAGE OverloadedStrings #-}
{-
https://atcoder.jp/contests/abc131/submissions/19271281
-}
import Data.Bool
import Data.Char
import Data.List
import Data.Maybe
import Data.Ord
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as V
import qualified Data.Vector.Algorithms.Intro as VA -- cabal install --lib vector-algorithms

main =
  putStrLn
  . solve
  =<< (\n -> V.unfoldrN n (\(a:b:ab) -> Just((a,b),ab))
        . unfoldr (B.readInt . B.dropWhile isSpace)
        <$> B.getContents) =<< readLn

solve :: V.Vector (Int, Int) -> String
solve =
  bool "No" "Yes"
  . isJust
  . V.foldM f 0
  . V.modify (VA.sortBy $ comparing snd)
  where
    f :: (Ord a, Num a) => a -> (a, a) -> Maybe a
    f t (a,b) = if t+a>b then Nothing else Just(t+a)

test :: IO ()
test = do
  print $ solve (V.fromList [(2,4),(1,9),(1,8),(4,9),(3,12)]) == "Yes"
  print $ solve (V.fromList [(334,1000),(334,1000),(334,1000)]) == "No"
  print $ solve (V.fromList [(384,8895),(1725,9791),(170,1024),(4,11105),(2,6),(578,1815),(702,3352),(143,5141),(1420,6980),(24,1602),(849,999),(76,7586),(85,5570),(444,4991),(719,11090),(470,10708),(1137,4547),(455,9003),(110,9901),(15,8578),(368,3692),(104,1286),(3,4),(366,12143),(7,6649),(610,2374),(152,7324),(4,7042),(292,11386),(334,5720)]) == "Yes"
