-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_C/review/2961501/utopian/Haskell
main :: IO()
main = do
  n <- readLn :: IO Int
  let
    left = (0, 0)
    right = (100, 0)
  outputPoint left
  koch n left right
  outputPoint right

koch :: Int -> (Float, Float) -> (Float, Float) -> IO()
koch 0 _ _ = return ()
koch n left@(x1, y1) right@(x2, y2) = do
  let
    s = ((2 * x1 + x2) / 3, (2 * y1 + y2) / 3)
    t = ((x1 + 2 * x2) / 3, (y1 + 2 * y2) / 3)
    u =
      (
        (fst t - fst s) * (cos $ pi / 3) - (snd t - snd s) * (sin $ pi / 3) + fst s,
        (fst t - fst s) * (sin $ pi / 3) + (snd t - snd s) * (cos $ pi / 3) + snd s
      )
  koch (n - 1) left s
  outputPoint s
  koch (n - 1) s u
  outputPoint u
  koch (n - 1) u t
  outputPoint t
  koch (n - 1) t right

outputPoint :: (Float, Float) -> IO()
outputPoint (x, y) = putStrLn $ show x ++ " " ++ show y
