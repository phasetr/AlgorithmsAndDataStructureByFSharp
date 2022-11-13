-- https://atcoder.jp/contests/abc085/submissions/13653884
import Data.List ( sortBy )

main :: IO ()
main = do
  [n,h] <- map read . words <$> getLine :: IO[Int]
  co <- getContents
  let (a,bs) = foldl (\ (a,bs) [a',b] -> (max a a', b:bs)) (0,[]) $ map (map read . words) $ lines co
  let xs = foldr (\ x' all@(x:xs) -> if x' >= x then x':all else all) [a] $ sortBy (flip compare) bs
  print $ solve h xs

solve :: Int -> [Int] -> Int
solve h [x] = (h+x-1) `div` x
solve h (x:xs) = if x >= h then 1 else 1 + solve (h-x) xs
solve _ _ = error "not come here"
