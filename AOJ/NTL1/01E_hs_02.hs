-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_E/review/2073059/Yoshimura/Haskell
import Control.Applicative ((<$>))

main :: IO ()
main = do
  [a, b] <- map read . words <$> getLine :: IO [Int]
  let (x, y) = extgcd a b
  putStrLn $ show x ++ " " ++ show y

extgcd :: Int -> Int -> (Int, Int)
extgcd a 0 = (1, 0)
extgcd a b = (x, y-a`div`b*x) where
  (y, x) = extgcd b (a `mod` b)
