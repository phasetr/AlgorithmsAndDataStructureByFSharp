-- https://atcoder.jp/contests/keyence2020/submissions/15311314
import Data.List ( sortOn )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as B
main :: IO ()
main = print.solve.map(map(fst.fromJust.B.readInt).B.words).B.lines =<< B.getContents
solve :: [[Int]] -> Int
solve ([n]:xls) = fst . foldr f (0,maxBound) . sortOn (uncurry (-)) $ map (\[x,l]->(x,l)) xls
solve _ = error "not come here"
f :: (Int,Int) -> (Int,Int) -> (Int,Int)
f (x,l) (i,p) = if x+l > p then (i,p) else (i+1,x-l)

test = do
  let xls = [(2,4),(4,3),(9,3),(100,5)]
  print $ sortOn (uncurry (-)) xls
  print $ foldr f (0,maxBound) . sortOn (uncurry (-)) $ xls
