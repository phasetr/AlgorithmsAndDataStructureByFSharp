main = readLn >>= putStrLn . (' ':) . unwords . f
f n = [show x | x <- [1..n], x `mod` 3 == 0 || '3' `elem` show x]
