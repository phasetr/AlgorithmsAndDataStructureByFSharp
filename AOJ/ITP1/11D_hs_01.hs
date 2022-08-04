-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_11_D
main :: IO ()
main = getLine >> getContents >>= putStrLn . solve . map words . lines

rot :: [a] -> Char -> [a]
rot [a,b,c,d,e,f] o
  | o == 'E'  = [d,b,a,f,e,c]
  | o == 'N'  = [b,f,c,d,a,e]
  | o == 'S'  = [e,a,c,d,f,b]
  | otherwise = [c,b,f,a,e,d]
rot _ _ = undefined

dices :: [a] -> [[a]]
dices dice = f dice (take 24 $ cycle "EEENNWWS") where
  f _ [] = []
  f dice xs = dice : f (rot dice (head xs)) (tail xs)

solve :: Eq a => [[a]] -> String
solve xs = if any (`elem` dices (head xs)) (tail xs) then "No" else "Yes"

test :: IO ()
test = do
  print $ solve [[1,2,3,4,5,6],[6,2,4,3,5,1],[6,5,4,3,2,1]] == "No"
  print $ solve [[1,2,3,4,5,6],[6,5,4,3,2,1],[5,4,3,2,1,6]] == "Yes"
