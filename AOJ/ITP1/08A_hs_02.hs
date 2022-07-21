-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_A/review/2211469/aimy/Haskell
import Data.Char (isLower,toLower,toUpper)
main = interact
  $ map (\c -> if isLower c then toUpper c else toLower c)
