{-
https://atcoder.jp/contests/agc022/submissions/3475093
-}
f :: Foldable t => t Char -> Char
f xs = head $ filter (`notElem` xs) ['a'..'z']

g :: Ord a => [a] -> [a]
g xs = go (init xs) [last xs]
  where
    go [] _  = []
    go as bs = case filter (> la) bs of
        [] -> go (init as) (la:bs)
        cs -> init as ++ [minimum cs]
      where la = last as

main :: IO ()
main = do
  ss <- getLine
  if length ss /= 26 then putStrLn $ ss ++ [f ss]
    else case g ss of
           [] -> print (-1)
           gs -> putStrLn gs
