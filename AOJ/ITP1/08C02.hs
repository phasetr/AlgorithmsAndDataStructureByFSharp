-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_C/review/2212398/aimy/Haskell
import Data.Char (isAlpha,toLower)
import Data.List (group,sort)

main :: IO ()
main = interact $ unlines . show' . solve
  where show' = zipWith (++) [a : " : " | a<-['a'..'z']] . map show

solve :: [Char] -> [Int]
solve = map (subtract 1 . length)
  . group . sort . (++ ['a'..'z']) . map toLower
  . filter isAlpha
