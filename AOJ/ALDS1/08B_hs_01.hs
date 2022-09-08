-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_B/review/2906868/lvs7k/Haskell
{-# LANGUAGE BangPatterns #-}

import           Control.Applicative
import           Control.Monad
import qualified Data.ByteString.Char8 as B
import qualified Data.IntMap.Strict    as M
import qualified Data.Sequence         as S

readi :: B.ByteString -> Int
readi bs | Just (n, _) <- B.readInt bs = n

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

solve :: Tree Int -> [[B.ByteString]] -> IO ()
solve _ [] = return ()
solve !t (bs:bss)
  | c == 'p' = do
      print' t
      solve t bss
  | c == 'f' = do
      let n = readi $ bs !! 1
      if find n t
        then putStrLn "yes"
        else putStrLn "no"
      solve t bss
  | otherwise = do
      let n = readi $ bs !! 1
      solve (insert n t) bss
  where c = B.head (head bs)

main :: IO ()
main = do
  B.getLine
  xss <- fmap B.words . B.lines <$> B.getContents
  solve Empty xss
