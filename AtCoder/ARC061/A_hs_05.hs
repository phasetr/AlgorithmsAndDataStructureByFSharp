-- https://atcoder.jp/contests/abc045/submissions/3338823
main :: IO ()
main = getLine >>= print . calc

calc :: String -> Int
calc = sum . map (sum . map read) . allSplits

allSplits :: String -> [[String]]
allSplits [c]    = [[[c]]]
allSplits (c:cs) = map noSplit prev ++ map split prev where
  noSplit (s:ss) = (c:s):ss
  noSplit _ = error "not come here"
  split ss       = [c]:ss
  prev           = allSplits cs
allSplits _ = error "not come here"
