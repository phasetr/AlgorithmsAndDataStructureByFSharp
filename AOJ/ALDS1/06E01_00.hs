import           Control.Monad ( forM_ )
import           Control.Monad.ST ( runST )
import qualified Data.ByteString.Char8 as B
import           Data.Maybe (fromJust)
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM

main :: IO ()
main = do
  n <- readLn
  let f (i:_:cs) = (i, cs)
      f _ = error "not come here"
  xss <- fmap (fmap (f . fmap (fst . fromJust . B.readInt) . B.words) . B.lines) B.getContents
  forM_ (solve n xss) $ \(n,p,d,t,l) -> do
    putStr $ "node " ++ show n ++ ": "
    putStr $ "parent = " ++ show p ++ ", "
    putStr $ "depth = " ++ show d ++ ", "
    putStr $ t ++ ", "
    printList l
    putStrLn ""

solve :: Int -> [(Int, [Int])] -> [(Int, Int, Int, String, [Int])]
solve n xss = map (\i -> (i, pi i, depth i pv, ntype (pi i) (ci i), ci i)) [0..n-1]
  where
    pv = parents n xss
    cv = childrens n xss
    pi i = pv V.! i
    ci i = cv V.! i
    ntype pi ci =
      case () of
        _ | pi == -1  -> "root"
          | null ci   -> "leaf"
          | otherwise -> "internal node"

printList :: [Int] -> IO ()
printList [] = putStr "[]"
printList (x:xs) = putStr ("[" ++ show x) >> go xs >> putStr "]" where
  go []     = return ()
  go (y:ys) = putStr (", " ++ show y) >> go ys

depth :: Int -> V.Vector Int -> Int
depth n parents = go 0 n where
  go d m
    | p == -1 = d
    | otherwise = go (d+1) p
    where p = parents V.! m

parents :: Int -> [(Int, [Int])] -> V.Vector Int
parents n xss = runST $ do
  pmv <- V.thaw (V.replicate n (-1))
  forM_ xss $ \(i, cs) -> do
    forM_ cs $ \c -> do
      VM.write pmv c i
  V.freeze pmv

childrens :: Int -> [(Int,[Int])] -> V.Vector [Int]
childrens n xss = runST $ do
  cmv <- V.thaw (V.replicate n [])
  forM_ xss $ uncurry (VM.write cmv)
  V.freeze cmv

test = do
  print $ solve 13 [(0,[1,4,10]),(1,[2,3]),(2,[]),(3,[]),(4,[5,6,7]),(5,[]),(6,[]),(7,[8,9]),(8,[]),(9,[]),(10,[11,12]),(11,[]),(12,[])]
    == [(0,-1,0,"root",[1,4,10]),(1,0,1,"internal node",[2,3]),(2,1,2,"leaf",[]),(3,1,2,"leaf",[]),(4,0,1,"internal node",[5,6,7]),(5,4,2,"leaf",[]),(6,4,2,"leaf",[]),(7,4,2,"internal node",[8,9]),(8,7,3,"leaf",[]),(9,7,3,"leaf",[]),(10,0,1,"internal node",[11,12]),(11,10,2,"leaf",[]),(12,10,2,"leaf",[])]
  print $ solve 4 [(1,[3,2,0]),(0,[]),(3,[]),(2,[])] == [(0,1,1,"leaf",[]),(1,-1,0,"root",[3,2,0]),(2,1,1,"leaf",[]),(3,1,1,"leaf",[])]
