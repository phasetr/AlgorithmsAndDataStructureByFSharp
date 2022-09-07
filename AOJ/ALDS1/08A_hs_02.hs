-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_A/review/3099719/utopian/Haskell
{-# LANGUAGE BangPatterns #-}
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as B
import Data.Maybe (fromJust)

main :: IO()
main = do
  n <- readLn :: IO Int
  cs <- replicateM n $ B.words <$> B.getLine :: IO [[B.ByteString]]
  solveBs cs EmptyTree

solveBs :: [[B.ByteString]] -> Tree Int -> IO()
solveBs [] _ = return ()
solveBs (c:cs) t
  | B.unpack command == "insert" = solveBs cs $! insertTree v t
  | B.unpack command == "print" = do
      printTree t
      solveBs cs t
    where
      command = head c
      v = fst . fromJust . B.readInt $ c !! 1 :: Int
solveBs _ _ = error "not come here"

data Tree a = EmptyTree | Node !a !(Tree a) !(Tree a) deriving (Show)

insertTree :: (Ord a) => a -> Tree a -> Tree a
insertTree c EmptyTree = Node c EmptyTree EmptyTree
insertTree c (Node v !left !right)
  | c >= v = let !inserted = insertTree c right in Node v left inserted
  | c < v = let !inserted = insertTree c left in Node v inserted right
  | otherwise = error "not come here"

inorder :: Tree a -> [a]
inorder EmptyTree = []
inorder (Node v left right) = inorder left ++ [v] ++ inorder right

preorder :: Tree a -> [a]
preorder EmptyTree = []
preorder (Node v left right) = v:preorder left ++ preorder right

printTree :: Tree Int -> IO ()
printTree t = do
  putStr " "
  putStrLn . unwords . map show $ inorder t
  putStr " "
  putStrLn . unwords . map show $ preorder t
