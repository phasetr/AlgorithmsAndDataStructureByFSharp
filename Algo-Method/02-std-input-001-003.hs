{-
https://algo-method.com/tasks/21
文字列 S が標準入力から与えられます。
S を 3 回繰り返してできる文字列を標準出力するプログラムを作成してください。
-}
main :: IO ()
main = getLine >>= putStrLn . (\s -> s++s++s)

solve1 :: [a] -> [a]
solve1 = concat . replicate 3
solve2 s = foldl (\acc _ -> acc++s) "" [1..3]
test =  solve1 "abc" == "abcabcabc"
  && solv2 "abc" == "abcabcabc"
