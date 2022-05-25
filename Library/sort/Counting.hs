{-
../../AOJ/ALDS1/06A01_arr.hs
Vectorだとかなりメモリを食う.
参考: ../../AOJ/ALDS1/06A01_vec_MLE.hs
-}
import Control.Monad ( forM_ )
import qualified Data.Array.MArray as AM
import qualified Data.Array.ST as AST
import qualified Data.Array.Unboxed as UA
import qualified Data.IntMap as IM
import qualified Data.List as L

csortArr :: (Int, Int) -> [Int] -> [Int]
csortArr (s,e) as = concatMap (\i -> replicate (ca UA.! i) i) [s..e]
  where ca = generateCA (s,e) as

generateCA :: (Int,Int) -> [Int] -> UA.UArray Int Int
generateCA (s,e) as = AST.runSTUArray $ do
  arr <- AM.newArray (s,e) 0
  forM_ as $ \a -> do
    val <- AM.readArray arr a
    AM.writeArray arr a (val + 1)
  return arr

-- AOJでWAが出たので何かおかしい可能性がある csortIM [2,5,1,3,2,3,0] == [0,1,2,2,3,3,5]
csortIM :: [IM.Key] -> [IM.Key]
csortIM as = concatMap (\(i,v) -> replicate v i) (L.sortOn fst pairs)
  where pairs = IM.toList $ generateIM as
generateIM :: [IM.Key] -> IM.IntMap Int
generateIM = foldr (flip (IM.insertWith (+)) 1) IM.empty

main :: IO ()
main = do
  let as = [2,5,1,3,2,3,0]
  print $ csortArr (0,10000) as == [0,1,2,2,3,3,5]
  print $ generateCA (0,5) as == UA.array (0,5) [(0,1),(1,1),(2,2),(3,2),(4,0),(5,1)]
  print $ generateIM as == IM.fromList [(0,1),(1,1),(2,2),(3,2),(5,1)]
