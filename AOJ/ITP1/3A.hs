#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_3_A&lang=ja
main = mapM_ putStrLn $ replicate 1000 "Hello World"
