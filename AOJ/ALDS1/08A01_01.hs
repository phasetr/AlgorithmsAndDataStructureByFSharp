-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_A/review/3386722/tyanon/Haskell
foldM_' :: (Monad m) => (a -> b -> m a) -> a -> [b] -> m ()
foldM_' _ _ [] = return ()
foldM_' f z (x:xs) = do
  z' <- f z x
  z' `seq` foldM_' f z' xs

data BST a = Empty | Node a (BST a) (BST a) deriving (Show)

bstInsert :: (Ord a) => BST a -> a -> BST a
bstInsert Empty x = Node x Empty Empty
bstInsert (Node y l r) x
  | x <= y    = Node y (bstInsert l x) r
  | otherwise = Node y l (bstInsert r x)

bstPreorder :: (Ord a) => BST a -> [a]
bstPreorder Empty = []
bstPreorder (Node x l r) = [x] ++ bstPreorder l ++ bstPreorder r

bstInorder :: (Ord a) => BST a -> [a]
bstInorder Empty = []
bstInorder (Node x l r) = bstInorder l ++ [x] ++ bstInorder r

doCmd :: BST Int -> [String] -> IO (BST Int)
doCmd node ("insert":arg0:_) = do
  let x = read arg0
  return $ bstInsert node x
doCmd node ("print":_) = do
  putStrLn . concatMap ((' ':) . show) $ bstInorder  node
  putStrLn . concatMap ((' ':) . show) $ bstPreorder node
  return node
doCmd _ _ = error "invalid command"

main :: IO ()
main = do
  _    <- getLine
  cmds <- fmap (map words . lines) getContents
  let bst = Empty :: BST Int
  foldM_' doCmd bst cmds
