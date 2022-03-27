import Control.Applicative
main = mapM_ (mapM_ putStrLn . chessboard) <$>
  fmap (takeWhile (\l -> l /= [0,0])
       . map (map read . words) . lines) getContents
  where
    line w i = map (\j -> if odd j then '#' else '.') [1..w]
    chessboard [h,w] = map (line w) [1..h] ++ [""]
    chessboard _ = error "undefined"
