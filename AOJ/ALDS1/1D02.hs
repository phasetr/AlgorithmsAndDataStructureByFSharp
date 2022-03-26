-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_D&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=3386071#1
import Control.Monad (replicateM)

solve :: [Int] -> Int
solve a =
  maximum $ zipWith (-) (tail a) $ scanl1 min a

main :: IO ()
main =
  getContents >>=
    putStrLn . show . solve . map (read :: String -> Int) . tail . words
