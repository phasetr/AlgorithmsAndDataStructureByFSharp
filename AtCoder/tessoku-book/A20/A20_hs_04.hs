-- https://atcoder.jp/contests/tessoku-book/submissions/37417172
{-# LANGUAGE MultiParamTypeClasses #-}
import qualified Data.ByteString.Char8 as B
import qualified Data.Map as M
import Data.Maybe ( fromJust )

main :: IO ()
main = B.interact (encode . solve . decode)

decode :: B.ByteString -> [[String]]
decode =  map (map B.unpack . B.words) . B.lines

readInt :: B.ByteString -> Int
readInt = fst . fromJust . B.readInt

encode :: [[Int]] -> B.ByteString
encode = B.unlines . map (B.unwords . map showInt)

showInt :: Int -> B.ByteString
showInt = B.pack . show

solve :: [[String]] -> [[Int]]
solve dss = case dss of [s]:[t]:_ -> [[ length (lcs s t)] ]

lcs :: Eq a => [a] -> [a] -> [a]
lcs xs = fst . head . foldr phi row0 where
  row0 = replicate (length xs + 1) nil
  phi y row = foldr (step y) [nil] (zip3 xs row (tail row))
  step y (x,cs1,cs2) row
    | x == y    = (x `cons` cs2) : row
    | otherwise = longer cs1 (head row) : row

longer :: Sized a -> Sized a -> Sized a
longer xs@(_,m) ys@(_,n)
  | m < n     = ys
  | otherwise = xs

type Sized a = ([a], Int)

nil :: Sized a
nil = ([],0)

cons :: a -> Sized a -> Sized a
cons x (xs,n) = (x:xs, succ n)
