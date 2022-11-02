-- https://atcoder.jp/contests/abc049/submissions/9032820
import Data.List ( isPrefixOf )

matching :: String -> String
matching "" = "YES"
matching str = if not (null x) then matching $ drop (length . head $ x) str else "NO" where
  prefixes = map reverse ["dream", "dreamer", "erase", "eraser"]
  matcher s = filter (`isPrefixOf` s) prefixes
  x = matcher str

main :: IO ()
main = getLine >>= putStrLn . matching . reverse
