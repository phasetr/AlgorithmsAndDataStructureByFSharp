-- https://atcoder.jp/contests/diverta2019/submissions/5356328
import Control.Monad ( replicateM )

main :: IO ()
main = do
  n<-readLn
  ss<-replicateM n getLine
  print $ solve n ss

solve :: Int->[String]->Int
solve n ss
  | lAfB /= 0 && lA == lAfB && fB == lAfB = nAB + bonus - 1
  | otherwise = nAB + bonus
  where
  bonus = min lA fB
  count [] = 0
  count ('A':'B':s)=1+count s
  count (c:s)=count s
  nAB = sum$map count ss
  lAs = filter((=='A').last)ss
  lA = length lAs
  fB = length$filter((=='B').head)ss
  lAfB = length$filter((=='B').head)lAs
