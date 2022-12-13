-- https://atcoder.jp/contests/abc097/submissions/2552166
import qualified Data.ByteString.Char8 as B
import Data.List ( group, sort )

f :: Int -> B.ByteString -> [[B.ByteString]]
f k = group . sort . concatMap B.inits . take (k + 1) . sort . B.tails

main :: IO ()
main = do
  s <- B.getLine
  k <- readLn :: IO Int
  let gs = f k s !! k
  B.putStrLn $ head gs
