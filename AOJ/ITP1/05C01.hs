import Control.Applicative ((<$>))
main = do
  [h,w] <- map read . words <$> getLine
  if (h,w)==(0,0) then return () else do
    mapM_ putStrLn (chessboard h w)
    putStrLn ""
    main
chessboard h w = map (line w) [1..h]
line w i = map (\j -> if even (j+i) then '#' else '.') [1..w]
