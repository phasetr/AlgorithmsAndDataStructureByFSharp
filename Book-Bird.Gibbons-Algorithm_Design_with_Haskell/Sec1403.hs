module Sec1403 where
import Sec140101 (Tree(..))
-- P.341 14.3 Examples

-- P.344
mct :: Ord a => [a] -> Tree a
mct xs = foldr Fork e (map Leaf ys) where
  e = foldl Fork (Leaf z) (map Leaf zs)
  (ys,z:zs) = span (/= maximum xs) xs

-- P.345
(<++>) :: [a] -> [a] -> [a]
[] <++> ys = ys
(x:xs) <++> ys = ys++x:(xs <++> reverse ys)
-- [3,4] <++> [0,1,2] == [0,1,2,3,2,1,0,4,0,1,2]
-- "abc" <++> "xyz" == "xyzazyxbxyzczyx"
