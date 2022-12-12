-- https://atcoder.jp/contests/abc045/submissions/16274977
import Control.Monad ( foldM )
main = do
  (x:xs) <- map (read . pure) <$> getLine
  print $ sum $ map (uncurry (+)) $ foldM (\(acc,top) cur -> [(acc+top,cur),(acc,10*top+cur)]) (0,x) xs
