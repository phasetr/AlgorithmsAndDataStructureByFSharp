-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_A&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=3707884#1
import Control.Applicative
import Control.Monad
import Data.Functor
import Data.List

insertList :: (Ord a) => [a] -> a -> [a]
insertList [] a = [a]
insertList xxs@(x:xs) a
  | a < x = a : xxs
  | otherwise = x : insertList xs a

f :: [Int] -> [[Int]]
f xs = tail $ zipWith (++) (scanl insertList [] xs) (scanr (:) [] xs)

main :: IO ()
main =
  getLine >> -- n を捨てる
    map (read :: String -> Int) . words <$> getLine >>=
      putStr
      . unlines
      . map (unwords . map show) . f
