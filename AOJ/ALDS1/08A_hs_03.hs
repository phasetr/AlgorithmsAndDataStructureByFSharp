-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_A/review/2906857/lvs7k/Haskell
{-# LANGUAGE BangPatterns #-}
import qualified Data.ByteString.Char8 as B
import Data.Maybe (fromJust)

data Tree a = Empty | Node a (Tree a) (Tree a) deriving Show

insert :: Ord a => a -> Tree a -> Tree a
insert x Empty = Node x Empty Empty
insert x (Node y l r)
  | x < y     = Node y (insert x l) r
  | otherwise = Node y l (insert x r)

preOrder :: Tree a -> [a]
preOrder Empty = []
preOrder (Node x l r) = x : preOrder l ++ preOrder r

inOrder :: Tree a -> [a]
inOrder Empty = []
inOrder (Node x l r) = inOrder l ++ [x] ++ inOrder r

solve :: Tree Int -> [[B.ByteString]] -> IO ()
solve _ [] = return ()
solve !t (bs:bss)
  | length bs == 1 = do
      putStrLn . (' ':) . unwords $ fmap show (inOrder t)
      putStrLn . (' ':) . unwords $ fmap show (preOrder t)
      solve t bss
  | otherwise = let [_, n] = bs in solve (insert ((fst . fromJust . B.readInt) n) t) bss

main :: IO ()
main = do
  B.getLine
  xss <- fmap (fmap B.words . B.lines) B.getContents
  solve Empty xss
