-- https://atcoder.jp/contests/abc049/submissions/15397350
import Data.Bool ( bool )
main :: IO ()
main = putStrLn.f.reverse =<< getLine
f :: String -> String
f ('r':'e':'m':'a':'e':'r':'d':s) = f s
f ('m':'a':'e':'r':'d':s) = f s
f ('r':'e':'s':'a':'r':'e':s) = f s
f ('e':'s':'a':'r':'e':s) = f s
f s = bool"NO""YES"$null s
