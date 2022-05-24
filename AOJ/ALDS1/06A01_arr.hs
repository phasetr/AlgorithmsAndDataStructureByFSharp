-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_6_A
import Control.Monad ( forM_ )
import Data.Maybe ( fromJust )
import qualified Data.Array.MArray as AM
import qualified Data.Array.ST as AST
import qualified Data.Array.Unboxed as UA
import qualified Data.ByteString.Char8 as B

main :: IO ()
main = getLine >> B.getLine >>=
  putStrLn . unwords . map show
  . solve . map (fst . fromJust . B.readInt) . B.words

solve :: [Int] -> [Int]
solve = csort (0,10000)

csort :: (Int, Int) -> [Int] -> [Int]
csort (s,e) as = concatMap (\i -> replicate (ca UA.! i) i) [s..e]
  where ca = generateCA (s,e) as

generateCA :: (Int,Int) -> [Int] -> UA.UArray Int Int
generateCA (s,e) as = AST.runSTUArray $ do
  arr <- AM.newArray (s,e) 0
  forM_ as $ \a -> do
    val <- AM.readArray arr a
    AM.writeArray arr a (val + 1)
  return arr

test :: IO ()
test = do
  let as = [2,5,1,3,2,3,0]
  print $ solve as == [0,1,2,2,3,3,5]
  print $ generateCA (0,5) as == UA.array (0,5) [(0,1),(1,1),(2,2),(3,2),(4,0),(5,1)]
  print $ csort (0,10000) as == [0,1,2,2,3,3,5]
