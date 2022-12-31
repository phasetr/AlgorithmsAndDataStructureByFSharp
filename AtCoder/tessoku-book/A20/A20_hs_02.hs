-- https://atcoder.jp/contests/tessoku-book/submissions/35242163
import Data.List ( foldl', zipWith4 )

tba20 :: String -> String -> Int
tba20 s t = last $ foldl' step (replicate (length t) 0) s where
 step xs si = last xs1 `seq` tail xs1 where
   xs1 = 0 : zipWith4 f t xs (0:xs) xs1
   f c xu xd xl = maximum $ [succ xd | c == si] ++ [xu, xl]

main :: IO ()
main = do
  s <- getLine
  t <- getLine
  let ans = tba20 s t
  print ans
