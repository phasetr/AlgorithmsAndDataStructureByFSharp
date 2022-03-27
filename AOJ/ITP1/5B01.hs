-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_5_B
import Control.Applicative ((<$>))
import Control.Monad (replicateM_)
main = do
  [h,w] <- map read . words <$> getLine
  if (h,w)==(0,0) then return () else do
    let allsharp = concat $ replicate w "#"
    putStrLn allsharp
    replicateM_ (h-2) (putStrLn (concat $ "#" : replicate (w-2) "." ++ ["#"] ))
    putStrLn allsharp
    putStrLn ""
    main
