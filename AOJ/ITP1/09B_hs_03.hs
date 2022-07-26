-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_B/review/2212438/aimy/Haskell
main :: IO ()
main = interact $ unlines . map solve . read' . lines where
  read' ("-":_) = []
  read' (str:n:xs) = (str, (map read . take (read n)) xs) : read' (drop (read n) xs)
  read' _ = undefined

solve :: Foldable t => ([a], t Int) -> [a]
solve (str,hs) = foldr shuffle str hs where
  shuffle n str = let (bot,top) = splitAt n str in top ++ bot
