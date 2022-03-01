{-
https://atcoder.jp/contests/agc016/submissions/14121190
-}
main :: IO ()
main = print . solve =<< getLine

solve s = minimum $ map (shrink 0 s) abc
  where
    abc = filter (`elem` s) ['a'..'z']
    shrink k s c
      | all (== c) s = k
      | otherwise = shrink (k+1) s' c
      where s' = zipWith (\c1 c2 -> if c1 == c || c2 == c then c else c1) s (tail s)

test = do
  print $ solve "serval" == 3
  print $ solve "jackal" == 2
  print $ solve "zzz" == 0
  print $ solve "whbrjpjyhsrywlqjxdbrbaomnw" == 8
