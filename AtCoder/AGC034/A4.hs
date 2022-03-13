{-
https://atcoder.jp/contests/agc034/submissions/5749879
-}
import Data.Bool (bool)

main :: IO ()
main = do
  [n,a,b,c,d] <- map read . words <$> getLine
  s <- getLine
  putStr $ bool "No" "Yes" $ solve n a b c d s

solve :: p -> Int -> Int -> Int -> Int -> [Char] -> Bool
solve n a b c d s
  | c < d = ans
  | otherwise = ans && canJump (fromTo (b-1) (d+1) s)
  where
    ans = canMove (fromTo a c s) && canMove (fromTo c d s)
    canMove [] = True
    canMove ('#':'#':_) = False
    canMove (c:s) = canMove s
    fromTo a b = drop (a-1) . take b
    canJump [] = False
    canJump ('.':'.':'.':_) = True
    canJump (c:s) = canJump s
