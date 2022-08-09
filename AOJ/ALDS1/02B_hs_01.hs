{-
https://onlinejudge.u-aizu.ac.jp/problems/ALDS1_2_B
See also
../../Library/sort/selection.fsx
../../Library/sort/selection.hs

選択ソートは各計算ステップで１つの最小値を「選択」していく、
直観的なアルゴリズムです。

1 selectionSort(A, N) // N個の要素を含む0-オリジンの配列A
2   for i が 0 から N-1 まで
3     minj = i
4     for j が i から N-1 まで
5       if A[j] < A[minj]
6         minj = j
7     A[i] と A[minj] を交換
-}
main :: IO ()
main = do
  getLine
  xs <- fmap (map read . words) getLine
  let (ys,c) = ssort xs
  putStrLn $ unwords $ map show ys
  print c

ssort :: [Int] -> ([Int],Int)
ssort xs = foldl f (xs,0) [0..n]
  where
    n = length xs - 2
    f (xs,c0) i = (as++ys, c)
      where
        (as,bs) = splitAt i xs
        (ys,c)  = swap (bs, c0) $ minIndex bs
swap :: ([Int],Int) -> Int -> ([Int],Int)
swap (xs,c) minj = if minj>0 then (m:ys++y:zs,c+1) else (xs,c)
  where (y:ys,m:zs) = splitAt minj xs
-- https://stackoverflow.com/questions/30119252/haskell-minimum-position
minIndex :: [Int] -> Int
minIndex xs = head . map fst
  . filter (\e -> snd e == minimum xs) $ zip [0..] xs

test = do
  print $ minIndex [1..5] == 0
  print $ minIndex [2,1,3] == 1
  print $ minIndex [3,2,1] == 2
  print $ ssort [5,6,4,2,1,3] == ([1..6],4)
  print $ ssort [5,2,4,6,1,3] == ([1..6],3)
