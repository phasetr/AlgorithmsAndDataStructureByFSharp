-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_D/review/2918039/rabbisland/Haskell
import Control.Applicative ((<$>), (<*>))
import Data.List ((\\), intersect)

main :: IO ()
main = solve <$> (getLine >> f) <*> f >>= putStrLn
  where f = map read . words <$> getLine

solve :: [Int] -> [Int] -> String
solve ps is = unwords . map show . postOrder $ mkBTree ps is

data BTree a = Leaf | Node a (BTree a) (BTree a) deriving Show

mkBTree :: [Int] -> [Int] -> BTree Int
mkBTree [] [] = Leaf
mkBTree (p:ps) is = Node p (mkBTree lp li) (mkBTree rp ri) where
  (li,_:ri) = break (==p) is
  lp = ps `intersect` li
  rp = ps \\ lp
mkBTree _ _ = error "not come here"

foldPost :: (a -> b -> b) -> b -> BTree a -> b
foldPost f z Leaf = z
foldPost f z (Node x l r) =
  let y1 = f x z
      y2 = foldPost f y1 r
  in foldPost f y2 l

postOrder :: BTree a -> [a]
postOrder = foldPost (:) []
