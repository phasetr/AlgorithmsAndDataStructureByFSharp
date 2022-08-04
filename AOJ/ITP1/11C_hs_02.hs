-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_C/review/1900672/enji/Haskell
import Control.Applicative ((<$>))

main :: IO ()
main = do
  [dice1, dice2] <- map (roll . take 3 . map read . words) . lines <$> getContents :: IO [[Int]]
  putStrLn $ if dice1 == dice2 then "Yes" else "No"

roll :: [Int] -> [Int]
roll xs@(a:b:c:_) =
  let
    cnt = length $ filter (>= 4) xs
    dice = map (\x -> min x (7 - x)) $ if even cnt then xs else [a, c, b]
    (as, bs) = break (== 1) dice
  in
    bs ++ as
roll _ = undefined
