-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_5_A
import Control.Monad ( replicateM_ )
main :: IO ()
main = do
  [h,w] <- fmap (map read . words) getLine
  if (h,w)==(0,0) then return () else do
    replicateM_ h (putStrLn (concat $ replicate w "#"))
    putStrLn ""
    main
