-- https://atcoder.jp/contests/dp/submissions/26355061
main :: IO ()
main = do
  li <- getLine
  let n = read li
  li <- getLine
  let ps = map read $ words li
  let ans = compute n ps
  print ans

compute :: Int -> [Double] -> Double
compute n ps = sum $ take (succ n `div` 2) $ foldl step [1] ps

step :: Num a => [a] -> a -> [a]
step qs p = zipWith (+) (map (p *) qs ++ [0]) (0 : map ((1-p) *) qs)
