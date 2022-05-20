main = getContents >>=
  mapM_ (\[h,w] -> do cb h w; putStrLn "")
  . takeWhile (/= [0,0]) . map (map read . words) . lines
cb :: Int -> Int -> IO ()
cb h w = sequence_
  $ take h . cycle . map (putStrLn . take w)
  $ [cycle "#.", cycle ".#"]
