-- https://atcoder.jp/contests/arc058/submissions/1454180
import Data.Maybe ( fromJust )
import Data.List ( find, intersect )
import Data.Char ( isDigit )

main = do
  [n,_] <- map read . words <$> getLine
  ds <- filter isDigit <$> getLine
  putStrLn (iroha n ds)

iroha :: Int -> [Char] -> String
iroha n ds = fromJust $ find (null . intersect ds) $ map show [n..]
