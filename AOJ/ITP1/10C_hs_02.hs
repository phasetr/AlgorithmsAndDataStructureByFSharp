-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_C/review/2527389/Yoshimura/Haskell
import Control.Applicative ((<$>))
import Control.Monad ( when )
import Text.Printf ( printf )

main :: IO ()
main = do
  n <- readLn :: IO Double
  when (n > 0) $ do
    s <- map read . words <$> getLine :: IO [Double]
    let
      m = sum s/n
    printf "%.8f\n" $ sqrt $ sum (map (\x -> (x-m)**2) s)/n
    main
