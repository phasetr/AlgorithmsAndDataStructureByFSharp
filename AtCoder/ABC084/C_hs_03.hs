-- https://atcoder.jp/contests/abc084/submissions/1930735
import Control.Monad ( replicateM )
import Data.List ( tails )

main :: IO ()
main = readLn
  >>= flip replicateM (map read . words <$> getLine) . subtract 1
  >>= mapM_ (print . foldl (\t [c,s,f] -> c + max s (f * div (t + f - 1) f)) 0) . tails
