-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_D/review/2318396/hsjoihs/Haskell
main :: IO ()
main = do
 _ <- getLine
 arr1 <- fmap words getLine
 arr2 <- fmap words getLine
 putStrLn . unwords $ solve arr1 arr2

solve :: (Eq a) => [a] -> [a] -> [a]
solve [] [] = []
solve preorder@(a:l1r1) inorder = l3 ++ r3 ++ [a] where
  (l2, _:r2) = break (== a) inorder
  (l1,r1) = splitAt (length l2) l1r1
  l3 = solve l1 l2
  r3 = solve r1 r2
solve _ _ = error "not come here"
