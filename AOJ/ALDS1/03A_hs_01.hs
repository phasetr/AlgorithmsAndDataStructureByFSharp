main :: IO ()
main = getLine >>= print . solve
solve :: String -> Int
solve = head . foldl rpn [] . words where
  rpn :: (Num a, Read a) => [a] -> String -> [a]
  rpn (x:y:zs) "*" = y * x  : zs
  rpn (x:y:zs) "-" = y - x  : zs
  rpn (x:y:zs) "+" = y + x  : zs
  rpn zs n         = read n : zs

test = do
  print $ solve "1 2 +"
  print $ solve "1 2 + 3 4 - *"
