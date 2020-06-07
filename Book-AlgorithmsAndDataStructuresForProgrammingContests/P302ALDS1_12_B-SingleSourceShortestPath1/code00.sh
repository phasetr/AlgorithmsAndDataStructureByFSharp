#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o code00.out code00.cpp
echo "=================="
echo "SAMPLE 1"
echo "ANSWER"
cat << EOS
0 0
1 2
2 2
3 1
4 3
EOS
echo "=================="
echo "RESULT"
./code00.out < sample1.txt
echo "=================="
