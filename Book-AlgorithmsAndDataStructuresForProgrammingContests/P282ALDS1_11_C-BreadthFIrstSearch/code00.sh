#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o code00.out code00.cpp
echo "=================="
echo "SAMPLE 1"
echo "ANSWER"
cat << EOS
1 0
2 1
3 2
4 1
EOS
echo "=================="
echo "RESULT"
./code00.out < sample1.txt
echo "=================="
