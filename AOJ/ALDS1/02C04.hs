-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_C/review/3096108/niruneru/Haskell
import Data.Ord(comparing)
import Data.List(minimumBy, unfoldr, sortBy)

bubble :: [String] -> Maybe (String, [String])
bubble = foldr step Nothing where
  x `step` Nothing = Just (x, [])
  x `step` Just (y, ys)
    | comparing last y x == LT = Just (y, x:ys)
    | otherwise                = Just (x, y:ys)

bSort :: [String] -> [String]
bSort = unfoldr bubble

select :: [String] -> Maybe (String, [String])
select []     = Nothing
select [x]    = Just (x,[])
select (x:xs) =
  let min = minimumBy (comparing last) xs
  in if comparing last min x == LT
     then Just (min, takeWhile (/=min) xs ++ x : tail (dropWhile (/=min) xs))
     else Just (x, xs)

sSort :: [String] -> [String]
sSort = unfoldr select

main :: IO ()
main = do
  getLine
  cs <- getLine
  let bs = unwords . bSort . words $ cs
  let ss = unwords . sSort . words $ cs
  putStrLn bs
  putStrLn "Stable"
  putStrLn ss
  if bs == ss then putStrLn "Stable" else putStrLn "Not stable"
