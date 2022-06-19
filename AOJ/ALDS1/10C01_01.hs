-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_C/review/3981913/niruneru/Haskell
{-# LANGUAGE BangPatterns #-}
main :: IO ()
main =
  getLine
  >>  fmap lines getContents
  >>= toPair []
  >>= mapM_ (print . solve)
  where
    toPair pairs [] = return $ reverse pairs
    toPair pairs (xs:ys:rest) = toPair ((xs, ys) : pairs) rest
    toPair _ _ = error "not come here"

solve :: (String, String) -> Int
solve (xss, yss) = lcs xss yss befMemo [0] where
  lcs [] _ memo _     = last memo
  lcs (x:xs) [] _  as = lcs xs yss (reverse as) [0]
  lcs xs ys (b:bs) as = lcs xs (tail ys) bs (m : as)
    where !m = if head xs == head ys then b + 1 else max (head as) (head bs)
  lcs _ _ _ _ = error "not come here"
  befMemo = replicate (length yss + 1) 0
