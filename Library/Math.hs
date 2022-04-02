intToNString :: Int -> Int -> String
intToNString n x
    | n == 0 = []
    | n == 1 = replicate x '1'
    | n <= 16 = getNString x n
    | otherwise = []
    where
        getNString :: Int -> Int -> String
        getNString x n
          | x == 0 = []
          | otherwise = getNString (x `div` n) n ++ (numbers !! (x `mod` n))
          where numbers = ["0","1","2","3","4","5","6","7","8","9","a","b","c","d","e","f"]

main :: IO ()
main =
    print $ map (intToNString 2) [1,2,3,4,5,9,10]
