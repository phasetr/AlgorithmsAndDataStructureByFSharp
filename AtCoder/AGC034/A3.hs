{-
https://atcoder.jp/contests/agc034/submissions/8936217
-}
import Data.List (group)

solve :: Int -> Int -> Int -> Int -> String -> Bool
solve a b c d s
  | c < d     = chk1 (part a c s) && chk1 (part b d s)
  | otherwise = chk1 (part a c s) && chk1 (part b d s) && chk2 (part (b-1) (d+1) s)
  where
    part p q = take (q-p+1) . drop (p-1)
    chk1 = all (\g -> (head g == '.') || ((head g == '#') && length g < 2)) . group
    chk2 = any (\g -> (head g == '.') && length g >= 3) . group

main :: IO ()
main = do
    [_,a,b,c,d] <- map read . words <$> getLine :: IO [Int]
    s <- getLine :: IO String
    putStrLn $ if solve a b c d s then "Yes" else "No"
