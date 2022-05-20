-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_C/review/5225983/warachia100/Haskell
import Control.Monad
import Control.Applicative
import Data.List (intercalate)

showRoom b f r l = sum [n | [x,y,z,n] <- l, b == x && f == y && r == z]
showFloor b f l = " " ++ unwords [show $ showRoom b f r l | r <- [1..10]] ++ "\n"
showBuilding b l = concat $ [showFloor b f l | f <- [1..3]]
main = do
  getLine
  inputs <- fmap (map read . words) . lines <$> getContents
  putStr $ intercalate "####################\n"  [showBuilding b inputs | b <- [1..4]]
