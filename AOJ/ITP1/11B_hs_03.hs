-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_B/review/1697614/amusan39/Haskell
import Control.Monad ( replicateM_ )

move :: [a] -> Char -> [a]
move [a,b,c,d,e,f] o
  | o == 'E' = [d,b,a,f,e,c]
  | o == 'N' = [b,f,c,d,a,e]
  | o == 'S' = [e,a,c,d,f,b]
  | o == 'W' = [c,b,f,a,e,d]
move _ _ = undefined

solve :: Eq a => [a] -> [a] -> [Char] -> a
solve dice@[a,b,c,d,e,f] q@[a',b'] (x:xs)
  | a == a' && b == b' = c
  | otherwise = solve (move dice x) q xs
solve _ _ _ = undefined

main :: IO ()
main = do
  dice <- fmap words getLine
  n <- readLn
  replicateM_ n $ do
    qs <- words <$> getLine
    putStrLn $ solve dice qs (cycle "EEENNWWS")
