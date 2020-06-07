#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o code00.out code00.cpp
echo "=================="
echo "SAMPLE 1"
echo "ANSWER:"
echo "5 2 4 6 1 3"
echo "2 5 4 6 1 3"
echo "2 4 5 6 1 3"
echo "1 2 4 5 6 3"
echo "1 2 3 4 5 6"
echo "=================="
echo "RESULT"
./code00.out < sample1.txt
echo "=================="
