-- cf. https://vaibhavsagar.com/blog/2017/05/29/imperative-haskell/
import Control.Monad ( when, forM_, replicateM )
import Data.Maybe (fromJust)
import Data.IORef
import qualified Data.ByteString.Char8 as B
import qualified Data.List as L
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM

main :: IO ()
main = do
  n <- fmap (fst . fromJust . B.readInt) B.getLine :: IO Int
  cs <- fmap (map ((\[x,y] -> (B.head x, (fst . fromJust . B.readInt) y)) . B.words)) (replicateM n B.getLine)
  cmv <- V.thaw $ V.fromList cs
  qsort cmv 0 (n-1)
  scv <- V.freeze cmv
  if isStable scv (L.sortBy (\(_,x) (_,y) -> compare x y) cs)
  then putStrLn "Stable"
  else putStrLn "Not stable"
  mapM_ (\(c,i) -> putStrLn (c:' ':show i)) $ V.toList scv

qsort amv p r =
  when (p < r) $ do
    (amv, q) <- partition amv p r
    qsort amv p (q-1)
    qsort amv (q+1) r

partition amv p r = do
  (s,x) <- VM.read amv r
  i <- newIORef (p-1)
  forM_ [p..r-1] $ \j -> do
    (s,y) <- VM.read amv j
    when (y<=x) $ do
      modifyIORef' i (+1)
      --i0 <- readIORef i
      --writeIORef i (i0+1)
      VM.swap amv i j
  i0 <- readIORef i
  VM.swap amv (i0+1) r
  return (amv, i0+1)

isStable :: V.Vector (Char, Int) -> [(Char, Int)] -> Bool
isStable scv scs = and $ zipWith (curry (\((c1,i1),(c2,i2)) -> c1==c2 && i1==i2)) (V.toList scv) scs

test = do
  print $ B.pack "D 3\nH 2\nD 1\nS 3\nD 2\nC 1"
  let n = 6
  let cs = [('D',3),('H',2),('D',1),('S',3),('D',2),('C',1)]
  let cv = V.fromList cs
  cmv <- V.thaw cv
  qsort cmv 0 (n-1)
  scv <- V.freeze cmv
  let scs = L.sortBy (\(_,x) (_,y) -> compare x y) cs
  print scs
  print $ zip (V.toList cv) scs
  print $ isStable scv scs
