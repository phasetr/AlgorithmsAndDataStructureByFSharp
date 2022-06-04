import Control.Monad ( when )
import Control.Monad.ST ( runST )
import Data.Char ( isSpace )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
main :: IO ()
main = do
  n <- readLn
  xvv <- V.replicateM n (fmap (V.unfoldr (B.readInt . B.dropWhile isSpace)) B.getLine)
  V.mapM_ putStrLnT $ solve n xvv

putStrLnT :: (Int,Int,Int,Int,Int,Int,String) -> IO ()
putStrLnT xv = putStrLn $
  "node " ++ show i
  ++ ": parent = " ++ show p
  ++ ", sibling = " ++ show s
  ++ ", degree = " ++ show deg
  ++ ", depth = " ++ show d
  ++ ", height = " ++ show h
  ++ ", " ++ nt
  where (i,p,s,deg,d,h,nt) = xv

solve :: Int -> V.Vector (V.Vector Int) -> V.Vector (Int, Int, Int, Int, Int, Int, String)
solve n xvv = V.map f (V.fromList [0..n-1])
  where
    f i = (i, pv V.! i, sv V.! i, degv V.! i, dv V.! i, hv V.! i, nodeType (pv V.! i) (degv V.! i))
    (_,_,sv,pv,degv) = getTree n xvv
    dv = V.map (\n -> depth pv n 0) (V.fromList [0..n-1])
    hv = V.map (height xvv) (V.fromList [0..n-1])

nodeType :: Int -> Int -> String
nodeType pi dgi
  | pi==(-1) = "root"
  | dgi==0   = "leaf"
  | otherwise = "internal node"

getTree :: Int -> V.Vector (V.Vector Int) -> (V.Vector Int, V.Vector Int, V.Vector Int, V.Vector Int, V.Vector Int)
getTree n xvv = runST $ do
  lmv <- V.thaw $ V.replicate n (-1)
  rmv <- V.thaw $ V.replicate n (-1)
  smv <- V.thaw $ V.replicate n (-1)
  pmv <- V.thaw $ V.replicate n (-1)
  degmv <- V.thaw $ V.replicate n 0
  V.forM_ xvv $ \xv -> do
    let (i,l,r) = (xv V.! 0, xv V.! 1, xv V.! 2)
    VM.write lmv i l
    VM.write rmv i r
    when (l /= -1) $ do
      VM.write pmv l i
      --VM.modify degmv (+1) i
      degmvi <- VM.read degmv i
      VM.write degmv i (degmvi+1)
    when (r /= -1) $ do
      VM.write pmv r i
      --VM.modify degmv (+1) i
      degmvi <- VM.read degmv i
      VM.write degmv i (degmvi+1)
    when (l /= -1 && r /= -1) $ do
      VM.write smv l r
      VM.write smv r l
  lv <- V.freeze lmv
  rv <- V.freeze rmv
  sv <- V.freeze smv
  pv <- V.freeze pmv
  degv <- V.freeze degmv
  return (lv,rv,sv,pv,degv)

depth :: V.Vector Int -> Int -> Int -> Int
depth pv n d = if pid == -1 then d else depth pv pid (d+1)
  where pid = pv V.! n
height :: V.Vector (V.Vector Int) -> Int -> Int
height xvv (-1) = -1
height xvv n = max (height xvv y) (height xvv z) + 1
  where
    xv = V.head $ V.filter (\xv -> xv V.! 0 == n) xvv
    y = xv V.! 1
    z = xv V.! 2

test :: IO ()
test = do
  let n = 9
  let xvv = V.fromList $ map V.fromList [
        [0,1,4],
        [1,2,3],
        [2,-1,-1],
        [3,-1,-1],
        [4,5,8],
        [5,6,7],
        [6,-1,-1],
        [7,-1,-1],
        [8,-1,-1]]
  let (_,_,_,pv,_) = getTree n xvv
  let dv = V.map (\n -> depth pv n 0) (V.fromList [0..n-1])
  let hv = V.map (height xvv) (V.fromList [0..n-1])
  print $ dv == V.fromList [0,1,2,2,1,2,3,3,2]
  print $ hv == V.fromList [3,1,0,0,2,1,0,0,0]
  print $ getTree n xvv == (V.fromList [1,2,-1,-1,5,6,-1,-1,-1], -- lv
                            V.fromList [4,3,-1,-1,8,7,-1,-1,-1], -- rv
                            V.fromList [-1,4,3,2,1,8,7,6,5],     -- sv
                            V.fromList [-1,0,1,1,0,4,5,5,4],     -- pv
                            V.fromList [2,2,0,0,2,2,0,0,0])      -- degv
  print $ solve n xvv == V.fromList [
    (0,-1,-1,2,0,3,"root"),
    (1,0,4,2,1,1,"internal node"),
    (2,1,3,0,2,0,"leaf"),
    (3,1,2,0,2,0,"leaf"),
    (4,0,1,2,1,2,"internal node"),
    (5,4,8,2,2,1,"internal node"),
    (6,5,7,0,3,0,"leaf"),
    (7,5,6,0,3,0,"leaf"),
    (8,4,5,0,2,0,"leaf")]

  let n = 5
  let xvv = V.fromList [
        V.fromList [3,4,0],
        V.fromList [4,-1,-1],
        V.fromList [1,-1,-1],
        V.fromList [2,-1,-1],
        V.fromList [0,1,2]]
  mapM_ print (solve n xvv)
  print $ solve n xvv == V.fromList [
    (0,3,4,2,1,1,"internal node"),
    (1,0,2,0,2,0,"leaf"),
    (2,0,1,0,2,0,"leaf"),
    (3,-1,-1,2,0,2,"root"),
    (4,3,0,0,1,0,"leaf")]
