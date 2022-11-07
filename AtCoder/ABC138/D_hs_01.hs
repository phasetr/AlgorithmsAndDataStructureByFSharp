-- https://atcoder.jp/contests/abc138/submissions/15904256
import Data.Char ( isSpace )
import Data.List ( unfoldr )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector as V
import qualified Data.IntMap as IM
main :: IO ()
main = putStrLn . solve . map (unfoldr $ B.readInt . B.dropWhile isSpace) . B.lines =<< B.getContents
solve :: [[Int]] -> String
solve ([n,q]:abpx) = unwords . map show . IM.elems $ f 0 0 0 IM.empty where
  (ab,px) = splitAt (n-1) abpx
  f x p v m = foldr (f y v) (IM.insert v y m) . filter(/=p) $ g V.! v where y=x+xs V.! v
  g = V.accum (flip (:)) (V.replicate n []) $ concatMap (\[a,b] -> [(a-1,b-1),(b-1,a-1)]) ab
  xs = V.accum (+) (V.replicate n 0) $ map (\[p,x] -> (p-1,x)) px
solve _ = error "not come here"
