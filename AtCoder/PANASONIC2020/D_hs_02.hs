-- https://atcoder.jp/contests/panasonic2020/submissions/15318373
import Data.Char ( ord, chr )
main :: IO ()
main = mapM_ putStrLn . solve =<< readLn
solve :: Int -> [String]
solve n = map (reverse . fst) $ foldr (\_ -> concatMap f) [("a",'b')] [2..n]
f :: (String, Char) -> [(String, Char)]
f (s,c) = map g ['a'..c] where
  g d = (d:s, if d/=c then c else chr $ ord c+1)
