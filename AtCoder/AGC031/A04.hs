{-
https://atcoder.jp/contests/agc031/submissions/10964708
-}
import qualified Data.ByteString.Char8 as B
import qualified Data.Map              as M

main :: IO ()
main = do
  _ <- getLine
  s <- B.getLine
  print $ solve s

solve :: B.ByteString -> Integer
solve = pred . M.foldr (%*%) 1 . M.map succ
  . B.foldr (\c mp -> M.insertWith (+) c 1 mp) M.empty
  where
    mnum = 1000000007
    x %*% y = ((x `mod` mnum) * (y `mod` mnum)) `mod` mnum
