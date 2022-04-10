-- https://atcoder.jp/contests/dp/submissions/3981448
import Data.List (foldl')
main :: IO ()
main = do
  [_,k] <- fmap (map read . words) getLine
  h0:hs <- fmap (map read . words) getLine
  let cEnd = snd $ head $ foldl' step s0 hs
      step l h = (h, c) : l
        where c = minimum
                  $ map (\(hi,ci) -> ci + abs (hi - h))
                  $ take k l
      s0 = [(h0, 0)]
  print cEnd
