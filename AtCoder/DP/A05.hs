-- https://atcoder.jp/contests/dp/submissions/28329243
solve :: [Int] -> Int
solve xs = snd $ last xdp where
  xdp = zip xs dp
  dp = 0 : abs (xs!!1 - head xs) :
      [ cost xdpk `min` cost xdpj
      | (xdpk, xdpj, xi) <- zip3 xdp (tail xdp) (drop 2 xs)
      , let cost (xj, dpj) = abs (xi - xj) + dpj
      ]

main :: IO ()
main = getLine >> getLine >>= print . solve . map read . words
