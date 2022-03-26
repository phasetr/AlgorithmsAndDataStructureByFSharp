{-
https://algo-method.com/tasks/33
文字列 S が 1 行目に、2 つの正の整数 N,M が空白区切りで 2 行目に入力されます。 S の前から N 番目の文字と、前から M 番目の文字を入れ替えた文字列を出力してください。

ただしここでは、文字列 S の先頭の文字は 1 文字目であるとします。
-}
import qualified Data.Vector.Unboxed as VU
main :: IO ()
main = do
  s <- getLine
  [n,m] <- map read . words <$> getLine :: IO [Int]
  putStr $ zipWith (f n m s) [1..length s] s
  where
    f n m s i c | i==n = s!!(m-1)
                | i==m = s!!(n-1)
                | otherwise = c

main2 = do
  s <- getLine
  [n,m] <- map read . words <$> getLine :: IO [Int]
  putStr $ swap s n m
swap s n m = VU.toList $ VU.update sv u where
  sv = VU.fromList s
  cn = sv VU.! (n-1)
  cm = sv VU.! (m-1)
  u = VU.fromList ([(n-1,cm),(m-1,cn)] :: [(Int,Char)])
