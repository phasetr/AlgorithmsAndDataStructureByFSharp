#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o code01.out code01.cpp
echo "=================="
echo "SAMPLE 1"
echo "ANSWER"
cat << EOS
1 1 12
2 2 11
3 3 8
4 9 10
5 4 7
6 5 6
EOS
echo "=================="
echo "RESULT"
./code01.out < sample1.txt
echo "=================="
