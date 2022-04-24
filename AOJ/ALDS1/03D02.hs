-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_D/review/5916969/pythagoras/Haskell
type State = (Stack, Areas, Pos)
type Stack = [Int]
type Areas = [(Int, Int)]
type Pos = Int

run :: String -> State -> Areas
run [] (_, as, _) = as
run (x : xs) (stk, as, i)
  | x == '\\' = run xs (i : stk, as, i + 1)
  | x == '/' = case stk of
    [] -> run xs (stk, as, i + 1)
    (j : stk') ->
      let (as', as'') = span ((j <) . fst) as
          s = i - j
          ss = sum $ map snd as'
       in run xs (stk', (j, s + ss) : as'', i + 1)
  | otherwise = run xs (stk, as, i + 1)

format :: Areas -> [String]
format (reverse -> as) = let as' = map snd as in [show . sum $ as', unwords . map show $ length as' : as']

main :: IO ()
main = getLine >>= (\x -> mapM_ putStrLn $ format $ run x ([], [], 0))
