-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_D/review/2974050/niruneru/Haskell
import System.Exit ( exitSuccess )

extra :: String -> Int -> Int -> [String]
extra cs a b = [take a cs, take (b - a + 1) (drop a cs), drop (b + 1) cs]

rev :: String -> Int -> Int -> String
rev cs a b = pre ++ reverse mid ++ pos
  where [pre, mid, pos] = extra cs a b

rpl :: String -> Int -> Int -> String -> String
rpl cs a b ns = pre ++ ns ++ pos
  where [pre, _, pos] = extra cs a b

prt :: String -> Int -> Int -> String
prt cs a b = mid
  where [pre, mid, pos] = extra cs a b

main :: IO ()
main = do
  cs <- getLine
  getLine
  ops <- map words . lines <$> getContents
  solve ops cs

solve :: [[String]] -> String -> IO ()
solve [] _ = exitSuccess
solve ((op:a:b:rest):ops) cs = do
  case op of
    "reverse" -> solve ops (rev cs (read a) (read b))
    "replace" -> solve ops (rpl cs (read a) (read b) (head rest))
    _         -> putStrLn (prt cs (read a) (read b)) >> solve ops cs
solve _ _ = undefined
