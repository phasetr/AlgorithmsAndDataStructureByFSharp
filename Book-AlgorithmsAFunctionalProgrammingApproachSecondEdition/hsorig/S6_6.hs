module S6_6 where
import Data.Array ( Ix, elems, accumArray )
import qualified Sort as S

-- P.129, 6.6 Representation-based sorting
-- | P.130, First version
split :: (Ix a) => Int -> (a,a) -> [S.Key a] -> S.Buckets a
split k bnds l  = accumArray f [] bnds [(x!!k , x) | x <- l]
  where f l key = l ++ [key]

-- | P.131
concatA :: (Ix a)=> S.Buckets a -> [S.Key a]
concatA bckts = concat (elems bckts)

rsort :: Ix a => Int -> (a,a) -> [S.Key a] -> [S.Key a]
rsort 0 bnds l = l
rsort p bnds l = rsort (p-1) bnds (concatA (split (p-1) bnds l))

-- | P.132, Improved version
split' :: (Ix a) => Int -> (a,a) -> [S.Key a] -> S.Buckets a
split' k bnds l = accumArray f [] bnds [(x!!k,x) | x <- l]
  where f l key = key : l
-- | P.132, Improved version
concatA' :: Ix a => S.Buckets a -> [S.Key a]
concatA' bckts = concatMap reverse (elems bckts)

main :: IO ()
main = print $ rsort 3 (0,9) l1 == [[1,1,1],[2,1,3],[2,3,1],[2,3,2],[3,9,8],[4,2,8],[5,2,1],[7,9,7],[8,2,1]]
  && rsort 4 (' ','z') l2 == ["fred","joe ","paul","sami"]
  && rsort 3 (0,9) l1 == S.rsort 3(0,9) l1
  && rsort 4 (' ','z') l2 == S.rsort 4 (' ','z') l2
  where
    l1 = [[2,3,2],[2,3,1],[4,2,8],[1,1,1],[2,1,3],
           [8,2,1],[7,9,7],[3,9,8],[5,2,1]]
    l2 = ["fred","sami","paul","joe "]
