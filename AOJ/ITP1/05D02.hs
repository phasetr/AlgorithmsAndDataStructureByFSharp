main = readLn >>=
  putStrLn . concat
  . (\n -> [" " ++ show x | x <- [1..n],
            elem '3' (show x) || (mod x 3 == 0)])
