-- https://atcoder.jp/contests/abc054/submissions/3089837
main :: IO ()
main = do
  [n,m] <- map read.words<$>getLine
  buf <- lines<$>getContents
  let a = take n buf
  let b = drop n buf
  putStrLn$if null [1|i<-[0..n-m],j<-[0..n-m],f m i j a b] then"No"else"Yes"
f :: Eq a => Int -> Int -> Int -> [[a]] -> [[a]] -> Bool
f m i j a b=(length[1|k<-[0..m-1],l<-[0..m-1],(a!!(i+k)!!(j+l))==(b!!k!!l)])==m^2

