main :: IO ()
main = do
  [n,q] <- fmap (map read . words) getLine
  pqs <- fmap (map ((\[n, t] -> (n, read t)) . words) . lines) getContents
  mapM_ putStrLn $ solve q 0 [] pqs []
solve :: Int -> Int -> [String] -> [(String,Int)] -> [(String,Int)] -> [String]
solve q t acc [] [] = reverse acc
solve q t acc [] tq = solve q t acc (reverse tq) []
solve q t acc (pq:pqs) tq =
  if t0 > q then solve q (t+q) acc pqs ((n0,t0-q):tq)
  else solve q (t+t0) ((n0 ++ " " ++ show (t+t0)) : acc) pqs tq
  where (n0,t0) = pq

test = print $ solve 100 0 [] [("p1",150),("p2",80),("p3",200),("p4",350),("p5",20)] [] == ["p2 180","p5 400","p1 450","p3 550","p4 800"]
