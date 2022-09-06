-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_D/review/2318396/hsjoihs/Haskell
import qualified Data.ByteString.Char8 as B
import Data.Maybe ( fromJust, isJust )
main :: IO ()
main = do
 _ <- B.getLine
 ps <- fmap B.words B.getLine
 is <- fmap B.words B.getLine
 B.putStrLn . B.unwords $ solve ps is

solve :: Eq a => [a] -> [a] -> [a]
solve pos [] = []
solve [] ios = []
solve pos ios = solve pos l ++ solve pos r ++ [p] where
  (l, p, r) = fromJust . head . filter isJust $ map (`splitMaybe` ios) pos
splitMaybe :: (Eq a) => a -> [a] -> Maybe ([a], a, [a])
splitMaybe k as = f k [] as where
  f _ _ [] = Nothing
  f k bs (a:as) = if k == a then Just (reverse bs, k, as) else f k (a:bs) as

test :: IO ()
test = do
  print $ solve [1,2,3,4,5] [3,2,4,1,5] == [3,4,2,5,1]
  print $ solve [1,2,3,4] [1,2,3,4] == [4,3,2,1]
