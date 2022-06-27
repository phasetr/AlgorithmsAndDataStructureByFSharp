-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_C/review/3396097/showzaemon/Haskell
import Data.List
import qualified Data.Set as Set
import qualified Data.Sequence as Seq
import qualified Data.ByteString.Char8 as B
import Data.Array ( array, (!) )
import Data.Maybe ( fromJust )
import qualified Data.Map as M

data Vertex = Vt Int Int deriving (Eq, Show) -- Vt <ID> <Distance>
instance Ord Vertex where
    compare (Vt ia da) (Vt ib db) =
        case (ia ,da, ib, db) of
         _  | ia == ib  -> EQ
            | ia >  ib  -> GT
            | otherwise -> LT

data Vertex' = Vt' Int Int deriving (Eq, Show) -- Vt' <ID> <Distance>
instance Ord Vertex' where
    compare (Vt' ia da) (Vt' ib db) =
        case (ia ,da, ib, db) of
         _  | da >  db  -> GT
            | da <  db  -> LT
            | ia >  ib  -> GT
            | ia <  ib  -> LT
            | otherwise -> EQ

solve :: Int -> [[Int]] -> [Vertex]
solve n lst = iter Set.empty initialQ where
  iter r q
    | Set.null (fst q) = Set.toAscList r
    | otherwise = iter r' q' where
        r' = Set.insert v r
        q' = iter restQ (adjacencyList!i) where
          iter q [] = q
          iter q ((j, d):rest) =
            case Set.lookupGE (Vt j 0) (fst q) of
              Just (Vt k c')
                | j == k -> iter q'' rest
                | otherwise -> iter q rest  where
                    c'' = min (c+d) c'
                    q'' = (Set.insert (Vt j c'') (fst q),
                            Set.insert (Vt' j c'') (Set.delete (Vt' j c') (snd q)))
              Nothing -> iter q rest

        (v'@(Vt' i c), s)= Set.deleteFindMin (snd q)
        v = Vt i c
        restQ = (Set.delete v (fst q), s)

  initialQ = (Set.fromList $ Vt 0 0 : [Vt x maxBound | x <- [1..n-1]],
              Set.fromList $ Vt' 0 0 : [Vt' x maxBound | x <- [1..n-1]])

  adjacencyList = array (0, n-1) (setupAL [] lst)
  setupAL al [] =  al
  setupAL al ((u:_:vcs):lines) = setupAL (iter [] vcs:al) lines where
    iter av [] = (u, av)
    iter av (v:c:rest) = iter ((v,c):av) rest
    iter _ _ = error "not come here"
  setupAL _ _ = error "not come here"

readIntLn:: IO Int
readIntLn = fmap (fst . fromJust . B.readInt) B.getLine

readIntList:: IO [Int]
readIntList = fmap (map (fst . fromJust . B.readInt) . B.words) B.getLine

print' :: Vertex -> IO ()
print' (Vt x y) = putStrLn $ show x ++ " " ++ show y

main :: IO()
main = do
  n  <- readIntLn
  l <- replicateM n readIntList
  mapM_ print' $ solve n l
