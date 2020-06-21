#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_1_B&lang=ja
main :: IO ()
main = readLn >>= print . (^3)
