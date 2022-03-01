{-
https://atcoder.jp/contests/agc016/tasks/agc016_a
1 ≤ |s| ≤ 100
s は英小文字のみからなる。

https://atcoder.jp/contests/agc016/submissions/15568498
-}
import Data.List (group, sort)
main :: IO()
main = print . solve =<< getLine

solve :: String -> Int
solve s = minimum . map (f s . head) . group . sort $ s
  where
    f s c = g 0 s where
      -- 再帰用の関数: 全ての文字が一致していたら終わり
      g i s =
        if all (==c) s then i
        else g (i+1) $ (zipWith h =<< tail) s
      -- 文字置換用の関数
      h c1 c2 = if c1==c || c2==c then c else c1

test = do
  print $ solve "serval" == 3
  print $ solve "jackal" == 2
  print $ solve "zzz" == 0
  print $ solve "whbrjpjyhsrywlqjxdbrbaomnw" == 8
