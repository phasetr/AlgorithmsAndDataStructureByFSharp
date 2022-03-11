{-
https://atcoder.jp/contests/keyence2020/submissions/15294121
-}
import qualified Data.ByteString.Char8 as BS
import Data.List (intersperse)
import Data.Maybe (fromJust)

main :: IO ()
main = do
  --[n,k,s] <- map read . words <$> getLine
  [n,k,s] <- map (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine
  putStrLn $ solve n k s

solve :: Int -> Int -> Int -> String
solve n k s = unwords $ map show (replicate k s ++ replicate (n-k) t)
  where t = if s > 10^5 then 1 else s+1
