-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_C/review/2212463/aimy/Haskell
main = getContents
  >>= putStrLn . unwords . solve
  . map words . tail . lines

solve :: [[String]] -> [String]
solve = match 0 0 where
  match t h [] = [show t, show h]
  match t h ([ct,ch]:xs)
    | ct > ch  = match (t+3) h xs
    | ct == ch = match (t+1) (h+1) xs
    | ct < ch  = match t (h+3) xs
  match _ _ _ = undefined
