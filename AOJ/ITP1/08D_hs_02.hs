-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_D/review/2212407/aimy/Haskell
import Data.List (isInfixOf)
main :: IO ()
main = interact
  $ (\[s,p] -> if p `isInfixOf` (s++s) then "Yes\n" else "No\n")
  . lines
