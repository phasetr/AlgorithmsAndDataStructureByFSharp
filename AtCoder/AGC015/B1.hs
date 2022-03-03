{-
https://atcoder.jp/contests/agc015/submissions/15103268
-}
import Data.Array (Array, listArray, (!))
import qualified Data.ByteString.Char8 as BS

solve :: Array Int Char -> Int -> Int -> Int
solve sa i n
  | i == n = n - 1
  | i == 1 = n - 1 + solve sa (i + 1) n
  | c == 'U' = (i - 1) * 2 + (n - i) + solve sa (i + 1) n
  | c == 'D' = (i - 1) + (n - i) * 2 + solve sa (i + 1) n
  | otherwise = error "Do not come here."
  where
    c = sa ! i

main :: IO ()
main = do
  [s] <- map BS.unpack . BS.words <$> BS.getLine
  let n = length s
  let sa = listArray (1, n) s
  print $ solve sa 1 n

test :: IO ()
test = do
  print $ solve (listArray (1,3) "UUD") 1 3 == 7
  print $ solve (listArray (1,8) "UUDUUDUD") 1 8 == 77
