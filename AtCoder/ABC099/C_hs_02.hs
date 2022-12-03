-- https://atcoder.jp/contests/abc099/submissions/2981662
radixConvert :: Integral t => t -> t -> [t]
radixConvert b n
  | n < b = [n]
  | otherwise = mod n b : radixConvert b (div n b)

main :: IO ()
main = do
  n <- readLn
  print $ minimum [sum (radixConvert 6 i) + sum (radixConvert 9 (n-i))| i<-[0..n]]
