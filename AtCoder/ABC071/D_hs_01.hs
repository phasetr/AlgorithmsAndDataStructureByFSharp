-- https://atcoder.jp/contests/abc071/submissions/16945776
main :: IO ()
main = print . solve . lines =<< getContents

solve :: Eq a => [[a]] -> Int
solve [_,s,t] = (`mod`(10^9+7)) . fst $ foldr f (1,0) $ zipWith (==) s t
solve _ = error "not come here"

f :: Num b => Bool -> (Int, Int) -> (Int, b)
f b (k,p)
  | p>2 = (k,2)
  | b = (k*(3-p),1)
  | otherwise = (k * [6,2,3] !! p, 3)
