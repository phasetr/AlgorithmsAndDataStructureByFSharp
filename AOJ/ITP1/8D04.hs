-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_D/review/1690443/satoshi3/Haskell
import Data.List (isInfixOf)
main = getContents >>= putStrLn
  . (\b -> if b then "Yes" else "No")
  . (\[s,p] -> isInfixOf p $ concat $ replicate 2 s)
  . words
