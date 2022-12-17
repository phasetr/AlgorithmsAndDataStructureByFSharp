-- https://atcoder.jp/contests/abc071/submissions/22299505
import Data.List ( foldl', group )

main :: IO ()
main = do
  n <- readLn
  s1 <- getLine
  s2 <- getLine
  print $ solve n s1 s2

solve :: Int -> String -> String -> Int
solve n s1 s2 = foldl' go (if hp == 1 then 3 else 6) $ zip patterns $ tail patterns where
  patterns = map length $ group s1
  hp = head patterns
  go acc (1, 1) = acc `modMul` 2
  go acc (1, 2) = acc `modMul` 2
  go acc (2, 1) = acc
  go acc _ = acc `modMul` 3

modMul :: Int -> Int -> Int
modMul a b = a * b `mod` modulus where modulus = 10^9+7
