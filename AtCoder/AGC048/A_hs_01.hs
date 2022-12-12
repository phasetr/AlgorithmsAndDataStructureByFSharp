-- https://atcoder.jp/contests/agc038/submissions/7647149
import Control.Monad ( replicateM_ )

main = do
  [h,w,a,b] <- map read . words <$> getLine
  replicateM_ b $ putStrLn $ replicate a '0' ++ replicate (w-a) '1'
  replicateM_ (h-b) $ putStrLn $ replicate a '1' ++ replicate (w-a) '0'
