main :: IO ()
main = interact
  $ unlines . map (unlines . cb . map read . words)
  . takeWhile (/="0 0") . lines

cb :: [Int] -> [String]
cb [x,y] = f x (f y '#' '.') (f y '.' '#')
  where f n a b = take n . cycle $ a : [b]
cb _ = error "undefined"
