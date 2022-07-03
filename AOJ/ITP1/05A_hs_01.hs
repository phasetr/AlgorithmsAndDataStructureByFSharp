-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_5_A
import Control.Applicative
import Control.Monad
main :: IO ()
main = do
  [h,w] <- map read . words <$> getLine
  if (h,w)==(0,0) then return () else do
    replicateM_ h (putStrLn (concat $ replicate w "#"))
    putStrLn ""
    main
