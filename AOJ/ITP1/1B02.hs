main :: IO ()
main = readLn >>= print . (^3)
