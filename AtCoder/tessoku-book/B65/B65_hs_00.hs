import Control.Monad ( forM_, forM, replicateM )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import Data.List ( sortOn )
import Data.Ord ( Down(Down) )
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import qualified Data.IntSet as IS
import qualified Data.Sequence as Sq

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  [n, t] <- getIntList
  ab <- replicateM (n-1) $ do
    [a, b] <- getIntList
    return (a-1, b-1)
  let edge = toEdge n ab
  let dist = toDist n t edge
  let dsorted = toDsorted dist
  let rank = toRank n edge dsorted
  putStrLn . unwords . map show $ VU.toList rank

toEdge n ab =
  V.create $ do
    vec <- VM.replicate n (IS.empty)
    forM_ ab $ \(x, y) -> do
      VM.modify vec (IS.insert x) y
      VM.modify vec (IS.insert y) x
    return vec
toDist n t edge =
  VU.create $ do
    vec <- VUM.replicate n (-1 :: Int)
    VUM.write vec (t-1) 0
    let go children Sq.Empty = return ()
        go children (q Sq.:<| qs) = do
            let newParents = IS.intersection children $ edge V.! q
                newParents' = IS.toList newParents
                children' = IS.difference children newParents
            k <- VUM.read vec q
            forM_ newParents' $ \j -> VUM.write vec j (k+1)
            go children' $ (Sq.><) qs (Sq.fromList newParents')
    go (IS.fromList (filter (/= (t-1)) [0..n-1])) (Sq.singleton (t-1))
    return vec
toDsorted dist = map snd . sortOn Down $ zip (VU.toList dist) [0..]
toRank n edge dsorted =
  VU.create $ do
    vec <- VUM.replicate n (-1 :: Int)
    forM_ dsorted $ \i -> do
      let chokuzoku = IS.toList $ edge V.! i
      ranks <- forM chokuzoku $ \j -> VUM.read vec j
      VUM.write vec i $ maximum ranks + 1
    return vec

test1 = do
  let n = 7
  let t = 1
  let ab = map (\(a,b) -> (a-1,b-1)) [(1,2),(1,3),(3,4),(2,5),(4,6),(4,7)]
  let edge = toEdge n ab
  let dist = toDist n t edge
  let dsorted = toDsorted dist
  let rank = toRank n edge dsorted
  print $ ab == [(0,1),(0,2),(2,3),(1,4),(3,5),(3,6)]
  print $ edge
  -- [fromList [1,2],fromList [0,4],fromList [0,3],fromList [2,5,6],fromList [1],fromList [3],fromList [3]]
  print $ dist == VU.fromList [0,1,1,2,2,3,3]
  print $ zip (VU.toList dist) [0..]
  print $ sortOn Down $ zip (VU.toList dist) [0..]
  print $ dsorted == [6,5,4,3,2,1,0]
  print $ rank == VU.fromList [3,1,2,1,0,0,0]

test2 = do
  let n = 15
  let t = 1
  let ab = map (\(a,b) -> (a-1,b-1)) [(1,2),(2,3),(1,4),(1,5),(1,6),(6,7),(2,8),(6,9),(9,10),(10,11),(6,12),(12,13),(13,14),(12,15)]
  let edge = toEdge n ab
  let dist = toDist n t edge
  let dsorted = toDsorted dist
  let rank = toRank n edge dsorted
  print $ ab
  print $ edge
  -- [fromList [1,2],fromList [0,4],fromList [0,3],fromList [2,5,6],fromList [1],fromList [3],fromList [3]]
  print $ dist == VU.fromList [0,1,2,1,1,1,2,2,2,3,4,2,3,4,3]
  print $ zip (VU.toList dist) [0..]
  print $ sortOn Down $ zip (VU.toList dist) [0..]
  print $ dsorted == [13,10,14,12,9,11,8,7,6,2,5,4,3,1,0]
  print $ rank == VU.fromList [4,1,0,0,0,3,0,0,2,1,0,2,1,0,0]

