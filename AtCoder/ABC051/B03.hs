-- https://atcoder.jp/contests/abc051/submissions/21602008
main :: IO ()
main = do
  [k, s] <- map read . words <$> getLine
  print $ solve k s

solve :: Int -> Int -> Int
solve k s = length [1 | x <- [0..k], y <- [0..k],
                    let z = s - x - y, z <= k, z >= 0]
