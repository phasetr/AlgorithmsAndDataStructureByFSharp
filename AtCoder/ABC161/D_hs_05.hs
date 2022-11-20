-- https://atcoder.jp/contests/abc161/submissions/11567621
main :: IO ()
main = readLn >>= putStrLn . (lunlun !!) . subtract 1

lunlun :: [String]
lunlun = prettify . concat . iterate (concatMap next) $ map pure [1 .. 9] where
  prettify = map (concatMap show . reverse)
  next xs@(x : _) = (:) <$> filter (\ x -> 0 <= x && x <= 9) [x - 1 .. x + 1] <*> [xs]
  next _ = error "not come here"
