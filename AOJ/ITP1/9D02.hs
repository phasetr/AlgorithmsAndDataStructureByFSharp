-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_D/review/2212687/aimy/Haskell
main :: IO()
main = interact $ unlines . solve . lines

solve :: [String] -> [[Char]]
solve (str:_:ps) = process (map words ps) str where
  process [] _ = []
  process (["print",a,b]:ps) str = print' (read a) (read b) str : process ps str
  process (["reverse",a,b]:ps) str = process ps (reverse' (read a) (read b) str)
  process (["replace",a,b,p]:ps) str = process ps (replace' (read a) (read b) p str)
  process _ _ = undefined
  print' a b = drop a . take (b+1)
  reverse' a b str = take a str ++ reverse ((drop a . take (b+1)) str) ++ drop (b+1) str
  replace' a b p str = take a str ++ p ++ drop (b+1) str
solve _ = undefined
