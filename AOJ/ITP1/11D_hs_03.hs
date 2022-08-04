-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_D/review/1697723/amusan39/Haskell
move :: [a] -> Char -> [a]
move [a,b,c,d,e,f] o
  | o == 'E' = [d,b,a,f,e,c]
  | o == 'N' = [b,f,c,d,a,e]
  | o == 'S' = [e,a,c,d,f,b]
  | o == 'W' = [c,b,f,a,e,d]
move _ _ = undefined

allDicePattern :: [a] -> [[a]]
allDicePattern dice = f dice (take 24 $ cycle "EEENNWWS") where
  f _ [] = []
  f dice (x:xs) = dice : f (move dice x) xs

solve :: Eq a => [[a]] -> [Char]
solve (x:xs) = if any (`elem` allDicePattern x) xs then "No" else "Yes"
solve _ = undefined

main :: IO ()
main = getContents >>= putStrLn . solve . map words . tail . lines
