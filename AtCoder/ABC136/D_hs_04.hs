-- https://atcoder.jp/contests/abc136/submissions/11231771
import Control.Monad ( when, replicateM_, unless )
import Data.List ( group )

main :: IO ()
main = do
  s <- getLine
  solve $ map length (group s)

solve :: [Int] -> IO ()
solve [] = putStrLn ""
solve (r : l : rls) = do
  when (r >= 1) $ replicateM_ (r - 1) (putStr "0 ")
  putStr . show $ ((r + 1) `div` 2) + (l `div` 2)
  putChar ' '
  putStr . show $ (r `div` 2) + ((l + 1) `div` 2)
  when (l >= 1) $ replicateM_ (l - 1) (putStr " 0")
  unless (null rls) $ putChar ' '
  solve rls
solve _ = error "not come here"
