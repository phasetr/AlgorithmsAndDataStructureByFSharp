-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_D/review/1690130/satoshi3/Haskell
mkList :: Int -> [Int] -> [[Int]]
mkList n x
  | null x = [[]]
  | otherwise = take n x : mkList n (drop n x)

main :: IO ()
main = getContents >>=
  mapM_ print
  . reverse . tail . init
  . map sum . (\(_:y:xs) -> mkList y (zipWith (*) (cycle $ take y $ reverse xs) (reverse xs)))
  . map read . words
