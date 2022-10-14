-- https://atcoder.jp/contests/abc076/submissions/1722951
-- テストケース漏れで「正しい」プログラムではない: test参照
checker :: [Char] -> [Char] -> [Bool]
checker s = zipWith (\x y -> x == '?' || x == y) (s ++ repeat '_')

f :: [Char] -> [Char] -> (Bool, [Char])
f [] _ = (False, [])
f s@(c:u) t
  | not b && and (checker s t) = (True, t ++ drop (length t - 1) v)
  | otherwise = (b, (if c == '?' then 'a' else c) : v)
  where (b,v) = f u t
main :: IO ()
main = do
  (b,s) <- f <$> getLine <*> getLine
  putStrLn $ if b then s else "UNRESTORABLE"

test :: IO ()
test = do
  print $ f "?tc????" "coder" == (True,"atcoder")
  print $ f "??p??d??" "abc" == (False, "aapaadaa")
  print $ f "?????" "z" == (True,"aaaaz")
  print $ f "???z?" "z" == (True,"aaaza") -- "aaazz"が返ってしまい不正
  print $ checker "?tc????" "coder" == [True,False,False,True,True]
  print $ checker "tc????" "coder"  == [False,False,True,True,True]
  print $ checker "c????" "coder"   == [True,True,True,True,True]
