{-
https://atcoder.jp/contests/agc032/submissions/4684146
-}
import qualified Data.Foldable as F
import qualified Data.List     as L
import Data.Monoid (Last(Last,getLast))

main :: IO ()
main = do
  n <- readLn :: IO Int
  xs <- map read.words <$> getLine
  case solve n xs of
    Just ys -> putStr . unlines $ map show ys
    Nothing -> print (-1)

solve :: Int -> [Int] -> Maybe [Int]
solve n xs = go [] xs
  where
    eq :: Int -> Int -> Maybe Int
    eq x y
        | x == y = Just x
        | otherwise = Nothing

    go acc [] = Just acc
    go acc xs = do
        x <- getLast . F.foldMap Last $ zipWith eq [1..] xs
        go (x:acc) $ L.delete x xs
