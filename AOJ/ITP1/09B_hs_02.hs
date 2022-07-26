-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_B/review/2527346/Yoshimura/Haskell
import Control.Monad ( when, replicateM )
main :: IO ()
main = do
  s <- getLine
  when (s /= "-") $ do
    m <- readLn
    hs <- replicateM m readLn
    putStrLn $ foldl rotate s hs
    main

rotate :: String -> Int -> String
rotate xs n = drop n xs ++ take n xs
