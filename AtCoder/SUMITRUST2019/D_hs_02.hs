-- https://atcoder.jp/contests/sumitrust2019/submissions/13412736
import Control.Monad ( replicateM )
main :: IO ()
main = do
  getLine
  s <- getLine
  print $ length [()| pin <- replicateM 3 "0123456789", check pin s]

check :: Eq a => [a] -> [a] -> Bool
check (a:b:c:_) s = (c `elem`) . chk b $ chk a s where
  chk k t = case dropWhile (/= k) t of
              [] -> []
              (x:xs) -> xs
check _ _ = error "not come here"
