-- https://atcoder.jp/contests/diverta2019/submissions/5384013
main :: IO ()
main = do
  p <- readLn
  let s = floor . sqrt . fromIntegral $ p
  if p == 1
  then print 0
  else print $ sum [r | c<-[1..s],mod p c==0, let r=div p c-1,div p r== mod p r]
