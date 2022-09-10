-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_D/review/3365986/showzaemon/Haskell
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as B
import qualified Data.Map as M
import Data.Maybe ( fromJust )
import qualified Data.Sequence as S

main :: IO()
main = do
  n <- fmap (fst . fromJust . B.readInt) B.getLine
  l <- replicateM n readCommand
  mapM_ putStrLn $ solve l

readCommand :: IO Command
readCommand = do
  l <- fmap B.words B.getLine
  let cmd = case l of
              [cmd, n, m]
                | cmd == sInsert -> Insert (toInt n) (toInt m)
              [cmd, n]
                | cmd == sDelete -> Delete (toInt n)
                | cmd == sFind   -> Find   (toInt n)
              [sPrint] -> Print
              _ -> error "not come here"
  return cmd
  where
    toInt = fst . fromJust . B.readInt
    sDelete = B.pack "delete"
    sFind   = B.pack "find"
    sInsert = B.pack "insert"
    sPrint  = B.pack "print"

data Tree a = Nil | Node a a (Tree a) (Tree a) deriving (Show)
data Command = Print | Delete Int | Find Int | Insert Int Int deriving (Show)
data Order = Preorder | Inorder deriving (Eq, Show)

solve :: [Command] -> [String]
solve = iter Nil where
  iter :: Tree Int-> [Command] -> [String]
  iter _ [] = []
  iter rt (c:cs) = case c of
    Print    -> inorder rt:preorder rt:iter rt cs
    Delete x -> iter (delete x rt) cs
    Find x   -> find x rt:iter rt cs
    Insert x p -> iter (insert x p rt) cs

  delete x = iter where
    iter Nil = Nil
    iter t@(Node y q l r)
      | x < y  = Node y q (iter l) r
      | x > y  = Node y q l (iter r)
      | x == y =
        case (l, r) of
          (Nil, Nil) -> Nil
          (Nil, r)   -> iter $ leftRotate t
          (l, Nil)   -> iter $ rightRotate t
          (Node _ lq _ _, Node _ rq _ _) -> iter $ if lq > rq then rightRotate t else leftRotate t
    iter _ = error "not come here"

  leftRotate (Node x p a (Node y q b c)) = Node y q (Node x p a b) c
  leftRotate _ = error "not come here"

  rightRotate (Node y q (Node x p a b) c) = Node x p a (Node y q b c)
  rightRotate _ = error "not come here"

  find x = iter where
    iter (Node y q l r)
        | x == y = "yes"
        | x <  y = iter l
        | x >  y = iter r
    iter Nil = "no"
    iter _ = error "not come here"

  insert x p = iter where
    iter (Node y q l r)
      | x < y =
        case iter l of
          t@(Node _ q' _ _)
            | q < q'    -> rightRotate (Node y q t r)
            | otherwise -> Node y q t r
          _ -> error "not come here"
      | otherwise =
        case iter r of
          t@(Node _ q' _ _)
            | q < q'    -> leftRotate (Node y q l t)
            | otherwise -> Node y q l t
          _ -> error "not come here"
    iter Nil = Node x p Nil Nil

  preorder = toString . toList Preorder
  inorder  = toString . toList Inorder

toList :: Order -> Tree a -> [a]
toList ord = iter where
  iter Nil = []
  iter (Node id p l r)
    | ord == Preorder = id:iter l ++ iter r
    | ord == Inorder  = iter l ++ id:iter r
  iter _ = error "not come here"

toString :: [Int] -> String
toString [] = []
toString (x:xs) = ' ':show x++ toString xs
