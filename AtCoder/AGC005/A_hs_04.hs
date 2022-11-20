-- https://atcoder.jp/contests/agc005/submissions/13657598
import qualified Data.ByteString.Char8 as BS

main :: IO ()
main = BS.getLine >>= print . compute

compute :: BS.ByteString -> Int
compute = (2 *) . BS.foldl' step 0

-- (Sの余っている数)
step :: Int -> Char -> Int
step s 'S' = succ s
step s _ = 0 `max` pred s
