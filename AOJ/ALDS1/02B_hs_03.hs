-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_B/review/4639153/phasetr/Haskell
import Data.List ( elemIndex, sort )

solve :: Int -> [Int] -> Int
solve n [] = n
solve n l
  | 0 /= getIndex l = solve (n+1) $ change l $ getIndex l
  | otherwise = solve n (tail l)
  where
    getIndex l = (\(Just x) -> x) $ elemIndex (minimum l) l
    change l i = tail $ take i l ++ [head l] ++ drop (i+1) l
main :: IO ()
main = do
  list <- fmap (map read . tail . words) getContents
  putStrLn $ unwords $ map show $ sort list
  print $ solve 0 list

