-- https://atcoder.jp/contests/dp/submissions/22779836
import qualified Data.ByteString.Char8 as C
import qualified Data.Vector.Unboxed as U
import Data.Vector.Unboxed ((!))

main :: IO ()
main = do
  n <- (read :: String -> Int) <$> getLine
  mapM (\_ -> get 3) [1..n] >>= (\abc -> print $ solve abc [0, 0, 0])

get :: Int -> IO (U.Vector Int)
get n = U.unfoldrN n (C.readInt . C.dropWhile (<'+')) <$> C.getLine

solve :: [U.Vector Int] -> [Int] -> Int
solve [] dp = maximum dp
solve (h:t) [a,b,c] = solve t [h!0 + max b c, h!1 + max a c, h!2 + max a b]
solve _ _ = undefined
