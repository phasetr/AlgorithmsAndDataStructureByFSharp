-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_C/review/2906969/lvs7k/Haskell
{-# LANGUAGE BangPatterns #-}
import qualified Data.ByteString.Char8 as B
import qualified Data.IntMap.Strict    as M
import Data.Maybe ( fromJust )
import qualified Data.Sequence         as S

readi :: B.ByteString -> Int
readi = fst . fromJust . B.readInt

data Tree a = Empty | Node a (Tree a) (Tree a) deriving Show

insert :: Ord a => a -> Tree a -> Tree a
insert x Empty = Node x Empty Empty
insert x (Node y l r)
  | x < y     = Node y (insert x l) r
  | otherwise = Node y l (insert x r)

print' :: Show a => Tree a -> IO ()
print' t = do
  putStrLn . (' ' :) . unwords $ fmap show (inOrder t)
  putStrLn . (' ' :) . unwords $ fmap show (preOrder t)

preOrder :: Tree a -> [a]
preOrder Empty        = []
preOrder (Node x l r) = x : preOrder l ++ preOrder r

inOrder :: Tree a -> [a]
inOrder Empty        = []
inOrder (Node x l r) = inOrder l ++ [x] ++ inOrder r

find :: Int -> Tree Int -> Bool
find _ Empty = False
find x (Node y l r)
  | x == y    = True
  | x < y     = find x l
  | otherwise = find x r

delete :: Int -> Tree Int -> Tree Int
delete _ Empty = error "delete from empty tree"
delete x (Node y l r)
  | x < y     = Node y (delete x l) r
  | x > y     = Node y l (delete x r)
  | isEmpty l && isEmpty r = Empty
  | isEmpty l = r
  | isEmpty r = l
  | otherwise = let m = getMin r in Node m l (delete m r)

isEmpty :: Tree Int -> Bool
isEmpty Empty = True
isEmpty _     = False

getMin :: Tree Int -> Int
getMin Empty = error "getMin from empty tree"
getMin (Node x Empty _) = x
getMin (Node _ l     _) = getMin l

solve :: Tree Int -> [[B.ByteString]] -> IO ()
solve _ [] = return ()
solve !t (bs:bss)
  | c == 'p' = do
      print' t
      solve t bss
  | c == 'f' = do
      let n = readi $ bs !! 1
      if find n t then putStrLn "yes" else putStrLn "no"
      solve t bss
  | c == 'd' = do
      let n = readi $ bs !! 1
      solve (delete n t) bss
  | otherwise = do
      let n = readi $ bs !! 1
      solve (insert n t) bss
  where c = B.head (head bs)

main :: IO ()
main = do
  B.getLine
  xss <- fmap B.words . B.lines <$> B.getContents
  solve Empty xss


