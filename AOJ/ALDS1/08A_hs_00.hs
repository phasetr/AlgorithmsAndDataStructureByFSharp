-- https://onlinejudge.u-aizu.ac.jp/problems/ALDS1_8_A
{-# LANGUAGE OverloadedStrings #-}
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as B
data Tree a = Empty | Node a (Tree a) (Tree a) deriving (Show)
main :: IO ()
main = do
  n    <- fmap (fst . fromJust . B.readInt) B.getLine
  cmds <- fmap (fmap B.words . B.lines) B.getContents
  let t = Empty :: Tree Int
  foldT doCmd t cmds

foldT :: (Monad m) => (a -> b -> m a) -> a -> [b] -> m ()
foldT _ _ [] = return ()
foldT f t (x:xs) = do
  t' <- f t x
  t' `seq` foldT f t' xs

insert :: (Ord a) => Tree a -> a -> Tree a
insert Empty x = Node x Empty Empty
insert (Node y l r) x
  | x <= y    = Node y (insert l x) r
  | otherwise = Node y l (insert r x)

toPreOrder :: (Ord a) => Tree a -> [a]
toPreOrder Empty = []
toPreOrder (Node x l r) = [x] ++ toPreOrder l ++ toPreOrder r

toInOrder :: (Ord a) => Tree a -> [a]
toInOrder Empty = []
toInOrder (Node x l r) = toInOrder l ++ [x] ++ toInOrder r

doCmd :: Tree Int -> [B.ByteString] -> IO (Tree Int)
doCmd t ("insert":arg0:_) = do
  let x = (fst . fromJust . B.readInt) arg0
  return $ insert t x
doCmd t ("print":_) = do
  putStrLn . concatMap ((' ':) . show) $ toInOrder  t
  putStrLn . concatMap ((' ':) . show) $ toPreOrder t
  return t
doCmd _ _ = error "invalid command"
