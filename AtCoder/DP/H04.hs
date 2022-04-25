-- https://atcoder.jp/contests/dp/submissions/21451148
import Data.List (scanl')

main :: IO ()
main = do
  let
    modulus = 1000000007 :: Int
    modAdd :: Int -> Int -> Int
    modAdd x y = (x + y) `mod` modulus
  [_, w] <- map read . words <$> getLine :: IO [Int]
  let
    f :: [[Bool]] -> Int
    f = last . foldl step (0 : 1 : replicate (w - 1) 0)
      where
        step :: [Int] -> [Bool] -> [Int]
        step = (scanl' step' 0 .) . zip . tail
          where
            step' :: Int -> (Int, Bool) -> Int
            step' l (u, True) = modAdd l u
            step' _ _         = 0
  ass <- map (map ('.' ==)) . lines <$> getContents :: IO [[Bool]]
  print $ f ass
