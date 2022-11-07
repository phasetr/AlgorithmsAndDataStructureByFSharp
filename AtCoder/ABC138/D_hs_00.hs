-- https://atcoder.jp/contests/abc138/submissions/15904256
import Data.Char ( isSpace )
import Data.List ( unfoldr )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector as V
import qualified Data.IntMap as IM
main :: IO ()
main = do
  [n,q] <- unfoldr (B.readInt . B.dropWhile isSpace) <$> B.getLine
  putStrLn . solve n q . map (unfoldr $ B.readInt . B.dropWhile isSpace) . B.lines =<< B.getContents
solve :: Int -> p -> [[Int]] -> String
solve n q abpx = unwords . map show . IM.elems $ f 0 0 0 IM.empty where
  (ab,px) = splitAt (n-1) abpx
  f x p v m = foldr (f y v) (IM.insert v y m) . filter(/=p) $ neighbors V.! v where y=x+counts V.! v
  neighbors = V.accum (flip (:)) (V.replicate n []) $ concatMap (\[a,b] -> [(a-1,b-1),(b-1,a-1)]) ab
  counts = V.accum (+) (V.replicate n 0) $ map (\[p,x] -> (p-1,x)) px

test = do
  --let (n,q,abpx) = (4,3,[[1,2],[2,3],[2,4],[2,10],[1,100],[3,1]])
  --let (ab,px) = splitAt (n-1) abpx
  --print $ concatMap (\[a,b] -> [(a-1,b-1),(b-1,a-1)]) ab
  --print $ V.accum (flip (:)) (V.replicate n []) $ concatMap (\[a,b] -> [(a-1,b-1),(b-1,a-1)]) ab
  --print $ V.accum (+) (V.replicate n 0) $ map (\[p,x] -> (p-1,x)) px
  let (n,q,abpx) = (3,3,[[1,3],[2,3],[2,10],[3,100],[1,1]])
  let (ab,px) = splitAt (n-1) abpx
  --print $ concatMap (\[a,b] -> [(a-1,b-1),(b-1,a-1)]) ab
  -- neighbors
  print $ V.accum (flip (:)) (V.replicate n []) $ concatMap (\[a,b] -> [(a-1,b-1),(b-1,a-1)]) ab
  -- counts
  print $ V.accum (+) (V.replicate n 0) $ map (\[p,x] -> (p-1,x)) px
  print "a"
