{-
https://atcoder.jp/contests/keyence2019/submissions/4008306
-}
import Data.List

f :: [Int] -> [Int] -> [Int]
f [] [] = []
f (a:as) (b:bs) = (a-b) : f as bs
f _ _ = error "undefined"

check :: Int -> [Int] -> Int
check _ [] = error "checkError"
check m (p:ps)
  | m==0      = 0
  | (m+p)>=0  = 1
  | otherwise = 1 + check (m+p) ps

main :: IO ()
main = do
   getLine
   as <- map read.words <$> getLine
   bs <- map read.words <$> getLine
   let ds = f as bs
       ms = filter (< 0) ds
       ps = reverse $ sort $ filter (> 0) ds
   if sum as < sum bs then print (-1)
   else print $ check (sum ms) ps + length ms
