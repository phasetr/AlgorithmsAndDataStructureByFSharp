-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_C/review/1697700/amusan39/Haskell
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

main :: IO ()
main = do
  dice <- words <$> getLine
  dice2 <- words <$> getLine
  putStrLn $ if dice2 `elem` allDicePattern dice then "Yes" else "No"
