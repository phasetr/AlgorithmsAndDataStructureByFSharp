-- https://atcoder.jp/contests/abc076/submissions/9944686
main :: IO ()
main = do
  s <- getLine
  t <- getLine
  let sl = length s
  let tl = length t
  let ok = [map(\c->if c=='?' then 'a' else c)$take i s++t++drop(i+tl)s|i<-[0..sl-tl],f$zip(take tl$drop i s)t]
  putStrLn $ if null ok then "UNRESTORABLE" else minimum ok

f :: [(Char, Char)] -> Bool
f [] = True
f ((a,b):s) = not (a/='?'&&a/=b) && f s
