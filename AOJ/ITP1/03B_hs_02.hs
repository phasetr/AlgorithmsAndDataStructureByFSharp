main :: IO ()
main = getContents >>=
  mapM_ putStrLn
  . map (\(i, l) -> "Case " ++ (show i) ++ ": " ++ l)
  . takeWhile (\(i, l) -> l /= "0")
  . zip [1..] . lines
