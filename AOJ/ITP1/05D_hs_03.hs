main :: IO ()
main = readLn >>= putStrLn . (' ':) . unwords . f
f :: (Integral a, Show a) => a -> [String]
f n = [show x | x <- [1..n], x `mod` 3 == 0 || '3' `elem` show x]
