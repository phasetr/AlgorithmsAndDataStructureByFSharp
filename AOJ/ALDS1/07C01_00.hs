-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_C/review/2905042/lvs7k/Haskell
import Control.Monad ( when )
import Control.Monad.ST ( runST )
import Data.Char (isSpace)
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import Data.List ( unfoldr )

main :: IO ()
main = do
  n <- readLn
  xtv <- V.replicateM n (fmap ((\[a,b,c] -> (a,(b,c))) . unfoldr (B.readInt . B.dropWhile isSpace)) B.getLine)
  let orders = solve n xtv
  putStrLn "Preorder"
  putStrLn . (' ':) . unwords . fmap show $ head orders
  putStrLn "Inorder"
  putStrLn . (' ':) . unwords . fmap show $ orders !! 1
  putStrLn "Postorder"
  putStrLn . (' ':) . unwords . fmap show $ orders !! 2

solve :: Int -> V.Vector (Int, (Int, Int)) -> [[Int]]
solve n xtv = [preOrder root tv, inOrder root tv, postOrder root tv]
  where (root, tv) = treeInfo n xtv

preOrder :: Int -> V.Vector (Int, Int) -> [Int]
preOrder (-1) _ = []
preOrder n  tv = [n] ++ preOrder l tv ++ preOrder r tv
  where (l,r) = tv V.! n

inOrder :: Int -> V.Vector (Int, Int) -> [Int]
inOrder (-1) _ = []
inOrder n  tv = inOrder l tv ++ [n] ++ inOrder r tv
  where (l,r) = tv V.! n

postOrder :: Int -> V.Vector (Int, Int) -> [Int]
postOrder (-1) _ = []
postOrder n  tv = postOrder l tv ++ postOrder r tv ++ [n]
  where (l,r) = tv V.! n

treeInfo :: Int -> V.Vector (Int, (Int, Int)) -> (Int, V.Vector (Int, Int))
treeInfo n xtv = runST $ do
  pmv <- V.thaw (V.replicate n (-1))
  tmv <- V.thaw (V.replicate n (-1,-1))
  V.forM_ xtv $ \(i,(l,r)) -> do
    VM.write tmv i (l,r)
    when (l /= -1) $ VM.write pmv l i
    when (r /= -1) $ VM.write pmv r i
  pv <- V.freeze pmv
  tv <- V.freeze tmv
  return (fromJust $ V.elemIndex (-1) pv, tv)

test :: IO ()
test = do
  let n = 9
  let xtv = V.fromList [
        (0,(1,4)),
        (1,(2,3)),
        (2,(-1,-1)),
        (3,(-1,-1)),
        (4,(5,8)),
        (5,(6,7)),
        (6,(-1,-1)),
        (7,(-1,-1)),
        (8,(-1,-1))]
  let orders = solve n xtv
  print $ head orders == [0,1,2,3,4,5,6,7,8]
  print $ orders !! 1 == [2,1,3,0,6,5,7,4,8]
  print $ orders !! 2 == [2,3,1,6,7,5,8,4,0]

  let n = 5
  let xtv = V.fromList [(3,(4,0)),(4,(-1,-1)),(1,(-1,-1)),(2,(-1,-1)),(0,(1,2))]
  print $ solve n xtv == [[3,4,0,1,2],[4,3,1,0,2],[4,1,2,0,3]]
