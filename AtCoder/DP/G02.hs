-- https://atcoder.jp/contests/dp/submissions/26351324
import qualified Data.ByteString.Char8 as BS
import Data.Char ( isSpace )
import Data.List ( unfoldr )
import Data.Array ( array, elems, listArray, (!), accumArray )

main :: IO ()
main = do
  li <- BS.getLine
  let [n,m] = unfoldr (BS.readInt . BS.dropWhile isSpace) li
  co <- BS.getContents
  let xys = map (unfoldr (BS.readInt . BS.dropWhile isSpace)) $ BS.lines co
  let ans = solve n m xys
  print ans

solve :: Int -> Int -> [[Int]] -> Int
solve n m xys = maximum $ elems d where
  g = accumArray (flip (:)) [] (1,n) [(x,y) | (x:y:_) <- xys]
  d = listArray (1,n) $ map df [1..n]
  df i = maximum (0 : map (succ . (d !)) (g ! i))

test :: IO ()
test = do
  print $ g == array (1,4) [(1,[3,2]),(2,[4]),(3,[4,2]),(4,[])]
  where
    g = accumArray (flip (:)) [] (1,n) xys
    n = 4
    m = 5
    xys = [(1,2),(1,3),(3,2),(2,4),(3,4)]
