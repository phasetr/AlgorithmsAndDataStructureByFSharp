-- https://atcoder.jp/contests/abc141/submissions/12918186
import qualified Data.IntMap as M

main :: IO ()
main = do
  li <- getLine
  let [n,m] = map read $ words li
  li <- getLine
  let as = map read $ words li
  let ans = compute n m as
  print ans

compute :: Int -> Int -> [Int] -> Int
compute n m as = sum $ map (uncurry (*)) $ loop m am where
  am = M.fromListWith (+) [ (a,1) | a <- as ]
  loop m am
    | m > c = loop (m-c) $ M.insertWith (+) (div x 2) c am1
    | otherwise  = (div x 2, m) : (x, c - m) : M.assocs am1
    where ((x,c),am1) = M.deleteFindMax am
