-- https://atcoder.jp/contests/code-festival-2016-quala/submissions/892847
import Data.Char ( ord, chr )

main :: IO ()
main = do
  s <- map (subtract (ord 'a') . ord) <$> getLine
  k <- readLn
  putStrLn $ map (chr . (+ ord 'a')) $ calc s k

calc :: [Int] -> Int -> [Int]
calc [x] i = [m $ x+i] where m = (`mod`26)
calc (x:xs) i
  | x == 0 = x:calc xs i
  | x + i >= 26 = 0 : calc xs (i-(26-x))
  | otherwise = x:calc xs i
calc _ _ = error "not come here"
