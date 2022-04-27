-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_D/review/3386207/tyanon/Haskell
main :: IO ()
main = do
  [_,k] <- fmap (map read . words) getLine
  getContents >>= print . solve k . map read . words

-- 二分探索で大きい積載量(max n * max w)から探しはじめる.
solve :: Int -> [Int] -> Int
solve k ws = bsearch 0 (10^11) (\p -> chk k ws p p)

bsearch :: Int -> Int -> (Int -> Bool) -> Int
bsearch l h f
  | l+1 == h = h
  | otherwise  = if f mid then bsearch l mid f else bsearch mid h f
  where mid = (l+h) `div` 2

chk :: Int -> [Int] -> Int -> Int -> Bool
chk _ [] _ _ = True  -- 十分な積載量があって荷物が積み切れた
chk 0 _ _ _  = False -- 積載量が足りずトラックに積み切れない
chk k xs@(w:ws) p r
  | w > r     = chk (k-1) xs p p -- k番目のトラックに積み切れなかったので次のトラックに変更
  | otherwise = chk k ws p (r-w) -- k番目のトラックに積めたので同じトラックに次の荷物を積めるか?

test :: IO ()
test = do
  print $ solve 3 [8,1,7,3,9] == 10
  print $ solve 2 [1,2,2,6] == 6
