-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_A/review/1434959/s1180040/Haskell
import Data.List ( find, (\\), sortBy )
import Data.Ord ( comparing )

f :: [(Int, Int)] -> Int -> [Int]
f xs ypos = filter fil_f [0 .. 7] where
  fil_f xpos =
    case find (isExist xpos) xs of
      Just _ -> False
      Nothing -> True
  isExist xpos a = snd a == xpos || abs (xpos - snd a) == abs (ypos - fst a)

solve2 :: [(Int, Int)] -> [Int] -> [(Int, Int)]
solve2 res [] = res
solve2 res (y:ys)
  | null next_xs = []
  | otherwise = foldr (\next_x_elem xs -> if next_res next_x_elem /= [] then next_res next_x_elem else xs) [] next_xs
  where
    lowList = filter (\a -> fst a < y) res
    highList = filter (\a -> fst a > y) res
    next_xs = f res y
    next_res next_x_elem = solve2 (lowList ++ [(y, next_x_elem)] ++ highList) ys

solve :: [(Int, Int)] -> [(Int, Int)]
solve ins = solve2 ins ([0 .. 7] \\ yList) where
  yList = map fst ins

input :: Int -> IO [(Int, Int)]
input n
  | n == 0 = return []
  | otherwise = do
      ins <- fmap (map read . words) getLine
      rems <- input $ n-1
      return $ (head ins, ins !! 1) : rems

display :: [(Int, Int)] -> IO ()
display [] = return ()
display (x:xs) = do
  putStrLn $ getStr (snd x) 0
  display xs
    where
      getStr a pos
        | pos == 8 = ""
        | a == pos = 'Q' : getStr a (pos+1)
        | otherwise = '.' : getStr a (pos+1)

main :: IO()
main = do
  n <- readLn
  _in <- input n
  display $ solve $ sortBy (comparing fst) _in
