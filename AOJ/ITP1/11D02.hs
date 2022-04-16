-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_D/review/2185547/satoshi3/Haskell
import Data.List ( nub )

n :: [Int] -> [Int]
n [a,b,c,d,e,f] = [b,f,c,d,a,e]
n _ = undefined

w :: [Int] -> [Int]
w [a,b,c,d,e,f] = [c,b,f,a,e,d]
w _ = undefined

turn :: [Int] -> [[Int]]
turn [a,b,c,d,e,f] = [[a,b,c,d,e,f],[a,c,e,b,d,f],[a,e,d,c,b,f],[a,d,b,e,c,f]]
turn _ = undefined

solve :: String -> [Int] -> [[Int]]
solve [] _ = []
solve (x:xs) list
  | 'f' == x = turn list ++ solve xs list
  | 'n' == x = (turn . n) list ++ solve xs (n list)
  | 'w' == x = (turn . w) list ++ solve xs (w list)
solve _ _ = undefined

main :: IO ()
main = do
  n <- fmap (*24) readLn
  m <- fmap (map (solve "fnnwnn". map read . words) . lines) getContents
  if a m == b m then putStrLn "Yes" else putStrLn "No"
  where a = sum . map (length . nub)
        b = length . nub . concat
