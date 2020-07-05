#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_A&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=1703447#1
import Data.List
main :: IO ()
main =
  getContents >>=
    mapM_ putStrLn . map (unwords . map show)
    -- . (\xs -> tail $ zipWith (++) (map sort $ inits xs) (tails xs))
    . tail . (zipWith (++) <$> map sort . inits <*> tails)
    . map (read :: String -> Int) . tail . words -- tail で n を捨てる
