-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_D/review/4084005/disktnk11/Haskell
import Control.Monad ( foldM, replicateM )
main :: IO String
main = do
  s <- getLine
  n <- readLn :: IO Int
  cmds <- replicateM n $ fmap words getLine
  foldM f1 s cmds

f1 :: String -> [String] -> IO String
f1 s [cmd,a1,a2] | cmd == "print" = do
                     putStrLn $ drop (read a1) $ take (1 + read a2) s
                     return s
f1 s [cmd,a1,a2] | cmd == "reverse" =
                   return
                   $ take (read a1) s ++ reverse (drop (read a1) $ take (1 + read a2) s) ++ drop (1 + read a2) s
f1 s [cmd,a1,a2,p] = do return $ take (read a1) s ++ p ++ drop (1 + read a2) s
f1 _ _ = undefined
