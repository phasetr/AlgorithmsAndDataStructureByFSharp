main = readLn >>=
  putStrLn . (\n -> " " ++ unwords (map show $ f n))
f n = filter (\j -> mod3 j || contain3 j) [1..n]
mod3 j = j `mod` 3 == 0
contain3 j = '3' `elem` show j
