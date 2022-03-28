import Data.List (intercalate)
main :: IO ()
main = getLine >> getContents >>= putStr
  . (\inputs -> intercalate "####################\n"
                [building b inputs | b <- [1..4]])
  . map (map read . words) . lines where
  room b f r l = sum [n | [x,y,z,n] <- l, b == x && f == y && r == z]
  floor b f l = " " ++ unwords [show $ room b f r l | r <- [1..10]] ++ "\n"
  building b l = concat $ [floor b f l | f <- [1..3]]
