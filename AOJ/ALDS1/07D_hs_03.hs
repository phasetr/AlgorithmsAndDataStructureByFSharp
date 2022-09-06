-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_D/review/3427139/utopian/Haskell
import Data.Maybe ( fromJust, isJust )

main :: IO ()
main = do
  _ <- getLine
  pos <- fmap (map read . words) getLine
  ios <- fmap (map read . words) getLine
  putStrLn $ solve pos ios

data Tree a = Leaf | Node a (Tree a) (Tree a)

solve :: [Int] -> [Int] -> String
solve pos ios = postOrder $ reconstruct pos ios where
  reconstruct :: [Int] -> [Int] -> Tree Int
  reconstruct pos [] = Leaf
  reconstruct [] ios = Leaf
  reconstruct pos ios = Node p (reconstruct pos l) (reconstruct pos r)
    where (l, p, r) = fromJust . head . filter isJust $ map (`splitIfEqual` ios) pos

splitIfEqual :: (Eq a) => a -> [a] -> Maybe ([a], a, [a])
splitIfEqual k as = go k [] as where
  go _ _ [] = Nothing
  go k bs (a:as) = if k == a then Just (reverse bs, k, as) else go k (a:bs) as

postOrder :: Tree Int -> String
postOrder = unwords . map show . postOrderedList where
  postOrderedList :: Tree Int -> [Int]
  postOrderedList Leaf = []
  postOrderedList (Node x left right) = postOrderedList left ++ postOrderedList right ++ [x]
