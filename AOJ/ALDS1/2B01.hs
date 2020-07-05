#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_2_B&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=3086221#1
import Control.Monad.State (State, modify, runState)

step :: [Int] -> State Int [Int]
step []     = return []
step (x:[]) = return [x]
step (x:xs)
  | minimum xs < x =
    modify (+1) >>
      step (left ++ (x : right)) >>=
        \ms -> return (m:ms)
  | otherwise =
    step xs >>=
      \rest -> return (x:rest)
  where
  m = minimum xs
  left = takeWhile (m/=) xs
  right = tail (dropWhile (m/=) xs)

ssort :: [Int] -> State Int [Int]
ssort [] = return []
ssort xs =
  step  xs >>=
    \(y:ys) -> ssort ys >>=
      \zs -> return (y:zs)

main =
  getLine >>
    getLine >>=
      mapM_ putStrLn
      . (\(ys, n) -> [unwords $ map show ys, show n])
      . (flip runState) 0
      . ssort . map (read :: String -> Int) . words
