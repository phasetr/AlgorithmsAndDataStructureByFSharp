-- https://atcoder.jp/contests/agc014/submissions/1264660
import Data.Bool ( bool )
import Data.List ( group, sort )

main :: IO ()
main = do
 getLine
 ls <- map length . group . sort . words <$> getContents
 putStrLn $ bool "NO" "YES" (all even ls)
