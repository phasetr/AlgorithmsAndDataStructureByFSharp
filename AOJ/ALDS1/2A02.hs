-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_2_A&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=3074283#1
import Control.Monad.State (State, modify, runState)

step :: [Int] -> State Int [Int]
step [x]    = return [x]
step (x:xs) =
  step xs >>=
    \(y:ys) ->
      if (x > y)
      then modify (+1) >> return (y:x:ys)
      else return (x:y:ys)

bsort :: [Int] -> State Int [Int]
bsort [] = return []
bsort xs =
  step xs >>=
    \(y:ys) ->
      bsort ys >>=
        \zs -> return (y:zs)

main =
  getLine >>
    getLine >>=
      mapM_ putStrLn
      . (\(ys, n) -> [unwords $ map show ys, show n])
      . (\xs -> runState (bsort xs) 0)
      . map read . words
