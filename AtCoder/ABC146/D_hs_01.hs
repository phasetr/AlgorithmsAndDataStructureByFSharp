-- https://atcoder.jp/contests/abc146/submissions/18522602
import Data.Char ( isSpace )
import Data.List ( unfoldr )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector as V
import qualified Data.IntMap as IM
main :: IO ()
main = do
  n <- readLn
  mapM_ print . solve n . unfoldr (B.readInt . B.dropWhile isSpace) =<< B.getContents

solve :: (Ord a, Num a, Enum a) => Int -> [Int] -> [a]
solve n ab = ((:) =<< maximum) . IM.elems $ h 0 0 0 IM.empty where
  g = V.accum (flip(:)) (V.replicate n []) . f 1 $ ab
  h i p c m = foldr (\(c,(j,k)) m -> h k i c $ IM.insert j c m) m . zip (filter (/=c) [1..]) . filter ((/=p) . snd) $ g V.! i
  f i (a:b:ab) = (a-1,(i,b-1)) : (b-1,(i,a-1)) : f (i+1) ab
  f _ _ = []

test = do
  let n = 3
  let ab = [1,2,2,3]
  let as = f 1 ab
  print as
  let g = V.accum (flip(:)) (V.replicate n []) . f 1 $ ab
  print g
  let h i p c m = foldr (\(c,(j,k)) m -> h k i c $ IM.insert j c m) m.zip (filter (/=c) [1..]) . filter ((/=p) . snd) $ g V.! i
  print $ h 0 0 0 IM.empty
  where
    f i (a:b:ab) = (a-1,(i,b-1)) : (b-1,(i,a-1)) : f (i+1) ab
    f _ _ = []
