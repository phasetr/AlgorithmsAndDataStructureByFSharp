-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_D/review/2376938/napo/Haskell
main :: IO ()
main = getContents
  >>= putStr . unlines
  . (\xs -> [fst x | x<-xs, fst x /= ""])
  . (\(x:_:xs) -> scanl (flip ($)) ("", x) $ map (f.words) xs) . lines
  where
    f ("print":a:b:_)     (_,s) = (between a b s, s)
    f ("reverse":a:b:_)   (_,s) = ("", g a b s $reverse (between a b s))
    f ("replace":a:b:p:_) (_,s) = ("", g a b s p)
    f _ _ = undefined
    g a b s t = take (read a) s ++ t ++ drop (read b+1) s
    between a b = take (read b-read a+1) . drop (read a)
