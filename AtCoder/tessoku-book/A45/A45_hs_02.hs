-- https://atcoder.jp/contests/tessoku-book/submissions/35518725
import qualified Data.ByteString.Char8 as BS

main :: IO ()
main = do
  li <- BS.getLine
  let Just (n, li1) = BS.readInt li
  let c = BS.index li1 1
  as <- BS.getLine
  let ans = tba45 n c as
  putStrLn $ if ans then "Yes" else "No"

tba45 :: Int -> Char -> BS.ByteString -> Bool
tba45 n c as = mod (r - b) 3 == k where
  r = BS.count 'R' as
  b = BS.count 'B' as
  k = case c of
    'R' -> 1
    'B' -> 2
    _ -> 0
